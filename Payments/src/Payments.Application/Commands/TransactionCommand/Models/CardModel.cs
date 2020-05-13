using System;
using System.ComponentModel.DataAnnotations;

namespace Payments.Application.Commands.TransactionCommand.Models
{
    public class CardModel
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string PlaceHolder { get; set; }
        [Required]
        public string CardType { get; set; }
        [Required]
        public string Cvv { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public int Installments { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
