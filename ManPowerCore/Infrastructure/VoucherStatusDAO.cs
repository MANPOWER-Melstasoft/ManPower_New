using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface VoucherStatusDAO
    {
        List<VoucherStatus> GetAllVoucherStatus(DBConnection dbConnection);
    }

    public class VoucherStatusDAOSqlImpl : VoucherStatusDAO
    {
        public List<VoucherStatus> GetAllVoucherStatus(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Payment_Vou_Status";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<VoucherStatus>(dbConnection.dr);
        }
    }
}
