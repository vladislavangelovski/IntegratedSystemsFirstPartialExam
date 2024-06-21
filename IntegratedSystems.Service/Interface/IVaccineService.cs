using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Interface
{
    public interface IVaccineService
    {
        List<Vaccine> ShowVaccinesInCenter(Guid centerId);
        void VaccinatePatient(VaccinatePatientDTO vaccinatePatientDTO);
        List<Vaccine> ShowVaccinesForPatient(Guid patientId);
    }
}
