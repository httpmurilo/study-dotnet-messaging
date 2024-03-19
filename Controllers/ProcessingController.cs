using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using study_project.messaging.service;
using study_project.model;
using study_project.repository;
using System.Text.Json;

namespace study_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessingController : ControllerBase
    {
        private readonly IItensRepository repository;

        private readonly ILogger _logger;

        private readonly ICartRepository cartRepository;

        private readonly ProducerCartUpdateService producer;



        public ProcessingController(IItensRepository repository, ILogger logger, ICartRepository cartRepository, ProducerCartUpdateService producer)
        {
            this.repository = repository;
            this._logger = logger;
            this.cartRepository = cartRepository;
            this.producer = producer;
        }

        [HttpPost("/processCartPending")]
        public async Task<IActionResult>  processCartPending()
        {
            var listItens = cartRepository.GetCarts().Where(c => c.status.Contains("pending"));

            foreach (var itens in listItens)
            {
                try
                {
                    var message = JsonSerializer.Serialize(itens);
                    _logger.LogInformation($"serialize to post : " + message);
                    await producer.ProduceAsync("processQueueCart", message);

                }
                catch(Exception ex)
                {
                    _logger.LogError($"Error in post a message to queue" + ex);
                }

                _logger.LogInformation($"sucess to post a message" + itens);

            }
            return Ok("Atualizacao concluida com sucesso");
           
        }

    }
}
