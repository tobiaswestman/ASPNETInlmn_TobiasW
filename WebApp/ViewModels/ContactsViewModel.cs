﻿using System.ComponentModel.DataAnnotations;
using WebApp.Models.dtos;

namespace WebApp.ViewModels;

public class ContactsViewModel
{
    [Required(ErrorMessage = "You need to write a name")]
    public string Name { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Not a valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You can't send an empy comment")]
    public string Comment { get; set; } = null!;
    public string ConfirmString { get; set; } = "";

    public static implicit operator CommentDTO(ContactsViewModel viewModel)
    {
        return new CommentDTO
        {
            CustomerName = viewModel.Name,
            CustomerEmail = viewModel.Email,
            Comment = viewModel.Comment,
        };
    }
}
