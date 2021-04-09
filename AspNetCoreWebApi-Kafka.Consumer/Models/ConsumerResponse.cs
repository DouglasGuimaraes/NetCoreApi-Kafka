using System;

namespace AspNetCoreWebApi_Kafka.Consumer.Models
{
    public class ConsumerResponse
    {
        public ConsumerResponse(string message)
        {
            Ok = true;
            Message = message;
        }
        public ConsumerResponse(Exception ex)
        {
            Ok = false;
            Exception = ex;
        }
        public bool Ok { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}