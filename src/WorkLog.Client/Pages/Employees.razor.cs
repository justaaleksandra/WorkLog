using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WorkLog.Bll.Models;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace WorkLog.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient Http { get; set; }

        private IList<Employee> _employees;
        private Employee _employee;
        private int _employeesCount;
        private int _employeesNextId;
        private bool isAddNewPressed = false;

        private string _firstName { get; set; }
        private string _lastName { get; set; }
        private string _position { get; set; }
        private decimal _hourlyWage { get; set; }
        private Employee employeeToAdd => new Employee
        {
            FirstName = _firstName,
            LastName = _lastName,
            Position = _position,
            HourlyWage = _hourlyWage,
        };

        public async Task GetEmployees()
        {
            _employees = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _employeesCount = _employees.Count();
        }
        public async Task AddEmployees()
        {
            _employee = await Http.PostJsonAsync<Employee>("api/employee", employeeToAdd);
            Console.WriteLine(JsonConvert.SerializeObject(_employee));
            isAddNewPressed = false;
        }

        public void AddEmployeesContent()
        {
            isAddNewPressed = true;
            _employeesNextId = _employeesCount + 1;
            //_firstName = "Halo";
            //_lastName = "Mario";
            //_position = "Programmer";
            //_hourlyWage = 40;
        }
    }
}
