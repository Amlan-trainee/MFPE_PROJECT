﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalReportBookBLL;
using MedicalReportBookEntities.Entities;

namespace MedicalReportBookBLL.Tests
{
    /// <summary>
    /// test class for DoctorService
    /// </summary>
    [TestFixture]
    public class DoctorService_Should
    {
        private DoctorService service;
        [OneTimeSetUp]
        public void Init()
        {
            service = new DoctorService();

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            service.Dispose();
        }
        /// <summary>
        /// Test method to test the  ViewConsultancyReportOfPatient of DoctorService
        /// </summary>
        [Test]
        public void ViewConsultancyReportOfPatient()
        {
            var EmilId = "abcd3@gmil.com";
            var DiseaseName = "Cold";
            var result = service.ViewConsultancyReportOfPatient(EmilId, DiseaseName);
            CollectionAssert.IsNotEmpty(result);
        }
        /// <summary>
        /// Test method for the ViewLabReportOfPatient of DoctorService
        /// </summary>
        [Test]
        public void ViewLabReportOfPatient()
        {

            var EmilId = "abcd3@gmil.com";
            var DiseaseName = "Ultrasound";
            var result = service.ViewLabReportOfPatient(EmilId, DiseaseName);
            CollectionAssert.IsNotEmpty(result);
        }
    }
}