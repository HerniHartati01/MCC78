using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class EducationView
    {
        public void ViewInsertEducation()
        {
            var education = new Educations();
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("         Insert New Educations     ");
            Console.Write("Major        : ");
            var major = Console.ReadLine();
            education.Major = major;
            Console.Write("Degree       : ");
            var degree = Console.ReadLine();
            education.Degree = degree;
            Console.Write("Gpa          : ");
            var gpa = Console.ReadLine();
            education.Gpa = gpa;
            Console.Write("University Id: ");
            var universityId = Convert.ToInt32(Console.ReadLine());
            education.UniversityId = universityId;
        }

        public void ViewUpdateEducation()
        {
            var education = new Educations();
            education.UpdateEducations(education);
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("       Update Educations    ");
            Console.Write("Education Id : ");
            var id = Convert.ToInt32(Console.ReadLine()); education.Id = id;
            Console.Write("Major        : ");
            var major = Console.ReadLine(); education.Major = major;
            Console.Write("Degree       : ");
            var degree = Console.ReadLine(); education.Degree = degree;
            Console.Write("Gpa          : ");
            var gpa = Console.ReadLine(); education.Gpa = gpa;
            Console.Write("University Id: ");
            var universityId = Convert.ToInt32(Console.ReadLine()); education.UniversityId = universityId;

        }

        public void ViewDeleteEducation()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("     Delete Educations By Id     ");
            Console.Write("Education Id   : ");
            var id = Convert.ToInt32(Console.ReadLine());
            var education = new Educations();
            education.Id = id;

        }

        public void getEducationView()
        {
            var educations = new Educations();
            Console.Write("Major           : "); var majorE = Console.ReadLine(); educations.Major = majorE;
            Console.Write("Degree          : "); var degreeE = Console.ReadLine(); educations.Degree = degreeE;
            Console.Write("GPA             : "); var gpaE = Console.ReadLine(); educations.Gpa = gpaE;
        }

        public void ViewEducation()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("           EDUCATION TABLE (CRUD)    ");
            Console.WriteLine("              Herni Hartati     ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n1. Insert ");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("------------------------------------------");
        }
    }
}
