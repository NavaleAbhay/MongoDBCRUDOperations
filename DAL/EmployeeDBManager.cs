using MongoDB.Bson;
using MongoDB.Driver;
using HR;

public class  EmployeeDBManager{
    protected static IMongoClient client=new MongoClient("mongodb://localhost:27017");
    protected static IMongoDatabase database=client.GetDatabase("Transflower");
    

    public static Employee GetEmployee()
    {
       
        Console.WriteLine("Enter Employee Firstname");
        string firstName=Console.ReadLine();
         Console.WriteLine("Enter Employee Lastname");
        string lastName=Console.ReadLine();
         Console.WriteLine("Enter Employee Email");
        string email=Console.ReadLine();
         Console.WriteLine("Enter Employee Address");
        string address=Console.ReadLine();
         Console.WriteLine("Enter Employee Password");
        string password=Console.ReadLine();
         Console.WriteLine("Enter Employee Manager Id");
        string managerId=Console.ReadLine();

         Employee employee=new Employee()
         {
            FirstName=firstName,
            LastName=lastName,
            Email=email,
            Address=address,
            Password=password,
            ManagerId=managerId

         };
        return employee;
    }

    public static void InsertEmployee(){
        Employee employee=GetEmployee();
        var collection=database.GetCollection<Employee>("employees");
        collection.InsertOne(employee);
    }

    public static void UpdateEmployee(string firstName,string lastName){
        //var employee=GetEmployee();
        var collection=database.GetCollection<Employee>("employees");
        var find=collection.UpdateMany
        (Builders<Employee>.Filter.Eq("FirstName",firstName),
        Builders<Employee>.Update.Set("LastName",lastName));
    }
    public static void DeleteEmployee(string deleteName){
        var collection=database.GetCollection<Employee>("employees");
        collection.DeleteOne(s => s.FirstName == deleteName);
    }
}