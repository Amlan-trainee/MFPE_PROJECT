using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// Model Binder Class for LabReportEntityDto
    /// </summary>
    public class LabReportEntityDtoBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var Request = HttpContext.Current.Request;
            if (Request.Files.Count == 0)
                return false;

            HttpPostedFile file = Request.Files[0];

            var jsonString = Request.Form.Get("labreport");
            var labReportEntityDto = JsonConvert.DeserializeObject<LabReportEntityDto>(jsonString);
            if (labReportEntityDto != null)
            {
                labReportEntityDto.File = file;
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                labReportEntityDto.LabReport = filename;
                bindingContext.Model = labReportEntityDto;
                return true;
            }
            return false;

        }
    }
}