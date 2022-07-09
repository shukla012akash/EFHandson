using EntityFrameworkDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class CrudEmployeeEducationManager
    {
        public ConsoleDbContext consoleDbContext;
        public CrudEmployeeEducationManager()
        {
            consoleDbContext = new ConsoleDbContext();
        }

        public EmployeeEducation GetEmplpoyeeById(int employeeId)
        {
            // Tracking not required
            var employee = consoleDbContext.EmployeeEducation.Where(x => x.ID == employeeId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            return employee;
        }

        public List<EmployeeEducation> GetAllEmployeeEducation()
        {
            var employee = consoleDbContext.EmployeeEducation.ToList();
            return employee;
        }

        public void Insert(Employee employee)
        {
            consoleDbContext.Employee.Add(employee);
            consoleDbContext.SaveChanges();
        }
        public void InsertEmployeeAndEducation(Employee employee, List<EmployeeEducation> educationList)
        {
            var objEmployee = new Employee
            {
                Name = employee.Name,
                Address = employee.Address,
                EducationList = educationList

            };

            consoleDbContext.Employee.Add(objEmployee);
            consoleDbContext.SaveChanges();
        }
        public void Update(int employeeId, Employee modifiedEmployee)
        {
            var employee = consoleDbContext.Employee.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            employee.Name = modifiedEmployee.Name;
            employee.Address = modifiedEmployee.Address;

            // Entity state : Modified
            consoleDbContext.Employee.Update(employee);

            // This issues insert statement
            consoleDbContext.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = consoleDbContext.EmployeeEducation.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            // Entity state : Deleted
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<EmployeeEducation> entityEntry = consoleDbContext.EmployeeEducation.Remove(employee);

            // This issues insert statement
            consoleDbContext.SaveChanges();
        }
    }
}
