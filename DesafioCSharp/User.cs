using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
     

namespace DesafioCSharp
{
    class User
    {
        public User(int id, string firstName, string lastName, DateTime birth, int planId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birth = birth;
            PlanId = planId;
        }
        public User(string firstName, string lastName, DateTime birth, int planId)
        {
            FirstName = firstName;
            LastName = lastName;
            Birth = birth;
            PlanId = planId;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birth { get; private set; }
        public int PlanId { get; private set; }
        public override string ToString()
        {
 
            return  $"Nome: {FirstName} {LastName}"+
                    $"Nasc.: {Birth}"+
                    $"IdPlan: {PlanId}";
        }

    }
}
