using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
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
    
    private static int _currentId = 4;
    
    // Lista Kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    // Odbieranie danych z formularza, zapis kontaktu i powrót do list kontaktów
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
        
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Details(int id)
    {
        
        return View(_contacts[id]);
    }

    public IActionResult Back()
    {
        return View("Index", _contacts);
    }
}