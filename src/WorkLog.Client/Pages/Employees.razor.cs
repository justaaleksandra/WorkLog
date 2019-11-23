using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private string StatusMessage;    
        private string StatusClass;     


        private IList<Employee> _employees;
        private Employee _employee;
        private int _employeesCount;
        private int _employeesNextId;
        private bool isAddNewPressed = false;

        [Required]
        private string _firstName { get; set; }
       
        [Required]
        private string _lastName { get; set; }
      
        [Required]
        private string _position { get; set; }
       
        [Required]
        private decimal _hourlyWage { get; set; }
        private Employee employeeToAdd => new Employee
        {
            FirstName = _firstName,
            LastName = _lastName,
            Position = _position,
            HourlyWage = _hourlyWage,
        };
        ////private Employee employeeToAdd;

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

        public async Task AddEmployeesAction()
        {
            isAddNewPressed = true;
            var e = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _employeesNextId = e.Count() + 1;
        }

        protected void HandleValidSubmit()
        {
            StatusClass = "alert-info";
            StatusMessage = DateTime.Now + " Handle valid submit";
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            StatusMessage = DateTime.Now + " Handle invalid submit";
        }
    }
}
