using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class VoucherDetail
    {
        [DBField("Payment_Voucher_Id")]
        public int PaymentVoucherId { get; set; }

        [DBField("Account_Code_Id")]
        public int AccountCodeId { get; set; }

        [DBField("Amount")]
        public decimal Amount { get; set; }
    }
}
