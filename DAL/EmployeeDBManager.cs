using HR;
using MongoDB.Bson;
using MongoDB.Driver;

public class EmployeeDBManager
{
    private static IMongoClient client;
    private static IMongoDatabase database;
    private static IMongoCollection<Employee> collection;
    static EmployeeDBManager()
    {
        client = new MongoClient("mongodb://localhost:27017");
        database = client.GetDatabase("Transflower");
        collection = database.GetCollection<Employee>("employees");
    }

    public static Employee GetEmployee()
    {

        Console.WriteLine("Enter Employee Firstname");
        string? firstName = Console.ReadLine();
        Console.WriteLine("Enter Employee Lastname");
        string? lastName = Console.ReadLine();
        Console.WriteLine("Enter Employee Email");
        string? email = Console.ReadLine();
        Console.WriteLine("Enter Employee Address");
        string? address = Console.ReadLine();
        Console.WriteLine("Enter Employee Password");
        string? password = Console.ReadLine();

        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Address = address,
            Password = password
        };
        return employee;
    }

    public static Employee ValidateEmployee()
    {
        Console.WriteLine("Enter Employee Firstname");
        string? firstName = Console.ReadLine();
        Console.WriteLine("Enter Employee Lastname");
        string? lastName = Console.ReadLine();
        Employee employee = new Employee()
        {
            FirstName = firstName,
            LastName = lastName,
        };
        return employee;
    }

    public static void ShowAllEmployyes()
    {
        var all = collection.Find(new BsonDocument());
        Console.WriteLine();

        foreach (var employee in all.ToEnumerable())
        {
            Console.WriteLine(employee._id + "\t" + employee.FirstName + "\t"
                             + employee.LastName + "\t" + employee.Email + "\t"
                             + employee.Password + "\t" + employee.Address);
        }
    }

    public static void ShowEmployeeByFirstName()
    {
        Console.WriteLine("Enter Employee FirstName whose Details to be shown");
        string? name = Console.ReadLine();
        var all = collection.Find(Builders<Employee>.Filter.Eq("FirstName", name));
        Console.WriteLine();
        foreach (var employee in all.ToEnumerable())
        {
            Console.WriteLine(employee._id + "\t" + employee.FirstName + "\t"
                             + employee.LastName + "\t" + employee.Email + "\t"
                             + employee.Password + "\t" + employee.Address);
        }
    }

    public static void InsertEmployee()
    {
        collection.InsertOne(GetEmployee());
    }

    public static void UpdateEmployee()
    {
        Console.WriteLine("Enter Firstname and lastname of Employee Update");
        Employee emp = ValidateEmployee();
        var filter = Builders<Employee>.Filter.Eq("FirstName", emp.FirstName) &
                    Builders<Employee>.Filter.Eq("LastName", emp.LastName);

        Console.WriteLine(" Now Enter  Employee Information to Update");
        Employee employee = GetEmployee();
        var update = Builders<Employee>.Update.
                       Set("FirstName", employee.FirstName).
                       Set("LastName", employee.LastName).
                       Set("Email", employee.Email).
                       Set("Address", employee.Address).
                       Set("Password", employee.Password);

        var result = collection.UpdateMany(filter, update);
    }
    public static void DeleteEmployee()
    {
        Console.WriteLine("Please Enter Details of Employee to Delete : ");
        Employee employee = ValidateEmployee();

        var filter = Builders<Employee>.Filter.Eq("FirstName", employee.FirstName) &
                    Builders<Employee>.Filter.Eq("LastName", employee.LastName);

        var result = collection.DeleteMany(filter);

    }
}