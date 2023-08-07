using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using TheNeighborhoodArtStore.Models;

namespace TheNeighborhoodArtStore.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            // Logic to add the item to the cart and update the session variable

            if (Session["cart"] == null)
            {
                List<Product> prod = new List<Product>();
                prod.Add(db.Products.Find(id));
                Session["cart"] = prod;
            }
            else
            {
                List<Product> strings = (List<Product>)Session["cart"];
                strings.Add(db.Products.Find(id));
                Session["cart"] = strings;
            }

            return Json(new { success = true });
        }
        /*public ActionResult AddToCart(int id)
        {
            if(Session["products"] == null)
            {
                Session["products"] = new List<Product>();
            }
            else
            {
                List<Product> prod = (List<Product>)Session["products"];
                prod.Add(db.Products.Find(id));
                Session["products"] = prod;
            }
            return View("Index", "Products");
        }*/
        public ActionResult GetToCart()
        {
            List<Product> cartItems = Session["cart"] as List<Product>; // Retrieve the cart items from the session

            if (cartItems == null)
            {
                return View(cartItems);
                //return View("Index", db.Products.ToList());
            }

            return View(cartItems);

        }
        [HttpPost]
        public ActionResult Clear ()
        {
            Session["cart"] = null;
            return Json(new { success = true });
        }
        public ActionResult Checkout()
        {
            return View();
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Description,Image,Color,Price")] Product product)
        {
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);
            var artist = db.Artists.FirstOrDefault(a => a.Email == user.Email);
            if (ModelState.IsValid)
            {
                artist.Products.Add(product);
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prod = db.Products.Find(id);
            if (User.Identity.Name != prod.Artist.Email)
            {
                return Redirect("/Artists/NoPermission");
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Description,Image,Color,Price")] Product product)
        {
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);
            var artistId = db.Artists.FirstOrDefault(a => a.Email == user.Email).Id;

            product.ArtistId = artistId;


            //var artist = db.Artists.FirstOrDefault(a => a.Id == user.Id);
            //product.ArtistId = id;
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }



        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
