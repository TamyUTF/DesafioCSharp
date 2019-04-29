using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCSharp
{
    public class Plan
    {
        public Plan(int id, string name, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Plan(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}