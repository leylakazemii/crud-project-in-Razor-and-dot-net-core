using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Shared
{
    [Index(nameof(Email), IsUnique = false)]
    public class Customer
    {
        public int Id { get; set; } = 0;
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }

        public DateTime? DateOfBirth { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        [EmailAddressAttribute]
       
        public string Email { get; set; }
        [CreditCardAttribute]
        public string BankAccountNumber { get; set; }

    }

}
