using MongoDB.Driver;

namespace API.Data;

public class MongoDbService
{
    private readonly IConfiguration _configuration;
    private readonly IMongoDatabase? _database;

    public MongoDbService(IConfiguration config)
    {
        _configuration = config;
        var connectionString = config.GetConnectionString("MongoDb");
        var mongoUrl = new MongoUrl(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }
    
    public IMongoDatabase? Database() => _database;
    
}