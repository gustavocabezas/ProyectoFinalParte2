using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negocios_CusumoApi
{
    public class BaseHttpClient : HttpClient, IDisposable
    {
        //https://localhost:44311/
        //https://tiusr33pl.cuc-carrera-ti.ac.cr/

        public BaseHttpClient(string baseUrl = "https://tiusr33pl.cuc-carrera-ti.ac.cr/")
        {
            Timeout = TimeSpan.FromSeconds(50);
            BaseAddress = new Uri(baseUrl);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Authorization = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // No es necesario llamar a base.Dispose()
            }
        }
    }
}
