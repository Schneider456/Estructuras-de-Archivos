using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diccionario_de_datos
{
    class Entidad
    {
        public string nombre;
        public long lDirEntidad;
        public long lDirAtrib; 
        public long lDirDatos;
        public long lDirSigEnt;
        public Hashtable hsAtributos = new Hashtable();
        public Hashtable hsRegistros = new Hashtable();
        public ArrayList alNomAtributos = new ArrayList();
        public ArrayList alCveBusqueda = new ArrayList();
        public List<PrimaryKey> listPrimaryKey = new List<PrimaryKey>();
        public List<List<ForeanKey>> listsForeanKey = new List<List<ForeanKey>>();
        public List<Nodo> listNod = new List<Nodo>();
        public Hashtable hsNodos = new Hashtable();

        public Entidad(string nombre, long lDirEntidad, long lDirAtrib, long lDirDatos, long lDirSigEnt)
        {
            this.nombre = nombre;
            this.lDirEntidad = lDirEntidad;
            this.lDirAtrib = lDirAtrib;
            this.lDirDatos = lDirDatos;
            this.lDirSigEnt = lDirSigEnt;
        }

        public Entidad()
        {
            
        }
    }


}