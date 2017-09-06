using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Site.Models;

namespace Site.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        // [Authorize]
        public ActionResult Index()
        {
            if (Session["token"] != null)
            {
                if(!ValidarToken())
                    return RedirectToAction("Login", "Account");

                IEnumerable<ProdutoModels> lstProduto = null;

                using (var client = new HttpClient())
                {
                    System.Net.Http.HttpResponseMessage response = client.GetAsync("http://localhost:35480/api/Produto").Result;

                    //se retornar com sucesso busca os dados
                    if (response.IsSuccessStatusCode)
                    {
                        //Pegando os dados do Rest e armazenando na variável usuários
                        lstProduto = response.Content.ReadAsAsync<IEnumerable<ProdutoModels>>().Result;
                    }
                }

                return View(lstProduto);
            }
            else
                return RedirectToAction("Login", "Account");
        }

        private bool ValidarToken()
        {
            Token token = (Token)Session["token"];
            string result = "";

            using (var client = new HttpClient())
            {
                System.Net.Http.HttpResponseMessage response = client.GetAsync("http://localhost:35480/api/Token/" + token.Usuario).Result;

                //se retornar com sucesso busca os dados
                if (response.IsSuccessStatusCode)
                {
                    //Pegando os dados do Rest e armazenando na variável usuários
                    result = response.Content.ReadAsAsync<string>().Result;
                }
            }

            if (String.IsNullOrEmpty(result) || result == "NOK")
            {
                return false;
            }
            else
                return true;

        }
    }
}
