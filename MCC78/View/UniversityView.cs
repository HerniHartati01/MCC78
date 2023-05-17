using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class UniversityView
    {
        public void ViewUniversity()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("           UNIVERSITY TABLE (CRUD)    ");
            Console.WriteLine("               Herni Hartati     ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n1. Insert ");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("------------------------------------------");
        }
        public void getUniversityView()
        {
            var universities = new Universities();
            Console.Write("University Name : "); var UniversityName = Console.ReadLine(); universities.Name = UniversityName;
        }
    }
}
