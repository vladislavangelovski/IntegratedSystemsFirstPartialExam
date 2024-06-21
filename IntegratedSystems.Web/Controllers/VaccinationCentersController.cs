using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;
using IntegratedSystems.Domain.DTO;

namespace IntegratedSystems.Web.Controllers
{
    public class VaccinationCentersController : Controller
    {
        private readonly IVaccineCenterService _vaccineCenterService;
        private readonly IVaccineService _vaccineService;
        private readonly IPatientService _patientService;

        public VaccinationCentersController(IVaccineCenterService vaccineCenterService, IVaccineService vaccineService, IPatientService patientService)
        {
            _vaccineCenterService = vaccineCenterService;
            _vaccineService = vaccineService;
            _patientService = patientService;
        }
        
        public IActionResult VaccinatePatient(Guid id)
        {
            VaccinatePatientDTO vaccinatePatientDTO = new VaccinatePatientDTO()
            {
                CenterId = id,
                Manufacturers = new List<string>
                {
                    "Test1", "Test2", "Test3", "Test4"
                },
                Patients = _patientService.GetAll()
            };
            return View(vaccinatePatientDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VaccinatePatient(VaccinatePatientDTO vaccinatePatientDTO)
        {
            
            if (ModelState.IsValid)
            {
                
                if (_vaccineCenterService.Get(vaccinatePatientDTO.CenterId).MaxCapacity <= 0)
                {
                    return View("NoCapacity");
                }
                _vaccineCenterService.LowerCapacity(_vaccineCenterService.Get(vaccinatePatientDTO.CenterId));
                _vaccineService.VaccinatePatient(vaccinatePatientDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinatePatientDTO);
        }

        // GET: VaccinationCenters
        public async Task<IActionResult> Index()
        {
            return View(_vaccineCenterService.GetAll());
        }

        // GET: VaccinationCenters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccineCenterService.Get(id);
            VaccinesInCenterDTO vaccinesInCenterDTO = new VaccinesInCenterDTO()
            {
                VaccinationCenter = vaccinationCenter,
                Vaccines = _vaccineService.ShowVaccinesInCenter((Guid)id)
            };

            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinesInCenterDTO);
        }

        // GET: VaccinationCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                vaccinationCenter.Id = Guid.NewGuid();
                _vaccineCenterService.Insert(vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccineCenterService.Get(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (id != vaccinationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vaccineCenterService.Update(vaccinationCenter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationCenterExists(vaccinationCenter.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccineCenterService.Get(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vaccinationCenter = _vaccineCenterService.Get(id);
            if (vaccinationCenter != null)
            {
                _vaccineCenterService.Delete(vaccinationCenter);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationCenterExists(Guid id)
        {
            return _vaccineCenterService.Get(id) != null;
        }
    }
}
