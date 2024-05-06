using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cancellieri.andre.ecommerc.Models;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;



namespace cancellieri.andre.ecommerc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
       /* string? login = HttpContext.Session.GetString("login");
        if(login=="Samuele")
        {
            return View("Privacy");
        }*/
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Logout()
    {
        return View();
    }
    [HttpPost]
    public IActionResult p1(Utente u)
    {
        Database db = new ();
        if(u.Email != null)
        {
            HttpContext.Session.SetString("login", u.Email);
        }
        string? login = HttpContext.Session.GetString("login");
        foreach(var item in db.Utenti)
        {
            if(u.Email==item.Email)
            {
                return View("Panini");
            }
            else
            {
                return View("Registrazione");
            }
        }
        return View("");
    }
    [HttpPost]
    public IActionResult p2()
    {
        HttpContext.Session.SetString("login", "-");
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Database()
    {
        /*string? nomeUtente = HttpContext.Session.GetString("NomeUtente");
        if (string.IsNullOrEmpty(nomeUtente))
            return Redirect("\\home\\index");*/
        Database db = new ();
        db.SaveChanges();
        return View(db);
    }
    public IActionResult Registrazione(Utente u)
    {     
    
        if(u != null && !string.IsNullOrEmpty(u.Nome))
        {
            Database db = new ();   
            db.Utenti.Add(u);
            db.SaveChanges();
            HttpContext.Session.SetString("NomeUtente", u.Nome);
        }
        return View(u);

    }
    
            
    public IActionResult Panini()
    {       
        return View();
    }
    public IActionResult Servizi()
    {
        
        return View();
    }
    public IActionResult Carrello()
    {
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
