﻿using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    [Serializable]

    public class LoanType
    {
        [DBField("Id")]
        public int Id { get; set; }

        [DBField("Loan_Type_Name")]
        public string Loan_Type_Name { get; set; }
    }

}
