using ClientesApp.Domain.Dtos;
using ClientesApp.Domain.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        //método construtor para injeção de dependência
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Serviço para cadastro  de clientes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponseDto), 201)]
        public IActionResult Post([FromBody] ClienteRequestDto dto)
        {
            try
            {
                var response = _clienteService.Incluir(dto);

                return StatusCode(201, response);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        } 

        /// <summary>
        /// Serviço para alteração de clientes
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public IActionResult Put(Guid id, [FromBody] ClienteRequestDto dto)
        {
            try
            {
                var response = _clienteService.Alterar(id, dto);

                return StatusCode(200, response);
            }
            catch (ValidationException ex)
            {
                var errors = ex.Errors.Select(e => new
                {
                    Name = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return StatusCode(400, errors);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// Serviço para deleção de clientes
        /// </summary>
        /// <returns>Retorna dados do cliente excluido</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var response = _clienteService.Excluir(id);

                return StatusCode(200, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// Serviço para consulta de clientes
        /// </summary>
        /// <returns>Retorna uma lista com os clientes cadastrados</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _clienteService.Consultar();
                
                if(response.Any())
                    return StatusCode(200, response);
                else
                    return StatusCode(204, new { message = "Nenhum cliente encontrado." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        /// <summary>
        /// Serviço para consultar um cliente em específico pelo ID
        /// </summary>
        /// <returns>Retorna dados do cliente procurado pelo ID</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponseDto), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _clienteService.ObterPorId(id);

                return StatusCode(200, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
