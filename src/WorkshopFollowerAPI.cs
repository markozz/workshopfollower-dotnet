using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consumer
{
    public class WorkshopFollowerAPI
    {

        private HttpClient _client;

        public WorkshopFollowerAPI(string baseUrl)
        {
            _client = new HttpClient {BaseAddress = new Uri(baseUrl)};
        }

        public async Task<HttpResponseMessage> FindWorkshopFollower(string id)
        {
            try
            {
                var response = await _client.GetAsync($"/api/workshopfollowers/{id}");
                return response;
            }
            catch(Exception e)
            {
                throw new Exception("Could not obtain workshopfollower from API", e);
            }
        }

        public async Task<HttpResponseMessage> CreateWorkshopFollower(WorkshopFollower workshopfollower)
        {
            try
            {
                string requestbody = JsonSerializer.Serialize(workshopfollower);
                var response = await _client.PostAsync("/api/workshopfollowers", new StringContent(requestbody, Encoding.UTF8, "application/json"));                                                
                return response;
            }
            catch(Exception e)
            {
                throw new Exception("Could not save the workshopfollower", e);
            }
        }
    }
}