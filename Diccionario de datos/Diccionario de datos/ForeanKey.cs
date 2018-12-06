using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class ForeanKey
    {
        public int iClave = -1;
        public string sClave = "";
        public List<long> listDirecciónes = new List<long>();

        public ForeanKey(int iClave)
        {
            this.iClave = iClave;
        }

        public ForeanKey(string sClave)
        {
            this.sClave = sClave;
        }

        public ForeanKey()
        {
         
        }
    }
}
