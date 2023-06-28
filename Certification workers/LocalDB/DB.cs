using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_workers.LocalDB
{
    public class DB
    {
        static CertificationWorkersContext entities;
        static object objectLock = new object();

        public static CertificationWorkersContext GetDB()
        {
            lock (objectLock)
            {
                if (entities == null)
                    entities = new CertificationWorkersContext();
                return entities;
            }
        }
    }
}
