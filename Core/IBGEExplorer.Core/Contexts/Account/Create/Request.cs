using System.ComponentModel.DataAnnotations;

namespace IBGEExplorer.Core.Contexts.Account.Create;

public class Request
{
    [Required(ErrorMessage = "Informe um email")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "E-mail invalido")]
    [EmailAddress(ErrorMessage = "E-mail no formato invalido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe uma senha")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Senha deve conter 8 ou no maxima 16 caracteres")]
    public string Password { get; set; }
}