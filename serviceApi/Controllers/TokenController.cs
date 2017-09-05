using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace serviceApi.Controllers
{
    public class TokenController : ApiController
    {
        // GET: api/Token
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Token/5
        public string Get(string id)
        {
            TokenApp t = new TokenApp();
            Token token = t.Get(id);

            if (token != null && DateTime.Now <= token.DataExpiracao)
                return "OK";
            else
                return "NOK";
        }

        //// POST: api/Token
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Token/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Token/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage PostToken(Token token)
        {
            TokenApp t = new TokenApp();
            t.Salvar(token);

            var response = Request.CreateResponse<Token>(HttpStatusCode.Created, token);

            string uri = Url.Link("DefaultApi", new { id = token.Valor });
            response.Headers.Location = new Uri(uri);
            return response;


        }
    }
}
