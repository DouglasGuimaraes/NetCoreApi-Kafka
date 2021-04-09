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
            string parameterJson = JsonConvert.SerializeObject(parameter);
            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                try
                {
                    await producer.ProduceAsync(topic, new Message<Null, string> { Value = parameterJson });
                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(true);
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}