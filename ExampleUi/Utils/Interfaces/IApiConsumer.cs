namespace ExampleUi.Utils.Interfaces {
    public interface IApiConsumer<T>{
        string BaseUrl{get;set;}
        Task<T> GetAsync(string url, HttpClientHandler httpClientHandler);
        Task<IEnumerable<T>> GetCollectionAsync(string url, HttpClientHandler httpClientHandler);
        Task DeleteAsync(string url,T entity, HttpClientHandler httpClientHandler);
        Task<T> PutAsync(string url,T entity, HttpClientHandler httpClientHandler);
        Task<T> PostAsync(string url,T entity, HttpClientHandler httpClientHandler);
    }
}