using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        
        /*
         * Napisz metodę Age, która przyjmije parametr z datą urodzin i wyświetla wiek w latach, miesiącach i dnia.
         */
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator( Operator? op, double? x, double? y)
    {
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);

        if (x == null || y == null)
        {
            ViewBag.ErrorMessage = "Please fill all values";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Invalid operation";
            return View("CalculatorError");
        }
        
        
        double? result = 0.0d;
        switch(op)
        {
            case Operator.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operator.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                result = x / y;
                ViewBag.Operator = ":";
                break;
        }
        ViewBag.result = result;
        ViewBag.x = x;
        ViewBag.y = y;
        return View();
    }

    public IActionResult Age(DateTime birthDate)
    {  
        DateTime currentDate = DateTime.Now;
        
        int years = currentDate.Year - birthDate.Year;
        int months = currentDate.Month - birthDate.Month;
        int days = currentDate.Day - birthDate.Day;
        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(currentDate.AddMonths(-1).Year, currentDate.AddMonths(-1).Month);;
        }
        
        if (months < 0)
        {
            years--;
            months += 12;
        }

        if (birthDate >= DateTime.Now)
        {
            ViewBag.Years = 0; ViewBag.Months = 0; ViewBag.Days = 0;
        }
        else
        {
            ViewBag.Years = years;
            ViewBag.Months = months;
            ViewBag.Days = days;
        }
        
        
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div
}

