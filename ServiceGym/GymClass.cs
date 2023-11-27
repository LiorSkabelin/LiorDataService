using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;

namespace ServiceGym
{
    public class GymService : IServiceGym
    {
        public int DeleteDevices(Devices devices)
        {
            DevicesDB db = new DevicesDB();
            return db.DeleteByID(devices);
        }

        public int DeleteGymer(Gymer gymer)
        {
            GymerBD db = new GymerBD();
            return db.DeleteByID(gymer);
        }

        public int DeleteTrainingProgram(TrainingProgram trainingp)
        {
            TrainingProgramDB db = new TrainingProgramDB();
            return db.DeleteByID(trainingp);
        }

        public int DeleteUser(User user)
        {
            UserDB db = new UserDB();
            return db.DeleteByID(user);
        }

        public int InsertDevices(Devices devices)
        {
            DevicesDB db = new DevicesDB();
            return db.Insert(devices);
        }

        public int InsertGymer(Gymer gymer)
        {
            GymerBD db = new GymerBD();
            return db.Insert(gymer);
        }

        public int InsertTrainingProgram(TrainingProgram trainingp)
        {
            TrainingProgramDB db = new TrainingProgramDB();
            return db.Insert(trainingp);
        }

        public int InsertUser(User user)
        {
            UserDB db = new UserDB();
            return db.Insert(user);
        }

        public DevicesList SelectAll()
        {
            DevicesDB db = new DevicesDB();
            DevicesList list = db.SelectAll();
            return list;
        }

        public GymerList SelectAllGymers()
        {
            GymerBD db = new GymerBD();
            GymerList list = db.SelectAll();
            return list;
        }

        public TrainingpList SelectAllTrainingp()
        {
            TrainingProgramDB db = new TrainingProgramDB();
            TrainingpList list = db.SelectAll();
            return list;
        }

        public UserList SelectAllUserList()
        {
            UserDB db = new UserDB();
            UserList list = db.SelectAll();
            return list;
        }

        public int UpdateDevices(Devices devices)
        {
            DevicesDB db = new DevicesDB();
            return db.Update(devices);
        }

        public int UpdateGymer(Gymer gymer)
        {
            GymerBD db = new GymerBD();
            return db.Update(gymer);
        }

        public int UpdateTrainingProgram(TrainingProgram trainingp)
        {
            TrainingProgramDB db = new TrainingProgramDB();
            return db.Update(trainingp);
        }

        public int UpdateUser(User user)
        {
            UserDB db = new UserDB();
            return db.Update(user);
        }
    }
}
