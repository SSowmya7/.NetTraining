using LINQPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace LINQPractice.Contracts
{
    public interface IEmployeeServices
    {
        public Task<IEnumerable<Employee>> Get();
    }
}
