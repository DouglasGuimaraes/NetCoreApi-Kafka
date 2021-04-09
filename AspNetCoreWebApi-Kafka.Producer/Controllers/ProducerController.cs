using AspNetCoreWebApiKafka.Producer.Models;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AspNetCoreWebApiKafka.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ProducerConfig _config;
        public ProducerController(ProducerConfig config)
        {
            this._config = config;
        }
        [HttpPost("Send")]
        public async Task<ActionResult> Send(string topic, [FromBody] ProducerParameter parameter)
        {
            ProducerResponse result;
            string parameterJson = JsonConvert.SerializeObject(parameter);
            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                try
                {
                    var produceAsyncResponse = await producer.ProduceAsync(topic, new Message<Null, string> { Value = parameterJson });
                    result = new ProducerResponse(produceAsyncResponse.Message.Value);

                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    result = new ProducerResponse(ex);
                    return BadRequest(result);
                }
            }
        }
    }
}