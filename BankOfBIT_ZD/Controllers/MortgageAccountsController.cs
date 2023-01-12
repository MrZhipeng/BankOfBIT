﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BankOfBIT_ZD.Data;
using BankOfBIT_ZD.Models;

namespace BankOfBIT_ZD.Controllers
{
    public class MortgageAccountsController : Controller
    {
        private BankOfBIT_ZDContext db = new BankOfBIT_ZDContext();

        // GET: MortgageAccounts
        public ActionResult Index()
        {
            var bankAccounts = db.MortgageAccounts.Include(m => m.AccountState).Include(m => m.Client);
            return View(bankAccounts.ToList());
        }

        // GET: MortgageAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MortgageAccount mortgageAccount = (MortgageAccount)db.BankAccounts.Find(id);
            if (mortgageAccount == null)
            {
                return HttpNotFound();
            }
            return View(mortgageAccount);
        }

        // GET: MortgageAccounts/Create
        public ActionResult Create()
        {
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AcountStateId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        // POST: MortgageAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankAccountId,ClientId,AccountStateId,AccountNumber,Balance,DateCreated,Notes,MortgageRate,Amortization")] MortgageAccount mortgageAccount)
        {
            //increment the AccountNumber by one.
            mortgageAccount.SetNextAccountNumber();

            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(mortgageAccount);
                mortgageAccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AcountStateId", "Description", mortgageAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", mortgageAccount.ClientId);
            return View(mortgageAccount);
        }

        // GET: MortgageAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MortgageAccount mortgageAccount = (MortgageAccount)db.BankAccounts.Find(id);
            if (mortgageAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AcountStateId", "Description", mortgageAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", mortgageAccount.ClientId);
            return View(mortgageAccount);
        }

        // POST: MortgageAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankAccountId,ClientId,AccountStateId,AccountNumber,Balance,DateCreated,Notes,MortgageRate,Amortization")] MortgageAccount mortgageAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mortgageAccount).State = EntityState.Modified;
                mortgageAccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AcountStateId", "Description", mortgageAccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", mortgageAccount.ClientId);
            return View(mortgageAccount);
        }

        // GET: MortgageAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MortgageAccount mortgageAccount = (MortgageAccount)db.BankAccounts.Find(id);
            if (mortgageAccount == null)
            {
                return HttpNotFound();
            }
            return View(mortgageAccount);
        }

        // POST: MortgageAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MortgageAccount mortgageAccount = (MortgageAccount)db.BankAccounts.Find(id);
            db.BankAccounts.Remove(mortgageAccount);
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
