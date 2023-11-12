using Newtonsoft.Json;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public class ComentariosClient
    {

        public ComentariosClient() { }

        public async Task<ComentariosBO> PostComentarios(ComentariosBO entity, string token)
        {
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    var content = JsonConvert.SerializeObject(entity);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.PostAsync("api/Peliculas/Comentarios", stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ComentariosBO>(responseContent);
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
                return null;
            }
        }

        public async Task<ComentariosBO> DeleteComentario(int id, string token)
        {
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.DeleteAsync($"api/Peliculas/Comentarios/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ComentariosBO>(responseContent);
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
                return null;
            }
        }
    }
}
