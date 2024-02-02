using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExampleUi.Utils.Interfaces;

namespace ExampleUi.Utils
{
    public class ApiConsumer<T> : IApiConsumer<T>
    { 

        public string BaseUrl { get; set; }
     

        public async Task DeleteAsync(string url, T entity, HttpClientHandler httpClientHandler)
        {
            try
            {
                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(this.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.DeleteAsync(url);

                    if (res.IsSuccessStatusCode==false)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAsync(string url, HttpClientHandler httpClientHandler)
        {
            try
            {
                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        return JsonSerializer.Deserialize<IEnumerable<T>>(content, options);
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }      

        public async Task PostAsync(string url, T entity, HttpClientHandler httpClientHandler)
        {
            try
            {
                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(this.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.PostAsJsonAsync<T>(url, entity);

                    if (res.IsSuccessStatusCode==false)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }     

        public async Task PutAsync(string url, T entity, HttpClientHandler httpClientHandler)
        {
            try
            {
                using (var client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(this.BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var res = await client.PutAsJsonAsync<T>(url, entity);

                    if (res.IsSuccessStatusCode==false)
                    {
                        throw new Exception(res.StatusCode.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}