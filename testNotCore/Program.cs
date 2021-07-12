using EtabsApi;
using EtabsApi._07_AnalysisResults;
using EtabsApi.Lateral_Loads;
using ETABSv17;
using System.Collections.Generic;


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
            //ret = mySapModel.InitializeNewModel(eUnits.Ton_m_C); 

            //ret = mySapModel.File.NewBlank(); 



            // we still miss seismic load
            // add load patterns 

            //var loadPatternOwnWeight = new LoadPattern(mySapModel, "OwnWeight", LoadPatternType.Dead, 1, true);
            //var loadPatternSD = new LoadPattern(mySapModel, "SD", LoadPatternType.SuperDead, 0, true);
            //var loadPatternWind = new LoadPattern(mySapModel, "Wind", LoadPatternType.Wind, 0, true);
            //var loadPatternLive = new LoadPattern(mySapModel, "Live", LoadPatternType.Live, 0, true);
            //var loadPatternLiveRoof = new LoadPattern(mySapModel, "LifeRoof", LoadPatternType.RoofLive, 0, true);

            //var material = new MaterialProperties(mySapModel, eMatType.Concrete,"concret-Amr", 24855.58, 0.2, 0.0000099, 23.5631);
            //var framSection = new RectSection(mySapModel, material, "concretAmr", 0.4, 0.4, 1);
            //var slapSection = new SlabSection(mySapModel, "slapSection", eSlabType.Slab, eShellType.ShellThin, material, 0.15);

            //var p11 = new Point(5, 5, 0, "pc1");
            //var p12 = new Point(5, 5, 3, "pc2");

            //var p21 = new Point(-5, 5, 0, "pc3");
            //var p22 = new Point(-5, 5, 3, "pc4");

            //var p31 = new Point(-5, -5, 0, "pc5");
            //var p32 = new Point(-5, -5, 3, "pc6");

            //var p41 = new Point(5, -5, 0, "pc7");
            //var p42 = new Point(5, -5, 3, "pc8");

            //var c1 = new FrameElement(mySapModel, p11, p12, framSection, "col-1");
            //var c2 = new FrameElement(mySapModel, p21, p22, framSection, "col-2");

            //var c3 = new FrameElement(mySapModel, p31, p32, framSection, "col-1");
            //var c4 = new FrameElement(mySapModel, p41, p42, framSection, "col-2");

            //var slap = new SlabElement(mySapModel, "slap-1", new List<Point> { p12, p22, p32, p42 },slapSection); 

            ret = mySapModel.File.OpenFile(@"D:\etabsModels\trailModels-10.EDB");

            ret = mySapModel.File.Save(@"D:\etabsModels\trailModels-10");
            ret = mySapModel.Analyze.RunAnalysis();
            var n=0;
            string[] storys = new string[] { };
            string d1 = "6";
            string d2 = "4";
            string[] uniquePoints = new string[] { };
            string[] lables = new string[] { };
            string[] loadCases = new string[] {  };
            double[] displacmentX = new double[] { };
            double[] displacmentY= new double[] { };
            double[] driftY=new double[] { };
            double[] driftX=new double[] { };

            double[] drift = new double[] { };

            double[] Z = new double[] { };
            double[] Y = new double[] { };
            double[] X = new double[] { };



            string[] stepType = new string[] { };
            double[] stepNumber = new double[] { };
            string[] directions = new string[] { };

            var result = new StoryDrift(mySapModel);

            //ret = mySapModel.Results.StoryDrifts(ref n, ref storys, ref loadCases, ref stepType, ref stepNumber, ref directions, ref drift, ref lables, ref X, ref Y, ref Z);

            //ret = mySapModel.Results.JointDrifts(ref n, ref storys, ref lables, ref uniquePoints, ref loadCases,ref stepType,ref stepNumber, ref displacmentX, ref displacmentY,ref driftX,ref driftY);
        }
    }
}
