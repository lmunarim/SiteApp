using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceApi
{
    public class ProdutoApp
    {
        public DBProduto db { get; set; }
        public ProdutoApp()
        {
            db = new DBProduto();
        }

        public void Salvar(ProdutoModel produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }
        public IEnumerable<ProdutoModel> Listar()
        {
            return db.Produtos.ToList();
        }

        public void Alterar(ProdutoModel produto)
        {
            ProdutoModel pSalvar = db.Produtos.Where(x => x.Id == produto.Id).First();
            pSalvar.Nome = produto.Nome;
            pSalvar.Preco = produto.Preco;
            db.SaveChanges();
        }

        public void Excluir(int id)
        {
            ProdutoModel pExcluir = db.Produtos.Where(x => x.Id == id).First();
            db.Set<ProdutoModel>().Remove(pExcluir);
            db.SaveChanges(); 
        }
    }
}
