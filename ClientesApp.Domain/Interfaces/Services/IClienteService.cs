using ClientesApp.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Definição dos métodos abstratos para regras de negócio com a entidade 'Cliente'.
    /// </summary>
    public interface IClienteService
    {
        ClienteResponseDto Incluir(ClienteRequestDto dto);
        ClienteResponseDto Alterar(Guid id, ClienteRequestDto dto);
        ClienteResponseDto Excluir(Guid id);
        List<ClienteResponseDto> Consultar();
        ClienteResponseDto ObterPorId(Guid id);
    }
}
