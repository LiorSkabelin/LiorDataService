using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Trainingp;

namespace ViewModel
{
    public class TrainingpDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Trainingp();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Trainingp trainingp = entity as Trainingp;
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
            Trainingp trainingp = entity as Trainingp;
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
        public Trainingp SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblTrainingp WHERE id=" + id;
            TrainingpList list = new TrainingpList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Trainingp trainingp)
        {
            command.CommandText = "INSERT INTO tblTrainingp (name) VALUES ('@Name'))";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }

        public int Update(Trainingp trainingp)
        {
            command.CommandText = "UPDATE tblTrainingp SET name = '@Nmae', description = '@Description', userId = @UserId";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }
        public int DeleteByID(Trainingp trainingp)
        {
            command.CommandText = "DELETE FROM tblTrainingp WHERE  (tblTrainingp.id = 1)";
            LoadParameters(trainingp);
            return ExecuteCRUD();
        }
    }
}
