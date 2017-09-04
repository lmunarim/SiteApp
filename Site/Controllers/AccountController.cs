using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Site.Models;
using Site.Repositorio;

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
                        new KeyValuePair<string, string>( "username", model.Email),
                        new KeyValuePair<string, string> ( "Password", model.Password )
                    };
                var content = new FormUrlEncodedContent(pairs);
                HttpResponseMessage response = client.PostAsync("http://localhost:35480/token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                if (tokenDictionary.ContainsKey("error_description") == true)
                {
                    ViewBag.Token = tokenDictionary["error_description"];
                    status = SignInStatus.Failure;
                }
                else
                {
                    TokenApp token = new TokenApp();
                    token.Salvar(new Token
                    {
                        DataExpiracao = Convert.ToDateTime(tokenDictionary[".expires"]),
                        Usuario = model.Email,
                        Valor = tokenDictionary["access_token"].ToString()
                    });
                    Session["token"]= string.Format("{0} - {1}", DateTime.Now < Convert.ToDateTime(tokenDictionary[".expires"]) ? "OK" : "NOK"  , tokenDictionary["access_token"]);
                    status = SignInStatus.Success;
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    Thread.CurrentPrincipal = HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                                        {
                                            new Claim(ClaimTypes.Name, model.Email)
                                        }, "someAuthTypeName"));
                    Session["usuario"] = model.Email;
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
