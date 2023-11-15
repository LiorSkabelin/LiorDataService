using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class Gymer : BaseEntity
    {
        protected int mycoach;
        protected int weight;
        protected int height;

        public int Mycoach { get { return mycoach; } set { mycoach = value; } }
        public int Weight { get { return weight; } set { weight = value; } }
        public int Height { get { return height; } set { height = value; } }
  
        public class GymerList : List<Gymer>
        {
            //בנאי ברירת מחדל - אוסף ריק
            public GymerList() { }
            //המרה אוסף גנרי לרשימת משתמשים
            public GymerList(IEnumerable<Gymer> list)
                : base(list) { }
            //המרה מטה מטיפוס בסיס לרשימת משתמשים
            public GymerList(IEnumerable<BaseEntity> list)
                : base(list.Cast<Gymer>().ToList()) { }
        }

    }
}
