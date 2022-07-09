using EntityFrameworkDemo;
using EntityFrameworkDemo.Entities;

public class Program
{
    public static void Main()
    {

        CrudEmployeeManager obj = new CrudEmployeeManager();
        //Console.WriteLine("Welcome To The Entity Framework Demo");
        //Console.WriteLine("Please Choose one of the following logs:");
        //Console.WriteLine("Press 1. for Employee:");
        //Console.WriteLine("Press 2. for EmployeeEducation:");
        //var employee3 = new Employee{Name = "Gopal", Address = "Gurgaon" };
        //var employee2 = new Employee { Name = "Gopal", Address = "Gurgaon" };
        //Console.WriteLine("Adding a new Employee");




        //Console.WriteLine("Updating Employee with EmployeeId 2");
        //obj.Update(2, new Employee { Name = "Modified Employee", Address = "Modified Address" });
        //PrintAllEmployee();

        //Console.WriteLine("Retrieving Employee details for EmployeeId 2");
        //var employee = obj.GetEmplpoyeeById(2);
        //Console.WriteLine($"Employee Name of employee ID 2 is {employee.Name}");

        Console.WriteLine("Deleting Employee details for EmployeeId 3");
        obj.Delete(1);
        PrintAllEmployee();

        //CrudEmployeeEducationManager objEducationManager = new CrudEmployeeEducationManager();
        //EmployeeEducation employeeEducation = new EmployeeEducation();
        //List<EmployeeEducation> EducationList = new();
        //EducationList.Add(new EmployeeEducation { CourseName = "Btech", UniversityName = "AKTU", PassingYear = 2021, MarksPercentage = 80, Employee = employee2 });
        //EducationList.Add(new EmployeeEducation { CourseName = "Btech", UniversityName = "AKTU", PassingYear = 2020, MarksPercentage = 90, Employee = employee2 });
        //objEducationManager.InsertEmployeeAndEducation(employee2, EducationList);

        ////Console.WriteLine("Updating Employee with EmployeeId 2");
        ////obj.Update(2, new EmployeeEducation { CourseName = "Modified Employee", UniversityName = "Modified Name", PassingYear = "Modified Year", MarksPercentage = "Modified Percentage" });
        ////PrintAllEmployee();

        //Console.WriteLine("Retrieving Employee details for EmployeeId 2");
        //var employee1 = obj.GetEmplpoyeeById(2);
        //Console.WriteLine($"Employee Name of employee ID 2 is {employee1.Name}");

        //Console.WriteLine("Deleting Employee details for EmployeeId 2");
        //obj.Delete(2);
        //PrintAllEmployee();

    }

    private static void PrintAllEmployee()
    {
        Console.WriteLine("Printing all Employees");
        CrudEmployeeManager obj = new CrudEmployeeManager();
        foreach (Employee employee in obj.GetAllEmployee())
        {
            Console.WriteLine($"Employee Name is {employee.Name} and address is {employee.Address}");
        }

    }
   

    private static void PrintAllEmployeeEducation()
    {
        Console.WriteLine("Printing all EmployeeEducation");
        CrudEmployeeEducationManager obj = new CrudEmployeeEducationManager();
        foreach (EmployeeEducation employee in obj.GetAllEmployeeEducation())
        {
            Console.WriteLine($"Employee Name is {employee.CourseName} and UniversityName is {employee.UniversityName}");
        }

    }

}
    

