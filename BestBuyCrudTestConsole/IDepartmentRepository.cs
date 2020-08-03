using System;
using System.Collections.Generic;

namespace BestBuyCrudTestConsole
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments(); //Stubbed out method
        void CreateDepartment(string Name);
    }
}
