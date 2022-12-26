

using MongoDB.Bson;
namespace HR; 

public class Department{
    
    public ObjectId _id{get;set;}
    public string? Name{get;set;}
    public string? Location{get;set;}

}