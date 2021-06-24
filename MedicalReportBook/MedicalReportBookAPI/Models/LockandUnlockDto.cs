using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class LockandUnlockDto
    {
        public int Report_Id { get; set; }
        public bool IsActive { get; set; }
    }
}