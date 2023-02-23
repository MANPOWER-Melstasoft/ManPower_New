using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DependentDAO
    {
        List<Dependant> GetAllDependant(DBConnection dbConnection);

        Dependant GetDependantById(int id, DBConnection dbConnection);

        int SaveDependantSpouse(Dependant dependant, DBConnection dbConnection);
        int SaveDependantOther(Dependant dependant, DBConnection dbConnection);
        int UpdateDependantSpouse(Dependant dependant, DBConnection dbConnection);
        int UpdateDependantOther(Dependant dependant, DBConnection dbConnection);

        List<Dependant> GetDependantByEmpId(int empId, DBConnection dbConnection);
    }

    public class DependentDAOImpl : DependentDAO
    {
        public int SaveDependantSpouse(Dependant dependant, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO DEPENDANT(DEPENDENT_TYPE_ID,EMPLOYEE_ID,FIRST_NAME,LAST_NAME, " +
                "NIC,PASSPORT_NO,BIRTH_CERTIFICATE_NUMBER,DATE_OF_BIRTH,RELATIONSHIP,SPECIAL_REMARKS,MARRIAGE_DATE,MARRIAGE_CERTIFICATE_NUMBER,WORKING_COMPANY,CITY,ATTACHMENTS)" +
                " VALUES(@DependantTypeId,@EmployeeID,@FirstName,@LName,@DependantNIC,@DependantPassportNo, " +
                "@BirthCertificateNumber,@DateOfBirth,@RelationshipToEmp,@SpecialRemarks,@MDate,@MCertificateNo,@WorkingCompany,@DependantCity, @DocumentUploads)";

            dbConnection.cmd.Parameters.AddWithValue("@DependantTypeId", dependant.DependantTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeID", dependant.EmpId);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", dependant.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LName", dependant.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@DependantNIC", dependant.DependantNIC);
            dbConnection.cmd.Parameters.AddWithValue("@DependantPassportNo", dependant.DependantPassportNo);
            dbConnection.cmd.Parameters.AddWithValue("@BirthCertificateNumber", dependant.BirthCertificateNumber);
            dbConnection.cmd.Parameters.AddWithValue("@DateOfBirth", dependant.Dob);
            dbConnection.cmd.Parameters.AddWithValue("@RelationshipToEmp", dependant.RelationshipToEmp);
            dbConnection.cmd.Parameters.AddWithValue("@SpecialRemarks", dependant.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@MDate", dependant.MarriageDate);
            dbConnection.cmd.Parameters.AddWithValue("@MCertificateNo", dependant.MarriageCertificateNo);
            dbConnection.cmd.Parameters.AddWithValue("@WorkingCompany", dependant.WorkingCompany);
            dbConnection.cmd.Parameters.AddWithValue("@DependantCity", dependant.City);
            dbConnection.cmd.Parameters.AddWithValue("@DocumentUploads", dependant.DocumentUploads);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }

        public int SaveDependantOther(Dependant dependant, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO DEPENDANT(DEPENDENT_TYPE_ID,EMPLOYEE_ID,FIRST_NAME,LAST_NAME, " +
                "PASSPORT_NO,BIRTH_CERTIFICATE_NUMBER,DATE_OF_BIRTH,RELATIONSHIP,SPECIAL_REMARKS,ATTACHMENTS)" +
                " VALUES(@DependantTypeId,@EmployeeID,@FirstName,@LName,@DependantPassportNo, " +
                "@BirthCertificateNumber,@DateOfBirth,@RelationshipToEmp,@SpecialRemarks, @DocumentUploads)";

            dbConnection.cmd.Parameters.AddWithValue("@DependantTypeId", dependant.DependantTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@EmployeeID", dependant.EmpId);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", dependant.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LName", dependant.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@DependantPassportNo", dependant.DependantPassportNo);
            dbConnection.cmd.Parameters.AddWithValue("@BirthCertificateNumber", dependant.BirthCertificateNumber);
            dbConnection.cmd.Parameters.AddWithValue("@DateOfBirth", dependant.Dob);
            dbConnection.cmd.Parameters.AddWithValue("@RelationshipToEmp", dependant.RelationshipToEmp);
            dbConnection.cmd.Parameters.AddWithValue("@SpecialRemarks", dependant.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@DocumentUploads", dependant.DocumentUploads);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }

        public int UpdateDependantSpouse(Dependant dependant, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE DEPENDANT SET DEPENDENT_TYPE_ID = @DependantTypeId," +
                "FIRST_NAME = @FirstName,LAST_NAME = @LName, " +
                "NIC = @DependantNIC,PASSPORT_NO = @DependantPassportNo ,BIRTH_CERTIFICATE_NUMBER = @BirthCertificateNumber ," +
                "DATE_OF_BIRTH = @DateOfBirth ,RELATIONSHIP = @RelationshipToEmp ,SPECIAL_REMARKS = @SpecialRemarks ,MARRIAGE_DATE = @MDate," +
                "MARRIAGE_CERTIFICATE_NUMBER = @MCertificateNo ,WORKING_COMPANY = @WorkingCompany ,CITY = @DependantCity WHERE ID = @DependantId";

            dbConnection.cmd.Parameters.AddWithValue("@DependantTypeId", dependant.DependantTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", dependant.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LName", dependant.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@DependantNIC", dependant.DependantNIC);
            dbConnection.cmd.Parameters.AddWithValue("@DependantPassportNo", dependant.DependantPassportNo);
            dbConnection.cmd.Parameters.AddWithValue("@BirthCertificateNumber", dependant.BirthCertificateNumber);
            dbConnection.cmd.Parameters.AddWithValue("@DateOfBirth", dependant.Dob);
            dbConnection.cmd.Parameters.AddWithValue("@RelationshipToEmp", dependant.RelationshipToEmp);
            dbConnection.cmd.Parameters.AddWithValue("@SpecialRemarks", dependant.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@MDate", dependant.MarriageDate);
            dbConnection.cmd.Parameters.AddWithValue("@MCertificateNo", dependant.MarriageCertificateNo);
            dbConnection.cmd.Parameters.AddWithValue("@WorkingCompany", dependant.WorkingCompany);
            dbConnection.cmd.Parameters.AddWithValue("@DependantCity", dependant.City);
            dbConnection.cmd.Parameters.AddWithValue("@DependantId", dependant.DependantId);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }

        public int UpdateDependantOther(Dependant dependant, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "UPDATE DEPENDANT SET DEPENDENT_TYPE_ID = @DependantTypeId," +
                "FIRST_NAME = @FirstName,LAST_NAME = @LName, " +
                "PASSPORT_NO = @DependantPassportNo ,BIRTH_CERTIFICATE_NUMBER = @BirthCertificateNumber ," +
                "DATE_OF_BIRTH = @DateOfBirth ,RELATIONSHIP = @RelationshipToEmp ,SPECIAL_REMARKS = @SpecialRemarks WHERE ID = @DependantId";

            dbConnection.cmd.Parameters.AddWithValue("@DependantTypeId", dependant.DependantTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", dependant.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LName", dependant.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@DependantPassportNo", dependant.DependantPassportNo);
            dbConnection.cmd.Parameters.AddWithValue("@BirthCertificateNumber", dependant.BirthCertificateNumber);
            dbConnection.cmd.Parameters.AddWithValue("@DateOfBirth", dependant.Dob);
            dbConnection.cmd.Parameters.AddWithValue("@RelationshipToEmp", dependant.RelationshipToEmp);
            dbConnection.cmd.Parameters.AddWithValue("@SpecialRemarks", dependant.Remarks);
            dbConnection.cmd.Parameters.AddWithValue("@DependantId", dependant.DependantId);

            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.cmd.Parameters.Clear();
            return 1;
        }


        public List<Dependant> GetAllDependant(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPENDANT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Dependant>(dbConnection.dr);

        }

        public Dependant GetDependantById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPENDANT WHERE ID=" + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Dependant>(dbConnection.dr);
        }

        public List<Dependant> GetDependantByEmpId(int empId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DEPENDANT WHERE EMPLOYEE_ID=" + empId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Dependant>(dbConnection.dr);
        }
    }
}

