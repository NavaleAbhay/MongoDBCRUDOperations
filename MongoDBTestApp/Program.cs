using HR;
using System;
// EmployeeDBManager.InsertEmployee();
Console.WriteLine("Enter Firstname");
string firstName=Console.ReadLine();
// Console.WriteLine("Enter Lastname");
// string lasttName=Console.ReadLine();
// EmployeeDBManager.UpdateEmployee(firstName,lasttName);
//DepartmentMongodbCRUDTest.CRUDwithMongoDb();

EmployeeDBManager.DeleteEmployee(firstName);
