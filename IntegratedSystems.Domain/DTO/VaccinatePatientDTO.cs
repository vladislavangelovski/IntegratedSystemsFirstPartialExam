using IntegratedSystems.Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Domain.DTO
{
    public class VaccinatePatientDTO
    {
        public List<string>? Manufacturers { get; set; }
        public DateTime DateTaken { get; set; }
        public Guid? PatientId { get; set; }
        public List<Patient>? Patients { get; set; }
        public string Manufacturer { get; set; }
        public Guid CenterId { get; set; }
    }
}
