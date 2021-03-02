using ETABSv17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsApi
{
  public  class WallElement:Element
    {
        public List<Point> coordinats { get; set; }

        double[] x;
        double[] y;
        double[] z;
        public WallElement(cSapModel _mySapModel, string _name, List<Point> _coordinats, WallSection section) :base(_mySapModel)
        {
            name = _name;
            coordinats = _coordinats;
            x = new double[coordinats.Count];
            y = new double[coordinats.Count];
            z = new double[coordinats.Count];
            for (int i = 0; i < _coordinats.Count; i++)
            {
                x[i] = _coordinats[i].x;
                y[i] = _coordinats[i].y;
                z[i] = _coordinats[i].z;
            }

            int ret = _mySapModel.AreaObj.AddByCoord(_coordinats.Count, ref x, ref y, ref z, ref _name, section.name);
        }
    }
}
