using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ado_basic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ado_basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestEmpController : ControllerBase
    {
        // GET: api/TestEmp
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            string connectionString = "Server = localhost; port = 3307; Database = misa_demo; User = root; Password = 12345678@Abc";



            // Khoi tao doi tuong Sql Connection 
            MySqlConnection sqlConnection = new MySqlConnection(connectionString);
            // Khoi tao doi tuong Sql Commmand - Cho phep  thao tac voi CSDL

            MySqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //Khai bao cau truy van
            sqlCommand.CommandText = "misa_demo.`dbo.Proc_Getemployees`";
            // Mo ket noi toi Database
            sqlConnection.Open();

            //Thuc thi cong viec voi Database

            MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Xu ly du lieu tra ve

            while (sqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang đoc
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị của cell đang đoc
                    var value = sqlDataReader.GetValue(i);

                    //Lấy propety giống với tên cột khia báo ở trên

                    var property = employee.GetType().GetProperty(colName);
                    //Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(employee, value);
                    }
                }
                // Them doi tuog khach hang vua build duoc vao list
                employees.Add(employee);
            }
            //Dong kết nối 
            sqlConnection.Close();
            return employees;
        }

        // GET: api/TestEmp/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestEmp
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/TestEmp/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
