using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class EmployeeView
    {
        public void ViewEmployee()
        {
            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("            INSERT DATA TABLE   ");
            Console.WriteLine("              Herni Hartati     ");
            Console.WriteLine("-----------------------------------------------");

            var employees = new Employees();
            Console.Write("Nik             : "); var nik = Console.ReadLine(); employees.Nik = nik;
            Console.Write("First Name      : "); var fistName = Console.ReadLine(); employees.FirstName = fistName;
            Console.Write("Last name       : "); var lastName = Console.ReadLine(); employees.LastName = lastName;
            Console.Write("BirthDate       : "); var birthDate = DateTime.Parse(Console.ReadLine()); employees.BirthDate = birthDate;
            Console.Write("Gender          : "); var gender = Console.ReadLine(); employees.Gender = gender;
            Console.Write("Hiring Date     : "); var hiringDate = DateTime.Parse(Console.ReadLine()); employees.HiringDate = hiringDate;
            Console.Write("Email           : "); var email = Console.ReadLine(); employees.Email = email;
            Console.Write("Phone Number    : "); var phoneNumber = Console.ReadLine(); employees.PhoneNumber = phoneNumber;
            Console.Write("Departement Id  : "); var depatmentId = Console.ReadLine(); employees.DepartmentId = depatmentId;
        }
    }
}
