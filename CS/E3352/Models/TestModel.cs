using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E3352.Models
{
    public class TestModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Information { get; set; }
        public static List<string> GetPropertyNames()
        {
            List<string> names = new List<string>();
            names.Add("FirstName");
            names.Add("LastName");
            names.Add("BirthDate");
            names.Add("Information");
            return names;
        }
        public static List<TestModel> GetDS()
        {
            return Enumerable.Range(0, 20).Select(i => new TestModel() {
                ID = i,
                FirstName = "FirstName " + i,
                LastName = "LastName " + i,
                BirthDate = new DateTime(1980, 1, 1).AddDays(i),
                Information = "Information " + i
            }).ToList<TestModel>();
        }
    }
}