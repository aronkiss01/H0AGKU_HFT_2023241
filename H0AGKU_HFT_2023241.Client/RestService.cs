using H0AGKU_HFT_2023241.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Client
{
    public class RestException
    {
        public RestException() { }
        public string ExceptionMsg { get; set; }
    }
}
public class RestService
{
    HttpClient client;

    public RestService(string url, string pingEndpoint = "swagger")
    {
        bool isConnected = false;
        do
        {
            isConnected = Ping(url + pingEndpoint);

        } while (isConnected.Equals(false));
        Init(url);
    }
    public bool Ping(string url)
    {
        try
        {
            WebClient wclient = new WebClient();
            wclient.DownloadData(url);
            return true;
        }
        catch
        {

            return false;
        }
    }
    public void Init(string Url)
    {
        client = new HttpClient();
        client.BaseAddress = new Uri(Url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        try
        {
            client.GetAsync("").GetAwaiter().GetResult();
        }
        catch (HttpRequestException)
        {

            throw new ArgumentException("The Endpoint is not available!");
        }
    }
    public List<T> Get<T>(string endP)
    {
        List<T> items = new List<T>();
        HttpResponseMessage response = client.GetAsync(endP).GetAwaiter().GetResult();
        if (response.IsSuccessStatusCode)
        {
            items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
        }
        else
        {
            var error = response.Content.ReadAsAsync<RestException>().GetAwaiter().GetResult();
            throw new ArgumentException(error.ExceptionMsg);



        }
        return items;
    }
    public T GetSingle<T>(string endP)
    {
        T item=default(T);
        HttpResponseMessage response = client.GetAsync(endP).GetAwaiter().GetResult();
        if (response.IsSuccessStatusCode)
        {
            item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
        }
        else
        {
            var error = response.Content.ReadAsAsync<RestException>().GetAwaiter().GetResult();
            throw new ArgumentException(error.ExceptionMsg);
        }
        return item;
    }
    public T Get<T>(int Id, string endP)
    {
        T item = default(T);
        HttpResponseMessage response = client.GetAsync(endP + "/" + Id.ToString()).GetAwaiter().GetResult();
        if (response.IsSuccessStatusCode)
        {
            item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
        }
        else
        {
            var error = response.Content.ReadAsAsync<RestException>().GetAwaiter().GetResult();
            throw new ArgumentException(error.ExceptionMsg);
        }
        return item;
    }



}

