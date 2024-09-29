using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace miniStore.ViewModels.System.Users
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}
