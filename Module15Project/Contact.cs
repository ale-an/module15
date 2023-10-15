namespace Module15;

public class Contact
{
    public string Name { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }

    public Contact(string name, long phone)
    {
        Name = name;
        Phone = phone;
        Email = string.Empty;
    }

    public Contact(string name, long phone, string email)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}