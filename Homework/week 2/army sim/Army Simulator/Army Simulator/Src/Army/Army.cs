using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    internal class Army 
    {
        private List<Unit> Units { get; set; }

        public Army(List<Unit> units)
        {
            Units = units;
        }

        public override string ToString()
        {
            return base.ToString();
        }



        //public void PrintArmy()
        //{
        //    for(int i = 0; i < Units.Count; i++)
        //    {
        //        Units[i]
        //    }
        //}


    }
}
