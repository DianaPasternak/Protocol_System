using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models.DB;

namespace ProtocolSystem.Controllers
{
    public class ProtocolController : Controller
    {

        private readonly ProtocolSystemContext _context;

        public ProtocolController(ProtocolSystemContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MyProtocols()
        {
            var user_email = User.Identity.Name;
            var userId = _context.Users.FirstOrDefault(x => x.Email == user_email).Id;

            var protocolContext = _context.Protocols.Include(c => c.User1).Include(c => c.User2).Where(p => p.User2Id == userId);
            return View(await protocolContext.ToListAsync());
        }

        public IActionResult GeneratePdf()
        {
            var user_email = User.Identity.Name;
            var protocol = _context.Protocols.Where(p => p.Id == 5).FirstOrDefault();

            var Renderer = new IronPdf.HtmlToPdf();
            Renderer.RenderHtmlAsPdf(
                "<h1>Протокол про адміністративне порушення</h1>" + 
                protocol.Id +
                user_email.ToString() + "Hellpo" +
                "Країна:"  + protocol.Country
                ).SaveAs(protocol.Id + ".pdf");

            return View();
        }

        public async Task<IActionResult> CreatedProtocols()
        {
            var user_email = User.Identity.Name;
            var userId = _context.Users.FirstOrDefault(x => x.Email == user_email).Id;

            var context = _context.Protocols.Include(c => c.User1).Include(c => c.User2).Where(p => p.User1Id == userId);//.Include(c => c.Contract).Include(c => c.TeamCoach).ThenInclude(t => t.Team);
            return View(await context.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocol = await _context.Protocols
                .Include(p => p.User1)
                .Include(p => p.User2)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (protocol == null)
            {
                return NotFound();
            }

            return View(protocol);
        }
        public async Task<IActionResult> All(int? protocolNumber)
        {
            if (protocolNumber == null) {
                var context = _context.Protocols.Include(c => c.User1).Include(c => c.User2);
                return View(await context.ToListAsync());
            }
            else
            {
                var context = _context.Protocols.Include(c => c.User1).Include(c => c.User2).Where(p=> p.Id == protocolNumber);
                return View(await context.ToListAsync());
            }
        }
        public async Task<IActionResult> BlogDetailed()
        {
            return View();
        }
        public async Task<IActionResult> Users()
        {

            var context = _context.Users;
            return View(await context.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Protocols protocol)
        {
            if (ModelState.IsValid)
            {

                var user_email = User.Identity.Name;
                var userId = _context.Users.FirstOrDefault(x => x.Email == user_email).Id;

                protocol.User1Id = userId;

                _context.Add(protocol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreatedProtocols));
            }
            return View(protocol);
        }

        public IActionResult CreateEuro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEuro(Protocols protocol)
        {
            if (ModelState.IsValid)
            {

                var user_email = User.Identity.Name;
                var userId = _context.Users.FirstOrDefault(x => x.Email == user_email).Id;

                protocol.User1Id = userId;

                _context.Add(protocol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CreatedProtocols));
            }
            return View(protocol);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}