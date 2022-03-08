using BusinessLayer_PMS;
using BusinessObject_PMS;
using ExceptionLayer_PMS;
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
            bool flag2 = true;
            while (flag2)
            {

                int i;
                Console.WriteLine("For Doctor press 1 and For Hospital Employee press 2");
                i = int.Parse(Console.ReadLine());
           
                switch (i)
                {

                    case 1:
                        Console.WriteLine("Enter User Id");
                        string c = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string pass = Console.ReadLine();
                        if (c == "Doctor21" && pass == "Password")
                        {
                            Console.WriteLine("Welcome!!");
                            ForDoctor();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect User Id or Password. \n Please try again.");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter User Id");
                        string d = Console.ReadLine();
                        Console.WriteLine("Enter Password");
                        string passw = Console.ReadLine();

                        if (d == "HEmployee" && passw == "Pass123")
                        {
                            Console.WriteLine("Employee");
                            ForHospitalEmployee();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect User Id or Password");
                            Console.ReadKey();
                        }
                        break;
                    case 3: flag2 = false;
                        break;

                    default:
                        Console.WriteLine("Enter Correct Input");

                        break;
                }
            }
           
        }
        static void ForHospitalEmployee()
        {
            bool flag1 = true;
            while (flag1)
            {
                Console.WriteLine("Press 1 to get all Patients info\nPress 2 to get Details by Id\nPress 3 to Patients info by DepartmentName\nPress 4 to Stop");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        GetallPatientsinfo();
                        break;

                    case 2:
                        GetLimitedDetailsbyid();
                        break;
                    case 3:
                        GetLimitedPatientsinfobyDepartmentName();
                        break;
                       
                    case 4:
                        flag1 = false;
                        break;

                   
                    default:
                        Console.WriteLine("Enter Correct Input");
                        break;

                }
            }
            Console.ReadLine();


        }
        
        static void ForDoctor()
        {
            try
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Press 1 to Add Patient info\nPress 2 to Delete Patients Info\nPress 3 to Get All Patients info\nPress 4 to get All Details By Patients Id\nPress 5 to Get All Details By Department Names\nPress 6 to Update Details\nPress 7 to Exit to Main menu");
                    int a = int.Parse(Console.ReadLine());
                    switch (a)
                    {

                        case 1:
                            GetAdded();
                            break;

                        case 2:
                            SaveDeleted();
                            break;

                        case 3:
                            GetAllPatientsinfo();

                            break;

                        case 4:
                            GetAllDetailsbyid();
                            break;
                        case 5:
                            GetAllPatientsinfobyDepartmentName();
                            break;

                        case 6:
                            SaveUpdated();
                            break;
                        case 7:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Enter Correct Input");
                            break;


                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
        static void GetAllDetailsbyid()
        {

            Doctor_BL bl = new Doctor_BL();
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

            Doctor_BL bl = new Doctor_BL();

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
            Doctor_BL bl = new Doctor_BL();
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
            Doctor_BL bl = new Doctor_BL();
            Patients bo = new Patients();
            Console.WriteLine("Enter Patient info");
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
            Console.WriteLine("1. A+\n2. B+\n3. A-\n4. B-\n5. AB+\n6. AB-\n7. O+\n8. O-\n");
            Console.WriteLine("Enter BloodGroupId");
            bo._BloodGroupId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter PhoneNumber");
            bo._PhoneNumber = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("10. Ortho\n11. Troma\n12. Dental\n13. Radiology Department (X-ray)\n 14. Gynecology\n15. Cardiology\n16. ENT");
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

            Doctor_BL bl = new Doctor_BL();
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

            Doctor_BL bl = new Doctor_BL();
            
           
            DataSet ds = bl.GetAllPatientsinfo();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nBirthdate=" + dr[2] + "\nGender =" + dr[3] + "\nWeight=" + dr[4] + "\nBloodGroupId=" + dr[5] + "\nPhoneNumber =" + dr[6] + "\nDepartmentId=" + dr[7] + "\nAppointmentDate=" + dr[8] + "\nDepartment Name =" + dr[10] + "\nBlood Gropu=" + dr[12]+"\n");
            }
           
        }

       

        static void GetLimitedPatientsinfobyDepartmentName()
        {

            HEmployeeBl bl = new HEmployeeBl();
            Patients bo = new Patients();
            Console.WriteLine("Enter Department Name");
            bo._DepartmentName = Console.ReadLine();

            DataSet ds = bl.GetLimitedPatientsinfobyDepartmentName(bo._DepartmentName);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("Department Name =" + dr[0] + "\nID =" + dr[1] + "\nPatient Name =" + dr[2] + "\nPhoneNumber =" + dr[3] + "\nAppointmentDate=" + dr[4] + "\n");
            }

        }
        static void GetallPatientsinfo()
        {

            HEmployeeBl bl = new HEmployeeBl();


            DataSet ds = bl.GetAllPatientinfo();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nPhoneNumber =" + dr[2] + "\nAppointmentDate=" + dr[3] + "\n");
            }

        }

        static void GetLimitedDetailsbyid()
        {

            HEmployeeBl bl = new HEmployeeBl();
            Console.WriteLine("Enter Id");
            int c = int.Parse(Console.ReadLine());

            DataSet ds = bl.GetLimiteddetailsByID(c);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("ID =" + dr[0] + "\nPatient Name=" + dr[1] + "\nPhoneNumber =" + dr[2] + "\nAppointmentDate=" + dr[3] + "\n");
            }


        }
    }

   
}

