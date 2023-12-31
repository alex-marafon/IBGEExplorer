﻿using IBGEExplorer.Account.Entities;
using System.ComponentModel.DataAnnotations;

namespace IBGEExplorer.Account.UseCases.Create;

public class Request
{
    [Required(ErrorMessage = "Informe um email")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "E-mail invalido")]
    [EmailAddress(ErrorMessage = "E-mail no formato invalido")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Informe primeiro nome")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome invalido")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Informe seu segundo nome")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Nome invalido")]
    public string LastName { get; set; } = null!;
    

    [Required(ErrorMessage = "Informe uma senha")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Senha deve conter 8 ou no maxima 16 caracteres")]
    public string Password { get; set; } = null!;

    public HashSet<int> RoleIds { get; set; } = null!;

    public static implicit operator User(Request request) =>
        new User()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            CanLogin = true
        };
}