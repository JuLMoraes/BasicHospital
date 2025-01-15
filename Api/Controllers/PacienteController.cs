using Domain.Core.Commands.Paciente;
using Domain.Core.Entities;
using Domain.Core.Handlers.Paciente;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/paciente")]
    public class PacienteController(
        GetPacienteCommandHandler getPacienteCommandHandler,
        CreatePacienteCommandHandler createPacienteCommandHandler,
        UpdatePacienteCommandHandler updatePacienteCommandHandler
        ) : Controller
    {
        [HttpGet]
        [Route("/obter")]
        public async Task<Paciente> Get([FromQuery]GetPacienteCommand command)
        {
            var result = await getPacienteCommandHandler.Handle(command);
            return result;
        }

        [HttpPost]
        [Route("/criar")]
        public async Task Cadastro(CreatePacienteCommand command)
        {
            await createPacienteCommandHandler.Handle(command);
        }

        [HttpPut]
        [Route("/editar")]
        public async Task<Paciente> Editar(UpdatePacienteCommand command)
        {
            var result = await updatePacienteCommandHandler.Handle(command);
            return result;
        }
    }
}
