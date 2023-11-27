using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.TrainingProgram;

namespace ViewModel
{
    public class TrainingProgramDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new TrainingProgram();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            TrainingProgram trainingp = entity as TrainingProgram;
            trainingp.ID = int.Parse(reader["id"].ToString());
            trainingp.Name = reader["name"].ToString();
            trainingp.Description = reader["description"].ToString();
            trainingp.Userld= int.Parse(reader["userId"].ToString());
            trainingp.Approved = bool.Parse(reader["aprroved"].ToString());
            trainingp.Level = reader["level"].ToString();

            return trainingp;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            TrainingProgram trainingp = entity as TrainingProgram;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", trainingp.ID);
            command.Parameters.AddWithValue("@Name", trainingp.Name);
            command.Parameters.AddWithValue("@Level", trainingp .Level);
            command.Parameters.AddWithValue("@Userld", trainingp.Userld);
        }
        public TrainingpList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblTrainingp";
            TrainingpList list = new TrainingpList(ExecuteCommand());
            return list;
        }
        public TrainingProgram SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblTrainingp WHERE id=" + id;
            TrainingpList list = new TrainingpList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(TrainingProgram trainingp)
        {
            command.CommandText = "INSERT INTO tblTrainingp (name) VALUES ('@Name'))";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }

        public int Update(TrainingProgram trainingp)
        {
            command.CommandText = "UPDATE tblTrainingp SET name = '@Nmae', description = '@Description', userId = @UserId";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }
        public int DeleteByID(TrainingProgram trainingp)
        {
            command.CommandText = "DELETE FROM tblTrainingp WHERE  (tblTrainingp.id = 1)";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }
    }
}
