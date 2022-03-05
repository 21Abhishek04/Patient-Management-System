using BusinessLayer_PMS;
using BusinessObject_PMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Patients bo = new Patients();
            Console.WriteLine("Enter Patient info as Id,PatientName,Birthdate,Gender,Weight,BloodGroupId,PhoneNumber,DepartmentId,AppointmentDate,BloodGroup,DeptName");
            bo._Id = int.Parse(Console.ReadLine());
            //bo._PatientName = Console.ReadLine();
            //bo._Birthdate = DateTime.Parse(Console.ReadLine());
            //bo._Gender = char.Parse(Console.ReadLine());
            //bo._Weight = float.Parse(Console.ReadLine());
            //bo._BloodGroupId = int.Parse(Console.ReadLine());
            //bo._PhoneNumber = Convert.ToInt64(Console.ReadLine());
            //bo._DepartmentId = int.Parse(Console.ReadLine());
            //bo._AppointmentDate = DateTime.Parse(Console.ReadLine());



            BLPMS pbl = new BLPMS();
            int h = pbl.SaveDetails(bo);
            if (h != 0)
                Console.WriteLine("Successfully");
            else
                Console.WriteLine("Failed");

            Console.ReadLine();



        }
    }
}
