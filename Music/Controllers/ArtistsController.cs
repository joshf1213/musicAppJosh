using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class ArtistsController : Controller
    {
        private MusicContext db = new MusicContext();
        
        // GET: Artists
        public ActionResult Index()
        {
            var artists = db.Artists.Include(a => a.Name).Include(a => a.Bio);

            return View(db.Artists.ToList());
        }
        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistID, Name, Bio")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Artist artist = db.Artists.Where(a => a.ArtistID == id).Single();

                if (artist == null)
                {
                    return HttpNotFound();
                }
                return View(artist);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


    }
}
