using StripsClientWPFReeksView.Exceptions;
using StripsREST.Model.Output;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Services
{
    public class StripServiceClient
    {
        static HttpClient client = new HttpClient();


        public StripServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5044");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }        

        public static async Task<ReeksRESToutputDTO> GetReeksAsync(string path)
        {
            ReeksRESToutputDTO reeks = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                reeks = await response.Content.ReadAsAsync<ReeksRESToutputDTO>();
            }
            else
            {
                return null;
            }
            return reeks;
        }
    }
}
