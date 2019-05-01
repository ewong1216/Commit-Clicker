
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab6.Models;
using Lab6.Models.AutoComplete;

namespace Lab6
{
    class WeatherRetriever
    {
        private string apikey = "EZcJ5o99vra7E5QMq2QQt";
        private string secret = "nnekBxezdDWD2HkL6uQHJgw57ne8pg45Y69sO1Df";

        public async Task<ObservationsRootObject> GetObservations(string cityLink)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/observations/{cityLink}/?client_id={apikey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            ObservationsRootObject observations = JsonConvert.DeserializeObject<ObservationsRootObject>(responseString);

            return observations;
        }

        public async Task<AutoCompleteRootObject> GetSuggestions(string enteredStr)
        {
            HttpClient httpClient = new HttpClient();
            string apiUrl = $"https://api.aerisapi.com/places/search?query=name:^{enteredStr}&limit=10&client_id={apikey}&client_secret={secret}";

            string responseString = await httpClient.GetStringAsync(apiUrl);

            AutoCompleteRootObject suggestions = JsonConvert.DeserializeObject<AutoCompleteRootObject>(responseString);

            return suggestions;
        }
    }
}
