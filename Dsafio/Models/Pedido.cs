
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDB.Models;

public class Pedido {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}= null;
    public string items {get; set;} = null!;
    public List<string> status {get; set;} = null!;
    public string costumer {get; set;} = null!;
    public int Total {get; set;}

}