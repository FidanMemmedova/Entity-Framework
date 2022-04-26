using ConsoleApp1.DataAccess;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.EmployeeController
{
    public class EmpController
    {
        public readonly AppDBContext _context;
        public EmpController()
        {
            _context = new AppDBContext();
        }
        public void GetEmployeebyId(int id)
        {
            Employee emp = _context.employees.Find(id);
            if (emp == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine(emp.Fullname);
            }
        }

        public void GetAllEmployees()
        {
            List<Employee> employees = _context.employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.Fullname);
            }
        }

        public void AddEmployee(string fullname)
        {
            try
            {
                Employee emp = new Employee { Fullname = fullname };
                _context.employees.Add(emp);
                _context.SaveChanges();
                Console.WriteLine("Employee is created.");
            }
            catch (Exception)
            {
                Console.WriteLine("Some problems exists");
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = _context.employees.Find(id);
            if (emp == null)
            {
                Console.WriteLine("Not Found");
            }
            _context.employees.Remove(emp);
            _context.SaveChanges();
            Console.WriteLine("Employee is deleted.");
        }

        public void FilterByName(string str)
        {
            List<Employee> emplist = _context.employees.ToList();
            string a = str.ToUpper();
            string b = str.ToLower();
            try
            {
                foreach (var item in emplist)
                {
                    if (item.Fullname.Contains(a) || item.Fullname.Contains(b))
                    {
                        Console.WriteLine(item.Fullname);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Not Found");
            }
            
        }



    }
}
