using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ClassLibrary.Category;

namespace ClassLibrary
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }

        private int count ;
        public int Count {
            get
            {
                return count;
            }
            set
            {
                count = value;
                if (count < 0)
                {
                    count = 0;
                }
            }
        }
        public string ImagePath { get; set; }
        public eCategory Category { get; set; }
    }
}
