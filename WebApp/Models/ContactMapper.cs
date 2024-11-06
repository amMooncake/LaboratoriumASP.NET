namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel model)
    {
        return new ContactEntity()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Category = model.Category,
        };
    }

    public static ContactModel FromEntity(ContactEntity model)
    {
        return new ContactModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Category = model.Category,
        };
    }
}