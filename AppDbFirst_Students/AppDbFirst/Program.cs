using AppDbFirst.Models;
using System;
using System.Linq;
using System.Text;

namespace AppDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext() ;

            // var result = AllEmployeesNames (contex) ;

            // var result = EmployeeInfo(contex);

            // var result = AllEmployees(contex);

            // var result = GetEmployeesWithFirstNameStartWithN(contex);

            // var result =  GetEmployeesFromClassicVest(contex);

            //  AddNewProject(contex);

            // var result = GetEmployeesFromEngineering(context);

            // var result = GetEmployeesAsMarketingSpecialist(context);

            // AddTown(context);

           

            var result = GetEmployeesByProjects(context);
        
            Console.WriteLine(result);
        }

        private static object AllEmployees(SoftUniContext contex)
        {
           var employees = contex . Employees 
                .Select ( x => new
                {
                   x.EmployeeId ,
                   x.FirstName,
                   x.MiddleName,
                   x.LastName ,
                   x.Salary,
                   x.JobTitle,
                   
                } 
                ).OrderBy(x => x.EmployeeId)
            .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees )
            {
                sb.AppendLine($"{employee.FirstName},{employee.LastName  },{employee .MiddleName },{employee.JobTitle }, {employee.Salary:F2}");
            }

            var result = sb.ToString ().TrimEnd();
            return result;
        }

        private static string EmployeeInfo(SoftUniContext contex)
        {
            var listOfEmployees = contex.Employees.Select(x => new
            {
                x.Salary,
                x.FirstName,
                x.JobTitle ,
                x.DepartmentId ,
            }

           ).OrderByDescending(x => x.Salary)
            .ToList();

            var sb = new StringBuilder();
            foreach (var employee in listOfEmployees)
            {
                sb.AppendLine($"{employee.Salary},{employee.FirstName },{employee. JobTitle }, {employee.DepartmentId }");
            }

            return sb.ToString().TrimEnd();
        }

        private static string AllEmployeesNames(SoftUniContext contex)
        {
            var listOfEmployees = contex.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
            }

           ).OrderBy (x=>x.EmployeeId )
            .ToList();

            var sb = new StringBuilder();
            foreach (var employee in listOfEmployees)
            {
                sb.AppendLine($"{employee.EmployeeId},{employee.FirstName },{employee.LastName }, {employee.MiddleName }");
            }

            return sb.ToString().TrimEnd(); 
        }
    
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context )
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 50000).ToList();
            var sb = new StringBuilder();
            foreach(var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    
   
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context .Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary,
                    DepartmentName = x.Department.Name,
                })

                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName } from{employee.DepartmentName } -$ {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
   
        public static int EmployeesCount(SoftUniContext contex)
        {
            var count = contex.Employees.Count();
            return count;

        }
    
        public static string GetEmployeesWithFirstNameStartWithN(SoftUniContext contex)
        {


            var employees = contex.Employees
                
                .Select(x => new
                {
                    FirstName=  x.FirstName,
                   

                })
                .Where(x => x.FirstName.StartsWith("N"))

                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName}");
            }

            var result = sb.ToString().TrimEnd();
            return result ;

        }
   
        public static string GetEmployeesFromClassicVest(SoftUniContext contex)
        {
            var employeesProject = contex.EmployeesProjects
               .OrderBy(x => x.ProjectId)
           .Select(x => new {
               
              employeeName = x.Employee.FirstName + " " + x.Employee.LastName ,
              projectName = x.Project.Name


             } )
            .Where(x => x.projectName == "Classic Vest")
            .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employeesProject)
            {
               sb.AppendLine($"{employee.employeeName} {employee.projectName }") ;
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static void AddNewProject(SoftUniContext context)
        {
            var project = new Project()
            {
                Name = "JudgeSystem",
                StartDate = DateTime.UtcNow
            };

            context.Projects.Add(project);
            context.SaveChanges();
        }
         
        public static string GetEmployeesFromEngineering(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.Department.Name == "Engineering")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                    DepartmentName = x.Department.Name,
                })

                .OrderBy(x => x.FirstName)
              
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName } from{employee.JobTitle } -$ {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    
        public static string GetEmployeesAsMarketingSpecialist(SoftUniContext context)
        {
            var employees = context.Employees
               .Where(x => x.JobTitle == "Marketing Specialist")
               .OrderBy(x => x.Department.Employees.Count)
               .Select(x => new
               {
                   x.FirstName,
                   x.LastName,
                   x.JobTitle,
                   x.Address.AddressText,
                   DepartmentName = x.Department.Name,
               })

               
               .Take(3)
               .ToList();



            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($" {employee.FirstName} {employee.LastName} - {employee.AddressText } - {employee.LastName } - {employee.JobTitle } - {employee . DepartmentName }");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    
        public static void AddTown(SoftUniContext context)
        {
            var town = new Town()
        {
            Name = "Zagora",
               
        };
      

        context.Towns.Add(town);
        context.SaveChanges();
        }
   
        public static string GetEmployeesByProjects(SoftUniContext context)
        {
            var employees = context.EmployeesProjects 
                
               .Where(x => x.Project.Name  == "Classic Vest" || x.Project.Name == "Sport-100")
               .Select(x => new
               {
                   x.ProjectId,
                   x.Employee.FirstName,
                   x.Employee.LastName,
                   x.Employee.Salary,

               })

               .OrderBy(x => x.Salary )

               .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName } {employee.ProjectId} {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
     
    }

}
