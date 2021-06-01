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
    public class DAOPoules
    {
        HttpClient client;


        public DAOPoules()
        {
            client = new HttpClient();

            RunAsync();
        }


       

        void RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://172.31.254.111/api/"); //Attention ! IP pas en static
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /********************************** get poule pour le graphique par poules individuellement **************************/
        //public async Task<Poules> GetPoules()
        //{
        //    Poules poule = null;
        //    HttpResponseMessage response = await client.GetAsync("RecupPouleActive");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        poule = await response.Content.ReadAsAsync<Poules>();
        //    }
        //    return poule;
        //}


        public async Task<int> GetPouleActive()
        {
             int nbpouleactive = 0;
      
            HttpResponseMessage response = await client.GetAsync("RecupPouleActive");
            if (response.IsSuccessStatusCode)
            {
                //poule = await response.Content.ReadAsAsync<Poules>();
                var t = await response.Content.ReadAsStringAsync();

                string x = t.Substring(6, 1);
                nbpouleactive = int.Parse(x);

                /************************************* autre solution **********************************************/
                //string[] separator  = t.Split(':');
                //string x = separator[1].Remove(1,2);

            }
            return nbpouleactive;
        }


        public async Task<Uri> CreatePoule(Poules poule)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/apipoules", poule);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        async Task<Poules> UpdatePouleAsync(Poules poule)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{poule.IDPoule}", poule);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            poule = await response.Content.ReadAsAsync<Poules>();
            return poule;
        }

    }


}
