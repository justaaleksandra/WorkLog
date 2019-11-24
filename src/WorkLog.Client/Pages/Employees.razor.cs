using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WorkLog.Bll.Models;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Web;
using Newtonsoft.Json;


namespace WorkLog.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient Http { get; set; }

        private string StatusMessage;    
        private string StatusClass;     


        private IList<Employee> _employees;
        private IOrderedEnumerable<Employee> _employeesSorted;
        private Employee _employee;
        private int _employeesCount;
        private bool isAddNewPressed = false;
        private bool isUpdateHourlyWagePressed = false;
        private bool isSaved = false;
        public partial class newEmployee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Position { get; set; }
            public string HourlyWage { get; set; }
        }
        private newEmployee employeeToAdd = new newEmployee()
        {
            FirstName = "",
            LastName = "",
            Position = "",
            HourlyWage = ""
        };

        public async Task GetEmployees()
        {
            _employees = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _employeesCount = _employees.Count();

            await InvokeAsync(StateHasChanged);
        }
        public async Task AddEmployees()
        {
            var employee = new Employee
            {
                FirstName = employeeToAdd.FirstName,
                LastName = employeeToAdd.LastName,
                Position = employeeToAdd.Position,
                HourlyWage = decimal.Parse(employeeToAdd.HourlyWage)
            };
            _employee = await Http.PostJsonAsync<Employee>("api/employee", employee);
            await GetEmployees();
            isAddNewPressed = false;
            isUpdateHourlyWagePressed = false;
        }

        public async Task AddEmployeesAction()
        {
            isAddNewPressed = true;
            var e = await Http.GetJsonAsync<IList<Employee>>("api/employee");
        }

        public async Task DeleteEmployee(Employee employee)
        {
            var responseMessage = await Http.DeleteAsync("/api/employee/" + employee.Id);
            await GetEmployees();
        }

        //public async Task UpdateHourlyWage(Employee employee)
        //{
        //    isUpdateHourlyWagePressed = true;
        //    var e = await Http.GetJsonAsync<Employee>("api/employee" + employee.Id);
        //    await Http.PutJsonAsync("/api/employee/UpdateHourlyWage", e);
        //    await GetEmployees();
        //    isUpdateHourlyWagePressed = false;
        //}
    }
}