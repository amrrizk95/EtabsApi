using Core._01_Initialization;
using ETABSv17;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
   public class LoadCombination :EtabsCore
    {
        public string name { get; set; }
        public LoadCombinationType type { get; set; }
        public List<double> scalFactors { get; set; }
        public List<LoadPattern> loadCases { get; set; }
        public LoadCombination(cSapModel _mySapModel, string _name, LoadCombinationType _type) : base(_mySapModel)
        {
            name = _name;
            type = _type;
            loadCases = new List<LoadPattern>();
            scalFactors = new List<double>();
            mySapModel.RespCombo.Add(name, (int)type);
        }
        public void AddLoadCases(List<LoadPattern> _loadPatterns, List<double> _loadPatternsFactors)
        {
            for (int i = 0; i < _loadPatterns.Count; i++)
            {
                if (loadCases.Contains(_loadPatterns[i]))
                {
                    for (int j = 0; j < loadCases.Count; j++)
                    {
                        if (loadCases[j].name == _loadPatterns[i].name)
                        {
                            scalFactors[j] = _loadPatternsFactors[i];
                        }
                    }
                }
                else
                {
                    loadCases.Add(_loadPatterns[i]);
                    scalFactors.Add(_loadPatternsFactors[i]);
                }
                eCNameType lC = eCNameType.LoadCase;
                mySapModel.RespCombo.SetCaseList(name, ref lC, _loadPatterns[i].name, _loadPatternsFactors[i]);
            }

        }

    }
}
