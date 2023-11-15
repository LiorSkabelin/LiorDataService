using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            user.ID = int.Parse(reader["id"].ToString());
            user.Firstname = reader["firstName"].ToString();
            user.Lastname = reader["lastName"].ToString();
            user.Email = reader["email"].ToString();
            user.Password = reader["password"].ToString();
            user.Gender = bool.Parse(reader["gender"].ToString());
            user.IsManger = bool.Parse(reader["isManager"].ToString());
            user.Bday = DateTime.Parse(reader["Bday"].ToString());
            return user;
        }
        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", user.ID);
            command.Parameters.AddWithValue("@Name", user.Firstname);
            command.Parameters.AddWithValue("@Lastname", user.Lastname);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Gender", user.Gender);
            command.Parameters.AddWithValue("@IsManger", user.IsManger);
            command.Parameters.AddWithValue("@Bday", user.Bday);
          

        }
        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM tbUser";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }
        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM tbUser WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }
        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO tbUser (firstName, lastName, [password], email, gender, City, bDay, isManger, isCoach) VALUES ('@id', '@firstName', '@lastName', '@email', @password, @gender,@isManager,@Bday,@isCoach)";
            LoadParameters(user);
            return ExecuteCRUD();
        }

        public int Update(User user)
        {
            command.CommandText = "UPDATE tbUser SET firstName = '@firstName', lastName = '@lastName', [password] = '@password', email = '@email', gender = @gender, bDay =@Bday, isManger = @isManager, isCoach = @isCoach";
            LoadParameters(user);
            return ExecuteCRUD();
        }
        public int DeleteByID(User user)
        {
            command.CommandText = "DELETE FROM tbUser WHERE  (id = 1)";
            LoadParameters(user);
            return ExecuteCRUD();
        }
    }
}
