using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace RedGrape.Infra.Transmit.Rest
{
    public class RestClient
    {
        

        public async Task<Response> PostAsync<Response,Request>(string apiUrl , Request request)
        {
            using(var httpClient = new HttpClient())
            {
                try
                {
                    var jsonRequest = JsonConvert.SerializeObject(request);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    SetHeaders(httpClient);
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var textResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<Response>(textResponse);
                        if (res == null)
                            throw new ArgumentNullException("response is null");
                        return res;
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString() + " " + response.ReasonPhrase);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<Response> GetAsync<Response>(string apiUrl)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    SetHeaders(httpClient);
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var textResponse = await response.Content.ReadAsStringAsync();
                        var res = JsonConvert.DeserializeObject<Response>(textResponse);
                        if (res == null)
                            throw new ArgumentNullException("response is null");
                        return res;
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString() + " " + response.ReasonPhrase);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }



        private void SetHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
