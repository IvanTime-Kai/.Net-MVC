using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public interface IEmployee
    {
        int ID { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        decimal Salary { get; set; }
        DateTime DateOfBirth { get; set; }
    }

    public class Employee : IEmployee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
