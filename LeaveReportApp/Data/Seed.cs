using LeaveReportApp.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace LeaveReportApp.Data
{
    public class Seed    //Seeds data to all the tables
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("SeedData method is being executed.");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LeaveReportDbContext>();

                //if db is empty, fill tables
                context.Database.Migrate();

                ////Makes sure the tables are filled in the right order, due to their relationship keys
                SeedEmployees(context);
                SeedLeaveReports(context);
            }
        }

        //method to seed Employees to database
        private static void SeedEmployees(LeaveReportDbContext context)
        {
            //adds the employees only if the table is empty
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(new List<Employee>()
                {
                new Employee() { FirstName = "Anne", LastName = "Roberts", Roles= Enum.Role.Principal },
                new Employee() { FirstName = "Kimberlin", LastName = "Anderson", Roles=Enum.Role.Administrator },
                new Employee() { FirstName = "Emily", LastName = "Davis", Roles=Enum.Role.SubjectTeacher },
                new Employee() { FirstName = "Lucas", LastName = "Brown", Roles=Enum.Role.SubjectTeacher },
                new Employee() { FirstName = "Michael", LastName = "Jonson", Roles=Enum.Role.SubjectTeacher },
                new Employee() { FirstName = "Thomas", LastName = "Erikson", Roles=Enum.Role.SchoolNurse },
                new Employee() { FirstName = "Peter", LastName = "Harris", Roles=Enum.Role.Caretaker },
                new Employee() { FirstName = "Jhon", LastName = "Wilson", Roles=Enum.Role.SpecialEducationTeacher },
                new Employee() { FirstName = "Jessica", LastName = "Miller", Roles=Enum.Role.SubstituteTeacher },
            });
                context.SaveChanges();
            }
        }
        //method to seed leave reports to database
        private static void SeedLeaveReports(LeaveReportDbContext context)
        {
            if (!context.LeaveReports.Any())
            {
                var employee = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Anne"));
                var employee2 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Kimberlin"));
                var employee3 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Emily"));
                var employee4 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Lucas"));                   
                var employee5 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Michael"));
                var employee6 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Thomas"));
                var employee7 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Peter"));
                var employee8 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Jhon"));
                var employee9 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Jessica"));

                context.LeaveReports.AddRange(new List<LeaveReport>()
            {
                new LeaveReport() { StartDate = DateTime.Parse("2024-06-11"), EndDate = DateTime.Parse("2024-07-11"), LeaveReportDate= DateTime.Parse("2024-03-20"), LeaveType= Enum.LeaveType.Vacation, FkEmployeeId =employee.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-04-20"), EndDate = DateTime.Parse("2024-04-20"), LeaveReportDate= DateTime.Parse("2024-04-19"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-07-15"), EndDate = DateTime.Parse("2024-08-20"), LeaveReportDate= DateTime.Parse("2024-03-22"), LeaveType= Enum.LeaveType.Vacation, FkEmployeeId =employee2.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-01-20"), EndDate = DateTime.Parse("2024-01-22"), LeaveReportDate= DateTime.Parse("2024-01-20"), LeaveType= Enum.LeaveType.VAB, FkEmployeeId =employee3.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-05-01"), EndDate = DateTime.Parse("2024-01-05"), LeaveReportDate= DateTime.Parse("2023-02-01"), LeaveType= Enum.LeaveType.PerentalLeave, FkEmployeeId =employee3.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-12-20"), EndDate = DateTime.Parse("2024-01-28"), LeaveReportDate= DateTime.Parse("2023-06-02"), LeaveType= Enum.LeaveType.Vacation, FkEmployeeId =employee4.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-09-20"), EndDate = DateTime.Parse("2023-09-20"), LeaveReportDate= DateTime.Parse("2023-09-20"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee4.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-03-28"), EndDate = DateTime.Parse("2024-04-15"), LeaveReportDate= DateTime.Parse("2024-01-23"), LeaveType= Enum.LeaveType.Vacation, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-10-05"), EndDate = DateTime.Parse("2023-10-07"), LeaveReportDate= DateTime.Parse("2023-10-05"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-11-05"), EndDate = DateTime.Parse("2023-11-07"), LeaveReportDate= DateTime.Parse("2023-11-05"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-08-20"), EndDate = DateTime.Parse("2023-08-25"), LeaveReportDate= DateTime.Parse("2023-08-25"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee6.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-05-02"), EndDate = DateTime.Parse("2023-05-04"), LeaveReportDate= DateTime.Parse("2023-05-05"), LeaveType= Enum.LeaveType.VAB, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-05-05"), EndDate = DateTime.Parse("2025-08-07"), LeaveReportDate= DateTime.Parse("2024-02-28"), LeaveType= Enum.LeaveType.PerentalLeave, FkEmployeeId =employee7.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-04-17"), EndDate = DateTime.Parse("2024-05-07"), LeaveReportDate= DateTime.Parse("2024-02-15"), LeaveType= Enum.LeaveType.PerentalLeave, FkEmployeeId =employee8.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-10-04"), EndDate = DateTime.Parse("2023-10-04"), LeaveReportDate= DateTime.Parse("2023-10-04"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-02-05"), EndDate = DateTime.Parse("2024-02-05"), LeaveReportDate= DateTime.Parse("2024-02-05"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-11-24"), EndDate = DateTime.Parse("2023-11-24"), LeaveReportDate= DateTime.Parse("2023-11-24"), LeaveType= Enum.LeaveType.Sick, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-06-05"), EndDate = DateTime.Parse("2023-07-07"), LeaveReportDate= DateTime.Parse("2023-03-11"), LeaveType= Enum.LeaveType.Vacation, FkEmployeeId =employee5.EmpId },
            });
                context.SaveChanges();
            }
        }
    }
}

