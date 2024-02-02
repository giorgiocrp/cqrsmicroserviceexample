namespace ExampleUi.Utils.Interfaces {
    public interface IApiConsumer<T>{
        string BaseUrl{get;set;}
        Task<IEnumerable<T>> GetAsync(string url, HttpClientHandler httpClientHandler);
        Task DeleteAsync(string url,T entity, HttpClientHandler httpClientHandler);
        Task PutAsync(string url,T entity, HttpClientHandler httpClientHandler);
        Task PostAsync(string url,T entity, HttpClientHandler httpClientHandler);
    }
}