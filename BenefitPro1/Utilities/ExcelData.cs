using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitPro1.Utilities
{
    public class ExcelData
    {
        FileObj fileObj = new FileObj();
      
        List<General> generalist = new List<General>();
         List<Add_Users> addUsersList  = new List<Add_Users>();
       List<Add_Roles> addRolesList  = new List<Add_Roles>();
        List <Management> managemenTList =new List<Management> ();
        List<Add_Benchmark>addBenchmarkList=new List<Add_Benchmark>();
        List<Accumulator_Mapping>addAccumulatorList=new List<Accumulator_Mapping>();
        List<Add_Project_Assignment>addProjectAssignmentList = new List<Add_Project_Assignment>();
        List<Modify_Project_Assignment>modifyProjectAssignmentList = new List<Modify_Project_Assignment>();
        List<Modify_Project_Assignment_Edit>modifyProjectAssignmentEditList = new List<Modify_Project_Assignment_Edit>();
        List<Add_Project_Owners>addProjectOwnersList =new List<Add_Project_Owners>();
         List<Modify_Project_Owners_Edit>modifyProjectOwnersEditList = new List<Modify_Project_Owners_Edit>();
        List<Modify_Project_Owners> modifyProjectOwnersList = new List<Modify_Project_Owners>();
        List<Process_Benefit> processBenefitList =new List<Process_Benefit>();
        List<Process_Claim> processClaimList =new List<Process_Claim>();
        General general;
        Add_Users addusers;
        Add_Roles addroles;
        Management management;
        Add_Benchmark addbenchmark;
        Accumulator_Mapping addaccumulator;
        Add_Project_Assignment addprojectassignment;
        Modify_Project_Assignment_Edit modifyprojectassignmentedit;
        Modify_Project_Assignment modifyprojectassignment;
        Add_Project_Owners addprojectowners;
        Modify_Project_Owners_Edit modifyprojectownersedit;
        Modify_Project_Owners modifyprojectowners;
        Process_Benefit processbenefit;
        Process_Claim processclaim;
        GenerateFile generateFile = new GenerateFile();
        public FileObj ReadExcel(string path)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                fileObj = new FileObj();
                generalist = new List<General>();
                addUsersList =new List<Add_Users>();
                addRolesList = new List<Add_Roles>();
                managemenTList =new List<Management>();
                addBenchmarkList=new List<Add_Benchmark>();
                addAccumulatorList = new List<Accumulator_Mapping>();
                addProjectAssignmentList=new List<Add_Project_Assignment>();
                modifyProjectAssignmentList =new List<Modify_Project_Assignment>();
                modifyProjectAssignmentEditList=new List<Modify_Project_Assignment_Edit>();
                addProjectOwnersList=new List<Add_Project_Owners>();
                modifyProjectOwnersEditList = new List<Modify_Project_Owners_Edit>();
                modifyProjectOwnersList = new List<Modify_Project_Owners>();
                processBenefitList=new List<Process_Benefit>();
                processClaimList =  new List<Process_Claim>();



                string fileName = "TestData.xlsx";
                string filePath = Path.Combine(Environment.CurrentDirectory, @"TestFiles\", fileName);
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    int SheetCount = xlPackage.Workbook.Worksheets.Count;

                  
                    for (int j = 0; j < SheetCount; j++)
                    {
                        ExcelWorksheet myWorksheet = xlPackage.Workbook.Worksheets[j];
                        var totalRows = myWorksheet.Dimension.End.Row;
                        var totalColumns = myWorksheet.Dimension.End.Column;

                        for (int x = 2; x <= totalRows; x++) 
                        {
                            bool RowIsEmpty = true;

                            for (int col = 1; col <= totalColumns; col++)
                            {

                                if (myWorksheet.Cells[x, col].Value != null)
                                {
                                    RowIsEmpty = false;
                                }
                            }

                            if (!RowIsEmpty)
                            {
                                if (j==0)
                                {
                                     general = new General();
                                        general.Key = myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                        general.Value = myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                        generalist.Add(general);
                                }

                               
                                else if (j==1) 
                                 {
                                    addusers=new Add_Users();
                                    addusers.User_Name = myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addusers.Password = myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addusers.First_Name= myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    addusers.Last_Name =myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    addusers.Select_A_Role= myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    addUsersList.Add(addusers);
                                 }
                                else if(j==2)
                                {
                                    addroles = new Add_Roles();
                                    addroles.Role_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addroles.Screen_Selection=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addroles.User_Management=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    addroles.BENEFIT_LOAD=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    addroles.PROJECT_STATUS_REPORT=myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    addroles.ROLE_MANAGEMENT=myWorksheet.Cells[x, 6].Value != null ? myWorksheet.Cells[x, 6].Value.ToString().Trim() : "";
                                    addroles.SERVICE_MANAGEMENT=myWorksheet.Cells[x, 7].Value != null ? myWorksheet.Cells[x, 7].Value.ToString().Trim() : "";
                                    addroles.CATEGORY_MANAGEMENT=myWorksheet.Cells[x, 8].Value != null ? myWorksheet.Cells[x, 8].Value.ToString().Trim() : "";
                                    addroles.PRODUCT_MANAGEMENT=myWorksheet.Cells[x, 9].Value != null ? myWorksheet.Cells[x, 9].Value.ToString().Trim() : "";
                                    addroles.BENCHMARK_MANAGEMENT=myWorksheet.Cells[x, 10].Value != null ? myWorksheet.Cells[x, 10].Value.ToString().Trim() : "";
                                    addroles.ACCUMULATOR_MANAGEMENT=myWorksheet.Cells[x, 11].Value != null ? myWorksheet.Cells[x, 11].Value.ToString().Trim() : "";
                                    addroles.PROJECT_ASSIGNMENT=myWorksheet.Cells[x, 12].Value != null ? myWorksheet.Cells[x,12].Value.ToString().Trim() : "";
                                    addroles.PROCESS_BENEFIT=myWorksheet.Cells[x, 13].Value != null ? myWorksheet.Cells[x, 13].Value.ToString().Trim() : "";
                                    addroles.PROCESS_CLAIM=myWorksheet.Cells[x, 14].Value != null ? myWorksheet.Cells[x, 14].Value.ToString().Trim() : "";
                                    addroles.PRODUCT_STATUS_REPORT=myWorksheet.Cells[x,15].Value != null ? myWorksheet.Cells[x, 15].Value.ToString().Trim() : "";
                                    addroles.PRODUCT_BENEFIT_REPORT=myWorksheet.Cells[x, 16].Value != null ? myWorksheet.Cells[x, 16].Value.ToString().Trim() : "";
                                    addroles.PRODUCT_CLAIM_REPORT=myWorksheet.Cells[x, 17].Value != null ? myWorksheet.Cells[x, 17].Value.ToString().Trim() : "";
                                    addroles.DASHBOARD=myWorksheet.Cells[x, 18].Value != null ? myWorksheet.Cells[x, 18].Value.ToString().Trim() : "";
                                    addroles.PROJECT_MANAGEMENT=myWorksheet.Cells[x, 19].Value != null ? myWorksheet.Cells[x, 19].Value.ToString().Trim() : "";
                                    addroles.CONFIG_TICKETS=myWorksheet.Cells[x, 20].Value != null ? myWorksheet.Cells[x, 20].Value.ToString().Trim() : "";
                                    addroles.TICKET_MANAGEMENT=myWorksheet.Cells[x, 21].Value != null ? myWorksheet.Cells[x, 21].Value.ToString().Trim() : "";
                                    addroles.PROJECT_STATUS=myWorksheet.Cells[x, 22].Value != null ? myWorksheet.Cells[x, 22].Value.ToString().Trim() : "";
                                    addroles.PROJECT_OWNERS=myWorksheet.Cells[x, 23].Value != null ? myWorksheet.Cells[x, 23].Value.ToString().Trim() : "";
                                    addroles.TICKETS=myWorksheet.Cells[x, 24].Value != null ? myWorksheet.Cells[x, 24].Value.ToString().Trim() : "";
                                    addRolesList.Add(addroles);

                                }
                                 else if (j==3)
                                {
                                  management=new Management();
                                  management.Add_Service=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    management.Add_Category=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    management.Add_Project =myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    management.Add_Product_ID=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    management.Select_LOB=myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    management.Product_Category=myWorksheet.Cells[x, 6].Value != null ? myWorksheet.Cells[x, 6].Value.ToString().Trim() : "";
                                    managemenTList.Add(management);

                                }
                                else if(j==4) 
                                { 
                                    addbenchmark=new Add_Benchmark();
                                    addbenchmark.Benchmark_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addbenchmark.Benchmark_FilePath=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addBenchmarkList.Add(addbenchmark);
                                  }
                                   else if(j==5) 
                                  {
                                    addaccumulator= new Accumulator_Mapping();
                                    addaccumulator.IN_NETWORK_Deductible_Individual=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addaccumulator.IN_NETWORK_Deductible_Family=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addaccumulator.IN_NETWORK_Limit_Individual=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    addaccumulator.IN_NETWORK_Limit_Family=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    addaccumulator.OUT_OF_NETWORK_Deductible_Individual=myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    addaccumulator.OUT_OF_NETWORK_Deductible_Family=myWorksheet.Cells[x, 6].Value != null ? myWorksheet.Cells[x, 6].Value.ToString().Trim() : "";
                                    addaccumulator.OUT_OF_NETWORK_Limit_Individual=myWorksheet.Cells[x, 7].Value != null ? myWorksheet.Cells[x, 7].Value.ToString().Trim() : "";
                                    addaccumulator.OUT_OF_NETWORK_Limit_Family=myWorksheet.Cells[x, 8].Value != null ? myWorksheet.Cells[x, 8].Value.ToString().Trim() : "";
                                    addAccumulatorList.Add(addaccumulator);
                                  }
                                  else if(j==6) 
                                  {
                                    addprojectassignment= new Add_Project_Assignment();
                                    addprojectassignment.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addprojectassignment.User_Name=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addprojectassignment.Product_ID=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    addprojectassignment.Service_Category=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    addProjectAssignmentList.Add(addprojectassignment);
                                  }
                                else if(j==7) 
                                    {
                                    modifyprojectassignmentedit= new Modify_Project_Assignment_Edit();
                                    modifyprojectassignmentedit.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    modifyprojectassignmentedit.User_Name=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    modifyprojectassignmentedit.Product_ID=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    modifyprojectassignmentedit.Service_Category=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    modifyProjectAssignmentEditList.Add(modifyprojectassignmentedit);
                                    }
                                else if(j==8) 
                                    {
                                    modifyprojectassignment= new Modify_Project_Assignment();
                                    modifyprojectassignment.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    modifyprojectassignment.Modify_User_Name=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    modifyprojectassignment.Modify_Product_ID=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    modifyprojectassignment.Modify_Service_Category=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    modifyProjectAssignmentList.Add(modifyprojectassignment);
                                    }
                                else if(j==9)
                                {
                                    addprojectowners=new Add_Project_Owners();
                                     addprojectowners.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    addprojectowners.Product_ID=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    addprojectowners.Owner_Name=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    addProjectOwnersList.Add(addprojectowners);
                                }
                                else if(j==10)
                                {
                                    modifyprojectownersedit=new Modify_Project_Owners_Edit();
                                     modifyprojectownersedit.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    modifyprojectownersedit.Product_ID=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    modifyprojectownersedit.Owner_Name=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    modifyProjectOwnersEditList.Add(modifyprojectownersedit);

                                }
                                  else if(j==11)
                                {
                                    modifyprojectowners=new Modify_Project_Owners();
                                     modifyprojectowners.Modify_Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    modifyprojectowners.Modify_Product_ID=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    modifyprojectowners.Modify_Owner_Name=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    modifyProjectOwnersList.Add(modifyprojectowners);

                                }
                                     else if(j==12)
                                {
                                    processbenefit=new Process_Benefit();
                                     processbenefit.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    processbenefit.Product_ID=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    processbenefit.Options=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    processbenefit.Service_Category=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    processbenefit.Comments=myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    processBenefitList.Add(processbenefit);

                                }
                                       else if(j==13)
                                {
                                    processclaim=new Process_Claim();
                                     processclaim.Project_Name=myWorksheet.Cells[x, 1].Value != null ? myWorksheet.Cells[x, 1].Value.ToString().Trim() : "";
                                    processclaim.Product_ID=myWorksheet.Cells[x, 2].Value != null ? myWorksheet.Cells[x, 2].Value.ToString().Trim() : "";
                                    processclaim.Service_Category=myWorksheet.Cells[x, 3].Value != null ? myWorksheet.Cells[x, 3].Value.ToString().Trim() : "";
                                    processclaim.Tier=myWorksheet.Cells[x, 4].Value != null ? myWorksheet.Cells[x, 4].Value.ToString().Trim() : "";
                                    processclaim.Range_Date_From=myWorksheet.Cells[x, 5].Value != null ? myWorksheet.Cells[x, 5].Value.ToString().Trim() : "";
                                    processclaim.Range_Date_To=myWorksheet.Cells[x, 6].Value != null ? myWorksheet.Cells[x, 6].Value.ToString().Trim() : "";
                                    processclaim.Comments=myWorksheet.Cells[x, 7].Value != null ? myWorksheet.Cells[x, 7].Value.ToString().Trim() : "";
                                    processClaimList.Add(processclaim);

                                }
                               
                               
                            }
                        }
                    }
                }
                fileObj.genaralList = new List<General>();
                fileObj.genaralList = generalist;
                fileObj.addusersList=addUsersList;
                fileObj.addrolesList=addRolesList;  
                fileObj.managementList=managemenTList;
                fileObj.addbenchmarkList=addBenchmarkList;
                fileObj.addaccumulatorList=addAccumulatorList;
                fileObj.addprojectAssignmentList=addProjectAssignmentList;
                fileObj.modifyprojectAssignmentEditList=modifyProjectAssignmentEditList;
                fileObj.modifyprojectAssignmentList=modifyProjectAssignmentList;
                fileObj.addprojectOwnersList=addProjectOwnersList;
                fileObj.modifyprojectOwnersEditList=modifyProjectOwnersEditList;
                fileObj.modifyprojectOwnersList = modifyProjectOwnersList;
                fileObj.processbenefitList=processBenefitList;
                fileObj.processclaimList =processClaimList;
            
            }
            catch (Exception ex)
            {
                 generateFile.LogException(ex, "Excel Reader");
            }



            return fileObj;
        }
            public string CreateNewResultFile()
        {
            string status = "";
            try
            {
                fileObj = ReadExcel("");
                string template_Dir = Path.Combine(Environment.CurrentDirectory, @"TestFiles\", "Result_Template.xlsx");
                string filename = "R" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Results.xlsx";
                string p1Path = fileObj.genaralList.Find(u => u.Key.Equals("ResultsDirectory")).Value + @"\";
                string actual_Result_File_Dir = Path.Combine(Environment.CurrentDirectory, p1Path, filename);
                File.Copy(template_Dir, actual_Result_File_Dir);
                status = actual_Result_File_Dir;
            }
            catch (Exception e)
            {
                generateFile.LogException(e, "Create New Result File");
            }
            return status;
        }



    }

}
