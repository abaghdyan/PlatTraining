using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PlatTraining.Reporting.Entities;
using PlatTraining.Reporting.Options;

namespace PlatTraining.Reporting.Services
{
    public class ReportService : IReportService
    {
        private readonly IMongoCollection<Report> _reportsCollection;

        public ReportService(
            IOptions<MongoDbOptions> mongoOptions)
        {
            var mongoClient = new MongoClient(
                mongoOptions.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoOptions.Value.DatabaseName);

            _reportsCollection = mongoDatabase.GetCollection<Report>(
                mongoOptions.Value.ReportsCollectionName);
        }

        public async Task<List<Report>> GetAsync() =>
            await _reportsCollection.Find(_ => true).ToListAsync();

        public async Task<Report?> GetAsync(string id) =>
            await _reportsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Report newReport) =>
            await _reportsCollection.InsertOneAsync(newReport);

        public async Task UpdateAsync(string id, Report updatedReport) =>
            await _reportsCollection.ReplaceOneAsync(x => x.Id == id, updatedReport);

        public async Task RemoveAsync(string id) =>
            await _reportsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
