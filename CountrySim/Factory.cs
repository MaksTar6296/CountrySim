using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountrySim
{
    public class Factory : Building
    {
        public Factory() : base("Factory", 250, "Money", 50, -10) { }
    }
}
