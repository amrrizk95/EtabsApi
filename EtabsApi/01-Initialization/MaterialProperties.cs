using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtabsApi
{
   public class MaterialProperties:EtabsCore
    {
        #region Properties
        public eMatType type { get; set; }
        public string name { get; set; }
        public double youngsModulus { get; set; }
        public double thermalCoeff { get; set; }
        public double unitWeight { get; set; }
        public double unitMass { get; set; }
        #endregion

        #region Constructor
        public MaterialProperties(cSapModel _mySapModel, eMatType _type, string _name, double _youngsModulus, double _thermalCoeff, double _unitWeight, double _unitMass) :base(_mySapModel)
        {
            type = _type;
            name = _name;
            youngsModulus = _youngsModulus;
            thermalCoeff = _thermalCoeff;
            unitWeight = _unitWeight;
            unitMass = _unitMass;
        }
        #endregion
    }
}
