using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC78.Model;

namespace MCC78.Controller
{
    public class UniversityController
    {
        public void Insert()
        {
            var university = new Universities();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("         Insert New University     ");
            Console.Write("University Name : ");
            var name = Console.ReadLine();
            university.Name = name;


            var results = university.InsertUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Insert success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
            }
        }

        public void Update()
        {
            var university = new Universities();
            university.UpdateUniversity(university);
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("       Update University    ");
            Console.Write("University Id   : ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("University Name : ");
            var name = Console.ReadLine();

            university.Name = name;
            university.Id = id;

            var results = university.UpdateUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Update success");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
        }

        public void Delete()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("   Delete University By Id     ");
            Console.Write("University Id   : ");
            var id = Convert.ToInt32(Console.ReadLine());
            var university = new Universities();
            university.Id = id;

            var results = university.DeleteUniversity(university);
            if (results > 0)
            {
                Console.WriteLine("Delete success");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }

    }
}
