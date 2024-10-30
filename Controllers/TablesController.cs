using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;

namespace AspnetCoreMvcFull.Controllers;

public class TablesController : Controller
{
    private readonly ApplicationContext _context;
    private object awaite;

    public TablesController(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Basic()
    {
        var Ticket = await _context.Tickets.ToListAsync();
        return View(Ticket);
    }
}