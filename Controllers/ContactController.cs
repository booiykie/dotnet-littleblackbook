using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLittleBlackBook.Controllers
{
	public class ContactController:Controller
	{
		private ContactDBContext db =newContactDBContext();
		//
		// GET: /Contacts/
		public ActionResult Index()
		{
			returnView(db.Contacts.ToList());
		}
		public ActionResult Details(int id =0)
		{
			Contact contact =db.Contacts.Find(id);
			if(contact ==null)
			{
				return HttpNotFound();
			}
			return View(contact);
		}
		
		//
		// GET: /Contacts/Edit/5
		public ActionResult Edit(int id =0)
		{
			Contact contact =db.Contacts.Find(id);
			if(contact ==null)
			{
				return HttpNotFound();
			}
			return View(contact);
		}
		
		//
		// POST: /Contacts/Edit/5
		[HttpPost]
		public ActionResult Edit(Contacts contact)
		{
			if(ModelState.IsValid)
			{
				db.Entry(contact).State=EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(movie);
		}
		
		public ActionResult SearchIndex(string contactId, string searchString)
		{
			var IdLst=newList<string>();
			var IdQry=from d in db.Contacts
			orderby d.Id
			select d.Id;
			IdLst.AddRange(IdQry.Distinct());
			ViewBag.contactId =new SelectList(IdLst);
			var contacts =from m in db.Contacts
			select m;
			if(!String.IsNullOrEmpty(searchString))
			{
				contacts= contacts.Where(s => s.Title.Contains(searchString));
			}
			if(string.IsNullOrEmpty(contactId))
				return View(contacts);
			else
			{
				return View(contacts.Where(x => x.Id== contactId));
			} 
		}
	}
}