using Newtonsoft.Json;
using RestSharp;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new RestClient("https://localhost:44348/");
            var usuario = "pepitox";

            //Obtengo personas
            Console.Out.WriteLine("Obtengo personas:");
            var request = new RestRequest("personas/" + "1");
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject<dynamic>(response).nombre);
            
            //Obtengo una persona
            Console.Out.WriteLine("Obtengo una persona:");
            request = new RestRequest("personas/1");
            response = client.Get(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject(response));

            // Agrego una persona
            Console.Out.WriteLine("Agrego una persona");
            request = new RestRequest("personas/");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = 70, nombre = "Flores", edad = 20});
            response = client.Post(request).Content;

           
            //Busco a la persona agregada
            Console.Out.WriteLine("Busco a la persona agregada:");
            request = new RestRequest("personas/70");
            response = client.Get(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject(response));

            // Borro una persona
            Console.Out.WriteLine("Borro una persona");
            request = new RestRequest("personas/70");
            response = client.Delete(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject(response));

            // Modifico una persona
            Console.Out.WriteLine("Modifico una persona");
            request = new RestRequest("personas/1");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { id = 1, nombre = "nombreModificado", edad = 120 });
            response = client.Put(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject(response));

            // Obtengo personas
            Console.Out.WriteLine("Obtengo personas para ver estado final:");
            request = new RestRequest("personas/");
            response = client.Get(request).Content;
            Console.Out.WriteLine(JsonConvert.DeserializeObject(response));

            Console.ReadLine();

        }
    }
}
