using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using AspnetCoreMvcFull.Models.ViewModels;
using AspnetCoreMvcFull.Models.Entities;
using AspnetCoreMvcFull.Data;

namespace AspnetCoreMvcFull.Controllers;

public class FormLayoutsController : Controller
{

    private readonly ApplicationContext _context;

    public FormLayoutsController( ApplicationContext context)
    {
        _context = context;
    }
    public IActionResult Horizontal() => View();
    public IActionResult Ticket() => View();


    [HttpPost]
    public async Task<IActionResult> Ticket(TicketModel model)
    {
        var NewTicket = new Tickets() { TicketAmount = model.TicketAmount, TicketName =model.TicketName,
        TicketDescription = model.TicketDescription,
        };
        if (ModelState.IsValid)
        {
            _context.Add(NewTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index" ,"Home");
        }
        return View();
    }



        }

