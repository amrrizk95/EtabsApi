﻿using Core._00_Base;
using Core._03_Drawing_Elements;
using Core.enums;
using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
   public class FrameElement:Element
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }
        public CSys cSys { get; set; }
        public FrameSection frameSection { get; set; }
        public double[] p { get; set; }
        public double[] v2 { get; set; }
        public double[] v2_envMax { get; set; }
        public double[] v2_envMin { get; set; }
        public double[] v3 { get; set; }
        public double[] t { get; set; }
        public double[] m2 { get; set; }
        public double[] m3 { get; set; }
        public double[] m3_envMax { get; set; }
        public double[] m3_envMin { get; set; }

        public double[] resultsStations { get; set; }
        public List<double> areaSteel { get; set; }
        public List<double> areaSteel_envMax { get; set; }
        public List<double> areaSteel_envMin { get; set; }
        public List<double> shearSteel { get; set; }
        public List<double> shearSteel_envMax { get; set; }
        public List<double> shearSteel_envMin { get; set; }
        public List<double> c1 { get; set; }
        public List<double> c1_envMax { get; set; }
        public List<double> c1_envMin { get; set; }
        public List<double> j { get; set; }
        public List<double> j_envMax { get; set; }
        public List<double> j_envMin { get; set; }
        public List<double> shearStress { get; set; }

        // no getter or setter propeties
        string temp1 = "";
        string temp2 = "";
        string temp3 = "";
        string sectionName;
        public FrameElement(cSapModel _mySapModel, double _xStart, double _ystart, double _zStart, double _xEnd, double _yEnd, double _zEnd, FrameSection _frameSection = null, string _userName = "", CSys _cSys = CSys.Global) : base(_mySapModel, _userName)
        {
            frameSection = _frameSection;
            startPoint = new Point();
            endPoint = new Point();
            startPoint.z = _xStart;
            startPoint.y = _ystart;
            startPoint.z = _zStart;
            endPoint.x = _xEnd;
            endPoint.y = _yEnd;
            endPoint.z = _zEnd;
            cSys = _cSys;

            if (frameSection == null)
            {
                sectionName = "None";
            }
            else
            {
                sectionName = frameSection.name;
            }

            temp1 = "";
            temp2 = "";
            temp3 = "";

            mySapModel.FrameObj.AddByCoord(startPoint.x, startPoint.y, startPoint.z, endPoint.x, endPoint.y, endPoint.z, ref temp1, sectionName, userName, cSys.ToString());
            name = temp1;

            // Set names of points
            mySapModel.FrameObj.GetPoints(name, ref temp2, ref temp3);
            startPoint.name = temp2;
            endPoint.name = temp3;

        }

        public FrameElement(cSapModel _mySapModel, Point _startPoint, Point _endPoint, FrameSection _frameSection = null, string _userName = "", CSys _cSys = CSys.Global) : this(_mySapModel, _startPoint.x, _startPoint.y, _startPoint.z, _endPoint.x, _endPoint.y, _endPoint.z, _frameSection, _userName, _cSys)
        { }
        //Constructor for existing frame with section in ETABS (No creation for frame in etabs, just to set P,M2,M3,N)
        public FrameElement(cSapModel _mySapModel, string frameElementName, FrameSection _frameSection = null, string _userName = "") : base(_mySapModel, _userName)
        {
            name = frameElementName;
            frameSection = _frameSection;
        }

        #region Methods
        public void RotateLocalAxes(double rotationAngel)
        {
            mySapModel.FrameObj.SetLocalAxes(name, rotationAngel, eItemType.Objects);
        }

        #endregion
    }
}
