using EtabsApi.enums;
using ETABSv17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsApi.Lateral_Loads
{
   public class MassSource : EtabsCore
    {
        public List<LoadPattern> LoadPatterns { get; set; }
        public int Option { get; set; }
        public MassSource(cSapModel _mySapModel, List<LoadPattern> loadPatterns,List<double> Multipliers ,MassSourceOptions massSourceOptions) :base(_mySapModel)
        {
            LoadPatterns = loadPatterns;
            Option = (int)massSourceOptions;
            int loadsCount = loadPatterns.Count;
            string[] LoadPat = new string[loadsCount];
            double[] sf = new double[loadsCount];
            if (loadPatterns.Count>0)
            {
                for (int i = 0; i < loadPatterns.Count; i++)
                {
                    LoadPat[i] = loadPatterns[i].name;
                    sf[i] = Multipliers[i];
                }
            }
          int result=  MySapModel.PropMaterial.SetMassSource(Option,  loadsCount, ref LoadPat, ref sf);
        }
    }
}
