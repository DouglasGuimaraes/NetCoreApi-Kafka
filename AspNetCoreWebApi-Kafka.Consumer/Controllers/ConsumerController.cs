using AspNetCoreWebApi_Kafka.Consumer.Models;
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
            ConsumerResponse result;
            try
            {
                using (var consumer = new ConsumerBuilder<Null, string>(_config).Build())
                {
                    consumer.Subscribe(topic);
                    var consumeResult = consumer.Consume();

                    // Logic ...

                    consumer.Commit(consumeResult);
                    
                    result = new ConsumerResponse(consumeResult.Message.Value);
                    
                    return Ok(result);
                }
            }
            catch (ConsumeException ex)
            {   
                result = new ConsumerResponse(ex);
                return BadRequest(result);
            } 
            catch (System.Exception ex)
            {   
                result = new ConsumerResponse(ex);
                return BadRequest(result);
            }   
        }
    }
}