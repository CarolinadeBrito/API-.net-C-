namespace MongoExemple.Models;

//usada para armazenar configurações relacionadas a uma conexão com o MongoDB
public class MongoDBSettings{ 

    public string ConnectionURI {get; set;}= null!;
    public string DatabaseName {get; set;}= null!;
    public string CollectionName {get; set;}= null!;

}