using System;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DapperCrud.Models
{
    public class DbActions
    {
        private string ConnectionString { get; set; }
        public DbActions()
        {
            ConnectionString = "Data Source = localhost;Initial Catalog = School;Integrated Security = True;";
        }
        public void Add(Student model)
        {
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Query($"Insert Into Student(FullName,Age) Values('{model.FullName}',{model.Age})");
            }
        }
        public List<Student> Select()
        {
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                List<Student> students = new List<Student>();
                students = db.Query<Student>("Select * from Student").ToList();
                return students;
            }
        }
        public void Update(Student model)
        {
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Query("$Update Student Set FullName = '{model.FullName}', Age = {Age}");
            }
        }
        public void Delete(int Id)
        {
            using(IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Query($"Delete from Student Where Id = {Id}");
            }
        }
    }
}