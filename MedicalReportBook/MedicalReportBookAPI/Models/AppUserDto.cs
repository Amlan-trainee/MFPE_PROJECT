﻿using MedicalReportBookEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicalReportBookAPI.Models
{
    /// <summary>
    /// Dto class for AppUser Table
    /// </summary>
    public class AppUserDto
    {
        
        [Key]
        public int UserId { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Pleasse enter your gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Pleasse enter the phone number")]
        [RegularExpression("^[\\d]{10}", ErrorMessage = "Please put a valid phone number")]
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "EmaiId feild is mandatory")]
        [Index(IsUnique =true)]
        public string EmailId { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Min Length should be 8 and Maximum should be 30", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(30, ErrorMessage = "Min Length should be 8 and Maximum should be 30", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "This must match the Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
       
    }
}