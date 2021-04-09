using System;

namespace AspNetCoreWebApiKafka.Producer.Models
{
    public class ProducerResponse{
        public ProducerResponse(string message)
        {
            Ok = true;
            Message = message;
        }

        public ProducerResponse(Exception ex)
        {
            Ok = false;
            Exception = ex;
        }
        public bool Ok { get; set; }
        public string Message { get; set; } 
        public Exception Exception { get; set; }
        
    }
}