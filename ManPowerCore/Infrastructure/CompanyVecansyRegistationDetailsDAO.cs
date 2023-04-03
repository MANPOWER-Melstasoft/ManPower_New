using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Infrastructure
{
    public interface CompanyVecansyRegistationDetailsDAO
    {
        int SaveCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails, DBConnection dbConnection);
        int UpdateCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails, DBConnection dbConnection);
        List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails(DBConnection dbConnection);
        List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationFilterDetails(string runPosition, string runYear, DBConnection dbConnection);
        CompanyVecansyRegistationDetails GetCompanyVecansyRegistationDetails(int id, DBConnection dbConnection);

    }

    public class CompanyVecansyRegistationDetailsDAOImpl : CompanyVecansyRegistationDetailsDAO
    {



        public int getMaxCompanyVecansyRegistationDetailsId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM COMPANY_VACANCY_REGISTATION_DETAILS";
            int orderId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (orderId == 0)
            {
                orderId = 1;
            }
            else
            {
                orderId += 1;
            }


            return orderId;
        }

        public int SaveCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxCompanyVecansyRegistationDetailsId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO COMPANY_VACANCY_REGISTATION_DETAILS" +
                "(DATE, ADDRESS, WEBSITE_LINK, BR_NUMBER, JOB_POSITION, CAREER_PATH, SALARY_LEVEL, NUMBER_OF_VACANCY, NAME, POSITION, CONTACT_NUMBER, " +
                "WHATSAPP_NUMBER, LEVELS, EMAIL, Vacancy_District_Id, Vacancy_DS_Division_Id, Company_Name) " +

                 "VALUES(@VDate, @VAddress, @WebSiteLink, @BusinessRegistationNumber, @JobPosition, @CareerPath, @SalaryLevel, @NumberOfVacancy, @ContactPersonName, " +
                 "@ContactPersonPosition, @ContactNumber, @WhatsappNumber, @VLevels, @ContactPersonEmail, @DistrictId, @DSDivisionId, @CompanyName) ";


            //dbConnection.cmd.Parameters.AddWithValue("@id", id);
            dbConnection.cmd.Parameters.AddWithValue("@VDate", companyVecansyRegistationDetails.VDate);
            dbConnection.cmd.Parameters.AddWithValue("@VAddress", companyVecansyRegistationDetails.VAddress);
            dbConnection.cmd.Parameters.AddWithValue("@WebSiteLink", companyVecansyRegistationDetails.WebSiteLink);
            dbConnection.cmd.Parameters.AddWithValue("@BusinessRegistationNumber", companyVecansyRegistationDetails.BusinessRegistationNumber);
            dbConnection.cmd.Parameters.AddWithValue("@JobPosition", companyVecansyRegistationDetails.JobPosition);
            dbConnection.cmd.Parameters.AddWithValue("@CareerPath", companyVecansyRegistationDetails.CareerPath);
            dbConnection.cmd.Parameters.AddWithValue("@SalaryLevel", companyVecansyRegistationDetails.SalaryLevel);
            dbConnection.cmd.Parameters.AddWithValue("@NumberOfVacancy", companyVecansyRegistationDetails.NumberOfVacancy);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonEmail", companyVecansyRegistationDetails.ContactPersonEmail);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonPosition", companyVecansyRegistationDetails.ContactPersonPosition);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", companyVecansyRegistationDetails.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", companyVecansyRegistationDetails.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@VLevels", companyVecansyRegistationDetails.VLevels);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonName", companyVecansyRegistationDetails.ContactPersonName);
            dbConnection.cmd.Parameters.AddWithValue("@CompanyName", companyVecansyRegistationDetails.CompanyName);
            dbConnection.cmd.Parameters.AddWithValue("@DistrictId", companyVecansyRegistationDetails.VDistrictId);
            dbConnection.cmd.Parameters.AddWithValue("@DSDivisionId", companyVecansyRegistationDetails.VDsId);




            dbConnection.cmd.ExecuteNonQuery();

            return 1;
        }

        public int UpdateCompanyVecansyRegistationDetails(CompanyVecansyRegistationDetails companyVecansyRegistationDetails, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE COMPANY_VACANCY_REGISTATION_DETAILS SET PROGRAM_TYPE_ID =@Date, ADDRESS=@Address, WEBSITE_LINK = @WebSiteLink," +
                " BR_NUMBER = @BusinessRegistationNumber, JOB_POSITION = @JobPosition , CAREER_PATH = @CareerPath,SALARY_LEVEL = @SalaryLevel, NUMBER_OF_VACANCY = @NumberOfVacancy," +
                " NAME = @Name, POSITION = @Position, CONTACT_NUMBER = @ContactNumber," +
                " WHATSAPP_NUMBER = @WhatsappNumber ,LEVELS = @Levels, EMAIL=@Email WHARE ID = @CompanyVacansyRegistationDetailsId";



            dbConnection.cmd.Parameters.AddWithValue("@CompanyVecansyRegistationDetailsId", companyVecansyRegistationDetails.CompanyVacansyRegistationDetailsId);
            dbConnection.cmd.Parameters.AddWithValue("@VDate", companyVecansyRegistationDetails.VDate);
            dbConnection.cmd.Parameters.AddWithValue("@VAddress", companyVecansyRegistationDetails.VAddress);
            dbConnection.cmd.Parameters.AddWithValue("@WebSiteLink", companyVecansyRegistationDetails.WebSiteLink);
            dbConnection.cmd.Parameters.AddWithValue("@BusinessRegistationNumber", companyVecansyRegistationDetails.BusinessRegistationNumber);
            dbConnection.cmd.Parameters.AddWithValue("@JobPosition", companyVecansyRegistationDetails.JobPosition);
            dbConnection.cmd.Parameters.AddWithValue("@CareerPath", companyVecansyRegistationDetails.CareerPath);
            dbConnection.cmd.Parameters.AddWithValue("@SalaryLevel", companyVecansyRegistationDetails.SalaryLevel);
            dbConnection.cmd.Parameters.AddWithValue("@NumberOfVacancy", companyVecansyRegistationDetails.NumberOfVacancy);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonName", companyVecansyRegistationDetails.ContactPersonName);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonPosition", companyVecansyRegistationDetails.ContactPersonPosition);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", companyVecansyRegistationDetails.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", companyVecansyRegistationDetails.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@VLevels", companyVecansyRegistationDetails.VLevels);
            dbConnection.cmd.Parameters.AddWithValue("@ContactPersonName", companyVecansyRegistationDetails.ContactPersonName);




            return dbConnection.cmd.ExecuteNonQuery();
        }


        public List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationDetails(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_VACANCY_REGISTATION_DETAILS ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CompanyVecansyRegistationDetails>(dbConnection.dr);

        }


        public List<CompanyVecansyRegistationDetails> GetAllCompanyVecansyRegistationFilterDetails(string runPosition, string runYear, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_VACANCY_REGISTATION_DETAILS  WHERE JOB_POSITION = '" + runPosition + "' and YEAR(DATE) = '" + runYear + "' ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<CompanyVecansyRegistationDetails>(dbConnection.dr);
        }


        public CompanyVecansyRegistationDetails GetCompanyVecansyRegistationDetails(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_VACANCY_REGISTATION_DETAILS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<CompanyVecansyRegistationDetails>(dbConnection.dr);

        }


    }


}
