namespace ClientesApp.Domain.Dtos
{
    /// <summary>
    /// DTO para saída de dados (Resposta) de clientes
    /// </summary>
    public class ClienteResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
