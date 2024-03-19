using Confluent.Kafka;

namespace study_project.messaging.service
{
    public class ProducerCartUpdateService
    {
        private readonly IConfiguration _configuration;

        private readonly IProducer<Null, string> _producer;

        public ProducerCartUpdateService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerconfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<Null, string> { Value = message, };

            await _producer.ProduceAsync(topic, kafkamessage);
        }
    }
}