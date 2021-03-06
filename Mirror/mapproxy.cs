﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Media;

namespace Mirror
{
    public class mapproxy
    {
        public class OpenMapProxy
        {
            public async static Task<RootObject> GetWeather(decimal lat, decimal lon)
            {
                var http = new HttpClient();
                var response = await http.GetAsync("http://openweathermap.org/data/2.5/weather?lat=35.1380556&lon=-79.0075&appid=b1b15e88fa797225412429c1c50c122a1");
                var result = await response.Content.ReadAsStringAsync();
                var serializer = new DataContractJsonSerializer(typeof(RootObject));

                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var data = (RootObject)serializer.ReadObject(ms);

                return data;
                
            }
        }
        [DataContract]
        public class Coord
        {
            [DataMember]
            public decimal lat { get; set; }
            [DataMember]
            public decimal lon { get; set; }
        }
        [DataContract]
        public class Weather
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }
        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public int pressure { get; set; }
            [DataMember]
            public int humidity { get; set; }
            [DataMember]
            public int temp_min { get; set; }
            [DataMember]
            public int temp_max { get; set; }
        }
        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public int deg { get; set; }
        }
        [DataContract]
        public class Clouds
        {
            [DataMember]
            public int all { get; set; }
        }
        [DataContract]
        public class Sys
        {
            [DataMember]
            public int type { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public int sunrise { get; set; }
            [DataMember]
            public int sunset { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public string @base { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public int visibility { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public int dt { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public int cod { get; set; }
        }
    }
}
