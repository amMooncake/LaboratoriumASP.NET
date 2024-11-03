namespace WebApp.Models.Services;
public class MemoryContactService : IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Id = 1,
                FirstName = "Aleksy",
                LastName = "Malawski",
                Email = "aleksy@gmail.com",
                PhoneNumber = "123 456 789",
                BirthDate = new DateOnly(year: 2000, month: 1, day: 1),
            }
        },
        {
            2, new ContactModel()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "555-1234",
                BirthDate = new DateOnly(1990, 5, 15),
            }
        },
        {
            3, new ContactModel()
            {
                Id = 3,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "555-5678",
                BirthDate = new DateOnly(1985, 10, 22),
            }
        },
        {
            4, new ContactModel()
            {
                Id = 4,
                FirstName = "Michael",
                LastName = "Johnson",
                Email = "michael.johnson@example.com",
                PhoneNumber = "555-8765",
                BirthDate = new DateOnly(1978, 3, 30),
            }
        }
    };
    private static int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }
    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }
    public void Delete(int id)
    {
        _contacts.Remove(id);
    }
    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }
    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}