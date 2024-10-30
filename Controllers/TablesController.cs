using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcFull.Data;
using AspnetCoreMvcFull.Models.ViewModels;

namespace AspnetCoreMvcFull.Controllers;

public class TablesController : Controller
{
    private readonly ApplicationContext _context;

    public TablesController(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Basic()
    {
        var Ticket = await _context.Tickets.ToListAsync();
        return View(Ticket);
    }


    //Editing Method

    public async Task<IActionResult> Edit(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }

        // Subject entity to SubjectView
        var Ticket = new TicketModel
        {
            TicketId = ticket.TicketId,
            TicketName= ticket.TicketName,
            TicketAmount = ticket.TicketAmount,
            TicketDescription = ticket.TicketDescription,
          
        };

        return View(Ticket);
    }





    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(TicketModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model); // Return view with validation errors
        }

        // Retrieve the existing subject from the database
        var existingSubject = await _context.Tickets.FindAsync(model.TicketId);
        if (existingSubject == null)
        {
            return NotFound();
        }

        // Update properties
        existingSubject.TicketId = model.TicketId;
        existingSubject.TicketName = model.TicketName;
        existingSubject.TicketAmount = model.TicketAmount;
        existingSubject.TicketDescription = model.TicketDescription;

        // Save changes to the database
        _context.Update(existingSubject);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index" ,"Home");
    }

    //Deleted

    // Delete -
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }

        // Convert to view model 

        var ticketView = new TicketModel
        {
            TicketId = ticket.TicketId,
            TicketName = ticket.TicketName,
            TicketAmount = ticket.TicketAmount,
            TicketDescription = ticket.TicketDescription,
        };



        return View(ticketView);
    }


    //Delete comfirmation
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var subject = await _context.Tickets.FindAsync(id);
        if (subject == null)
        {
            return NotFound();
        }

        // Remove the subject from the context and save changes
        _context.Tickets.Remove(subject);
        await _context.SaveChangesAsync();

        return RedirectToAction("Basic" ,"Tables");
    }







}