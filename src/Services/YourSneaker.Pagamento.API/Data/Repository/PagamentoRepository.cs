﻿using Microsoft.EntityFrameworkCore;
using YourSneaker.Core.Data;
using YourSneaker.Pagamento.API.Models;

namespace YourSneaker.Pagamento.API.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentosContext _context;

        public PagamentoRepository(PagamentosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarPagamento(Pagamentos pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public async Task<Pagamentos> ObterPagamentoPorPedidoId(Guid pedidoId)
        {
            return await _context.Pagamentos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.PedidoId == pedidoId);
        }

        public async Task<IEnumerable<Transacao>> ObterTransacaoesPorPedidoId(Guid pedidoId)
        {
            return await _context.Transacoes.AsNoTracking()
                .Where(t => t.Pagamento.PedidoId == pedidoId).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
