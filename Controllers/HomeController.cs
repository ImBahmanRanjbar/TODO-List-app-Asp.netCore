using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO.Models;

namespace TODO.Controllers;

public class HomeController : Controller
{
    private readonly TODOContext context;

    public HomeController(TODOContext ctx)
    {
        context = ctx;
    }

    public IActionResult Index(string id)
    {
        var filters = new Filters(id);
        ViewBag.Filters = filters;
        ViewBag.Categories = context.Categories.ToList();
        ViewBag.Statuses = context.statuses.ToList();
        ViewBag.DueFilter = Filters.DueFilterValuse;
        IQueryable<Models.TODO> query = context.TODOs
            .Include(p => p.Category)
            .Include(p => p.Status);

        if (filters.HasCategory)
            query = query.Where(p => p.CategoryID == filters.CategoryID);
        if (filters.HasStatus)
            query = query.Where(p => p.StatusID == filters.StatusID);
        if (filters.HasDue)
        {
            var today = DateTime.Today;
            if (filters.IsPast)
                query = query.Where(p => p.DueDate < today);
            else if (filters.IsFuture)
                query = query.Where(p => p.DueDate > today);
            else if (filters.IsToday) query = query.Where(p => p.DueDate == today);
        }

        var tasks = query.OrderBy(p => p.DueDate).ToList();
        return View(tasks);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = context.Categories.ToList();
        ViewBag.Statuses = context.statuses.ToList();
        var task = new Models.TODO {StatusID = "open"};
        return View(task);
    }

    [HttpPost]
    public IActionResult Add(Models.TODO task)
    {
        if (ModelState.IsValid)
        {
            context.TODOs.Add(task);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        else
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.statuses.ToList();
            return View(task);


        }
    }

    [HttpPost]
    public IActionResult Filter(string[] filter)
    {
        string id = string.Join('-', filter);
        return RedirectToAction("Index", new {ID = id});
    }

    [HttpPost]
    public IActionResult MarkComplete([FromRoute] string id,Models.TODO selected)
    {
        selected = context.TODOs.Find(selected.ID)!;
        if (selected != null)
        {
            selected.StatusID = "closed";
            context.SaveChanges();
        }
        return RedirectToAction("Index", new {ID = id});
    }

    [HttpPost]
    public IActionResult DeleteCopmleted(string id)
    {
        var toDelete = context.TODOs.Where(p => p.StatusID == "closed").ToList();
        foreach (var task in toDelete)
        {
            context.TODOs.Remove(task);
        }
        context.SaveChanges();
        return RedirectToAction("Index", new {ID = id});
    }
}
