using Newtonsoft.Json;
using PlatTraining.Reporting.Entities;
using PlatTraining.Reporting.Messages;
using PlatTraining.Reporting.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PlatTraining.Reporting.Consumers
{
    public class RabbitMqListener : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private const string QueueName = "plat_queue";
        private readonly IServiceProvider _serviceProvider;

        public RabbitMqListener(IServiceProvider serviceProvider)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Password = "Passw0rd", UserName = "plat" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: QueueName, exclusive: false, autoDelete: false);
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, e) =>
            {
                try
                {
                    var body = e.Body;
                    using var scope = _serviceProvider.CreateScope();
                    var msg = Encoding.UTF8.GetString(body.ToArray());
                    var reportDbModel = JsonConvert.DeserializeObject<ReportMessage>(msg);
                    var repService = scope.ServiceProvider.GetRequiredService<IReportService>();
                    var reportEntity = new Report
                    {
                        Body = reportDbModel.Body,
                        Date = reportDbModel.Date,
                        QueryString = reportDbModel.QueryString,
                        ReportType = reportDbModel.ReportType,
                        UserId = reportDbModel.UserId,
                        Url = reportDbModel.Url
                    };
                    await repService.CreateAsync(reportEntity);
                    _channel.BasicAck(e.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
            _channel.BasicConsume(QueueName, false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
