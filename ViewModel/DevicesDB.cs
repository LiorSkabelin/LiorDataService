using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Devices;

namespace ViewModel
{
    public class DevicesDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Devices();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Devices devices = entity as Devices;
            devices.ID = int.Parse(reader["id"].ToString());
            devices.Name = reader["name"].ToString();
            return devices;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Devices devices= entity as Devices;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", devices.ID);
            command.Parameters.AddWithValue("@Name", devices.Name);
        }
        public DevicesList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblDevices";
            DevicesList list = new DevicesList(ExecuteCommand());
            return list;
        }
        public Devices SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblDevices WHERE id=" + id;
            DevicesList list = new DevicesList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Devices devices)
        {
            command.CommandText = "INSERT INTO tblDevices (name) VALUES (@Name)";
            LoadParameters(devices);
            return ExecuteCRUD();
        }

        public int Update(Devices devices) 
        {
            command.CommandText = "UPDATE tblDevices SET id =, name = '@Name' WHERE  (tblDevices.id = 1)";
            LoadParameters(devices);
            return ExecuteCRUD();
        }
        public int DeleteByID(Devices devices) 
        {
            command.CommandText = "DELETE FROM tblDevices WHERE  (id = 1)";
            LoadParameters(devices);
            return ExecuteCRUD();
        }
    }


       
    
}
