﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourSneaker.Core.Messages.Integration
{
    public class PedidoIniciadoIntegrationEvent : IntegrationEvent
    {
        // =========== DADOS DE PEDIDO =========== 
        public Guid ClienteId { get; set; }
        public Guid PedidoId { get; set; }
        public int TipoPagamento { get; set; }
        public decimal Valor { get; set; }

        //  =========== DADOS DO CARTAO  =========== 
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string MesAnoVencimento { get; set; }
        public string CVV { get; set; }
    }
}
