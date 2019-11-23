using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WorkLog.Bll.Models;
using System.Net.Http;


namespace WorkLog.Client.Pages
{
    public partial class Employees
    {
        [Inject] public HttpClient Http { get; set; }

        private IList<Employee> _employees;
        private int _employeesCount;

        //protected override async Task OnInitializedAsync()
        public async Task GetEmployees()
        {
            _employees = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _employeesCount = _employees.Count();
        }
        //public async Task AddEmployees()
        //{
        //    _employees = await Http.PostJsonAsync<Employee>("api/employee",);
        //    _employeesCount = _employees.Count();
        //}
    }
}
