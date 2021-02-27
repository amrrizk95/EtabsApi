using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
  public  class ConcretMaterial:MaterialProperties
    {
        #region Properites
        public double poissonRatio { get; set; }
        public double shearModulus { get; set; }
        public double compressiveStrength { get; set; }
        public double isLightWeight { get; set; }
        #endregion
        #region Constructor
        public ConcretMaterial(cSapModel _mySapModel, eMatType _type, string _name, double _youngsModulus, double _thermalCoeff, double _unitWeight, double _unitMass,double _poissonRatio,double _shearModulus,double _compressiveStrength,double _isLightWeight) 
            :base( _mySapModel,  _type,  _name,  _youngsModulus,  _thermalCoeff,  _unitWeight,  _unitMass)
        {
            poissonRatio = _poissonRatio;
            shearModulus = _shearModulus;
            compressiveStrength = _compressiveStrength;
            isLightWeight = _isLightWeight;
        }
        #endregion
    }
}
