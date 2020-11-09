using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EmployeePayrollSystemThreading;
using System.Net.Http.Headers;
using System.Diagnostics;
using System;
using System.Threading;

namespace Employee_Payroll_system_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
        public List<EmployeeDetails> AddingDataToList()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails.Add(new EmployeeDetails(EmployeeID: 31, EmployeeName: "Bruce", PhoneNumber: "9999999999", Address: "xyz", Department: "abc", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "def"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 32, EmployeeName: "Lee", PhoneNumber: "8888888888", Address: "xayz", Department: "abcd", Gender: 'F', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 33, EmployeeName: "Sachin", PhoneNumber: "9999999988", Address: "axyz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 34, EmployeeName: "Tendulkar", PhoneNumber: "9999988999", Address: "xygz", Department: "abc", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqrs", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 35, EmployeeName: "Mahendar", PhoneNumber: "9998899999", Address: "xyzd", Department: "abcd", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 36, EmployeeName: "Singh", PhoneNumber: "9988999999", Address: "xydz", Department: "abc", Gender: 'F', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqsr", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 37, EmployeeName: "Dhoni", PhoneNumber: "9988899999", Address: "xyz", Department: "abec", Gender: 'M', BasicPay: 50000, Deductions: 2000, TaxablePay: 48000, Tax: 1000, NetPay: 47000, City: "pqra", Country: "defg"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 38, EmployeeName: "Vishal", PhoneNumber: "9999888999", Address: "axyz", Department: "abec", Gender: 'M', BasicPay: 25000, Deductions: 1000, TaxablePay: 24000, Tax: 1000, NetPay: 23000, City: "pqar", Country: "defg"));

            return employeeDetails;

            
        }
        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayrollList()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayroll(employeeDetails);
            DateTime endtime = DateTime.Now;

            Console.WriteLine("Total time without thread: {0}", starttime - endtime);
        }
        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayRollList_UsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayrollWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time with thread: {0}", starttime1 - endtime1);
        }
        [TestMethod]
        public void AddingDataIntoDataBase()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.addEmployeeToPayrollDataBase(employeeDetails);
            DateTime endtime = DateTime.Now;
            Console.WriteLine("Total time for operation withut thread: {0}", starttime - endtime);
        }
        [TestMethod]
        public void AddingDataintoDataBaseUsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.addEmployeeToPayrollDataBaseWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time for operation with thread: {0}", starttime1 - endtime1);
        }
        [TestMethod]
        public void AddingDataIntoListWithMultiThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            Thread t1 = new Thread(() => employeePayrollOperations.addEmployeeToPayroll(employeeDetails));
            Thread t2 = new Thread(() => employeePayrollOperations.addEmployeeToPayroll(employeeDetails));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            t1.Start();
            t2.Start();
            stopwatch.Stop();
            t1.Join();
            t2.Join();
            Console.WriteLine("Elapsed time with multithreading");
            Console.WriteLine(stopwatch.Elapsed);
        }
        [TestMethod]
        public void AddingDataIntoDataBaseWithMultiThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            Thread t1 = new Thread(() => employeePayrollOperations.addEmployeeToPayrollDataBase(employeeDetails));
            Thread t2 = new Thread(() => employeePayrollOperations.addEmployeeToPayrollDataBase(employeeDetails));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            t1.Start();
            t2.Start();
            stopwatch.Stop();
            t1.Join();
            t2.Join();
            Console.WriteLine("Elapsed time with multithreading");
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
