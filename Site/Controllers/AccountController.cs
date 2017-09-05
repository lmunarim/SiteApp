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
                    status = SignInStatus.Success;
                    Token token = new Token();
                    token.Usuario = model.Usuario;
                    token.Valor = tokenDictionary["access_token"];
                    token.DataExpiracao = Convert.ToDateTime(tokenDictionary[".expires"]);
                    Session["token"] = token;
                    //using (var clientToken = new HttpClient())
                    //{
                    //    var serialized = JsonConvert.SerializeObject(token);
                    //    var contentToken = new StringContent(serialized, Encoding.UTF8, "application/json");
                    //    Task<HttpResponseMessage> responseMessage = clientToken.PostAsync("http://localhost:35480/api/Token/", contentToken);

                    //    ViewBag.Result = result;
                    //}

                    using (var clientToken = new HttpClient())
                    {
                        var uri = new Uri("http://localhost:35480/api/Token/");
                        var json = JsonConvert.SerializeObject(token);
                        var contentToken = new StringContent(json, Encoding.UTF8, "text/json");
                        //Task<HttpResponseMessage> responseToken = new HttpResponseMessage();
                        Task<HttpResponseMessage> responseMessage = clientToken.PostAsync(uri, content);
                        //if (responseToken.IsSuccessStatusCode)
                        //{
                        //    await DisplayAlert("Alert", "Post executado!", "Ok");
                        //}
                        //else
                        //{
                        //    await DisplayAlert("Alert", "Post não executado!", "Ok");
                        //}
                    }

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
