using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Helpers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Validations
{
    /// <summary>
    /// Classe de validação do FluentValidator para a entidade Cliente
    /// </summary>
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("O ID do cliente é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty()
                    .WithMessage("O nome do cliente é obrigatório.")
                .Length(6, 150)
                    .WithMessage("O nome do cliente deve ter de 6 à 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty()
                    .WithMessage("O email do cliente é obrigatório.")
                .EmailAddress()
                    .WithMessage("O email do cliente deve ser um endereço de email válido.");

            RuleFor(c => c.Cpf)
                .NotEmpty()
                    .WithMessage("O cpf do cliente é obrigatório.")
                .Matches(@"^\d{11}$")
                    .WithMessage("O cpf do cliente deve ter exatamente 11 dígitos.")
                .Must(ValidationsHelper.IsValidCpf)
                    .WithMessage("O número de cpf é inválido.");

            RuleFor(c => c.DataInclusao)
                .NotEmpty()
                    .WithMessage("A data de inclusão do cliente é obrigatória.");

            RuleFor(c => c.DataUltimaAlteracao)
                .NotEmpty()
                    .WithMessage("A data da última alteração do cliente é obrigatória.");

            RuleFor(c => c.Ativo)
                .NotEmpty()
                    .WithMessage("A informação de Ativo ou Inativo do cliente é obrigatória.");
        }
    }
}
