using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class UserClient : BaseHttpClient
    {

        public async Task<bool> PutUserState(UserBO entity)
        {
            bool success = false;
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    var content = JsonConvert.SerializeObject(entity);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"api/usuarios/actualizarEstado/{entity.NombreUsuario}", stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
            }
            return success;
        }

        public async Task<UserBO> GetUser(string username, string token)
        {
            UserBO user = new UserBO();
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await httpClient.GetAsync($"api/peliculas/usuarios/{username}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        user = JObject.Parse(responseContent)["mensaje"].ToObject<UserBO>();
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
            }
            return user;
        }

        //        public async void PutUserState(UserBO entity)
        //        {
        //            try
        //            {
        //                using (var httpClient = new BaseHttpClient())
        //                {
        //                    var content = JsonConvert.SerializeObject(entity);
        //                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
        //                    var response = await httpClient.PostAsync($"api/Login/{entity.NombreUsuario}", stringContent);

        //                    if (response.IsSuccessStatusCode)
        //                    {
        //                        string authorization = response.Headers.GetValues("Authorization").FirstOrDefault();
        //                        return authorization;
        //                    }
        //                    else
        //                    {
        //                        return null;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //#if DEBUG
        //                Debugger.Break();
        //#endif
        //                return null;
        //            }
        //        }
    }
}
