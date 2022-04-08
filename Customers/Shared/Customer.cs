using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Shared
{
    public class Customer
    {
        public int Id { get; set; } = 0;
        //[Required]
        public string Firstname { get; set; }
        //[Required]
        public string Lastname { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        //[DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        //[DataType(DataType.EmailAddress)]
        //[Required]
        public string Email { get; set; }
        //[DataType(DataType.CreditCard)]
        public string BankAccountNumber { get; set; }

    }

}
