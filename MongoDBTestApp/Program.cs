using HR;


string? Mainchoice;
do
{
    Console.WriteLine("MongoDB Operations \n");
    Console.WriteLine("1.Department Operations");
    Console.WriteLine("2.Employee Operations");
    Console.WriteLine("0.Exit \n");

    Console.WriteLine("Enter your choice");
    Mainchoice = Console.ReadLine();
    string? choice;
    switch (Mainchoice)
    {

        case "1":
            do
            {
                Console.WriteLine("\n***Department Operations***\n");
                Console.WriteLine("1.Show List of Departments");
                Console.WriteLine("2.Show Department by Name");
                Console.WriteLine("3.Insert Department");
                Console.WriteLine("4.Update Department");
                Console.WriteLine("5.Delete Department");
                Console.WriteLine("0.Exit \n");

                Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DepartmentDBManager.ShowAllDepartments();
                        break;

                    case "2":
                        DepartmentDBManager.ShowDepartmentByName();
                        break;

                    case "3":
                        DepartmentDBManager.InsertDepartment();
                        break;

                    case "4":
                        DepartmentDBManager.UpdateDepartment();
                        break;

                    case "5":
                        DepartmentDBManager.DeleteDepartment();
                        break;

                    case "0":
                        Console.WriteLine("***Exiting***");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != "0");
            break;

        case "2":
            do
            {
                Console.WriteLine("\n***Employee Operations***\n");
                Console.WriteLine("1.Show List of Employees");
                Console.WriteLine("2.Show Employee by Firstname");
                Console.WriteLine("3.Insert Employee");
                Console.WriteLine("4.Update Employee");
                Console.WriteLine("5.Delete Employee");
                Console.WriteLine("0.Exit \n");

                Console.WriteLine("Enter your choice");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EmployeeDBManager.ShowAllEmployyes();
                        break;

                    case "2":
                        EmployeeDBManager.ShowEmployeeByFirstName();
                        break;

                    case "3":
                        EmployeeDBManager.InsertEmployee();
                        break;

                    case "4":
                        EmployeeDBManager.UpdateEmployee();
                        break;

                    case "5":
                        EmployeeDBManager.DeleteEmployee();
                        break;

                    case "0":
                        Console.WriteLine("***Exiting***");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != "0");
            break;

        case "0":
            Console.WriteLine("***Exiting***");
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }

} while (Mainchoice != "0");




