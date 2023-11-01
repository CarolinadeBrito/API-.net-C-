//dependecias que permitiram as interações com o db
using MongoExemple.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Models;
using MongoDB.Bson;

namespace MongoExemple.Services;
public class MongoDBService {
    private readonly IMongoCollection<Pedido> pedidoCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient (mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.ConnectionURI);
        pedidoCollection = database.GetCollection<Pedido>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync (Pedido pedido){
        await pedidoCollection.InsertOneAsync(pedido);
        return;
    }

    public async Task<List<Pedido>> GetAsync (){
        return await pedidoCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToPedidoAsync( string id, string pedidoiId) {
        FilterDefinition<Pedido> filter = Builders<Pedido>.Filter.Eq("Id", id);
        UpdateDefinition<Pedido> update = Builders<Pedido>.Update.AddToSet<string>("pedidoId", pedidoiId);
        await pedidoCollection.UpdateOneAsync(filter, update);
        return;
    }

     public async Task DeleteAsync( string id) {
        FilterDefinition<Pedido> filter = Builders<Pedido>.Filter.Eq("Id", id);
        await pedidoCollection.DeleteOneAsync(filter);
        return;
     }
}
