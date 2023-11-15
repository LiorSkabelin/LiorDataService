using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Trainingp : BaseEntity
    {
        protected string name;
        protected string description;
        protected int userld;
        protected bool approved;
        protected string level;
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Userld { get { return userld; } set { userld = value; } }
        public bool Approved { get { return approved; } set { approved = value; } }
        public string Level { get { return level; } set { level = value; } }
        public class TrainingpList : List<Trainingp>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public TrainingpList() { }
            //המרה אוסף גנרי לרשימת משתמשים
            public TrainingpList(IEnumerable<Trainingp> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת משתמשים
            public TrainingpList(IEnumerable<BaseEntity> list)
                : base(list.Cast<Trainingp>().ToList()) { }
        }
    }
}
