using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TrainingMainDAO
    {
        int Save(TrainingMain trainingMain, DBConnection dbConnection);

        int Update(TrainingMain trainingMain, DBConnection dbConnection);

        List<TrainingMain> GetAllTrainingMain(DBConnection dbConnection);
    }

    public class TrainingMainDAOSqlImpl : TrainingMainDAO
    {
        public int Save(TrainingMain trainingMain, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO Training_Main (Title, Content, Created_date, Created_user, Member_Count, Open_date, End_date, Post_img) " +
                "VALUES (@Title, @Content, @CreatedDate, @CreatedUser, @MemberCount, @OpenDate, @EndDate, @PostImg) ";

            dbConnection.cmd.Parameters.AddWithValue("@Title", trainingMain.Title);
            dbConnection.cmd.Parameters.AddWithValue("@Content", trainingMain.Content);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingMain.Created_Date);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingMain.Created_User);
            dbConnection.cmd.Parameters.AddWithValue("@MemberCount", trainingMain.Member_Count);
            dbConnection.cmd.Parameters.AddWithValue("@OpenDate", trainingMain.Start_Date);
            dbConnection.cmd.Parameters.AddWithValue("@EndDate", trainingMain.End_date);
            dbConnection.cmd.Parameters.AddWithValue("@PostImg", trainingMain.Post_img);



            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public int Update(TrainingMain trainingMain, DBConnection dbConnection)
        {
            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "UPDATE Training_Main SET Title = @Title, Content = @Content, Created_date = @CreatedDate, " +
                                "Created_user = @CreatedUser, Member_Count = @MemberCount, Open_date = @OpenDate, " +
                                "End_date = @EndDate, Post_img = @PostImg, Is_Active = @IsActive WHERE Id = @Id";

            dbConnection.cmd.Parameters.AddWithValue("@Title", trainingMain.Title);
            dbConnection.cmd.Parameters.AddWithValue("@Content", trainingMain.Content);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", trainingMain.Created_Date);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", trainingMain.Created_User);
            dbConnection.cmd.Parameters.AddWithValue("@MemberCount", trainingMain.Member_Count);
            dbConnection.cmd.Parameters.AddWithValue("@OpenDate", trainingMain.Start_Date);
            dbConnection.cmd.Parameters.AddWithValue("@EndDate", trainingMain.End_date);
            dbConnection.cmd.Parameters.AddWithValue("@PostImg", trainingMain.Post_img);
            dbConnection.cmd.Parameters.AddWithValue("@Id", trainingMain.TrainingMainId);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", trainingMain.Is_Active);


            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            return output;
        }

        public List<TrainingMain> GetAllTrainingMain(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Training_Main";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TrainingMain>(dbConnection.dr);
        }
    }
}
