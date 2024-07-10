using CruzEvaluacion3P.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CruzEvaluacion3P.Services
{
    public class SCPeliculaService
    {
        public async Task<SCPelicula> GetMovie(DateTime dt)
        {
            SCPelicula dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.themoviedb.org/3/movie/157336/videos?api_key=18d343172084ddeea28efad6b2ddf9e6";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<SCPelicula>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }
    }
}
