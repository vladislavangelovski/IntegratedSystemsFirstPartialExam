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
    public class VaccineCenterServiceImpl : IVaccineCenterService
    {
        private readonly IRepository<VaccinationCenter> _vaccineCenterRepository;

        public VaccineCenterServiceImpl(IRepository<VaccinationCenter> vaccineCenterRepository)
        {
            _vaccineCenterRepository = vaccineCenterRepository;
        }

        public VaccinationCenter Delete(VaccinationCenter vaccinationCenter)
        {
            return _vaccineCenterRepository.Delete(vaccinationCenter);
        }

        public VaccinationCenter Get(Guid? id)
        {
            return _vaccineCenterRepository.Get(id);
        }

        public List<VaccinationCenter> GetAll()
        {
            return _vaccineCenterRepository.GetAll().ToList();
        }

        public VaccinationCenter Insert(VaccinationCenter vaccinationCenter)
        {
            return _vaccineCenterRepository.Insert(vaccinationCenter);
        }

        public VaccinationCenter LowerCapacity(VaccinationCenter vaccinationCenter)
        {
            --vaccinationCenter.MaxCapacity;
            return vaccinationCenter;
        }

        public VaccinationCenter Update(VaccinationCenter vaccinationCenter)
        {
            return _vaccineCenterRepository.Update(vaccinationCenter);
        }
    }
}
