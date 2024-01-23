namespace DelftHornStudio.Models.DTOs;

public class RegistrationDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    //Start student info
    public int Grade { get; set; }
    public string Phone { get; set; }
    public string ParentName { get; set; }
    public string ParentEmail { get; set; }
    public string ParentPhone { get; set; }
    public string ParentAddress { get; set; }
    //End student info
}