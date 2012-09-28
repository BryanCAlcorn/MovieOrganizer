using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MovieOrganizer
{
    public class RottenTomatoesDAL : IMovieDAL
    {
        private const string rtKey = "?apikey=e2kfc6h7czdw9cpf6pyenqpg";
        private const string rtURL = "http://api.rottentomatoes.com/api/public/v1.0/movies.json";
        private const string rtQuery = "&q={title}";
        private static int numberOfRequests;

        public RottenTomatoesDAL()
        {
            numberOfRequests = 0;
        }

        public List<string> getGenres(string title)
        {
            List<string> genres = new List<string>();
            string queryURL = rtURL + rtKey + rtQuery.Replace("{title}", fixSpacesForQuery(title));
            if (numberOfRequests >= 10)
            {
                System.Threading.Thread.Sleep(1000);
                numberOfRequests = 0;
            }
            try
            {
                HttpWebRequest searchRequest = WebRequest.Create(queryURL) as HttpWebRequest;
                using (HttpWebResponse searchResponse = searchRequest.GetResponse() as HttpWebResponse)
                {
                    numberOfRequests++;
                    if (searchResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string jsonSearchString = GetJSONFromWebResp(searchResponse);
                        JObject jObj = JObject.Parse(jsonSearchString);
                        //Finds the movie search response with the exact title, instead of defaulting to first result
                        //ex: Searching for "Toy Story" may bring up "Toy Story 3" as first result.
                        var exactMovie =
                            from m in jObj["movies"].Children()
                            where ((string)m["title"]).ToLower() == title.ToLower()
                            select m;
                        JToken[] exactMovies = exactMovie.ToArray();
                        if (exactMovies.Length > 0)
                        {
                            //Gets the Self Link from the RT JSON, then make a 2nd request to get details w/ genre
                            string selfLink = (string)exactMovies[0]["links"]["self"];
                            selfLink = selfLink + rtKey;
                            HttpWebRequest detailsRequest = WebRequest.Create(selfLink) as HttpWebRequest;
                            using (HttpWebResponse detailsResponse = detailsRequest.GetResponse() as HttpWebResponse)
                            {
                                numberOfRequests++;
                                if (detailsResponse.StatusCode == HttpStatusCode.OK)
                                {
                                    string jsonDetailsString = GetJSONFromWebResp(detailsResponse);
                                    JObject jDetailsObj = JObject.Parse(jsonDetailsString);
                                    JArray jGenres = (JArray)jDetailsObj["genres"];
                                    genres = jGenres.Select(g => (string)g).ToList();
                                    return genres;
                                }
                            }
                        }
                    }
                }
                return genres;
            }
            catch (Exception)
            {
                return genres;
            }
        }

        private string fixSpacesForQuery(string queryText)
        {
            return queryText.Replace(' ', '+');
        }

        private string GetJSONFromWebResp(HttpWebResponse response)
        {
            string jsonString = String.Empty;
            using (Stream respStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
                char[] trimchars = { '\n', ' ', '\t' };
                jsonString = jsonString.Trim(trimchars);
            }

            return jsonString;
        }
    }
}
