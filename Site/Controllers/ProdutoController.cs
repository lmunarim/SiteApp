using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Site.Models;
using Site.Repositorio;

namespace Site.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        // [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated || Session["usuario"] != null)
            {
                string usuario = Session["usuario"].ToString();

                ProdutoApp produto = new ProdutoApp();

                TokenApp tokenApp = new TokenApp();
                Token token = tokenApp.Get(usuario);
                if (DateTime.Now > token.DataExpiracao)
                {
                    return RedirectToAction("Login", "Account");
                }
                
                IEnumerable<ProdutoModels> lstProduto = produto.Listar();

                return View(lstProduto);
            }
            else
                return View();
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
