using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public static void WeatherMap()
        {
            var client = new HttpClient();

            var key = "00ae6454b638418981c524595d42e8d4";
            //var city = "Hilliard";

            /*var weatherURL = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&appid={key}&units=imperial";
            //var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}";
            var response = client.GetStringAsync(weatherURL).Result;
            //Console.WriteLine(response);

            JObject formattedResponse = JObject.Parse(response);
            var temp = formattedResponse["list"][0]["main"]["temp"];
            //var temp = formattedResponse["main"]["temp"];
            Console.WriteLine(temp);*/

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
                var city_name = Console.ReadLine();
                //var city_name = "Hillard";
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={key}";

                String response = "";
                String formattedResponse = "";

                try
                {
                    response = client.GetStringAsync(weatherURL).Result;
                    formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    var temp = JObject.Parse(formattedResponse).GetValue("temp");
                    Console.WriteLine($"The current Temperature is {temp} degrees Fahrenheit");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                
                
                AddSpaces(2);
                Console.WriteLine("Would you like to exit?");
                var userInput = "";

                do
                {
                    userInput = Console.ReadLine();

                    if (userInput == null)
                    {
                        Console.WriteLine("Need a better response");
                    }

                }while(userInput == null);
                
                AddSpaces(2);

                if(userInput.ToLower().Trim() == "yes")
                {
                    break;
                }
                
            }
        }

        public static void AddSpaces(int spaces)
        {
            for(int i = 0; i < spaces; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
