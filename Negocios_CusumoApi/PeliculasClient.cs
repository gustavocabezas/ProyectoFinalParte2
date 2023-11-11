using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public class PeliculasClient : BaseHttpClient
    {
        public async Task<PeliculasTopIdResponse> GetPeliculasTopInfo(int id, string token)
        {
            PeliculasTopIdResponse entity = new PeliculasTopIdResponse();
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync($"api/Peliculas/PeliculasInfo/{id}").ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        entity = JsonConvert.DeserializeObject<PeliculasTopIdResponse>(responseContent);
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
            }
            return entity;
        }
    }
}
