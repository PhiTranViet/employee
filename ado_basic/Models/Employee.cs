using System;
using System.Collections.Generic;

namespace ado_basic.Models
{
    public class Employee
    {
        private Guid _employeeID;
        public Guid EmployeeId
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        //public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }   
        public string Phone { get; set; } 
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
