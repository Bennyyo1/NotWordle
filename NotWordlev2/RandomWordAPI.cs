using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWordlev2
{
    internal class RandomWordAPI
    {
        public static async Task<string> GetRandomWord()
        {

            string apiUrl = "https://random-word-api.vercel.app/api?words=1&length=5&type=uppercase";

            //json?
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    string[] words = responseBody.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
                    return words[0];
                }
                catch (HttpRequestException e)
                {
                    await ShowErrorMessage($"Could not get API: {e.Message}");
                    return null;
                }
            }
        }
        private static async Task ShowErrorMessage(string message)
        {
            await Application.Current.MainPage.DisplayAlert("Error", message, "OK"); //testa failed api call
        }
    }

    
}
