using IBGEExplorer.Account.Entities;

namespace IBGEExplorer.Account.UseCases.Get.Contracts;

public class Response
{
    public Response(string firstName, string lastName, string email, List<string> roles)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Roles = roles;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
}
