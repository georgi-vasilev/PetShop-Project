﻿using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views.SearchViews
{
    public class EmployeeSearch
    {
        public static void SearchBy()
        {
            int choice = 0;
            do
            {
                DisplayMenu();
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                Redirect(choice);
                Console.Clear();
            } while (choice != 0);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1:Name");
            Console.WriteLine("2:SSN");
            Console.WriteLine("3:Job type");
            Console.WriteLine("0:Back");
        }

        public static void Redirect(int menu)
        {
            var employee = new Employee();
            var employeeController = new EmployeeController();
            switch (menu)
            {
                case 1:
                    Console.Write("Enter name of employee: ");
                    string name = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Employee Name"));
                    Console.Write(String.Format("{0,11}|", "SSN"));
                    Console.Write(String.Format("{0,7}|", "Salary"));
                    Console.Write(String.Format("{0,9}|", "Job Type"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 51));
                    foreach (var e in employeeController.SearchByTagsEmployee(name,"",""))
                    {
                        Console.Write(String.Format("||{0,2}|", e.Id));
                        Console.Write(String.Format("{0,15}|", e.EmployeeName));
                        Console.Write(String.Format("{0,11}|", e.Ssn));
                        Console.Write(String.Format("{0,7}|", e.Salary));
                        Console.Write(String.Format("{0,9}|", e.JobType));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 51));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter SSN of employee: ");
                    string ssn = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Employee Name"));
                    Console.Write(String.Format("{0,11}|", "SSN"));
                    Console.Write(String.Format("{0,7}|", "Salary"));
                    Console.Write(String.Format("{0,9}|", "Job Type"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 51));
                    foreach (var e in employeeController.SearchByTagsEmployee("", ssn, ""))
                    {
                        Console.Write(String.Format("||{0,2}|", e.Id));
                        Console.Write(String.Format("{0,15}|", e.EmployeeName));
                        Console.Write(String.Format("{0,11}|", e.Ssn));
                        Console.Write(String.Format("{0,7}|", e.Salary));
                        Console.Write(String.Format("{0,9}|", e.JobType));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 51));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter job of employee: ");
                    string job = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Employee Name"));
                    Console.Write(String.Format("{0,11}|", "SSN"));
                    Console.Write(String.Format("{0,7}|", "Salary"));
                    Console.Write(String.Format("{0,9}|", "Job Type"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 51));
                    foreach (var e in employeeController.SearchByTagsEmployee("", "", job))
                    {
                        Console.Write(String.Format("||{0,2}|", e.Id));
                        Console.Write(String.Format("{0,15}|", e.EmployeeName));
                        Console.Write(String.Format("{0,11}|", e.Ssn));
                        Console.Write(String.Format("{0,7}|", e.Salary));
                        Console.Write(String.Format("{0,9}|", e.JobType));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 51));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
