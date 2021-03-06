﻿using EtabsApi;
using ETABSv17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace testNotCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // open etabs  
            int ret = 0;
        //   string ProgramPath = "C:\\Program Files\\Computers and Structures\\ETABS 17\\ETABS";
            //dimension the ETABS Object as cOAPI type
            ETABSv17.cHelper myHelper = new ETABSv17.Helper();
            ETABSv17.cOAPI myETABSObject = null;
            myETABSObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject");


            ret = myETABSObject.ApplicationStart();

            ETABSv17.cSapModel mySapModel = default(ETABSv17.cSapModel);
            mySapModel = myETABSObject.SapModel;


            // intialize model 
            ret = mySapModel.InitializeNewModel(eUnits.Ton_m_C);
            ret = mySapModel.File.NewBlank();
                
            // define concrete  material
            var conMaterial = new ConcretMaterial(mySapModel, "tempAmrConcrete", 2.4028, 2534563.54, 0.2, 0.0000099);
            // define section
            var recSection = new RectSection(mySapModel, conMaterial, "tempAmrSection", .6, .9, 0);
            // set modefires
           double[] framModefires = new double[] {1,0.7,1,1,0.8,0.8,1 ,1};
           double[] elementModefires = new double[] {0.7,0.7,0.7,0.7,0.7,0.7,0.7 ,0.7};
            ret = recSection.setModefires(ref framModefires);
            // set  column points 
            var a0 = new Point(0, 0, 0);
            var a1 = new Point(0, 0, 3);

            var b0 = new Point(10, 0, 0);
            var b1 = new Point(10, 0, 3);

            var c0 = new Point(10, 10, 0);
            var c1 = new Point(10, 10, 3);

            var d0 = new Point(0, 10, 0);
            var d1 = new Point(0, 10, 3);

            // wall points 
            var w0 = new Point(4, 5, 0);
            var w1 = new Point(7, 5, 0);
            var w2 = new Point(7, 5, 3);
            var w3 = new Point(4, 5, 3);


            /// draw coloumns
            var col1 = new FrameElement(mySapModel, a0, a1, recSection, "tempAmrCol1", CSys.Global);
          ret=  col1.elementModifire(ref elementModefires);
            var col2 = new FrameElement(mySapModel, b0, b1, recSection, "tempAmrCol2",  CSys.Global);
          ret=  col2.elementModifire(ref elementModefires);
            var col3 = new FrameElement(mySapModel, c0, c1, recSection, "tempAmrCol3",  CSys.Global);
          ret=  col3.elementModifire(ref elementModefires);
            var col4 = new FrameElement(mySapModel, d0, d1, recSection, "tempAmrCol4",  CSys.Global);
         ret=   col4.elementModifire(ref elementModefires);

            // draw beams
            var beam1 = new FrameElement(mySapModel, a1, b1, recSection, "tempAmrBeam1", CSys.Global);
            var beam2 = new FrameElement(mySapModel, b1, c1, recSection, "tempAmrBeam2",  CSys.Global);
            var beam3 = new FrameElement(mySapModel, c1, d1, recSection, "tempAmrBeam3",  CSys.Global);
            var beam4 = new FrameElement(mySapModel, d1, a1, recSection, "tempAmrBeam4",  CSys.Global);
            // set slab points 
            var slabPoints = new List<Point>() {
                a1,
                b1,
                c1,
                d1
                };
            // set slab section
            var slabSection = new SlabSection(mySapModel, "tempAmrSlabSection", eSlabType.Slab, eShellType.ShellThin, 
                conMaterial, .20);
            // set slab modefires 
            double[] slabModefires = new double[] { 1, 0.7, 1, 1, 0.9, 0.9, 1, 1 ,.5,.5};
            double[] elmentModefires = new double[] { 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 1 ,.5,.5};

            ret = slabSection.setModefires(ref slabModefires);
            var slab = new SlabElement(mySapModel, "tempAmrSlab", slabPoints, slabSection);
            slab.elementModifire(ref elmentModefires);
            // draw wall 

            // define section for wall
            var wallSection = new WallSection(mySapModel, "tempAmrWallSection", eWallPropType.Specified, eShellType.ShellThin, conMaterial, .30);

            // set wall points 
            var wallPoints = new List<Point>() {
                w0,
                w1,
                w2,
                w3
                };
            var wall = new SlabElement(mySapModel, "tempAmrWall", wallPoints, slabSection);

        }
    }
}
