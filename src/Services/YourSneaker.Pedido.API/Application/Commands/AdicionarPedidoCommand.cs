﻿using FluentValidation;
using YourSneaker.Core.Messages;
using YourSneaker.Pedido.API.Application.DTO;

namespace YourSneaker.Pedido.API.Application.Commands
{
    public class AdicionarPedidoCommand : Command
    {
        // Pedido
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoItemDTO> PedidoItems { get; set; }

        // Cupom
        public string CupomCodigo { get; set; }
        public bool CumpomUtilizado { get; set; }
        public decimal Desconto { get; set; }

        // Endereco
        public EnderecoDTO Endereco { get; set; }

        // Cartao
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        public override bool EstaValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarPedidoValidation : AbstractValidator<AdicionarPedidoCommand>
        {
            public AdicionarPedidoValidation()
            {
                RuleFor(c => c.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente não está válido");

                RuleFor(c => c.PedidoItems.Count)
                    .GreaterThan(0)
                    .WithMessage("O pedido precisa ter no mínimo 1 produto");

                RuleFor(c => c.ValorTotal)
                    .GreaterThan(0)
                    .WithMessage("Valor do pedido não está válido");

                RuleFor(c => c.NumeroCartao)
                    .CreditCard()
                    .WithMessage("Número de cartão não está válido");

                RuleFor(c => c.NomeCartao)
                    .NotNull()
                    .WithMessage("Nome do portador do cartão é obrigatório");

                RuleFor(c => c.CvvCartao.Length)
                    .GreaterThan(2)
                    .LessThan(5)
                    .WithMessage("O CVV do cartão precisa ter 3 ou 4 números");

                RuleFor(c => c.ExpiracaoCartao)
                    .NotNull()
                    .WithMessage("Data expiração do cartão é obrigatória");
            }
        }
    }
}
