﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DBGames.Models
{
    public class GamesController : Controller
    {
        private GameModelContext db = new GameModelContext();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.Developer).Include(g => g.Engine).Include(g => g.Platform);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "DeveloperName");
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineName");
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "PlatformName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Title,Genre,Mode,DeveloperId,EngineId,PlatformId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineName", game.EngineId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "PlatformName", game.PlatformId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineName", game.EngineId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "PlatformName", game.PlatformId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Title,Genre,Mode,DeveloperId,EngineId,PlatformId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeveloperId = new SelectList(db.Developers, "DeveloperId", "DeveloperName", game.DeveloperId);
            ViewBag.EngineId = new SelectList(db.Engines, "EngineId", "EngineName", game.EngineId);
            ViewBag.PlatformId = new SelectList(db.Platforms, "PlatformId", "PlatformName", game.PlatformId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
