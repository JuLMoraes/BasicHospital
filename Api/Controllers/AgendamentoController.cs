using Domain.Core.Commands;
using Domain.Core.Commands.Agendamento;
using Domain.Core.Handlers.Agendamento;
using Domain.Core.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/agendamento")]
    public class AgendamentoController(
        GetConsultaCommandHandler getConsultaCommandHandler,
        GetConsultasCommandHandler getConsultasCommandHandler,
        CreateConsultaCommandHandler createConsultaCommandHandler
        ) :Controller
    {
        [HttpGet]
        [Route("/consulta")]
        public async Task<GetConsultaCommandResult> Get([FromQuery]GetConsultaCommand command)
        {
            var result = await getConsultaCommandHandler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("/consultas")]
        public async Task<List<GetConsultaCommandResult>> GetList([FromQuery]BaseCredentialsCommand command)
        {
            var result = await getConsultasCommandHandler.Handle(command);
            return result;
        }

        [HttpPost]
        [Route("/consulta")]
        public async Task Post(CreateConsultaCommand command)
        {
            await createConsultaCommandHandler.Handle(command);
        }
    }
}
