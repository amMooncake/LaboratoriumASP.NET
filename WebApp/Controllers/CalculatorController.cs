using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(Operators? op, double? x, double? y)
    {
        
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);

        if (x == null || y == null)
        {
            ViewBag.ErrorMessage = "Please fill all values";
            return View("CalculatorError");
        }

        Console.WriteLine(op);
        if (op is null)
        {
            ViewBag.ErrorMessage = "Invalid operation";
            return View("CalculatorError");
        }
        
        
        double? result = 0.0d;
        switch(op)
        {
            case Operators.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operators.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operators.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operators.Div:
                result = x / y;
                ViewBag.Operator = ":";
                break;
        }
        ViewBag.result = result;
        ViewBag.x = x;
        ViewBag.y = y;
        return View();
    }
    
    
}


public enum Operators
{
    Add, Sub, Mul, Div
}