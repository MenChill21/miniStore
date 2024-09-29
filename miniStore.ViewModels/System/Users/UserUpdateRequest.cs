using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace miniStore.ViewModels.System.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên")]
        public string FirstName { get; set; }

        [Display(Name = "Họ")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

    }
}
