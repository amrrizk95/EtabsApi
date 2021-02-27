using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core._03_Drawing_Elements
{
   public abstract class Element:EtabsCore
    {
        #region MemberVariable
        public string name { get; set; }
        public string userName { get; set; }
        public static cSapModel myStaticSapModel { get; set; }
        #endregion
        public Element(cSapModel _mySapModel, string _userName = "") : base(_mySapModel)
        {
            userName = _userName;
            myStaticSapModel = _mySapModel;
        }
    }
}
