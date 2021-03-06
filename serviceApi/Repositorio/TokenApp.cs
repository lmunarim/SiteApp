﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceApi
{
    public class TokenApp
    {
        public DBProduto db { get; set; }

        public TokenApp()
        {
            db = new DBProduto();
        }

        public void Salvar(Token token)
        {
            db.Tokens.Add(token);
            db.SaveChanges();
        }

        public bool Get()
        {
            return true;
        }

        public Token Get(string usuario)
        {
            return db.Tokens.Where(x => x.Usuario == usuario).OrderByDescending(p => p.Id).FirstOrDefault();
        }
    }
}
