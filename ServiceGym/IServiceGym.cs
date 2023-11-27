using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Model;

namespace ServiceGym
{
    [ServiceContract]
    public interface IServiceGym
    {
        //Devices
        [OperationContract] DevicesList SelectAll();
        [OperationContract] int InsertDevices(Devices devices);
        [OperationContract] int UpdateDevices(Devices devices);
        [OperationContract] int DeleteDevices(Devices devices);


        //Gymer
        [OperationContract] GymerList SelectAllGymers();
        [OperationContract] int InsertGymer(Gymer gymer);
        [OperationContract] int UpdateGymer(Gymer gymer);
        [OperationContract] int DeleteGymer(Gymer gymer);


        //TrainingProgram
        [OperationContract] TrainingpList SelectAllTrainingp();
        [OperationContract] int InsertTrainingProgram(TrainingProgram trainingp);
        [OperationContract] int UpdateTrainingProgram(TrainingProgram trainingp);
        [OperationContract] int DeleteTrainingProgram(TrainingProgram trainingp);


        //User
        [OperationContract] UserList SelectAllUserList();
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);

    }
}
