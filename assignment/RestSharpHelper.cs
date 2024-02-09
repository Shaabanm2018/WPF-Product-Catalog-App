using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using static assignment.Type;

namespace assignment
{
    public class GetJsonResponse
    {

        public string TotalProducts { get; set; }
        public string TotalPages { get; set; }

        public dynamic Data;
    }
    internal class RestSharpHelper
    {
        public GetJsonResponse getProductData()
        {
            string username = "ck_2682b35c4d9a8b6b6effac126ac552e0bfb315";
            string password = "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71";
            string url = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";

            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };

            var client = new RestClient(options);

            var request = new RestRequest("GET");

            try
            {
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    var headers = response.Headers;

                    var totalProducts = headers.FirstOrDefault(h => h.Name == "X-WP-Total")?.Value.ToString();
                    var totalPages = headers.FirstOrDefault(h => h.Name == "X-WP-TotalPages")?.Value.ToString();

                    return new GetJsonResponse
                    {
                        TotalProducts = totalProducts,
                        TotalPages = totalPages,
                        Data = JsonConvert.DeserializeObject<dynamic>(response.Content)
                    };
                }
                else
                {
                    return new GetJsonResponse
                    {
                        TotalProducts = "0",
                        TotalPages = "0",
                        Data = {}
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception occurred: " + ex.Message);
                return new GetJsonResponse
                {
                    TotalProducts = "0",
                    TotalPages = "0",
                    Data = {}
                };
            }
        }

        public GetJsonResponse getProductDataPerPage(int page)
        {
            string username = "ck_2682b35c4d9a8b6b6effac126ac552e0bfb315";
            string password = "cs_cab8c9a729dfb49c50ce801a9ea41b577c00ad71";
            string url = "https://mangomart-autocount.myboostorder.com/wp-json/wc/v1/products";

            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator(username, password),
                
            };

            var client = new RestClient(options);

            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("page", page);
            System.Diagnostics.Debug.WriteLine("we are in>>>>>>");
            try
            {
                var response = client.Execute(request);
                System.Diagnostics.Debug.WriteLine("Here the response >>>>>>");
                System.Diagnostics.Debug.WriteLine(response.IsSuccessful);
                if (response.IsSuccessful)
                {
                    // System.Diagnostics.Debug.WriteLine((dynamic)JsonConvert.DeserializeObject(response.Content));
                    var headers = response.Headers;

                    var totalProducts = headers.FirstOrDefault(h => h.Name == "X-WP-Total")?.Value.ToString();
                    var totalPages = headers.FirstOrDefault(h => h.Name == "X-WP-TotalPages")?.Value.ToString();

                    return new GetJsonResponse
                    {
                        TotalProducts = totalProducts,
                        TotalPages = totalPages,
                        Data =  JsonConvert.DeserializeObject<dynamic>(response.Content)
                    };
                }
                else
                {
                    return new GetJsonResponse
                    {
                        TotalProducts = "0",
                        TotalPages = "0",
                        Data = {}
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Here the exceptions >>>>>>");
                System.Diagnostics.Debug.WriteLine(ex);
                return new GetJsonResponse
                {
                    TotalProducts = "0",
                    TotalPages = "0",
                    Data = {}
                };
            }
        }
    }
}

