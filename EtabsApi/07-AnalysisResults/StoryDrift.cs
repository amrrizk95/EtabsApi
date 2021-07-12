using ETABSv17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsApi._07_AnalysisResults
{
   public class StoryDrift : EtabsCore
    {
            int n = 0;
            string[] storys ;
            string[] lables ;
            string[] loadCases ;
            string[] objects;
            double[] objectsSta;
            string[] Eles;
            double[] ElesStat;
            double[] drift ;
            double[] Z ;
            double[] Y ;
            double[] X ;
            string[] stepType ;
            double[] stepNumber ;
            string[] directions;


        double[] P;
        double[] V2;
        double[] V3;
        double[] T; 
        double[] M2; 
        double[] M3;
        public StoryDrift(cSapModel _mySapModel):base(_mySapModel)
        {
          int ret=  mySapModel.Results.StoryDrifts(ref n, ref storys, ref loadCases, ref stepType, ref stepNumber, ref directions, ref drift, ref lables, ref X, ref Y, ref Z);
            int ret2 = mySapModel.Results.FrameForce("551", eItemTypeElm.Element, ref n, ref objects, ref objectsSta, ref Eles, ref ElesStat, ref loadCases, ref stepType, ref stepNumber, ref P, ref V2, ref V3, ref T, ref M2, ref M3);
            int ret3 = mySapModel.Results.FrameForce("C15", eItemTypeElm.Element, ref n, ref objects, ref objectsSta, ref Eles, ref ElesStat, ref loadCases, ref stepType, ref stepNumber, ref P, ref V2, ref V3, ref T, ref M2, ref M3);
        }
    }
}
