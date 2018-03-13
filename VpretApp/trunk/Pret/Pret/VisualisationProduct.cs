using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vpret;

namespace Pret
{
    public class VisualisationProduct
    {
        public string Name { get; set; }
        public string Sn { get; set; }
        public string Com { get; set; }
        public List<VisualitationAccesories> listAccessories { get; set; }
    }
}
