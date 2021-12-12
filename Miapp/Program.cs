using System;
using System.Net.Http;
using System.Collections.Generic;

namespace clientAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            getMunicipio();
            Console.ReadKey();
        }

        static void getMunicipio()
        {
            ClientAPI client =new ClientAPI();
            HttpResponseMessage httpResponseMessage = client.Find("Municipio").Result;
            List<Municipio> municipio = httpResponseMessage.Content.ReadAsAsync<List<Municipio>>().Result;
            Console.WriteLine("Municipio");

            foreach(Municipio mun in municipio)
            {
                Console.WriteLine("ID: " + mun.municipioID);
                Console.WriteLine("Nombre: " + mun.nombre);
                Console.WriteLine("Poblacion: " + mun.poblacion);
                Console.WriteLine("Latitud: " + mun.latitud);
                Console.WriteLine("Longitud: " + mun.longitud);
            }

        }
    }
}
