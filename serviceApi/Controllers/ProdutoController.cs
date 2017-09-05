using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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

        public List<ProdutoModel> GetAllProdutos()
        {
            ProdutoApp app = new ProdutoApp();
            return app.Listar().ToList();
        }
    }
}