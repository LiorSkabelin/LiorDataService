using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Gymer;
using static Model.TrainingProgram;

namespace ViewModel
{

    public class GymerBD : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Gymer();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Gymer gymer = entity as Gymer;
            gymer.ID = int.Parse(reader["id"].ToString());
            gymer.Mycoach = int.Parse(reader["mycoach"].ToString());
            gymer.Weight = int.Parse(reader["weight"].ToString());
            gymer.Height = int.Parse(reader["height"].ToString());

            return gymer;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            Gymer gymer = entity as Gymer;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", gymer.ID);
            command.Parameters.AddWithValue("@Weight", gymer.Weight);
            command.Parameters.AddWithValue("@Height", gymer.Height);
            command.Parameters.AddWithValue("Mycoach", gymer.Mycoach);
        }
        public GymerList SelectAll()
        {
            command.CommandText = "SELECT * FROM tblGymer";//fds
            GymerList list = new GymerList(ExecuteCommand());
            return list;
        }
        public Gymer SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tblGymer WHERE id=" + id;
            GymerList list = new GymerList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(Gymer gymer)
        {
            command.CommandText = "INSERT INTO tblGymer (weight, height, myCoach) VALUES(@weight, @height, @myCoach)";
            LoadParameters(gymer);
            return ExecuteCRUD();
        }

        public int Update(Gymer gymer)
        {
            command.CommandText = "UPDATE tblGymer SET myCoach = @myCoach, weight = @weight, height = @height WHERE  (tblGymer.id = 1)";
            LoadParameters(gymer);
            return ExecuteCRUD();
        }
        public int DeleteByID(Gymer gymer)
        {
            command.CommandText = "DELETE FROM tblGymer WHERE  (tblGymer.id = 1)";
            LoadParameters(gymer);
            return ExecuteCRUD();
        }
    }

    
}
