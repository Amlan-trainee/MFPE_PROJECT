using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Globalization;

namespace MedicalReportBookAPI.Models
{
    public class ConsultancyReportDtoConverter:TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) //check if conversion is possible
        {
            if (sourceType == typeof(string))
                return true;
            return base.CanConvertFrom(context, sourceType);
        }
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) //convert the incoming value
        {
            if(value is string)
            {
                var consultancyReport = new ConsultancyReportDto();
                var reports = value.ToString().Split(new string[] { "}{" }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(s => s.Trim('{', '}'))
                                             .Select(s => s.Split(':'));


                foreach(var repo in reports)
                {
                    consultancyReport.ClinicName = repo[0];
                    consultancyReport.DoctorName = repo[1];
                    consultancyReport.DateofConsultancy =Convert.ToDateTime( repo[2]);
                    consultancyReport.DiseaseName = repo[3];
                    consultancyReport.Prescription = repo[4];
                    consultancyReport.IsActive = Convert.ToBoolean(repo[5]);
                    consultancyReport.UId = Convert.ToInt32(repo[6]);

                }
                return consultancyReport;                
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}