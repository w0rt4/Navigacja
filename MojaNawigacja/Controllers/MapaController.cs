using MojaNawigacja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MojaNawigacja.Controllers
{
    public class MapaController : Controller
    {
        static NawigacjaDBEntities entities = new NawigacjaDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult index(FormCollection formularz)
        {
            if (ModelState.IsValid)
            {
                int idNowejTrasy = 0;
                if (entities.Adresy.Count() > 0)
                {
                    idNowejTrasy = (from adres in entities.Adresy
                                    where adres.IdTrasy != null
                                    select adres.IdTrasy).Max();
                }
                ++idNowejTrasy;
                Adresy nowaTrasa = new Adresy();
                nowaTrasa.IdTrasy = idNowejTrasy;
                nowaTrasa.MiejsceDocelowe = formularz["miejsceDocelowe"].ToString();
                nowaTrasa.MiejsceWyjazdu = formularz["miejsceWyjazdu"].ToString();
                nowaTrasa.DataDodania = DateTime.Now;

                entities.Adresy.Add(nowaTrasa);
                entities.SaveChanges();

                return View(nowaTrasa);
            }
            return View();
        }
       
        public ActionResult WyswietlTrasy()
        {
            return View("Trasy", entities);
        }
        public ActionResult UsunTrase(Adresy adres)
        {
            if (entities.Adresy.Count() > 0)
            {
                Adresy trasaDoUsuniecia =
                    entities.Adresy.Where(s => s.IdTrasy == adres.IdTrasy).First();
                entities.Adresy.Remove(trasaDoUsuniecia);
                entities.SaveChanges();
            }
            return View("Trasy", entities);
        }
    }
}