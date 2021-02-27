using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core._02_Define_Sections
{
   public class RectSection:FrameSection
    {
        #region properities
        public double width { get; set; }
        public double height { get; set; }
        #endregion
        //Constructor for existing frame R section in ETABS (No creation for frame R section in etabs, Just be used in analysis and get results P,M2,M3,N
        public RectSection(cSapModel _mySapModel, string _name, double _width, double _height, string _notes = "", string _guid = "") : base(_mySapModel, _name, _notes, _guid)
        {
            height = _height;
            width = _width;
        }
    }
}
