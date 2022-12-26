using System;
using MongoDB.Bson;
using MongoDB.Driver;
namespace HR;

public class DepartmentMongodbCRUDTest
{
    protected static IMongoClient client;
    protected static IMongoDatabase database;
    public static Department GetDepartment()
    {
        Console.WriteLine("Enter name of department:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter location of department:");
        string location = Console.ReadLine();

        Department department = new Department()
        {
            Name = name,
            Location = location
        };
        return department;
    }



    public static void CRUDwithMongoDb()
    {
        string userSelection;
        do
        {
            client = new MongoClient();
            database = client.GetDatabase("Transflower");
            var collection = database.GetCollection<Department>("departments");
            Console.WriteLine("\nPress select your option from the following\n1 - Insert\n2 - UpdateOne Document\n3 - Delete\n4 - Read All\n");
            userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    collection.InsertOne(GetDepartment());
                    break;

                case "2":
                    var obj1 = GetDepartment();
                    collection.FindOneAndUpdate<Department>
                    (Builders<Department>.Filter.Eq("Name", obj1.Name),
                            Builders<Department>.Update.Set("Location", obj1.Location));
                    break;
                case "3":
                    //Find and Delete  
                    Console.WriteLine("Please Enter the name to delete the record(so called document) : ");
                    var deleteName = Console.ReadLine();
                    collection.DeleteOne(s => s.Name == deleteName);
                    break;

                case "4":
                    //Read all existing document  
                    var all = collection.Find(new BsonDocument());
                    Console.WriteLine();

                    foreach (var i in all.ToEnumerable())
                    {
                        Console.WriteLine(i._id + "\t" + i.Name + "\t" + i.Location);
                    }
                    break;

                default:
                    Console.WriteLine("Please choose a correct option");
                    break;
            }
        }while(userSelection!="0");
}
}

