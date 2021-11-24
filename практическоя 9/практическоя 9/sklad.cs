using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практическоя_9
{
    class sklad
    {
        public string info;
        public double obiom;
        public int stoimist;


        public override string ToString()
        {
            return info + " Стоимость=" + stoimist + " Объём=" + obiom;
        }
    }
}
