using Newtonsoft.Json;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public class LoginClient : BaseHttpClient
    {

        public async Task<string> PostLogin(LoginBO login)
        {
            try
            {
                using (var httpClient = new BaseHttpClient())
                {
                    var content = JsonConvert.SerializeObject(login);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("api/Login", stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string authorization = response.Headers.GetValues("Authorization").FirstOrDefault(); 
                        return authorization;
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
