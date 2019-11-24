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
using AutoMapper;

namespace WorkLog.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] public IMapper _mapper { get; set; }

        private IList<Employee> _employees;

        private Employee _employee;
        private int _employeesCount;
        private bool isAddNewPressed = false;

        public partial class EmployeeViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Position { get; set; }
            public string HourlyWage { get; set; }
        }

        private EmployeeViewModel _toAdd = new EmployeeViewModel
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
            var employee = _mapper.Map<Employee>(_toAdd);
            _employee = await Http.PostJsonAsync<Employee>("api/employee", employee);
            await GetEmployees();
            
            isAddNewPressed = false;
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
    }
}