<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="Pages_MainMenu" %>

 <ul id="menu">
                    <li><a href="#">File</a>
                        <ul>
                            
                            <li><a href="#">Change Password</a></li>
                            <li><a href="LogIn.aspx">User Logout</a></li>
                            <li><a href="#">Exit</a></li>
                        </ul>
                    </li>
                  <%--  <li><a href="#">SetUp</a>
                        <ul>
                            
                            
                        </ul>
                    </li>--%>
                    <li><a href="#">Master</a>
                        <ul>
                        <li><a href="../Setup/FinancialYear.aspx">Academic Years</a></li>
                        <li><a href="../Pages/Organization.aspx">Organization</a></li>
                        <li><a href="../Pages/Availibility.aspx">Schedule</a></li>
                        <li><a href="../Pages/Department.aspx">Department</a></li>
                         <li><a href="../Pages/Designation.aspx">Designation</a></li>
                          <li><a href="../Pages/Grade.aspx">Grade</a></li>
                          <li><a href="../Pages/ShiftDetail.aspx">Shift Details</a></li>
                           <li><a href="../Pages/BankSetUp.aspx">Bank Details</a></li>
                           <li><a href="../Pages/Superviser.aspx">HOD SetUp</a></li>
                            <li><a href="../Pages/LeaveMaster.aspx">Leave Type</a></li>
                           <li><a href="../Pages/LeaveDefine.aspx">Leave Setup</a></li>
                           
                            <li><a href="../Pages/Location.aspx">Location Details</a></li>
                            <li><a href="../Pages/Section.aspx">Section Details</a></li>
                            <li><a href="../Pages/SkillCategory.aspx">Skill Category</a></li>
                             <li><a href="../Pages/Documents.aspx">Documents</a></li>
                             <li><a href="../Pages/OverTimeRate.aspx">Extra Work Load</a></li>
                              <li><a href="../Pages/Allowdedelements.aspx">HR Elements</a></li>
                            <li><a href="../Setup/User.aspx">Setup User</a></li>
                            <li><a href="../Setup/Role.aspx">Setup Role</a></li>
                            <li><a href="User/UserRights.aspx">Setup User Rights</a></li>
                             <%--   <li><a href="../Pages/Countries.aspx">Country</a></li>
                            <li><a href="../Pages/Course.aspx">Course</a></li>--%>
                            <%--<li><a href="../Pages/Emirates.aspx">Emirates</a></li>--%>
 
                           <%-- <li><a href="../Pages/Relation.aspx">Relationship</a></li>
                            <li><a href="../Pages/Religion.aspx">Religion</a></li>--%>
                <%--            <li><a href="../Pages/Title.aspx">Title</a></li>--%>
                            <%--<li><a href="TrainingCourse.aspx">Training Course</a></li>--%>
                        </ul>
                    </li>
                    <li><a href="#">Employee</a>
                        <ul>
                            <li><a href="../Employee/Find.aspx">Enter and Maintain</a></li>
                            <li><a href="../Employee/EndofServices.aspx">End Of Service</a></li>
                            <li><a href="../Employee/EmpDeptTransfer.aspx">Employee Dept Transfer</a></li>
                            <li><a href="../Employee/EditEmpDetails.aspx">Edit Staff</a></li>
                        </ul>
                        <li><a href="#">Salary</a>
                            <ul>
                                <li><a href="../Salary/FindEmpSal.aspx">Salary Entry</a></li>
                                <li><a href="../Salary/SalaryModification(increament).aspx">Salary Increment </a></li>
                            </ul>
                        </li>
                        <li><a href="#">Payroll</a>
                            <ul>
                                <li><a href="../Setup/PayrollSetUp.aspx">Setup Payroll</a></li>
                                <li><a href="../Employee/AllowanceaAndDeductionSearch.aspx">Allowance/Deduction Report</a></li>
                              <%--  <li><a href="../Employee/TemAllowance.aspx">Temprory Allowance</a></li>
                                <li><a href="../Employee/TempDeduction.aspx">Temprory Deduction</a></li>--%>
                                <li><a href="../Payroll/PayrollRun.aspx">Payroll Run</a></li>
                                <li><a href="../Payroll/PayrollResult.aspx">Payroll Result(Consolidated)</a></li>
                                <li><a href="../Payroll/PayrollDetailReport.aspx">Payroll Detail Summery Report</a></li>
                                <li><a href="../Payroll/PayrollDetailedSummaryReportBankwise.aspx">Payroll Detail Summery
                                    Bank Report</a></li>
                                <li><a href="../Payroll/PayrollResultDetailed.aspx">Payroll Result(Detail)</a></li>
                                <li><a href="../Payroll/PayrollFreez.aspx">Payroll Freez</a></li>
                                <li><a href="../Payroll/SalaryTransferReport.aspx">Salary Transfer Report</a></li>
                                <li><a href="../Payroll/DepartmentWiseReport.aspx">Department Wise Salary Report</a></li>
                                <%--<li><a href="../Payroll/GratuityDepartmentWise.aspx">Project Gratituity Department Wise</a></li>--%>
                                <li><a href="../Payroll/Loan.aspx">Loan</a></li>
                                <li><a href="../Payroll/SalarySlip.aspx">Salary Slip</a></li>
                                <li><a href="../Payroll/SalaryManager.aspx">Salary Manager</a></li>
                            </ul>
                        </li>
                        
                        <li><a href="#">Application Mgmt</a>
                            <ul>
                                <li><a href="../Leave/LeaveApply.aspx">Leave Entry</a></li>
                                <li><a href="../Leave/HolidaySetting.aspx">Holiday Settings</a></li>
                                <li><a href="../Leave/MonthlyAttendance.aspx">Monthly Attendence</a></li>
                            </ul>
                           
                     <%--       <li><a href="#">Project</a>
                                <ul>
                                    <li><a href="#">Add Project</a></li>
                                    <li><a href="../Project/ClassMaster.aspx">Add Class </a></li>
                                    <li><a href="#">Class Allocation</a></li>
                                    <li><a href="#">Class teacher </a></li>
                                </ul>
                            </li>--%>
                            <li><a href="#">Time System</a>
                                <ul>
                                    <li><a href="#">Emplyee</a></li>
                                    <li><a href="#">Compile </a></li>
                                    <li><a href="#">Rollback Compile</a></li>
                                    <li><a href="#">IN-OUT Detail </a></li>
                                    <li><a href="#">Absentees</a></li>
                                    <li><a href="#">Consolidated </a></li>
                                    <li><a href="#">Manual Entry(Curr. Day)</a></li>
                                    <li><a href="#">Manual Entry(Prev. Day) </a></li>
                                </ul>
                            </li>
                 <%--           <li><a href="#">Attendence</a>
                                <ul>
                                    <li><a href="#">-Entry -</a></li>
                                </ul>--%>
                            </li>
                            <li><a href="#">Reports </a>
                                <ul>
                                    <li><a href="../Reportfiles/Deptwiserep.aspx">Department Wise</a></li>
                                    <li><a href="../Reportfiles/Sectionwise.aspx">Section Wise</a></li>
                                    <li><a href="../Reportfiles/Designationwise.aspx">Designation Wise</a></li>
                                    <li><a href="../Reportfiles/Locationwise.aspx">Location Wise</a></li>
                                    <li><a href="../Reportfiles/Nationalitywise.aspx">Nationality Wise</a></li>
                                    <li><a href="../Reportfiles/Indemnity.aspx">Indemnity Report Department Wise</a></li>
                                    <li><a href="../Reportfiles/IndemnityEmployee.aspx">Employee Indemnity Report </a></li>
                                    <li><a href="../Reportfiles/FinalSalarySettlement.aspx">Final Salary Statement </a></li>
                                    <li><a href="../Reportfiles/EmplyeeDetail.aspx">Employee Detail Record </a></li>
                                    <li><a href="../Reportfiles/DocumentExpiry.aspx">Documents Expiry Report </a></li>
                                    <li><a href="../Reportfiles/LeftEmployee.aspx">Left Employee List </a></li>
                                </ul>
                            </li>
                            <li><a href="#">Hiring and Search</a>
                                <ul>
                                    <li><a href="../Pages/HiringAndSearch.aspx">HiringAndSearch</a></li>
                                </ul>
                            </li>
                             <li><a href="#">Training</a>
                                <ul>
                                    <li><a href="../Training/Training.aspx">Training Enrolment</a></li>
                                    <li><a href="../Training/TrainingCourse.aspx">Training Detaile</a></li>
                                </ul>
                            </li>
                             <li><a href="#">Hostel</a>
                            <ul>
                                <li><a href="../Accommodation/AccomodationSetup.aspx">Setup</a></li>
                                <li><a href="../Accommodation/AccommodationDetail.aspx">Registration</a></li>
                            </ul>
                        </li>
                           
                            <li><a href="#">Transport</a>
                                <ul>
                                    <li><a href="../Transport/BusAllocation.aspx">Allocation</a></li>
                                    <li><a href="../Transport/BusMaster.aspx">Bus Master</a></li>
                                    <li><a href="../Transport/TransportStop.aspx">Transport Stop</a></li>
                                    <li><a href="">Bus report</a></li>
                                    <li><a href="">Bus Travel report</a></li>
                                    <li><a href="../Transport/BusCheck.aspx">Bus Check</a></li>
                                </ul>
                            </li>
                       <%--     <li><a href="#">Help</a>
                                <ul>
                                    <li><a href="#">How Do I ?</a></li>
                                </ul>
                            </li>--%>
                        </li>
                </ul>