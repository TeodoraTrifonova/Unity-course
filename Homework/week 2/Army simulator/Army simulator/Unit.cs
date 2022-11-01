using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_simulator
{
    public class Unit
    {
        public string UnitName { get; private set; }
        private int level { get; set; }
        private int xp { get; set; }
        private int range { get; set; }
        private string ability { get; set; }
        private int attack { get; set; }
        public int health { get; private set; }
        

        
    }
}
