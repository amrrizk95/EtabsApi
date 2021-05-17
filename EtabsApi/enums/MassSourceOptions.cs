using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsApi.enums
{
 public enum MassSourceOptions
    {
        FromElementSelfMassAndAdditionalMasses=1,
        FromLoads=2,
        FromElementSelfMassesAndAdditionalMassesLoads=3
    }
}
