using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PoulaillerMaquette.Class;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;



namespace PoulaillerMaquette.DAO
{
    public class DAOSuivi
    {
        static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://172.31.253.11:64195/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }


}
