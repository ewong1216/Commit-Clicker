using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Lab6.Models.Observations;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apikey = "EZcJ5o99vra7E5QMq2QQt";
        private string secret = "nnekBxezdDWD2HkL6uQHJgw57ne8pg45Y69sO1Df";

        public async Task<ObservationsRootObject> GetObservations()
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/observations/Seattle,WA,US/?client_id={apikey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ObservationsRootObject observations = JsonConvert.DeserializeObject<ObservationsRootObject>(responseString);

            return observations;
        }
    }
}
