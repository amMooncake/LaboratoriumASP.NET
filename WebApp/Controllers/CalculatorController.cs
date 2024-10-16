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
    
    public IActionResult Result(string op, double? x, double? y)
    {
        //
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);

        // if (x == null || y == null)
        // {
        //     ViewBag.ErrorMessage = "Please fill all values";
        //     return View("CalculatorError");
        // }
        //
        // if (op is null)
        // {
        //     ViewBag.ErrorMessage = "Invalid operation";
        //     return View("CalculatorError");
        // }
        //
        
        double? result = 0.0d;
        switch(op)
        {
            case "+":
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case "-":
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case "*":
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case "/":
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

