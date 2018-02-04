using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Vendor
{
    public class VendorCreateVm
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Enter Vendor Name")]
        [StringLength(100, ErrorMessage = "Maximun length is 100 characters")]
        [Index(IsUnique = true)]
        [DisplayName("Vendor Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Enter Short Name")]
        [StringLength(10, ErrorMessage = "Maximun length is 10 characters")]
        [RegularExpression(@"^[A-Z]{4,10}$", ErrorMessage = "Only uppercase letters are allowed with no empty space. Range 4-10 character")]
        [DisplayName("Short Name")]
        public string ShortName { get; set; }


        //[DisplayName("Email Address")]
        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]{1,20}@[a-zA-Z0-9-]{1,10}.[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Address")]
        [Required(ErrorMessage = "Enter your Email Address")]
        public string Email { get; set; }


        [DisplayName("Contact")]
        [RegularExpression(@"^(([0]{2}|[\+])[8]{2})[0][1][5-9][\d]{8}$", ErrorMessage = "Invalid Phone Number. Number Format is +8801xxxxxxxxx or 008801xxxxxxxxx")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your Phone Number. Format is +8801xxxxxxxxx or 008801xxxxxxxxx")]
        public string ContactNo { get; set; }



        [Required(ErrorMessage = "Enter your Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Put your Comments")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
    }
}
