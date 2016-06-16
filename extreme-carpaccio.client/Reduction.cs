using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCarpaccio.client
{
    public class Reduction
    {
        public Dictionary<int, double> ListReducTotal { get; set; }

        public Reduction()
        {
            ListReducTotal.Add(50000, 0.15);
            ListReducTotal.Add(10000, 0.10);
            ListReducTotal.Add(7000, 0.07);
            ListReducTotal.Add(5000, 0.05);
            ListReducTotal.Add(1000, 0.03);
        }
    }
}
