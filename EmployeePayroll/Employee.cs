using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class Employee
    {
         private static int s_employeeId = 1000;

        public string EmployeeId { get; }
        public string EmployeeName { get; set; }
        public string Role {get; set;}
        public WorkLocation Location { get; set; }
        public string TeamName { get; set; }
        public DateTime DOJ {get; set;}
        public GenderDetails Gender {get; set;}
        
        // public int NoOfWorkingDays {get; set;}
        // public int NoOfLeaveTaken {get;set;}
        public int Salary =0 ;


        public Employee(string employeeName, string role, WorkLocation location, string teamName , DateTime doj , GenderDetails gender)
        {
            s_employeeId++;
           EmployeeId = "SF" + s_employeeId;
            EmployeeName = employeeName;
            Role = role;
            Location = location;
            TeamName = teamName;
            DOJ = doj;
            Gender = gender;
           
        }

        public Employee()
        {

        }

        public void SalaryCalculation(int NoOfWorkingDays, int NoOfLeaveTaken)
        {
            int accountable = NoOfWorkingDays - NoOfLeaveTaken;
            Salary += accountable*500 ;
            
        }

        

    }
}