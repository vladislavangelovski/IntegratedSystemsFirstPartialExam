using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccineCenterService
    {
        List<VaccinationCenter> GetAll();
        VaccinationCenter Get(Guid? id);
        VaccinationCenter Insert(VaccinationCenter vaccinationCenter);
        VaccinationCenter Update(VaccinationCenter vaccinationCenter);
        VaccinationCenter Delete(VaccinationCenter vaccinationCenter);
        VaccinationCenter LowerCapacity(VaccinationCenter vaccinationCenter);
    }
}
