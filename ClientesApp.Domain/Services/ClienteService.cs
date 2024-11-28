using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using ClientesApp.Domain.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        //atributos (somente leitura)
        private readonly IClienteRepository _clienteRepository;

        //PRINCIPIO SOLID: DIP - DEPENDENCY INVERSION PRINCIPLE
        //método construtor para injeção de dependência
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponseDto Incluir(ClienteRequestDto dto)
        {
            #region Capturar e validar os dados do cliente

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                DataInclusao = DateTime.Now,
                DataUltimaAlteracao = DateTime.Now,
                Ativo = true
            };

            var clienteValidator = new ClienteValidator();
            var result = clienteValidator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo email

            if (_clienteRepository.VerifyEmail(dto.Email, cliente.Id))
                throw new ApplicationException("O email informado já está cadastrado para outro cliente.");

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo Cpf

            if (_clienteRepository.VerifyCpf(dto.Cpf, cliente.Id))
                throw new ApplicationException("O cpf informado já está cadastrado para outro cliente.");

            #endregion

            #region Realizar o cadastro do cliente

            _clienteRepository.Add(cliente);

            #endregion

            #region Devolvendo a resposta com os dados do cliente cadastrado

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }

        public ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto)
        {
            #region Buscar o cliente no banco de dados através do ID

            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Capturar e validar os dados do cliente

            cliente.Nome = dto.Nome;
            cliente.Cpf = dto.Cpf;
            cliente.Email = dto.Email;
            cliente.DataUltimaAlteracao = DateTime.Now;

            var clienteValidator = new ClienteValidator();
            var result = clienteValidator.Validate(cliente);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo email

            if (_clienteRepository.VerifyEmail(dto.Email, cliente.Id))
                throw new ApplicationException("O email informado já está cadastrado para outro cliente.");

            #endregion

            #region Não permitir a inclusão de clientes com o mesmo Cpf

            if (_clienteRepository.VerifyCpf(dto.Cpf, cliente.Id))
                throw new ApplicationException("O cpf informado já está cadastrado para outro cliente.");

            #endregion

            #region Realizar o cadastro do cliente

            _clienteRepository.Update(cliente);

            #endregion

            #region Devolvendo a resposta com os dados do cliente cadastrado

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }

        public ClienteResponseDto Excluir(Guid id)
        {
            #region Buscar o cliente no banco de dados através do ID

            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não foi encontrado, verifique o ID informado.");

            #endregion

            #region Inativando o registro do cliente - Soft Delete

            cliente.Ativo = false;
            cliente.DataUltimaAlteracao = DateTime.Now;

            _clienteRepository.Update(cliente);

            #endregion

            #region Devolvendo a resposta com os dados do cliente "excluido"

            return new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            #endregion
        }

        public List<ClienteResponseDto> Consultar()
        {
            var response = new List<ClienteResponseDto>();

            var clientes = _clienteRepository.GetAll();

            foreach (var cliente in clientes)
            {
                response.Add(new ClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataInclusao = cliente.DataInclusao,
                    DataUltimaAlteracao = cliente.DataUltimaAlteracao
                });
            }

            return response;
        }

        public ClienteResponseDto ObterPorId(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
                throw new ApplicationException("Cliente não encontrado, verifique o ID informado.");

            var response = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf,
                DataInclusao = cliente.DataInclusao,
                DataUltimaAlteracao = cliente.DataUltimaAlteracao
            };

            return response;
        }
    }
}
