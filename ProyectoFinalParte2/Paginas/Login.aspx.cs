using Microsoft.Ajax.Utilities;
using Negocios_CusumoApi;
using Newtonsoft.Json;
using ProyectoFinalParte2BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalParte2.Paginas
{
    public partial class Login : System.Web.UI.Page
    {

        public bool _isRequiredLogin = false;
        public bool _isRequiredRegistrarse = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBind();
            }
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los controles TextBox
            string user = txtlogin.Text;
            string password = txtcontrasena.Text;

            try
            {
                using (LoginClient loginClient = new LoginClient())
                {
                    LoginBO login = new LoginBO() { NombreUsuario = user, Contraseña = password };
                    string authorization = await loginClient.PostLogin(login);
                    if (!string.IsNullOrEmpty(authorization))
                    {
                        // Almacenar el valor de autorización en una cookie o en la sesión, según tus necesidades
                        const string prefixToRemove = "Bearer ";
                        if (authorization.StartsWith(prefixToRemove))
                        {
                            authorization = authorization.Substring(prefixToRemove.Length);
                            Application["Authorization"] = authorization;
                        }

                        Dictionary<string, int> userAttempts = Application["UserAttempts"] as Dictionary<string, int>;

                        if (userAttempts != null && userAttempts.ContainsKey(user))
                        {
                            userAttempts[user] = 0;
                            Application["UserAttempts"] = new Dictionary<string, int>();
                        }

                        using (UserClient userClient = new UserClient())
                        {
                            UserBO response = await userClient.GetUser(login.NombreUsuario, authorization);
                            if (response != null && !response.Estado.Equals("inactivo", StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("PaginaPrincipal.aspx");
                            }
                            else
                            {
                                Application["UserAttempts"] = new Dictionary<string, int>();
                                string script2 = "alert('Su usuario se encuentra inactivo, por favor comuníquese con el administrador');";
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", script2, true);
                            }
                        }
                    }
                    else
                    {
                        // Obtener el diccionario de la sesión o inicializarlo si no existe
                        Dictionary<string, int> userAttempts = (Dictionary<string, int>)Application["UserAttempts"];
                        if (userAttempts == null)
                            userAttempts = new Dictionary<string, int>();

                        if (userAttempts.ContainsKey(login.NombreUsuario))
                            userAttempts[login.NombreUsuario]++;
                        else
                            userAttempts[login.NombreUsuario] = 1;

                        Application["UserAttempts"] = userAttempts;

                        if (userAttempts[login.NombreUsuario] >= 3)
                        {
                            // Si el usuario ha fallado 3 veces
                            using (UserClient userClient = new UserClient())
                            {
                                bool response = await userClient.PutUserState(new UserBO() { NombreUsuario = user, Estado = "inactivo" });
                                if (response)
                                {
                                    string script2 = "alert('Su usuario se encuentra inactivo, por favor comuníquese con el administrador');";
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", script2, true);
                                    // Reiniciar el contador
                                    Application["AttemptsLogin"] = 0;
                                }
                                else
                                {
                                    // Inyectar el script que muestra el mensaje de error
                                    string script = "alert('Usuario y/o contraseña incorrectos');";
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", script, true);
                                }
                            }
                        }
                        else
                        {
                            // Inyectar el script que muestra el mensaje de error
                            string script = "alert('Usuario y/o contraseña incorrectos');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", script, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debugger.Break();
#endif
            }
        }


        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsername.Text;
            string nombre = txtFirstName.Text;
            string primerApellido = txtLastName.Text;
            string segundoApellido = txtsecunName.Text;
            string correo = txtEmail.Text;
            string contraseña = txtPassword.Text;


            UserBO newUser = new UserBO
            {
                NombreUsuario = nombreUsuario,
                Nombre = nombre,
                PrimerApellido = primerApellido,
                SegundoApellido = segundoApellido,
                Contraseña = contraseña,
                Estado = "Activo",
                Correo = correo
            };

            // Crea una instancia del cliente HTTP personalizado que tienes
            using (BaseHttpClient apiClient = new BaseHttpClient())
            {
                try
                {

                    HttpResponseMessage checkUserResponse = await apiClient.GetAsync($"api/Peliculas/Usuarios/{nombreUsuario}");

                    if (checkUserResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Convierte el objeto newUser a JSON
                        string jsonUser = JsonConvert.SerializeObject(newUser);

                        // Crea un contenido JSON
                        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                        // Realiza una solicitud POST a la API para registrar al usuario
                        HttpResponseMessage response = await apiClient.PostAsync("api/Peliculas/Usuarios", content);

                        if (response.IsSuccessStatusCode)
                        {
                            string successScript = "alert('Usuario creado con éxito');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", successScript, true);

                            // Limpia los TextBox
                            txtUsername.Text = string.Empty;
                            txtFirstName.Text = string.Empty;
                            txtLastName.Text = string.Empty;
                            txtsecunName.Text = string.Empty;
                            txtEmail.Text = string.Empty;
                            txtPassword.Text = string.Empty;

                        }
                        else
                        {
                            string successScript = "alert('Ha ocurrido un error intente de nuevo');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", successScript, true);
                        }
                    }
                    else
                    {
                        string successScript = "alert('Ha ocurrido un error intente de nuevo');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ErrorScript", successScript, true);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones en caso de un error en la solicitud HTTP
                }
            }
        }
    }
}
