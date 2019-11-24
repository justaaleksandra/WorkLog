using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using WorkLog.Bll.Models;

namespace WorkLog.Client.Pages
{
    public partial class WorkTimes
    {
        [Inject] public HttpClient Http { get; set; }
        [Inject] public IMapper _mapper { get; set; }

        private IList<Employee> _employees;
        private Bll.Models.WorkTime _workTime;
        private bool isAddNewPressed = false;
        private Employee _selectedEmployee;

        public partial class WorkTimeViewModel
        {
            public int Hours { get; set; }
            public string CreatedOnUtc { get; set; }
            public int HourlyWage { get; set; }
            public Guid EmployeeId { get; set; }
        }

        private WorkTimeViewModel _workTimeToAdd = new WorkTimeViewModel
        {
            Hours = 0,
            CreatedOnUtc = "",
            HourlyWage = 0
        };

        public async Task AddHours()
        {
            var workTime = _mapper.Map<Bll.Models.WorkTime>(_workTimeToAdd);

            workTime.EmployeeId = _selectedEmployee.Id;
            _workTime = await Http.PostJsonAsync<Bll.Models.WorkTime>("api/WorkTime", workTime);
            
            isAddNewPressed = false;
        }

        public async Task SelectEmployee(Employee employee)
        {
            _employees = await Http.GetJsonAsync<IList<Employee>>("api/employee");
            _selectedEmployee = employee;
            isAddNewPressed = true;
        }

        protected override async Task OnInitializedAsync()
        {
           _employees = await Http.GetJsonAsync<IList<Employee>>("api/employee");
        }
    }
}
