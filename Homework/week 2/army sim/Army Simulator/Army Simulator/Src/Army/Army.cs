using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army_Simulator.Src.Unit
{
    public class Army 
    {
        public List<Unit> Units { get; set; }

        public Army(List<Unit> units)
        {
            Units = units;
        }




        public void PrintArmy()
        {
            for (int i = 0; i < Units.Count; i++)
            {
                Console.WriteLine(Units[i].ToString());
            }
        }


    }
}
