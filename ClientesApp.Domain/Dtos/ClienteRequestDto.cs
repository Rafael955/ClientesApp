using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Dtos
{
    /// <summary>
    /// DTO para entrada de dados (Requisição) de clientes
    /// </summary>
    public class ClienteRequestDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

    }
}
