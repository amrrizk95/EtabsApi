using EtabsApi;
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
            ret = mySapModel.InitializeNewModel(eUnits.Ton_m_C);
            ret = mySapModel.File.NewBlank();

            // we still miss seismic load
            // add load patterns 
         
            var loadPatternOwnWeight = new LoadPattern(mySapModel, "OwnWeight", LoadPatternType.Dead, 1, true);
            var loadPatternSD = new LoadPattern(mySapModel, "SD", LoadPatternType.SuperDead, 0, true);
            var loadPatternWind = new LoadPattern(mySapModel, "Wind", LoadPatternType.Wind, 0, true);
            var loadPatternLive = new LoadPattern(mySapModel, "Live", LoadPatternType.Live, 0, true);
            var loadPatternLiveRoof = new LoadPattern(mySapModel, "LifeRoof", LoadPatternType.RoofLive, 0, true);

            var massParticpationRatio = new MassSource(
                mySapModel,
                new List<LoadPattern> { loadPatternLive, loadPatternLiveRoof, loadPatternOwnWeight },
                new List<double> { 1, 1.4, 1.2 },
                EtabsApi.enums.MassSourceOptions.FromLoads
                );



        }
    }
}
