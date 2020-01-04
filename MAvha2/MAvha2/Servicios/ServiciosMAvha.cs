using MAvha2.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MAvha2.Servicios
{
    public class ServiciosMAvha
    {
        public const string baseUrl = "https://localhost:44323/";
        private const string Path = "api/MAvhaApi/";
        public void InsertarProducto(Modelo.TODO pEN)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                
                var jsonContent = JsonConvert.SerializeObject(pEN);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");                
                var result = client.PostAsync(Path, content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }

        public List<TODO> GetAll()
        {
            List<TODO> list = new List<TODO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var jsonContent = JsonConvert.SerializeObject(list);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");                
                var result = client.GetAsync(Path).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TODO>>(resultContent);
                return list;
            }
        }

        public TODO GetById(long? Id)
        {
            var cadena = "?id=";
            TODO entidad = new TODO();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var jsonContent = JsonConvert.SerializeObject(Id);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var result = client.GetAsync(Path + cadena + Id.ToString()).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                entidad = JsonConvert.DeserializeObject<TODO>(resultContent);
                return entidad;
            }
        }

        public List<TODO> GetByStatus(byte? status)
        {
            var cadena ="?Status=";
            List<TODO> list = new List<TODO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var jsonContent = JsonConvert.SerializeObject(list);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");                
                var result = client.GetAsync(Path + cadena +status.ToString()).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TODO>>(resultContent);
                return list;
            }
        }

        public List<TODO> GetByDescription(string Description)
        {
            var cadena = "?description=";
            List<TODO> list = new List<TODO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                var jsonContent = JsonConvert.SerializeObject(list);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");                
                var result = client.GetAsync(Path + cadena + Description).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TODO>>(resultContent);
                return list;
            }
        }
    }
}