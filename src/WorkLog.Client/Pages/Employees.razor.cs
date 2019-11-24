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
        private Employee _employee;
        private int _employeesCount;
        private int _employeesNextId;
        private bool isAddNewPressed = false;
        private bool isSaved = false;

        [Required]
        private string _firstName { get; set; }
       
        [Required]
        private string _lastName { get; set; }
      
        [Required]
        private string _position { get; set; }
       
        [Required]
        private decimal _hourlyWage { get; set; }


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
            Console.WriteLine(JsonConvert.SerializeObject(_employee));
            isAddNewPressed = false;
        }

        public async Task AddEmployeesAction()
        {
            isAddNewPressed = true;
            var e = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _employeesNextId = e.Count() + 1;
        }

        public async Task ConfirmDeleteEmployee(Employee employee)
        {
            var responseMessage = await Http.DeleteAsync("/api/employee/" + employee.Id);
        }
    }
}