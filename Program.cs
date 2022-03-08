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

            ForDoctor();
            

           
        }
        
        static void ForDoctor()
        {
            Console.WriteLine("Press 1 to Add Patient info\nPress 2 to Delete Patients Info\nPress 3 to Get All Patients info\nPress 4 to get All Details By Patients Id\nPress 5 to Get All Details By Department Names\nPress 6 to Update Details");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {

                case 1:
                    GetAdded(); Console.WriteLine("Press Enter to Exit");
                    break;

                case 2:
                    SaveDeleted(); Console.WriteLine("Press Enter to Exit");
                    break;

                case 3:
                    GetAllPatientsinfo();
                    Console.WriteLine("Press Enter to Exit");
                    break;

                case 4:
                    GetAllDetailsbyid(); Console.WriteLine("Press Enter to Exit");
                    break;
                case 5:
                    GetAllPatientsinfobyDepartmentName(); Console.WriteLine("Press Enter to Exit");
                    break;

                case 6:
                    SaveUpdated(); Console.WriteLine("Press Enter to Exit");
                    break;
                default:
                    Console.WriteLine("Enter Correct Input");
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
                Console.WriteLine("ID = " + dr[0] + "\nPatient Name =" + dr[1] + "\nBirthdate = " + dr[2] + "\nGender = " + dr[3] + "\nWeight = " + dr[4] + "\nBloodGroupId = " + dr[5] + "\nPhoneNumber = "+dr[6] + "\nDepartmentId = "+dr[7] + "\nAppointmentDate = " + dr[8]+ "\nDepartment Name = "+ dr[10] + "\nBlood Group= "+ dr[12]+"\n");
                
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
            {
                Console.WriteLine("Failed");
                Console.ReadLine();
            }
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
            {
                Console.WriteLine("Failed");
                Console.ReadLine();
            }
        }


        static void GetAdded()
        { 
            PMS_BL bl = new PMS_BL();
            Patients bo = new Patients();
            Console.WriteLine("Enter Patient info as Id,PatientName,Birthdate,Gender,Weight,BloodGroupId,PhoneNumber,DepartmentId,AppointmentDate");
            Console.WriteLine("Enter ID");
            bo._Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PatientName ");
            bo._PatientName = Console.ReadLine();
            Console.WriteLine("Enter Birthdate");
            bo._Birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Gender");
            bo._Gender = char.Parse(Console.ReadLine());
            Console.WriteLine("Weight");
            bo._Weight = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter BloodGroupId");
            bo._BloodGroupId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            bo._PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter DepartmentId");
            bo._DepartmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("AppointmentDate");
            bo._AppointmentDate = DateTime.Parse(Console.ReadLine());

           
            int h =bl.SaveAddedDetails(bo);
            if (h != 0)
                Console.WriteLine("Added Successfully");
            else
            {
                Console.WriteLine("Failed");
                Console.ReadLine();
            }
        }

        static void GetAllPatientsinfobyDepartmentName()
        {

            PMS_BL bl = new PMS_BL();
            Patients bo = new Patients();
            Console.WriteLine("Enter Department Name");
            bo._DepartmentName = Console.ReadLine();

            DataSet ds = bl.GetAllPatientsinfobyDepartmentName(bo._DepartmentName);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nBirthdate=" + dr[2] + "\nGender =" + dr[3] + "\nWeight=" + dr[4] + "\nBloodGroupId=" + dr[5] + "\nPhoneNumber =" + dr[6] + "\nDepartmentId=" + dr[7] + "\nAppointmentDate=" + dr[8] + "\nDepartment Name =" + dr[10] + "\nBlood Gropu=" + dr[12]);
            }

        }

        static void GetAllPatientsinfo()
        {

            PMS_BL bl = new PMS_BL();
            
           
            DataSet ds = bl.GetAllPatientsinfo();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nBirthdate=" + dr[2] + "\nGender =" + dr[3] + "\nWeight=" + dr[4] + "\nBloodGroupId=" + dr[5] + "\nPhoneNumber =" + dr[6] + "\nDepartmentId=" + dr[7] + "\nAppointmentDate=" + dr[8] + "\nDepartment Name =" + dr[10] + "\nBlood Gropu=" + dr[12]);
            }
            Console.WriteLine();
        }
    }

    
}

