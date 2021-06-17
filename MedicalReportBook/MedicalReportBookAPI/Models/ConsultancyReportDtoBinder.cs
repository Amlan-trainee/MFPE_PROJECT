using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Globalization;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using System.IO;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// Model Binder class for ConsultancyReportDto
    /// </summary>
    public class ConsultancyReportDtoBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var Request = HttpContext.Current.Request;
            if (Request.Files.Count == 0)
                return false;
           
                HttpPostedFile file = Request.Files[0];
            
            var jsonString = Request.Form.Get("prescription");
            var consultancyReportDto = JsonConvert.DeserializeObject<ConsultancyReportDto>(jsonString);
            if(consultancyReportDto!=null)
            {
                consultancyReportDto.File = file;
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                consultancyReportDto.Prescription = filename;
                bindingContext.Model = consultancyReportDto;
                return true;
            }
            return false;


        }
    }
}