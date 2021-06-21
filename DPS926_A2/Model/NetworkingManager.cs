using DPS926_A2.Model.Players;
using DPS926_A2.Model.Teams;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DPS926_A2.Model
{

    class NetworkingManager
    {
        private string url = "https://www.balldontlie.io/api/v1/";
        private HttpClient client = new HttpClient();


        public async Task<List<Player>> GetAllPlayers()
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url + "players");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Player>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Player>>(array.ToString());

            }

        }

        public async Task<List<Player>> GetAllPlayerByNames(string first_name, string last_name)
        {
            //client.GetStringAsync
            string searchParams = "";

            if (String.IsNullOrEmpty(first_name) && String.IsNullOrEmpty(last_name))
            {
                searchParams = first_name + "+" + last_name;
            }
            else if(String.IsNullOrEmpty(first_name) && !String.IsNullOrEmpty(last_name))
            {
                searchParams = last_name;
            }
            else if(!String.IsNullOrEmpty(first_name) && String.IsNullOrEmpty(last_name))
            {
                searchParams = first_name;
            }

            var response = await client.GetAsync(url + "players?search=" + searchParams);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Player>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Player>>(array.ToString());

            }

        }

        public async Task<List<Stats>> GetPlayerStatsByID(int id)
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url + "season_averages?player_ids[]=" + id.ToString());
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Stats>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Stats>>(array.ToString());

            }

        }

        public async Task<List<Team>> GetAllTeams()
        {
            //client.GetStringAsync

            var response = await client.GetAsync(url + "teams");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Team>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();// json
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                var array = dic.ElementAt(0).Value;
                return JsonConvert.DeserializeObject<List<Team>>(array.ToString());

            }

        }


    }
}
