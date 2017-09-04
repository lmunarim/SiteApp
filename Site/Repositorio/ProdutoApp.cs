using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Site.Models;

namespace Site.Repositorio
{
    public class ProdutoApp
    {
        public DBProduto db { get; set; }
        public ProdutoApp()
        {
            db = new DBProduto();
        }

        public void Salvar(ProdutoModels produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }
        public IEnumerable<ProdutoModels> Listar()
        {
            return db.Produtos.ToList();
        }

        public void Alterar(ProdutoModels produto)
        {
            ProdutoModels pSalvar = db.Produtos.Where(x => x.Id == produto.Id).First();
            pSalvar.Nome = produto.Nome;
            pSalvar.Preco = produto.Preco;
            db.SaveChanges();
        }

        public void Excluir(int id)
        {
            ProdutoModels pExcluir = db.Produtos.Where(x => x.Id == id).First();
            db.Set<ProdutoModels>().Remove(pExcluir);
            db.SaveChanges(); 
        }
    }
}
