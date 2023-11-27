using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class TrainingProgram : BaseEntity
    {
        
        protected string name;
        
        protected string description;
        
        protected int userld;
        
        protected bool approved;
      
        protected string level;
        
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string Description { get { return description; } set { description = value; } }
        [DataMember]
        public int Userld { get { return userld; } set { userld = value; } }
        [DataMember]
        public bool Approved { get { return approved; } set { approved = value; } }
        [DataMember]
        public string Level { get { return level; } set { level = value; } }
    }
    [CollectionDataContract]
    public class TrainingpList : List<TrainingProgram>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public TrainingpList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public TrainingpList(IEnumerable<TrainingProgram> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public TrainingpList(IEnumerable<BaseEntity> list)
            : base(list.Cast<TrainingProgram>().ToList()) { }
    }
}