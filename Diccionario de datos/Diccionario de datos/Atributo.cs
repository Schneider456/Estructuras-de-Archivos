using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class Atributo
    {
        public string nombre;
        public char cTipo;
        public int iLongitud;
        public int iTipoIndice;
        public long lDirAtributo;
        public long lDirIndice;
        public long lDirSigAtrib;

        public Atributo(string nombre, char cTipo, int iLongitud, int iTipoIndice, long lDirAtributo, long lDirIndice, long lDirSigAtrib)
        {
            this.nombre = nombre;
            this.cTipo = cTipo;
            this.iLongitud = iLongitud;
            this.iTipoIndice = iTipoIndice;
            this.lDirAtributo = lDirAtributo;
            this.lDirIndice = lDirIndice;
            this.lDirSigAtrib = lDirSigAtrib;
        }

        public Atributo()
        {

        }
    }
}
