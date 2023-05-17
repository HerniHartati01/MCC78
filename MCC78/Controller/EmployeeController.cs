using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC78.Model;

namespace MCC78.Controller
{
    public class EmployeeController
    {
        private Employees employees = new();
        public void GetAllData()
        {
            //Get All Employee
            var emply = new Employees();
            var univ = new Universities();
            var edu = new Educations();
            var profil = new Profilings();


            var eduGetAll = edu.GetEducation();
            var empGetAll = emply.GetEmployees();
            var univGetAll = univ.GetUniversities();
            var profilGetAll = profil.GetProfilings();  
           

            var getData =
                from y in empGetAll
                join p in profilGetAll on y.Id equals p.EmployeeId
                join ed in eduGetAll on p.EducationId equals ed.Id
                join unv in univGetAll on ed.UniversityId equals unv.Id
                select new
                {
                    y.Nik,
                    Fullname = y.FirstName + " " + y.LastName,
                    y.BirthDate,
                    y.Gender,
                    y.HiringDate,
                    y.Email,
                    y.PhoneNumber,
                    ed.Major,
                    ed.Degree,
                    ed.Gpa,
                    unv.Name
                };
            foreach (var emp in getData)
            {
                Console.WriteLine("Nik             : " + emp.Nik);
                Console.WriteLine("First Name      : " + emp.Fullname);
                Console.WriteLine("BirthDate       : " + emp.BirthDate);
                Console.WriteLine("Gender          : " + emp.Gender);
                Console.WriteLine("Hiring Date     : " + emp.HiringDate);
                Console.WriteLine("Email           : " + emp.Email);
                Console.WriteLine("Phone Number    : " + emp.PhoneNumber);
                Console.WriteLine("Major           : " + emp.Major);
                Console.WriteLine("Degree          : " + emp.Degree);
                Console.WriteLine("Gpa             : " + emp.Gpa);
                Console.WriteLine("University Name : " + emp.Name);
                Console.WriteLine("=====================================================");
            }
        }
    }
}
