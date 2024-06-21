using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccineServiceImpl : IVaccineService
    {
        private readonly IRepository<Vaccine> _vaccineRepository;
        private readonly IRepository<VaccinationCenter> _vaccinateionCenterRepository;
        private readonly IRepository<Patient> _patientRepository;

        public VaccineServiceImpl(IRepository<Vaccine> vaccineRepository, IRepository<VaccinationCenter> vaccinateionCenterRepository, IRepository<Patient> patientRepository)
        {
            _vaccineRepository = vaccineRepository;
            _vaccinateionCenterRepository = vaccinateionCenterRepository;
            _patientRepository = patientRepository;
        }

        public List<Vaccine> ShowVaccinesForPatient(Guid patientId)
        {
            return _vaccineRepository.GetAll().Where(v => v.PatientId == patientId).ToList();
        }

        public List<Vaccine> ShowVaccinesInCenter(Guid centerId)
        {
            return _vaccineRepository.GetAll().Where(v => v.VaccinationCenter == centerId).ToList();
        }

        public void VaccinatePatient(VaccinatePatientDTO vaccinatePatientDTO)
        {
            Vaccine vaccine = new Vaccine()
            {
                Manufacturer = vaccinatePatientDTO.Manufacturer,
                Certificate = Guid.NewGuid(),
                DateTaken = vaccinatePatientDTO.DateTaken,
                VaccinationCenter = vaccinatePatientDTO.CenterId,
                Center = _vaccinateionCenterRepository.Get(vaccinatePatientDTO.CenterId),
                PatientId = (Guid)vaccinatePatientDTO.PatientId,
                PatientFor = _patientRepository.Get(vaccinatePatientDTO.PatientId)
            };
            _vaccineRepository.Insert(vaccine);
        }
    }
}
