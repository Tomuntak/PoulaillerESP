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
        static HttpClient client = new HttpClient();

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://172.31.253.11:64195/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        static async Task<Poules> GetPoules()
        {
            Poules poule = null;
            HttpResponseMessage response = await client.GetAsync("RecupPouleActive");
            if (response.IsSuccessStatusCode)
            {
                poule = await response.Content.ReadAsAsync<Poules>();
            }
            return poule;
        }

        /******************************************************************************************** passage par le broker seulement ****************************************************************************************/

        //static async Task<Poules> GetPoulesIn()
        //{
        //    Poules poule = null;
        //    HttpResponseMessage response = await client.GetAsync("RecupPouleInside");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        poule = await response.Content.ReadAsAsync<Poules>();
        //    }
        //    return poule;
        //}

        /*********************************************************************************************************************************************************************************************************************/

        static async Task<Uri> CreatePoule(Poules poule)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/apipoules", poule);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Poules> UpdatePouleAsync(Poules poule)
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
