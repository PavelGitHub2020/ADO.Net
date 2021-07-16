using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientLogicLibrary.DAL
{
    public interface IPatientDAO
    {
        List<Patient> GetAll();
        int Add(Patient patient);
        int Update(Patient patient);
        int Remove(int id);

        DataTable GetTable();
    }
}
