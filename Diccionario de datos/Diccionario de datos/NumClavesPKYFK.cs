using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class NumClavesPKYFK
    {
        public int iPK = 0;
        public int iFK = 0;
        public int iML = 0;
        public List<int> listamML = new List<int>();
        public int tamPK = 0;
        public List<int> listamFK = new List<int>();
    }
}
