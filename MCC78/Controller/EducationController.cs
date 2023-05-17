using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Controller
{
    public class EducationController
    {
        public void Insert()
        {
            var education = new Educations();
            var results = education.InsertEducations(education);
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
            var education = new Educations();
            var results = education.UpdateEducations(education);
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
            var education = new Educations();
            var results = education.DeleteEducations(education);
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
