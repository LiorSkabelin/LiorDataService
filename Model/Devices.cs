using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Routing;
using System.Runtime.Serialization;


namespace Model
{
    [DataContract]
    public class Devices : BaseEntity
    {
       
        protected string name;
       
        public string Name { get { return name; } set { name = value; } }
    }
    [CollectionDataContract]
    public class DevicesList : List<Devices>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public DevicesList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public DevicesList(IEnumerable<Devices> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public DevicesList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Devices>().ToList()) { }
    }
}
