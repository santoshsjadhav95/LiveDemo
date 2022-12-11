using CrudUsingAdo.Net.Business_Layer;
using CrudUsingAdo.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudUsingAdo.Net.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            TrainerBL bl = new TrainerBL();
            List<Trainer> trainers = bl.GetAllTrainer();
            return View(trainers);
        }

        [HttpGet]
        public ActionResult Details(int? tainerId)
        {
            TrainerBL bl = new TrainerBL();
            Trainer trainer = bl.GetAllTrainer().Find(t => t.TrainerId == tainerId);
            return View(trainer);
        }

        public ActionResult GetStudentByTrainerId(int? TrainerId, string trainername)
        {
            ViewBag.trainername = trainername;
            TrainerBL bl = new TrainerBL();
            List<Student> students = bl.GetStudentByTrainerId(TrainerId ??0);
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            TrainerBL bl = new TrainerBL();
            if(bl.Create(trainer))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? tainerId)
        {
            TrainerBL bl = new TrainerBL();
            Trainer trainer = bl.GetAllTrainer().Find(t=>t.TrainerId == tainerId);
            return View(trainer);
        }

        [HttpPost]
       // public ActionResult Edit([Bind(Exclude="Salary")]Trainer trainer)
        public ActionResult Edit()
        {
            Trainer trainer = new Trainer();
            //UpdateModel<Trainer>(trainer);
            UpdateModel<ITrainer>(trainer);

            TrainerBL bl = new TrainerBL();
            if (bl.Update(trainer))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? tainerId)
        {
            TrainerBL bl = new TrainerBL();
            Trainer trainer = bl.GetAllTrainer().Find(t => t.TrainerId == tainerId);
            return View(trainer);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int? tainerId)
        {
            TrainerBL bl = new TrainerBL();
            if (bl.Delete(tainerId ?? 0))
            {
                return RedirectToAction("Index");
            }
            Trainer trainer = bl.GetAllTrainer().Find(t => t.TrainerId == tainerId);
            return View(trainer);
        }

    }
}