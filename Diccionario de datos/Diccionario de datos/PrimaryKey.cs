using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class PrimaryKey
    {
        public int iClave = -1;
        public string sClave = "";
        public long lDirección = -1;
        public bool ocupado = false;

        public PrimaryKey(int iClave, long lDirección)
        {
            this.iClave = iClave;
            this.lDirección = lDirección;
        }

        public PrimaryKey(string sClave, long lDirección)
        {
            this.sClave = sClave;
            this.lDirección = lDirección;
        }

        public PrimaryKey()
        {
            
        }
    }
}
