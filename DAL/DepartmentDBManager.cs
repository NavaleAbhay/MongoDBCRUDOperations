
using MongoDB.Bson;
using MongoDB.Driver;
namespace HR;

public class DepartmentDBManager
{
    private static IMongoClient client;
    private static IMongoDatabase database;
    private static IMongoCollection<Department> collection;
    static DepartmentDBManager()
    {
        client = new MongoClient("mongodb://localhost:27017");
        database = client.GetDatabase("Transflower");
        collection = database.GetCollection<Department>("departments");
    }
    public static Department GetDepartment()
    {
        Console.WriteLine("Enter name of department:");
        string? name = Console.ReadLine();
        Console.WriteLine("Enter location of department:");
        string? location = Console.ReadLine();

        Department department = new Department()
        {
            Name = name,
            Location = location
        };
        return department;
    }
     public static void ShowAllDepartments()
    {
        var all = collection.Find(new BsonDocument());
        Console.WriteLine();

        foreach (var i in all.ToEnumerable())
        {
            Console.WriteLine(i._id + "\t" + i.Name + "\t" + i.Location);
        }
    }

    public static void ShowDepartmentByName()
    {
        Console.WriteLine("Enter Department Name whose Details to be shown");
        string? name = Console.ReadLine();
        var dept = collection.Find(Builders<Department>.Filter.Eq("Name", name));
        Console.WriteLine();

        foreach (var i in dept.ToEnumerable())
        {
            Console.WriteLine(i._id + "\t" + i.Name + "\t" + i.Location);
        }
    }
   
    public static void InsertDepartment()
    {
        collection.InsertOne(GetDepartment());
    }

    public static void UpdateDepartment()
    {
        Console.WriteLine("Enter Existing Department Information to Update");
        Department obj1 = GetDepartment();
        var filter = Builders<Department>.Filter.Eq("Name", obj1.Name) &
                    Builders<Department>.Filter.Eq("Location", obj1.Location);

        Console.WriteLine("Enter new Department Information");
        Department obj2 = GetDepartment();

        //UpdateDefinition<Department>?
        var update = Builders<Department>.Update.Set("Name", obj2.Name)
                    .Set("Location", obj2.Location);

        var result = collection.UpdateMany(filter, update);

    }

    public static void DeleteDepartment()
    {
        Console.WriteLine("Please Enter Details of Department to Delete : ");
        var obj1 = GetDepartment();
        var deletefilter = Builders<Department>.Filter.Eq("Name", obj1.Name) &
                           Builders<Department>.Filter.Eq("Location", obj1.Location);

        var result=collection.DeleteMany(deletefilter);
    }
}

