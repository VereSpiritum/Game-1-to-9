using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Digits
    {
        public int Save { get; set; }
        public int N
        {
            get; set;
        }
        public int Dig()
        {
            Random random = new Random();
            N = random.Next(1, 9);
            if(Save == N)
            {
                Dig();
            }
            
            return N;
        }
    }
}
