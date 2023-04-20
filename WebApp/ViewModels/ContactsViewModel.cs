﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ContactsViewModel
    {
        [Required(ErrorMessage = "Name can't be blank")]
        public string Name { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string Email { get; set; } = null!;

        //required?
        [Required(ErrorMessage = "You must enter a comment")]
        public string Comment { get; set; } = null!;
    }
}
