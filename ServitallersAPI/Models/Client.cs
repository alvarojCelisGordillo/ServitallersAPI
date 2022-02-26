using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ServitallersAPI.Models.Enums;

namespace ServitallersAPI.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EnumDataType(typeof(Enums.ClientType))]
        public ClientType ClientType { get; set; }
        [Required]
        [EnumDataType(typeof(Enums.TypeOfIdentification))]
        public TypeOfIdentification TypeOfIdentification { get; set; }
        [Required]
        [Range(9999999, int.MaxValue)]
        public int NumberOfIdentification { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        public string FirstLastName { get; set; }
        [Required]
        public string SecondLastName { get; set; }
        public Int64? TelephoneNumber { get; set; }
        [Required]
        public Int64 MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Website { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(0, 138)]
        public Cities CityId { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public Int64 ContactPhone { get; set; }
        public Int64? ContactPhone2 { get; set; }
        [Required]
        public bool Credit { get; set; }
        public Int64 CreditAmount { get; set; }
        [AllowNull]
        public int DaysCredit { get; set; }
        

        public bool Declarant { get; set; }
        public int ReteFuente { get; set; }
        public int ReteIva { get; set; }
        
    }
}
