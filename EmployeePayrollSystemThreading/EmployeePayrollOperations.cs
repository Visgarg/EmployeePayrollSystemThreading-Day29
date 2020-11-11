using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollSystemThreading
{
    /// <summary>
    /// Employee payroll operations class which contains all threading operations
    /// </summary>
    public class EmployeePayrollOperations
    {
        //Adding NLog to show log details
        NLog nLog = new NLog();
        //mutex class is defined in threading namespace 
        //it is used for synchronizing threads
        private static Mutex mut = new Mutex();
        //making a connectionstring
        //public static string connectionString = @"Data Source=DESKTOP-ERFDFCL\SQLEXPRESS01;Initial Catalog=payroll;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //making a sql connection
        //SqlConnection connection = new SqlConnection(connectionString);
        //making employee payroll detail list where data will be added
        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();
        /// <summary>
        /// Adds the employee to payroll. UC1
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                nLog.LogDebug("Adding of Employee: "+employeeData.EmployeeName+ " :addEmployeeToPayroll()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                this.addEmployeePayroll(employeeData);
                Console.WriteLine("Thread Execution: " + Thread.CurrentThread.ManagedThreadId);
                nLog.LogInfo("Employee Successfully added in List: addEmployeeToPayroll() ||ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Employee added:" + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }
        /// <summary>
        /// Adds the employee to payroll with thread and tasks UC2
        /// multiple threads are made here
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                //TPL concept is used
                //multiple threads are made 
                Task thread = new Task(() =>
                 {
                     nLog.LogDebug("Adding of Employee :addEmployeeToPayrollWithThread()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                     Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                     this.addEmployeePayroll(employeeData);
                     Console.WriteLine("Employee added:" + employeeData.EmployeeName);
                     nLog.LogInfo("Employee Successfully added in List: addEmployeeToPayrollWithThread() ||ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                     Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                 });
                nLog.LogDebug("Starting Of thread:" + Thread.CurrentThread.ManagedThreadId);
                thread.Start();

            });
        }
        /// <summary>
        /// Adds the employee payroll. UC1/UC2
        /// </summary>
        /// <param name="emp">The emp.</param>
        public void addEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }
        /// <summary>
        /// Adds the employee to payroll with thread with synchronization. UC3
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayrollWithThreadWithSynchronization(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData=>
            {
                Thread thread = new Thread(() =>
                {
                    //mutex waitone method is used
                    //this method does not allow to other threads to go in it, until current thread execution is complete
                    mut.WaitOne();
                    nLog.LogDebug("Starting of synchronized Thread using Mutex : addEmployeeToPayrollWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                    nLog.LogDebug("adding Employee to Database- "+employeeData.EmployeeName+":addEmployeeToPayrollWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                    this.addEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added:" + employeeData.EmployeeName);
                    nLog.LogDebug("added Employee to Database- " + employeeData.EmployeeName + ":addEmployeeToPayrollWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    //mut realease mutex is used, which releases current thread and allows new thread to be used.
                    mut.ReleaseMutex();
                    nLog.LogDebug("Ending of synchronized Thread using Mutex : addEmployeeToPayrollWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                });
                thread.Start();
                thread.Join();

            });
        }

        /// <summary>
        /// Adds the employee to payroll data base. UC1
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayrollDataBase(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                nLog.LogDebug("Adding of Employee: " + employeeData.EmployeeName + " :addEmployeeToPayrollDataBase()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                this.addEmployeePayrollDatabase(employeeData);
                Console.WriteLine("Employee added" + employeeData.EmployeeName);
                nLog.LogDebug(" Employee Added: " + employeeData.EmployeeName + " :addEmployeeToPayrollDataBase()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);
            });
        }
        /// <summary>
        /// Adds the employee to payroll data base with thread. UC2
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayrollDataBaseWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                //TPL concept is used
                //multiple threads are made 
                Thread thread = new Thread(() =>
                {
                    nLog.LogDebug("Adding of Employee:"+employeeData.EmployeeName+" :addEmployeeToPayrollDatabaseWithThread()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    addEmployeePayrollDatabase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    nLog.LogDebug("Employee Added:" + employeeData.EmployeeName + " :addEmployeeToPayrollDatabaseWithThread()||ThreadID: " + Thread.CurrentThread.ManagedThreadId);

                });
                thread.Start();
                thread.Join();
            });
        }
        /// <summary>
        /// Adds the employee payroll database. UC1/UC2
        /// </summary>
        /// <param name="employeeDetails">The employee details.</param>
        public void addEmployeePayrollDatabase(EmployeeDetails employeeDetails)
        {
            string connectionString = @"Data Source=DESKTOP-ERFDFCL\SQLEXPRESS01;Initial Catalog=payroll;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //making a sql connection
            SqlConnection connection = new SqlConnection(connectionString);
            //Adding data into single table
            //SqlCommand command = new SqlCommand("spInsertData", connection);
            //adding data into multiple table
            SqlCommand command = new SqlCommand("insertingdatainmultipletable", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeID);
            command.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
            command.Parameters.AddWithValue("@phoneNumber", employeeDetails.PhoneNumber);
            command.Parameters.AddWithValue("@Address", employeeDetails.Address);
            command.Parameters.AddWithValue("@Department", employeeDetails.Department);
            command.Parameters.AddWithValue("@gender", employeeDetails.Gender);
            command.Parameters.AddWithValue("@basicpay", employeeDetails.BasicPay);
            command.Parameters.AddWithValue("@deductions", employeeDetails.Deductions);
            command.Parameters.AddWithValue("@taxablepay", employeeDetails.TaxablePay);
            command.Parameters.AddWithValue("@tax", employeeDetails.Tax);
            command.Parameters.AddWithValue("@netpay", employeeDetails.NetPay);
            command.Parameters.AddWithValue("@city", employeeDetails.City);
            command.Parameters.AddWithValue("@country", employeeDetails.Country);
            connection.Open();
            //adding data into database - using disconnected architecture(as connected architecture only reads the data)
            var result = command.ExecuteNonQuery();
            //closing connection
            connection.Close();

        }
        /// <summary>
        /// Adds the employee to payroll data base with thread with synchronization. UC3
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void addEmployeeToPayrollDataBaseWithThreadWithSynchronization(List<EmployeeDetails> employeePayrollDataList)
        {
            //using parallel.foreach multiple threads work at same time to complete the task of inserting the data.
            //employeePayrollDataList.ForEach(employeeData =>
            Parallel.ForEach(employeePayrollDataList,employeeData=>
            {
                //Task thread = new Task(() =>
                //{
                    //mutex waitone method is used
                    //this method does not allow to other threads to go in it, until current thread execution is complete
                    mut.WaitOne();
                    nLog.LogDebug("Starting of synchronized Thread using Mutex : addEmployeeToPayrollDatabaseWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    nLog.LogDebug("adding Employee to Database- " + employeeData.EmployeeName + ":addEmployeeToPayrollDataBaseWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);
                    this.addEmployeePayrollDatabase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                    Console.WriteLine("Current Thread Id"+Thread.CurrentThread.ManagedThreadId);
                    //mut realease mutex is used, which releases current thread and allows new thread to be used.
                    mut.ReleaseMutex();
                    nLog.LogDebug("Ending of synchronized Thread using Mutex : addEmployeeToPayrollDatabaseWithThreadWithSynchronization|| ThreadId" + Thread.CurrentThread.ManagedThreadId);

                //});
                ///thread.Start();
                //task.wait or task.join also blocks other threads to come until current execution is not complete
                //hence applying synchronization
                //but it reduces no of threads to only one, as thread execution get complete and same thread execute again
                //ask doubt for this. when thread.wait is not used with task, then error is thrown, while opening up connection
                //thread.Wait();
            });
        }
      
    }

}
