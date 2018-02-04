using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ATS.Models.Models.ViewModel.Employee
{
    public class EmployeeEditVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        [DisplayName("Email Address")]
        //[EmailAddress]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]{1,20}@[a-zA-Z0-9-]{1,10}.[a-zA-Z]{2,6}$", ErrorMessage = "Please enter a valid Email Address")]
        [Required(ErrorMessage = "Enter your Email Address")]
        public string Email { get; set; }

    
        [DisplayName("Contact")]
        //[RegularExpression(@"^(([0]{2}|[\+])[8]{2})[0][1][5-9][\d]{8}$", ErrorMessage = "Invalid Phone Number. Number Format is +8801xxxxxxxxx or 008801xxxxxxxxx")]
        [RegularExpression(@"^[0][1][5-9][\d]{8}$", ErrorMessage = "Invalid Phone Number. Number Format is 01xxxxxxxxx. Just 11 digit")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter your Phone Number. Format is 01xxxxxxxxx. Just 11 digit")]
        public string ContactNo { get; set; }


        [Required(ErrorMessage = "Enter Department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Enter Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Enter your Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Code")]
        public string Code { get; set; }

        //[Required(ErrorMessage = "Select a picture")]
        public string Image { get; set; }


        [Required(ErrorMessage = "Select Branch")]
        [DisplayName("Branch")]
        public int BranchId { get; set; }
        public virtual EntityModel.Branch Branch { get; set; }

        [Required(ErrorMessage = "Select Organization")]
        public int OrganizationId { get; set; }

        public List<SelectListItem> OrganizationLookUp { get; set; }
        public List<SelectListItem> BranchLookUp { get; set; }
    }
}
