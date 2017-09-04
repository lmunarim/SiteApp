using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DAL;
using Microsoft.Owin.Security;
using serviceApi.Entidades;

namespace serviceApi.Controllers
{
    public class ProdutoController : ApiController
    {
        
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        // [Authorize]
        public bool Get()
        {
            return true;
        }

        public List<Pessoa> BuscarPessoas()
        {
            List<Pessoa> lstPessoa = new List<Pessoa>();

            lstPessoa.Add(new Pessoa { Nome = "Joao", Idade = 10 });
            lstPessoa.Add(new Pessoa { Nome = "Maria", Idade = 10 });

            return lstPessoa;
        }

        //public List<Produto> BuscarProdutos()
        //{
        //    ProdutoApp app = new ProdutoApp();
        //    return app.Listar().ToList();
        //}
    }
}