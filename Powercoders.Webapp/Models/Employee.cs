namespace Powercoders.Webapp.Models;

public record Employee(uint? Id, string Firstname, string Lastname, string Email)
{
    public uint? Id { get; set; } = Id;
    public string Firstname { get; set; } = Firstname;
    public string Lastname { get; set; } = Lastname;
    public string Email { get; set; } = Email;
}