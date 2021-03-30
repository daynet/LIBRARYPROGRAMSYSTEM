using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MainAdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //public class MDIMAIN
    //{

    //    private void BANKToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        BankSetUp.MdiParent = this;
    //        BankSetUp.Show();
    //    }

    //    private void SALARYENTRYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        varcall = "SALARY";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void SALARYMODIFYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        // Form1.MdiParent = Me
    //        // Form1.Show()
    //        varcall = "SALARYMODIFY";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void ENTRYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Attendence.MdiParent = this;
    //        Attendence.Show();
    //    }

    //    private void REGISTRATIONToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        AccomodationDetail.MdiParent = this;
    //        AccomodationDetail.Show();
    //    }

    //    private void LEAVEENTRYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        varcall = "LEAVE";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void ENTERANDMAINTAINToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        varcall = "EMPADD";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void DEPARTMENTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Deaprtment.MdiParent = this;
    //        Deaprtment.Show();
    //    }

    //    private void DESIGNATIONToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Designation.MdiParent = this;
    //        Designation.Show();
    //    }

    //    private void SHIFTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ShiftDetail.MdiParent = this;
    //        ShiftDetail.Show();
    //    }

    //    private void GRADEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Grade.MdiParent = this;
    //        Grade.Show();
    //    }

    //    private void POSITIONToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Section.MdiParent = this;
    //        Section.Show();
    //    }

    //    private void SUPERVISORToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Supervisor.MdiParent = this;
    //        Supervisor.Show();
    //    }

    //    private void AVAILABILITYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Availability.MdiParent = this;
    //        Availability.Show();
    //    }

    //    private void OVERTIMEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        OverTimeRate.MdiParent = this;
    //        OverTimeRate.Show();
    //    }

    //    private void COUNTRYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Countries.MdiParent = this;
    //        Countries.Show();
    //    }

    //    private void EMIRATEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Emirates.MdiParent = this;
    //        Emirates.Show();
    //    }

    //    private void COURSEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Course.MdiParent = this;
    //        Course.Show();
    //    }

    //    private void RELATIONSHIPToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Relation.MdiParent = this;
    //        Relation.Show();
    //    }

    //    private void DOCUMENTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Document.MdiParent = this;
    //        Document.Show();
    //    }

    //    private void RELIGIONToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Religion.MdiParent = this;
    //        Religion.Show();
    //    }

    //    private void LOCATIONToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Location.MdiParent = this;
    //        Location.Show();
    //    }

    //    private void SKILLCATEGORYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        SkillCategory.MdiParent = this;
    //        SkillCategory.Show();
    //    }

    //    private void USERToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Users.MdiParent = this;
    //        Users.Show();
    //    }

    //    private void ROLEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Role.MdiParent = this;
    //        Role.Show();
    //    }

    //    private void USERRIGHTSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        UserRights.MdiParent = this;
    //        UserRights.Show();
    //    }

    //    private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //    }

    //    private void LOGINToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        LoginForm.ShowDialog();
    //    }

    //    private void PAYROLLRUNToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        PayroolRun.MdiParent = this;
    //        PayroolRun.Show();
    //    }

    //    private void SETUPToolStripMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        AccomodationSetup.MdiParent = this;
    //        AccomodationSetup.Show();
    //    }

    //    private void ENDOFSERVICEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        EndOfService.MdiParent = this;
    //        EndOfService.Show();
    //    }

    //    private void PAYROLLSETUPToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        PayroolSetUp.MdiParent = this;
    //        PayroolSetUp.Show();
    //    }

    //    private void PYROLLFREEZToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Freeze.MdiParent = this;
    //        Freeze.Show();
    //    }

    //    private void PAYROLLRESULTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        PayrollResult.MdiParent = this;
    //        PayrollResult.Show();
    //    }

    //    private void SALARYYTRANSFERREPORTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        BankTransfer.MdiParent = this;
    //        BankTransfer.Show();
    //    }

    //    private void TEMPALLOWANCEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        TemproryAllownce.MdiParent = this;
    //        TemproryAllownce.ddlAllwonceType.DataSource = CGeneralFunction.filldata("Select element_id as ID,element_name as Description from HR_ELEMENTS where RECURING_NONRECURING=\'N\' a" +
    //            "nd EARNING_DEDUCTION_INFO=\'E\' ORDER BY ELEMENT_NAME");
    //        TemproryAllownce.ddlAllwonceType.ValueMember = "ID";
    //        TemproryAllownce.ddlAllwonceType.DisplayMember = "Description";
    //        TemproryAllownce.Show();
    //    }

    //    private void TEMPDEDUCTIONSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        TemproryDeduction.MdiParent = this;
    //        TemproryDeduction.ddlDeductionType.DataSource = CGeneralFunction.filldata("Select element_id as ID,element_name as Description from HR_ELEMENTS where RECURING_NONRECURING=\'N\' a" +
    //            "nd EARNING_DEDUCTION_INFO=\'D\' ORDER BY ELEMENT_NAME");
    //        TemproryDeduction.ddlDeductionType.ValueMember = "ID";
    //        TemproryDeduction.ddlDeductionType.DisplayMember = "Description";
    //        TemproryDeduction.Show();
    //    }

    //    private void DEPARTMENTWISESALARYREPORTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        SalaryDetailDepartmentWise.MdiParent = this;
    //        SalaryDetailDepartmentWise.Show();
    //    }

    //    private void CHANGEPASSWORDToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ChangePassword.MdiParent = this;
    //        ChangePassword.Show();
    //    }

    //    private void MDIMAIN_Load(object sender, System.EventArgs e)
    //    {
    //        LoginForm.Close();
    //        if ((roleID != 1))
    //        {
    //            string query = ("select f.toolstripmenuitem from forms f,UserRights ur " + ("where f.formid=ur.formid and ur.roleid=" + roleID));
    //            DataTable dtRoleRights = CGeneralFunction.filldata(query);
    //            foreach (ToolStripMenuItem mainMenu in this.MenuStrip.Items)
    //            {
    //                foreach (ToolStripMenuItem subMenu in mainMenu.DropDownItems)
    //                {
    //                    subMenu.Enabled = false;
    //                }
    //            }
    //            foreach (DataRow row in dtRoleRights.Rows)
    //            {
    //                foreach (ToolStripMenuItem mainMenu in this.MenuStrip.Items)
    //                {
    //                    foreach (ToolStripMenuItem subMenu in mainMenu.DropDownItems)
    //                    {
    //                        if ((row["toolstripmenuitem"].ToString().Trim() == subMenu.Name))
    //                        {
    //                            subMenu.Enabled = true;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    private void TRAININGENROLLMENTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Training.MdiParent = this;
    //        Training.Show();
    //    }

    //    private void TRAININGDETAILSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        TrainingDetailCourses.MdiParent = this;
    //        TrainingDetailCourses.Show();
    //    }

    //    private void ALLOWANCEDEDUCTIONREPORTToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        AllowanceDeduction.MdiParent = this;
    //        AllowanceDeduction.Show();
    //    }

    //    private void LOANToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Loan.MdiParent = this;
    //        Loan.Show();
    //    }

    //    private void HOLIDAYSETTINGSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Holiday.MdiParent = this;
    //        Holiday.Show();
    //    }

    //    private void PROJECTEDGRATUITYDEPARTMENTWISEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Gratuity.MdiParent = this;
    //        Gratuity.Show();
    //    }

    //    private void MONTHLYATTENDANCEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        MonthlyAttendance.MdiParent = this;
    //        MonthlyAttendance.Show();
    //    }

    //    private void LEAVESETUPToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        DefineLeave.MdiParent = this;
    //        DefineLeave.Show();
    //    }

    //    private void HRELEMENTSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Allowdedelements.MdiParent = this;
    //        Allowdedelements.Show();
    //    }

    //    private void DEPARTMENTWISEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        DepartmentWiseReport.MdiParent = this;
    //        DepartmentWiseReport.Show();
    //    }

    //    private void DESIGNATIONWISEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        DesignationWiseReport.MdiParent = this;
    //        DesignationWiseReport.Show();
    //    }

    //    private void LOCATIONToolStripMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        LocationWiseReport.MdiParent = this;
    //        LocationWiseReport.Show();
    //    }

    //    private void NATIONALITYWISEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        NationalityWiseReport.MdiParent = this;
    //        NationalityWiseReport.Show();
    //    }

    //    private void TrainingCoursesToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        TrainingCourses.MdiParent = this;
    //        TrainingCourses.Show();
    //    }

    //    private void FINANCIALYEARToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        FinancialYear.MdiParent = this;
    //        FinancialYear.Show();
    //    }

    //    private void LEAVETYPEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        LeaveMaster.MdiParent = this;
    //        LeaveMaster.Show();
    //    }

    //    private void TITLEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Title.MdiParent = this;
    //        Title.Show();
    //    }

    //    private void SALARYSLIPToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        SalarySlip.MdiParent = this;
    //        SalarySlip.Show();
    //    }

    //    private void HOWDOIToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //    }

    //    private void UsersToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Users_edit.MdiParent = this;
    //        Users_edit.Show();
    //    }

    //    private void COMPILEToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Compile.MdiParent = this;
    //        Compile.Show();
    //    }

    //    private void INOUTDETAILSToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        INOUTDetail.MdiParent = this;
    //        INOUTDetail.Show();
    //    }

    //    private void MANUALENTRYCURRDAYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ManualEntryPrevious.MdiParent = this;
    //        ManualEntryPrevious.Show();
    //    }

    //    private void MANUALENTRYPREVDAYToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ManualEntryPreviousPrev.MdiParent = this;
    //        ManualEntryPreviousPrev.Show();
    //    }

    //    private void ABSENTIESToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Absenties.MdiParent = this;
    //        Absenties.Show();
    //    }

    //    private void CONSOLIDATEDToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Consolidated.MdiParent = this;
    //        Consolidated.Show();
    //    }

    //    private void RollbackCompileToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Rolback.MdiParent = this;
    //        Rolback.Show();
    //    }

    //    private void ErrorCorectionToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Correction.MdiParent = this;
    //        Correction.Show();
    //    }

    //    private void PAYROLLToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //    }

    //    private void IndemnityReportToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        IndeminityReport.MdiParent = this;
    //        IndeminityReport.Show();
    //    }

    //    private void IndemnityUsersToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        IdemnityEmplyee.MdiParent = this;
    //        IdemnityEmplyee.Show();
    //    }

    //    private void UsersDetailRecordEDRToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        EDRReportDefault2.MdiParent = this;
    //        EDRReportDefault2.Show();
    //    }

    //    private void FinalSalaryUsersToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        FinalSalary.MdiParent = this;
    //        FinalSalary.Show();
    //    }

    //    private void DocumentExpiryReportToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ExpiryRepoet.MdiParent = this;
    //        ExpiryRepoet.Show();
    //    }

    //    private void UsersToolStripButton1_Click(object sender, System.EventArgs e)
    //    {
    //        varcall = "EMPADD";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void SalarySlipToolStripButton2_Click(object sender, System.EventArgs e)
    //    {
    //        SalarySlip.MdiParent = this;
    //        SalarySlip.Show();
    //    }

    //    private void LeaveToolStripButton3_Click(object sender, System.EventArgs e)
    //    {
    //        varcall = "LEAVE";
    //        Find.MdiParent = this;
    //        Find.Show();
    //    }

    //    private void TempallowanceToolStripButton4_Click(object sender, System.EventArgs e)
    //    {
    //        TemproryAllownce.MdiParent = this;
    //        TemproryAllownce.ddlAllwonceType.DataSource = CGeneralFunction.filldata("Select element_id as ID,element_name as Description from HR_ELEMENTS where RECURING_NONRECURING=\'N\' a" +
    //            "nd EARNING_DEDUCTION_INFO=\'E\' ORDER BY ELEMENT_NAME");
    //        TemproryAllownce.ddlAllwonceType.ValueMember = "ID";
    //        TemproryAllownce.ddlAllwonceType.DisplayMember = "Description";
    //        TemproryAllownce.Show();
    //    }

    //    private void TemporaryDeductionsToolStripButton1_Click(object sender, System.EventArgs e)
    //    {
    //        TemproryDeduction.MdiParent = this;
    //        TemproryDeduction.ddlDeductionType.DataSource = CGeneralFunction.filldata("Select element_id as ID,element_name as Description from HR_ELEMENTS where RECURING_NONRECURING=\'N\' a" +
    //            "nd EARNING_DEDUCTION_INFO=\'D\' ORDER BY ELEMENT_NAME");
    //        TemproryDeduction.ddlDeductionType.ValueMember = "ID";
    //        TemproryDeduction.ddlDeductionType.DisplayMember = "Description";
    //        TemproryDeduction.Show();
    //    }

    //    private void UsersDepartmentTransferToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        EmplyeeDepartmentTransfer.MdiParent = this;
    //        EmplyeeDepartmentTransfer.Show();
    //    }

    //    private void SalaryManagerToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        SalaryManager.MdiParent = this;
    //        SalaryManager.Show();
    //    }

    //    private void LeftUsersListToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        frmLeftUsers.MdiParent = this;
    //        frmLeftUsers.Show();
    //    }

    //    private void PayrollResultToolStripMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        PayrollResult2.MdiParent = this;
    //        PayrollResult2.Show();
    //    }

    //    private void TempAllowanceAnddeductionEntryToolStripMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        frmUsersSearch2.MdiParent = this;
    //        frmUsersSearch2.Show();
    //    }

    //    private void SectionwiseToolStripMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        SectionWiseReport.MdiParent = this;
    //        SectionWiseReport.Show();
    //    }

    //    private void PayrollDetailedSummaryReportMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        SalaryDetailSummryReport.MdiParent = this;
    //        SalaryDetailSummryReport.Show();
    //    }

    //    private void PayrollDetailedSummaryBankReportMenuItem1_Click(object sender, System.EventArgs e)
    //    {
    //        PayrollDetailSummeryBAnkReport.MdiParent = this;
    //        PayrollDetailSummeryBAnkReport.Show();
    //    }

    //    private void SiteToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        frmSiteMaster.MdiParent = this;
    //        frmSiteMaster.Show();
    //    }

    //    private void RoasterSetupToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        Roster.MdiParent = this;
    //        Roster.Show();
    //    }

    //    private void EditStaffToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        StaffDetail.MdiParent = this;
    //        StaffDetail.Show();
    //    }

    //    private void AllocationToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        staffBusAllocation.MdiParent = this;
    //        staffBusAllocation.Show();
    //    }

    //    private void BusMasterToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        BusMaster.MdiParent = this;
    //        BusMaster.Show();
    //    }

    //    private void TransportStopToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        TransprotStop.MdiParent = this;
    //        TransprotStop.Show();
    //    }

    //    private void AddProjectToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ProjectAdd.MdiParent = this;
    //        ProjectAdd.Show();
    //    }

    //    private void AddClassToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ClassMaster.MdiParent = this;
    //        ClassMaster.Show();
    //    }

    //    private void ClassAllocationToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ClassAllocation.MdiParent = this;
    //        ClassAllocation.Show();
    //    }

    //    private void ClassTeacherToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        ClassTeacher.MdiParent = this;
    //        ClassTeacher.Show();
    //        // frmTeacherslogin.MdiParent = Me
    //        // frmTeacherslogin.Show()
    //    }

    //    private void StudentAllocationToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //        StudentBusAllocation.MdiParent = this;
    //        StudentBusAllocation.Show();
    //    }

    //    private void SETUPToolStripMenuItem_Click(object sender, System.EventArgs e)
    //    {
    //    }
    //}
}