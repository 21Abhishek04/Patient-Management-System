using BusinessLayer_PMS;
using BusinessObject_PMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            Console.WriteLine("Press 1 to Add Patient\nPress 2 to Delete Patients Info\nPress 3 to Get All Patients info\n Press 4 to get All Details By Patients Id\nPress 5 to Get All Details By Department Names\nPress 6 to Update Details");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
               
                case 1:GetAdded();
                    break;
                case 2: SaveDeleted();
                    break;
                case 3:Console.WriteLine();
                    break;

                case 4:  GetAllDetailsbyid();
                    break;
                case 5:
                    Console.WriteLine("WIP");
                    break;
                case 6:
                    SaveUpdated();
                    break;

            }
            Console.ReadLine();
        }

        static void GetAllDetailsbyid()
        {

            PMS_BL bl = new PMS_BL();
            Console.WriteLine("Enter Id");
            int c = int.Parse(Console.ReadLine());

            DataSet ds = bl.GetAlldetailsByID(c);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nBirthdate=" + dr[2] + "\nGender =" + dr[3] + "\nWeight=" + dr[4] + "\nBloodGroupId=" + dr[5] + "\nPhoneNumber =" + dr[6] + "\nDepartmentId=" + dr[7] + "\nAppointmentDate=" + dr[8]+ "\nDepartment Name =" + dr[10] + "\nBlood Gropu=" + dr[12]);
            }

        }
       
        static void SaveDeleted()
        {

            PMS_BL bl = new PMS_BL();

            Console.WriteLine("Enter Id");
            int c = int.Parse(Console.ReadLine());
            int h=bl.SavedeletedDetails(c);
            if (h != 0)
                Console.WriteLine(" Deleted Successfully");
            else
                Console.WriteLine("Failed");

            Console.ReadLine();
        }


        static void SaveUpdated()
        {
           

            PMS_BL bl = new PMS_BL();

            Console.WriteLine("Enter Id");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Weight");
            float d = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long e = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Appointment Date");
            DateTime g= DateTime.Parse(Console.ReadLine());
           


            int h =bl.UpdatedDetails(c,d,e,f,g);

            if (h != 0)
                Console.WriteLine(" Updated Successfully");
            else
                Console.WriteLine("Failed");

            Console.ReadLine();
        }


        static void GetAdded()
        { 
            PMS_BL bl = new PMS_BL();
            Patients bo = new Patients();
            Console.WriteLine("Enter Patient info as Id,PatientName,Birthdate,Gender,Weight,BloodGroupId,PhoneNumber,DepartmentId,AppointmentDate,BloodGroup,DeptName");
             bo._Id = int.Parse(Console.ReadLine());
             bo._PatientName = Console.ReadLine();
            bo._Birthdate = DateTime.Parse(Console.ReadLine());
            
            bo._Gender = char.Parse(Console.ReadLine());
            bo._Weight = float.Parse(Console.ReadLine());
            bo._BloodGroupId = int.Parse(Console.ReadLine());
            bo._PhoneNumber = Convert.ToInt64(Console.ReadLine());
            bo._DepartmentId = int.Parse(Console.ReadLine());
            bo._AppointmentDate = DateTime.Parse(Console.ReadLine());

           
            int h =bl.SaveAddedDetails(bo);
            if (h != 0)
                Console.WriteLine("Added Successfully");
            else
                Console.WriteLine("Failed");

            Console.ReadLine();
        }

    }

    
}

