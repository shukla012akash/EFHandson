using EntityFrameworkDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo
{
    public class CrudEmployeeManager
    {
        public ConsoleDbContext consoleDbContext;
        public CrudEmployeeManager()
        {
            consoleDbContext = new ConsoleDbContext();
        }

        public Employee GetEmplpoyeeById(int employeeId)
        {
            // Tracking not required
            var employee = consoleDbContext.Employee.Where(x => x.ID == employeeId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            return employee;
        }

        public List<Employee> GetAllEmployee()
        {
            var employee = consoleDbContext.Employee.ToList();
            return employee;
        }

        public void Insert(Employee employee)
        {
            consoleDbContext.Employee.Add(employee);
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
            var employee = consoleDbContext.Employee.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            // Entity state : Deleted
            consoleDbContext.Employee.Remove(employee);

            // This issues insert statement
            consoleDbContext.SaveChanges();
        }


    }
}
