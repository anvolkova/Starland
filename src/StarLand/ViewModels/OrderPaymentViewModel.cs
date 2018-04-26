using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StarLand.ViewModels
{
    public class OrderPaymentViewModel
    {
        public string Name { get; set; }
        public double TotalPrice { get; set; }
        public int PlanetId { get; set; }

        [Required, DataType(DataType.CreditCard)]
            //CreditCard(ErrorMessage = "Please enter a valid card number")]
        public string CardNumber { get; set; }
        [Required, Range(1,12)]
        public int Month { get; set; }
        [Required, Range(2000,2030)]
        public int Year { get; set; }
        [Required, MaxLength(256)]
        public string NameOnCard { get; set; }
        [Required, StringLength(3)]
        public string CVV { get; set; }
        
    }
}
