using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PatientLogicLibrary.DAL
{
    public interface IBaseDAO
    {
        IDbConnection GetConnection();
        void ReleaseConnection(IDbConnection conn);
    }
}
