using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.Utilities
{
    public class General
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
    public class TestCaseStatusObj
    {
        public bool status { get; set; }
        public string Links { get; set; }
        public string Links1 { get; set; }
    }
    public class FileObj
    {
        public List<General>? genaralList { get; set; }
        public List<Add_Users> addusersList { get; set; }
        public List<Add_Roles> addrolesList { get; set; }
        public List<Add_Benchmark> addbenchmarkList { get; set; }
        public List<Accumulator_Mapping> addaccumulatorList {get; set; }
        public List<Add_Project_Assignment> addprojectAssignmentList { get; set; }
        public List<Modify_Project_Assignment_Edit> modifyprojectAssignmentEditList { get; set; }
        public List<Modify_Project_Assignment> modifyprojectAssignmentList { get; set; }
        public List<Add_Project_Owners> addprojectOwnersList { get; set; }
        public List<Modify_Project_Owners_Edit> modifyprojectOwnersEditList { get; set; }
        public List<Modify_Project_Owners> modifyprojectOwnersList { get; set; }
        public List<Management> managementList { get; set; }
        public List<Process_Benefit> processbenefitList { get; set; }
        public List <Process_Claim> processclaimList { get; set; }
    }
    public class Add_Users
    {
        //public string Active_Directory { get; set; }
        //public string Native_Directory { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Select_A_Role { get; set; }
    }
    public class Add_Roles
    {
        public string Role_Name { get; set; }
        public string Screen_Selection { get; set; }
         public string User_Management { get; set; } 
           public string  BENEFIT_LOAD{get;set;}	
         public string PROJECT_STATUS_REPORT { get;set;}
        public string ROLE_MANAGEMENT  { get;set;}
       public string SERVICE_MANAGEMENT { get;set; }
        public string CATEGORY_MANAGEMENT { get;set;}
		public string PRODUCT_MANAGEMENT { get;set;}
        public string BENCHMARK_MANAGEMENT { get;set;}
        public string ACCUMULATOR_MANAGEMENT { get;set;}
        public string PROJECT_ASSIGNMENT { get;set;}
        public string  PROCESS_BENEFIT	{ get;set;}
        public string PROCESS_CLAIM { get;set;}
        public string PRODUCT_STATUS_REPORT { get;set;}
        public string PRODUCT_BENEFIT_REPORT { get;set;}
        public string PRODUCT_CLAIM_REPORT { get;set;}
        public string DASHBOARD	 { get;set;}
        public string PROJECT_MANAGEMENT { get;set;}
        public string CONFIG_TICKETS { get;set;}
        public string TICKET_MANAGEMENT { get;set;}
        public string PROJECT_STATUS {get;set;}
        public string PROJECT_OWNERS { get;set;}
        public string TICKETS { get;set;}
    }
    public class Management
    {
        public string Add_Service { get; set; }
        public string Add_Category { get; set; }
        public string Add_Project { get; set; }
        public string Add_Product_ID { get; set; }
        public string Select_LOB { get; set; }
        public string Product_Category { get; set; }

    }
    public class Add_Benchmark
    {
        public string Benchmark_Name { get; set; }
        public string Benchmark_FilePath { get; set; }
    }
    public class Accumulator_Mapping
    {
        public string IN_NETWORK_Deductible_Individual{get;set; }
        public string IN_NETWORK_Deductible_Family{get; set; }
        public string IN_NETWORK_Limit_Individual{get;set; }
        public string IN_NETWORK_Limit_Family{get;set; }
        public string OUT_OF_NETWORK_Deductible_Individual{get;set; }
        public string OUT_OF_NETWORK_Deductible_Family{get; set; }
        public string OUT_OF_NETWORK_Limit_Individual{get;set; }
        public string OUT_OF_NETWORK_Limit_Family{get;set; }

    }
    public class Add_Project_Assignment
    {
        public string Project_Name { get; set; }
        public string User_Name { get; set; }
        public string Product_ID { get; set; }
        public string Service_Category { get; set; }
    }
    public class Modify_Project_Assignment_Edit
    {
        public string Project_Name { get; set; }
        public string User_Name { get; set; }
        public string Product_ID { get; set; }
        public string Service_Category { get; set; }

    }
    public class Modify_Project_Assignment
    {
        public string Project_Name { get; set; }
        public string Modify_User_Name { get; set; }
        public string Modify_Product_ID { get; set; }
        public string Modify_Service_Category { get; set; }

    }
    public class Add_Project_Owners
    {
        public string Project_Name { get; set; }
        public string Product_ID { get; set; }
        public string Owner_Name { get; set; }

    }
    public class Modify_Project_Owners_Edit
    {
        public string Project_Name { get; set; }
        public string Product_ID { get; set; }
        public string Owner_Name { get; set; }

    }
    public class Modify_Project_Owners
    {
        public string Modify_Project_Name { get; set; }
        public string Modify_Product_ID { get; set; }
        public string Modify_Owner_Name { get; set; }

    }
    public class Process_Benefit
    {
        public string Project_Name { get; set; }
        public string Product_ID { get; set; }
        public string Options { get; set; }
        public string Service_Category { get; set; }
        public string Comments { get; set; }

       
    }
     public class Process_Claim
        {
            public string Project_Name { get; set; }
            public string Product_ID { get; set; }
            public string Service_Category { get; set; }
            public string Tier { get; set; }
            public string Range_Date_From { get; set; }
            public string Range_Date_To { get; set; }
            public string Comments { get; set; }

        }
    public class ExcelResultFileObj
    {
        public List<Add_Users> users_Results { get; set; }

    }

}
