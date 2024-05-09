﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourSneaker.Core.DomainObjects;

namespace YourSneaker.Pedido.Domain.Pedidos
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string ProdutoImagem { get; set; }

        //EF rel
        public Pedidos Pedido { get; set; }

        public PedidoItem(Guid produtoId,
                          string produtoNome,
                          int quantidade,
                          decimal valorUnitario,
                          string produtoImagem)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;  
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ProdutoImagem = produtoImagem;
        }

        //EF ctor
        public PedidoItem(){ }

        internal decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }
    }
}
