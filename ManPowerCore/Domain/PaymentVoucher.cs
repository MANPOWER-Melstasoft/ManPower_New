using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]
    public class PaymentVoucher
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Supplier_Id")]
        public int SupplierId { get; set; }

        [DBField("Voucher_Number")]
        public string VoucherNumber { get; set; }

        [DBField("Voucher_Date")]
        public DateTime VoucherDate { get; set; }

        [DBField("Payee_Name")]
        public string PayeeName { get; set; }

        [DBField("Payee_Address")]
        public string PayeeAddress { get; set; }

        [DBField("Cheque_Number")]
        public string ChequeNumber { get; set; }

        [DBField("Total_Amount")]
        public decimal TotalAmount { get; set; }

        [DBField("Is_Voucher_Authorized")]
        public int IsVoucherAuthorized { get; set; }

        [DBField("Vou_Authorized_Date")]
        public DateTime? VouAuthorizedDate { get; set; }

        [DBField("Vou_Authorized_User")]
        public string VouAuthorizedUser { get; set; }

        [DBField("Is_Pay_Authorized")]
        public int IsPayAuthorized { get; set; }

        [DBField("Pay_Authorized_Date")]
        public DateTime PayAuthorizedDate { get; set; }

        [DBField("Pay_Authorized_User")]
        public string PayAuthorizedUser { get; set; }

        [DBField("Is_Canceled")]
        public int IsCanceled { get; set; }

        [DBField("CanCeled_Date")]
        public DateTime CanceledDate { get; set; }

        [DBField("Canceled_User")]
        public string CanceledUser { get; set; }

        [DBField("Created_User")]
        public string CreatedUser { get; set; }

        [DBField("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [DBField("Bank_Account")]
        public string BankAccount { get; set; }

        [DBField("Recommended_By")]
        public string RecommendedUser { get; set; }
        [DBField("Reconmmended_Date")]
        public DateTime RecommendedDate { get; set; }

        [DBField("Certify_By")]
        public string CertifyUser { get; set; }
        [DBField("Certify_Date")]
        public DateTime CertifyDate { get; set; }

        [DBField("Paid_By")]
        public string CheckBy { get; set; }
        [DBField("Paid_Date")]
        public DateTime CheckDate { get; set; }

        [DBField("Status")]
        public int Status { get; set; }
    }

}
