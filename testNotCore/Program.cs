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
           string ProgramPath = "C:\\Program Files\\Computers and Structures\\ETABS 17\\ETABS";
            //dimension the ETABS Object as cOAPI type
            ETABSv17.cHelper myHelper = new ETABSv17.Helper();
            ETABSv17.cOAPI myETABSObject = null;
            //create ETABS object
            //myETABSObject = myHelper.CreateObject(ProgramPath);
            myETABSObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject");


            ret = myETABSObject.ApplicationStart();

            ETABSv17.cSapModel mySapModel = default(ETABSv17.cSapModel);
            mySapModel = myETABSObject.SapModel;

            // intialize model 
            ret = mySapModel.InitializeNewModel();
            ret = mySapModel.File.NewBlank();
            // nuber of stories 
            int noStories = 6;
            // create model 
           // ret = mySapModel.File.NewGridOnly(noStories, 12, 14, 1, 1, 24, 24);
            // save model
           // ret = mySapModel.File.Save("E:\\projectswork\\testEtabs\\model-1");

            //***************build etabs model*************///

            // for columns 
            var xCoordinats =new double[] {0,10,10,0 };
            var yCoordinats =new double[] {0,0,10,10};
            var zCoordinats =new double[] {3,6,12,15,18};
            var colNo = xCoordinats.Length;
            string  Name ="";
                double totalHieght = 0;
               ret=  mySapModel.SetPresentUnits(eUnits.Ton_m_C);


            for (int i = 0; i < noStories; i++)
            {
              

                for (int j = 0; j < colNo; j++)
                {
                    ret = mySapModel.FrameObj.AddByCoord(xCoordinats[j], yCoordinats[j], totalHieght, xCoordinats[j], yCoordinats[j], totalHieght+3, ref Name);
                ret = mySapModel.View.RefreshView(0, false);
                }
                totalHieght = totalHieght + 3;
            }
          
            totalHieght = 3;
            // for beams 
            for (int i = 0; i < noStories; i++)
            {
                
                //beam1
                ret = mySapModel.FrameObj.AddByCoord(xCoordinats[0], yCoordinats[0], totalHieght, xCoordinats[ 1], yCoordinats[1], totalHieght, ref Name);
                //beam2
                ret = mySapModel.FrameObj.AddByCoord(xCoordinats[1], yCoordinats[1], totalHieght, xCoordinats[2], yCoordinats[ 2], totalHieght, ref Name);

                //beam3
                ret = mySapModel.FrameObj.AddByCoord(xCoordinats[2], yCoordinats[ 2], totalHieght, xCoordinats[3], yCoordinats[ 3], totalHieght, ref Name);

                //beam4
                ret = mySapModel.FrameObj.AddByCoord(xCoordinats[3], yCoordinats[ 3], totalHieght, xCoordinats[0], yCoordinats[0], totalHieght, ref Name);
                totalHieght+=3;
                ret = mySapModel.View.RefreshView(0, false);
            }
            ret = mySapModel.View.RefreshView(0, false);
            // for floors 
            double[] x = new double[] { 10, 10, 0, 0 };
            double[] y = new double[] { 0, 10, 10, 0 };
            double[] z1 = new double[] { 3, 3, 3, 3 };
            double[] z2 = new double[] { 6, 6, 6, 6 };
            double[] z3 = new double[] { 9, 9, 9, 9 };
            double[] z4 = new double[] { 12, 12, 12, 12 };
            double[] z5 = new double[] { 15, 15, 15, 15 };
            ret = mySapModel.View.RefreshView(0, false);
            ret = mySapModel.AreaObj.AddByCoord(4, ref x, ref y, ref z1, ref Name);
                ret = mySapModel.AreaObj.AddByCoord(4, ref x, ref y, ref z2, ref Name);
                ret = mySapModel.AreaObj.AddByCoord(4, ref x, ref y, ref z3, ref Name);
                ret = mySapModel.AreaObj.AddByCoord(4, ref x, ref y, ref z4, ref Name);
                ret = mySapModel.AreaObj.AddByCoord(4, ref x, ref y, ref z5, ref Name);


        }
    }
}
