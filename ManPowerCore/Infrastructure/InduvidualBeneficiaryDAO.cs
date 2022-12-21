using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface InduvidualBeneficiaryDAO
    {
        int SaveInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary, DBConnection dbConnection);
        List<InduvidualBeneficiary> GetAllInduvidualBeneficiary(DBConnection dbConnection);

        List<InduvidualBeneficiary> GetAllInduvidualBeneficiaryFilter(string runName, DBConnection dbConnection);
    }

    public class InduvidualBeneficiaryDAOImpl : InduvidualBeneficiaryDAO
    {


        public int SaveInduvidualBeneficiary(InduvidualBeneficiary induvidualBeneficiary, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();



            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(BENEFICIARY_TYPE_ID,DISTRICT,DIVISIONAL_SECRETERY) " +
                                           "VALUES(@BeneficiaryTypeId,@District,@DivisionalSecretery) SELECT SCOPE_IDENTITY() ";

            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryTypeId", 1);
            dbConnection.cmd.Parameters.AddWithValue("@District", induvidualBeneficiary.District);
            dbConnection.cmd.Parameters.AddWithValue("@DivisionalSecretery", induvidualBeneficiary.DivisionalSecretery);


            induvidualBeneficiary.BeneficiaryId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());


            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO INDUVIDUAL_BENEFICIARY(ID,NIC, NAME, GENDER, DATE_OF_BIRTH , PERSONAL_ADDRESS, EMAIL, JOB_PREFERENCE, CONTACT_NUMBER, WHATSAPP_NUMBER, SCHOOL_NAME, ADDRESS_OF_SCHOOL, GRADE, PARENT_NIC) " +

                                           "VALUES(@BenificiaryId,@BeneficiaryNic ,@InduvidualBeneficiaryName, @BeneficiaryGender, @DateOfBirth, @PersonalAddress, @BeneficiaryEmail, @JobPreference, @ContactNumber, @WhatsappNumber, @SchoolName, @AddressOfSchool, @SchoolGrade, @ParentNic)";


            dbConnection.cmd.Parameters.AddWithValue("@BenificiaryId", induvidualBeneficiary.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryNic", induvidualBeneficiary.BeneficiaryNic);
            dbConnection.cmd.Parameters.AddWithValue("@InduvidualBeneficiaryName", induvidualBeneficiary.InduvidualBeneficiaryName);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryGender", induvidualBeneficiary.BeneficiaryGender);
            dbConnection.cmd.Parameters.AddWithValue("@DateOfBirth", induvidualBeneficiary.DateOfBirth);
            dbConnection.cmd.Parameters.AddWithValue("@PersonalAddress", induvidualBeneficiary.PersonalAddress);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryEmail", induvidualBeneficiary.BeneficiaryEmail);
            dbConnection.cmd.Parameters.AddWithValue("@JobPreference", induvidualBeneficiary.JobPreference);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", induvidualBeneficiary.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", induvidualBeneficiary.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@SchoolName", induvidualBeneficiary.SchoolName);
            dbConnection.cmd.Parameters.AddWithValue("@AddressOfSchool", induvidualBeneficiary.AddressOfSchool);
            dbConnection.cmd.Parameters.AddWithValue("@SchoolGrade", induvidualBeneficiary.SchoolGrade);
            dbConnection.cmd.Parameters.AddWithValue("@ParentNic", induvidualBeneficiary.ParentNic);

            dbConnection.cmd.ExecuteNonQuery();

            return 1;
        }

        public List<InduvidualBeneficiary> GetAllInduvidualBeneficiary(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM INDUVIDUAL_BENEFICIARY";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<InduvidualBeneficiary>(dbConnection.dr);

        }

        public List<InduvidualBeneficiary> GetAllInduvidualBeneficiaryFilter(string runName, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM INDUVIDUAL_BENEFICIARY WHERE NAME = '" + runName + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<InduvidualBeneficiary>(dbConnection.dr);

        }
    }
}
