using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using Site.Models;

namespace Site.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
     
        public AccountController()
        {
        }
    
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SignInStatus status;

            using (var client = new HttpClient())
            {
                var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", model.Usuario),
                        new KeyValuePair<string, string> ( "Password", model.Password )
                    };
                var content = new FormUrlEncodedContent(pairs);
                HttpResponseMessage response = client.PostAsync("http://localhost:35480/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                if (tokenDictionary.ContainsKey("error_description") == true)
                {
                    ViewBag.Token = tokenDictionary["error_description"];
                    status = SignInStatus.Failure;
                }
                else
                {
                    status = SignInStatus.Success;
                    Token token = new Token();
                    token.Usuario = model.Usuario;
                    token.Valor = tokenDictionary["access_token"];
                    token.DataExpiracao = Convert.ToDateTime(tokenDictionary[".expires"]);
                    Session["token"] = token;

                    // Gravamos o novo token no dataBase
                    var values = new Dictionary<string, string>()
                            {
                                {"Usuario", "teste"},
                                {"Valor", tokenDictionary["access_token"]},
                                {"DataExpiracao", Convert.ToDateTime(tokenDictionary[".expires"]).ToString()}
                            };
                    content = new FormUrlEncodedContent(values);

                    HttpResponseMessage response2 = client.PostAsync("http://localhost:35480/api/Token", content).Result;
                    response2.EnsureSuccessStatusCode();

                }
            }

            switch (status)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Produto");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }
    }
}
