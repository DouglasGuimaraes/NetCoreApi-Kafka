using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AspNetCoreWebApiKafka.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private ConsumerConfig _config;
        public ConsumerController(ConsumerConfig config)
        {
            this._config = config;
        }
        [HttpPost("Messages")]
        public ActionResult Messages(string topic)
        {
            try
            {
                using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
                {
                    consumer.Subscribe(topic);
                    var consumeResult = consumer.Consume();

                    // Logic ...

                    consumer.Commit(consumeResult);

                    var jsonConsumerResponse = JsonConvert.SerializeObject(consumeResult);
                    return Ok(jsonConsumerResponse);
                }
            }
            catch (ConsumeException ex)
            {   
                throw ex;
            } 
            catch (System.Exception ex)
            {   
                throw ex;
            }   
        }
    }
}