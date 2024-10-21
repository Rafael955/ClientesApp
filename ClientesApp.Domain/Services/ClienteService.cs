using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    public class ClienteService : IClienteService
    {
        public ClienteResponseDto Incluir(ClienteRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ClienteResponseDto> Consultar()
        {
            throw new NotImplementedException();
        }

        public ClienteResponseDto ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
