using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EmployeePayrollSystemThreading;
using System.Net.Http.Headers;
using System.Diagnostics;
using System;

namespace Employee_Payroll_system_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAddedToList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeName: "Bruce", PhoneNumber: "9999999999", Address: "xyz", Department: "abc", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "def"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeName: "Lee", PhoneNumber: "8888888888", Address: "xayz", Department: "abcd", Gender: 'F', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeName: "Sachin", PhoneNumber: "9999999988", Address: "axyz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeName: "Tendulkar", PhoneNumber: "9999988999", Address: "xygz", Department: "abc", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeName: "Mahendar", PhoneNumber: "9998899999", Address: "xyzd", Department: "abcd", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 6, EmployeeName: "Singh", PhoneNumber: "9988999999", Address: "xydz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 7, EmployeeName: "Dhoni", PhoneNumber: "9988899999", Address: "xyz", Department: "abec", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqra", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 8, EmployeeName: "Vishal", PhoneNumber: "9999888999", Address: "axyz", Department: "abec", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqar", Country: "defg"));

            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.addEmployeeToPayroll(employeeDetails);
            DateTime endtime = DateTime.Now;

        }
        [TestMethod]
        public void Given8Employee_WhenAddedToDataBAse_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeName: "Bruce", PhoneNumber: "9999999999", Address: "xyz", Department: "abc", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "def"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeName: "Lee", PhoneNumber: "8888888888", Address: "xayz", Department: "abcd", Gender: 'F', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeName: "Sachin", PhoneNumber: "9999999988", Address: "axyz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeName: "Tendulkar", PhoneNumber: "9999988999", Address: "xygz", Department: "abc", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeName: "Mahendar", PhoneNumber: "9998899999", Address: "xyzd", Department: "abcd", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 6, EmployeeName: "Singh", PhoneNumber: "9988999999", Address: "xydz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 7, EmployeeName: "Dhoni", PhoneNumber: "9988899999", Address: "xyz", Department: "abec", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqra", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 8, EmployeeName: "Vishal", PhoneNumber: "9999888999", Address: "axyz", Department: "abec", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqar", Country: "defg"));
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.addEmployeeToPayrollDataBase(employeeDetails);
            DateTime endtime = DateTime.Now;
            stopwatch1.Stop();
            Console.WriteLine("Total time for operation" + stopwatch1.ElapsedMilliseconds);
            Console.WriteLine("Total time: {0}", starttime - endtime);
        }
    }
}
