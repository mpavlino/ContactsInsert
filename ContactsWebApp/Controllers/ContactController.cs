using ContactsWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactsWebApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController
        //Kreiraj get poziv na web api te prosljedi dobiveni response/rezultat Viewu za prikaz ukoliko ga ima
        public async Task<IActionResult> Index()
        {
            IEnumerable<Contact> contacts = null;
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44341/api/ContactApi");

            if (response.IsSuccessStatusCode)
            {
                var readContactTable = await response.Content.ReadAsAsync<IList<Contact>>();
                contacts = readContactTable;
            }
            else
            {
                contacts = Enumerable.Empty<Contact>();
                ModelState.AddModelError(string.Empty, "No records found...");
            }

            return View(contacts);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        //Kreiraj post poziv na web api koji obavlja spremanje podataka te uz uspješan response napravi redirect na listu kontakta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync<Contact>("https://localhost:44341/api/ContactApi", contact);

                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }              
            }
            return View();
        }
    }
}
