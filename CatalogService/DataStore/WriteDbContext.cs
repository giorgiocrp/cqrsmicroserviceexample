using CatalogService.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataStore
{
    public class WriteDbContext : DbContext
    {
         private IPublisher _publisher;
         
        public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
        {
            // When should you publish domain events?
            //
            // 1. BEFORE calling SaveChangesAsync
            //     - domain events are part of the same transaction
            //     - immediate consistency
            // 2. AFTER calling SaveChangesAsync
            //     - domain events are a separate transaction
            //     - eventual consistency
            //     - handlers can fail

            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return result;
        }

         private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                .Entries<Entity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetDomainEvents();

                    entity.ClearDomainEvents();

                    return domainEvents;
                })
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}