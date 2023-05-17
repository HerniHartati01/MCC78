using MCC78.Controller;
using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class MenuView
    {
        public void MenuTampilan()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("               CRUD TABLE     ");
            Console.WriteLine("              Herni Hartati     ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\n1. Insert data");
            Console.WriteLine("2. University table (CRUD)");
            Console.WriteLine("3. Education table (CRUD)");
            Console.WriteLine("4. LINQ ");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------------------------------");
            Console.Write("Pilih Angka (Menu) : "); string pilihan = Console.ReadLine();
            switch (pilihan)
            {
                case "1":
                    /*Employee*/
                    var employees = new Employees();
                    EmployeeView employeeView = new();
                    employeeView.ViewEmployee();
                    employees.InsertDataEmployee(employees);

                    /*University*/
                    var universities = new Universities();
                    UniversityView universityView = new();
                    universityView.getUniversityView();
                    universities.InsertUniversity(universities);

                    /*Education*/
                    var educations = new Educations();
                    EducationView educationView1 = new();
                    educationView1.getEducationView();
                    educations.UniversityId = educations.GetUnivEduId(1);
                    educations.InsertEducations(educations);

                    //Profiling
                    var profilings = new Profilings();
                    var educationGet = new Educations();
                    profilings.EmployeeId = Profilings.GetEmpId(employees.Nik);
                    profilings.EducationId = educationGet.GetUnivEduId(2);
                    ProfilingController profilingController = new();
                    profilingController.Get();
                    Console.WriteLine("-----------------------------------------------");
                    break;
                case "2":
                    UniversityView universityView1 = new();
                    universityView1.ViewUniversity();
                    Console.Write("Pilih Menu : "); string PilihanCrudUniversity = Console.ReadLine();
                    UniversityController controller = new();
                    switch (PilihanCrudUniversity)
                    {
                        case "1":
                            controller.Insert();
                            break;
                        case "2":
                            controller.Update();
                            break;
                        case "3":
                            controller.Delete();
                            break;
                            ;
                    }

                    break;
                case "3":
                    EducationView educationView2 = new();
                    educationView2.ViewEducation();
                    Console.Write("Pilih Menu : "); string PilihanCrudEducation = Console.ReadLine();
                    EducationController educationController = new();
                    EducationView educationView = new();
                    switch (PilihanCrudEducation)
                    {
                        case "1":
                            educationView.ViewInsertEducation();
                            educationController.Insert();
                            break;
                        case "2":
                            educationView.ViewUpdateEducation();
                            educationController.Update();
                            break;
                        case "3":
                            educationView.ViewDeleteEducation();
                            educationController.Delete();
                            break;
                    }

                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("\"=====================================================");
                    Console.WriteLine("                         LINQ     ");
                    Console.WriteLine("-------------------------------------------------------");
                    EmployeeController employeeController = new();
                    employeeController.GetAllData();
                    break;

                case "5":
                    Console.WriteLine("==========================================");
                    Console.WriteLine("                THANK YOU     ");
                    Console.WriteLine("------------------------------------------");
                    break;

            }
        }
        
    }
}
