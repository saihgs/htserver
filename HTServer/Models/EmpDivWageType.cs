﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HTServer.Models
{
    public class EmpDivWageType
    {

        [Key]
        public int EmpDivWageTypeID { get; set; }

        [ForeignKey("EmpDivID")]
        public int EmpDivID { get; set; }
        //public EmpEmployerDiv EmpEmployerDiv { get; set; }

        public string WageType { get; set; }
        public string Description { get; set; }
        public int NumOfEmployees { get; set; }
        public int ComPaidPerEmployee { get; set; }
        public int NumOfDependents { get; set; }
        public int ComPaidPerDependent { get; set; }
        public decimal TotalPremPaidByCompany { get; set; }
        public decimal TotalPremPaidByEmployee { get; set; }

        public int? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
