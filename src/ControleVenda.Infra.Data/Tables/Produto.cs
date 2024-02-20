﻿using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Tables
{
    public class Produto : IKeyIdentitication
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


    }
}
