using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class PatientServiceImpl : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientServiceImpl(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient Delete(Patient entity)
        {
            return _patientRepository.Delete(entity);
        }

        public Patient Get(Guid? id)
        {
            return _patientRepository.Get(id);
        }

        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll().ToList();
        }

        public Patient Insert(Patient entity)
        {
            return _patientRepository.Insert(entity);
        }

        public Patient Update(Patient entity)
        {
            return _patientRepository.Update(entity);
        }
    }
}
