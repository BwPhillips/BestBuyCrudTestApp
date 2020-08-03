using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyCrudTestConsole
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

        public void CreateDepartment(string name)
        {
            _connection.Execute("INSERT INTO departments Name Values(@name);", new { name = name });
        }

        public void UpdateDepartment(int id, string newName)
        {
            _connection.Execute("UPDATE departments SET Name = @newName WHERE DepartmentID = @id;", new { newName = newName, id = id });
        }

        //Delete data
        public void DeleteDepartment(int departmentID)
        {
            _connection.Execute("DELETE FROM departments WHERE DepartmentID = @departmentID;",
                new { departmentID = departmentID });

            //_connection.Execute("DELETE FROM departments WHERE Name = @name;",
            //    new { departmentID = departmentID });
            
        }

    }
}
