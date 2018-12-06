using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace Diccionario_de_datos
{
    public partial class Form1 : Form
    {
        Hashtable hsEntidades = new Hashtable();
        ArrayList alNomEntSort = new ArrayList();
        Nodo auxRa = null;
        List<int> lClav = new List<int>(new int[] { 29, 33, 39, 41, 52, 22, 25, 27, 37, 90, 8, 77, 68, 36, 30, 13, 57, 24, 28, 85, 35, 31, 38, 150, 84, 80, 70, 160, 155, 45, 43, 40, 75, 69, 73 });
        int Paco = 0;

        String sNomEntidad;
        String sNombreAtr;
        String fileNameDD;
        String fileNameDat;
        String fileNameIdx;
        char cTip;
        long nvll = -1;
        long Cab = -1;
        bool band = false;
        bool bndModfica = false;
        bool bndElimina = false;
        bool bndPK = false;
        bool bndCveBus = false;
        bool bandAddReg = false;
        bool bandModifReg = false;
        bool bandModifRegTem = false;
        int renglonSeleccionado = -1;
        int indListNodo = 0;
        Nodo nodo;
        int indR = 0;

        public Form1()
        {
            InitializeComponent();

            MyDataGridViewInitializationMethod();
            cmbTipo.Items.Insert(0, "C");
            cmbTipo.Items.Insert(1, "E");
            cmbtipoIndice.Items.Add("0");
            cmbtipoIndice.Items.Add("1");
            cmbtipoIndice.Items.Add("2");
            cmbtipoIndice.Items.Add("3");
            cmbtipoIndice.Items.Add("4");
            //Se inicializa el estilo de los combobox Tipo y Tipo Indice en "DropDownList" para que los valores de estos no puedan ser modificados
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbtipoIndice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNomEntActual.DropDownStyle = ComboBoxStyle.DropDownList;
            ((Control)tabEntidad).Enabled = false;

        }

        //El boton Add es el que agrega una entidad a la lista de entidades que se crearan.

        #region Interface

        private void cmbBoxListValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            sNomEntidad = cmbNomEntActual.Text;
            //Cuando el valor del combobox que contiene las entidades cambia, se habilitan los controles que permiten agregar los atributos de la entidad seleccionada.
            txtBoxNomAtribut.Enabled = true;
            cmbTipo.Enabled = true;
            cmbtipoIndice.Enabled = true;
            btnAltaAtr.Enabled = true;
            btnEliminaAtr.Enabled = true;
            btnModificaAtr.Enabled = true;
            ///////////////////////////////////////////////////////////////


            actualizaDataGridAtributos();

            if (((Entidad)hsEntidades[sNomEntidad]).lDirDatos != nvll)
            {
                GeneraColumnas();
                actualizaDataGridRegistros();
                actualizaDataGridForeanKey();
                actualizaDataGridPrimaryKey();
                actualizaDataGridÁrbol();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!bndModfica)
            {
                //Se Valida que el textbox no este vacio
                if (string.IsNullOrEmpty(txtBIngNoment.Text))
                    return;

                sNomEntidad = txtBIngNoment.Text;

                /* Se agrega el nombre de la nueva entidad a dos listas, alNomEntSort, el proposito de esta es ordenar 
                 * alfabeticamente los nombres de las entidades ya que de esta manera estaran ordenadas logicamente 
                 * las entidades.
                 ****************************************************************************************************/
                alNomEntSort.Add(sNomEntidad);
                alNomEntSort.Sort();
                string sNomEnt30 = ajustaTam(sNomEntidad, 30);
                FileInfo file = new FileInfo(fileNameDD);

                Entidad aux = new Entidad(sNomEnt30, file.Length, nvll, nvll, nvll);

                guardaEntidad(aux, sNomEntidad);

                hsEntidades.Add(sNomEntidad, aux);

                //Se agrega al combobox donde esta contenida la lista de Entidades
                cmbNomEntActual.Items.Add(txtBIngNoment.Text);
                txtBIngNoment.Clear();
                txtBIngNoment.Focus();

                actualizaDataGridEntidades();
            }
        }

        private void actualizaDataGridEntidades()
        {
            dgEntidades.Rows.Clear();
            for (int i = 0; i < alNomEntSort.Count; i++)
            {
                string sNom;
                sNom = (alNomEntSort[i]).ToString();
                Entidad aux = ((Entidad)(hsEntidades[sNom]));
                dgEntidades.Rows.Add(aux.nombre, aux.lDirEntidad, aux.lDirAtrib, aux.lDirDatos, aux.lDirSigEnt);
            }
        }

        private void actualizaDataGridPrimaryKey()
        {
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            dgPrimaryKey.Rows.Clear();
            if (aux.listPrimaryKey.Count != 0)
            {
                for (int i = 0; i < aux.listPrimaryKey.Count; i++)
                {
                    if (aux.listPrimaryKey[i].iClave != -1)
                        dgPrimaryKey.Rows.Add(aux.listPrimaryKey[i].iClave, aux.listPrimaryKey[i].lDirección);
                    else
                        dgPrimaryKey.Rows.Add(aux.listPrimaryKey[i].sClave, aux.listPrimaryKey[i].lDirección);
                }
            }
        }

        private void actualizaDataGridForeanKey()
        {
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            dgForeanKey.Rows.Clear();

            for (int k = 0; k < aux.listsForeanKey.Count; k++)
                if (aux.listsForeanKey[k].Count != 0)
                {
                    for (int i = 0; i < aux.listsForeanKey[k].Count; i++)
                    {
                        dgForeanKey.Rows.Add();
                        for (int j = 0; j < aux.listsForeanKey[k][i].listDirecciónes.Count + 1; j++)
                        {
                            if (aux.listsForeanKey[k][i].iClave != -1)
                                if (j == 0)
                                    dgForeanKey.Rows[dgForeanKey.Rows.Count - 2].Cells[j].Value = aux.listsForeanKey[k][i].iClave;
                                else
                                    dgForeanKey.Rows[dgForeanKey.Rows.Count - 2].Cells[j].Value = aux.listsForeanKey[k][i].listDirecciónes[j - 1];
                            else
                                if (j == 0)
                                    dgForeanKey.Rows[dgForeanKey.Rows.Count - 2].Cells[j].Value = aux.listsForeanKey[k][i].sClave;
                                else
                                    dgForeanKey.Rows[dgForeanKey.Rows.Count - 2].Cells[j].Value = aux.listsForeanKey[k][i].listDirecciónes[j - 1];
                        }
                    }
                }
        }


        private void actualizaDataGridAtributos()
        {
            dgAtributos.Rows.Clear();
            //Nombre de la entidad seleccionada
            Entidad Entaux = ((Entidad)(hsEntidades[(cmbNomEntActual.Text).ToString()]));
            //Error
            if (Entaux.hsAtributos.Count != 0)
            {
                for (int i = 0; i < Entaux.alNomAtributos.Count; i++)
                {
                    string sNom;
                    sNom = (Entaux.alNomAtributos[i]).ToString();
                    Atributo aux = (Atributo)(Entaux.hsAtributos[sNom]);
                    dgAtributos.Rows.Add(aux.nombre, aux.cTipo, aux.iLongitud, aux.iTipoIndice, aux.lDirAtributo, aux.lDirIndice, aux.lDirSigAtrib);
                }
            }
        }

        private bool validarCampos()
        {
            bool bnd = true;
            if (txtBoxNomAtribut.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(txtBoxNomAtribut, "Ingrese Nombre");
            }
            if (txtBoxLong.Text == "")
            {
                if (band)
                {
                    bnd = false;
                    errorProvider1.SetError(txtBoxLong, "Ingrese la Longitud");
                }
            }
            if (cmbTipo.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(cmbTipo, "Elija el tipo");
            }
            if (cmbtipoIndice.Text == "")
            {
                bnd = false;
                errorProvider1.SetError(cmbtipoIndice, "Elija el tipo de indice");
            }
            return bnd;
        }

        private void borrarErrorProviders()
        {
            errorProvider1.SetError(txtBoxNomAtribut, "");
            errorProvider1.SetError(txtBoxLong, "");
            errorProvider1.SetError(cmbTipo, "");
            errorProvider1.SetError(cmbtipoIndice, "");
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            borrarErrorProviders();
            if (cmbTipo.Text == "E")
            {

                txtBoxLong.Enabled = false;
                band = false;
            }
            else
            {
                txtBoxLong.Enabled = true;
                band = true;
            }
        }

        private void txtBoxLong_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaciónTextBoxs.onlyNumbers(e);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!bndModfica)
            {
                borrarErrorProviders();
                if (validarCampos())
                {
                    guardaAtributo();
                    txtBoxNomAtribut.Clear();
                    txtBoxNomAtribut.Focus();
                    cmbTipo.SelectedIndex = -1;
                    cmbtipoIndice.SelectedIndex = -1;
                    txtBoxLong.Clear();
                    txtBoxLong.Focus();
                    txtBoxLong.Enabled = false;

                }
                modificaCBoxTipoIndice();
                actualizaDataGridAtributos();
                actualizaDataGridEntidades();
            }
        }

        #endregion

        #region Escritura
        private void guardaAtributo()
        {
            long lfseek;
            FileInfo file = new FileInfo(fileNameDD);
            sNombreAtr = txtBoxNomAtribut.Text;
            string sNomAtr30 = ajustaTam(sNombreAtr, 30);

            Entidad Entaux = ((Entidad)(hsEntidades[sNomEntidad]));
            Entaux.alNomAtributos.Add(sNombreAtr);


            if (Entaux.hsAtributos.Count == 0)
            {
                lfseek = file.Length;
                /*En este caso, no existe ningun Atributo dentro de la entidad,
                 * por lo que es el primero en insertarse
                 * *********************************************************/
                Atributo aux;
                if (txtBoxLong.Enabled)
                {
                    Int32 itipoInd = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                    //(Nombre del atributo, Tipo,                     longitud,                  tipo de indice,  DirAtribut, DirIndice, dirSigAtr)
                    aux = new Atributo(sNomAtr30, 'C', Int32.Parse(txtBoxLong.Text), itipoInd, file.Length, nvll, nvll);
                }
                else
                {
                    Int32 itipoInd = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                    //(Nombre del atributo, Tipo, longitud,                  tipo de indice,  DirAtribut, DirIndice, dirSigAtr)
                    aux = new Atributo(sNomAtr30, 'E', 4, itipoInd, file.Length, nvll, nvll);

                }

                Entaux.hsAtributos.Add(sNombreAtr, aux);

                EscribeArchivo.escribeAtr(aux, fileNameDD);

                Entaux.lDirAtrib = aux.lDirAtributo;

                EscribeArchivo.escribeEnt(Entaux, fileNameDD);
            }
            else
            {

                lfseek = file.Length;
                /*En este caso, ya existe almenos un Atributo dentro de la entidad,
                 * por lo que se inserta delante de otra.
                 **********************************************************/
                int pos = Entaux.alNomAtributos.IndexOf(sNombreAtr);

                /*Con la variable pos, la cual es la posicion del atributo en orden de llegada se obtiene el 
                 *nombre de el atributo que se inserto antes que este.
                 *******************************************************************************************/
                string nomAntAtr = (Entaux.alNomAtributos[pos - 1]).ToString();


                /*Se crea una instancia de la clase Atributo, esta sera el elemento a insertar dentro de nuestra estructura 
                 *en memoria y en nuestro archivo.
                 *******************************************************************************************/
                Atributo aux;
                if (txtBoxLong.Enabled)
                {
                    Int32 itipoInd = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                    //(Nombre del atributo,Tipo,                     longitud,                  tipo de indice,  DirAtribut, DirIndice,                        dirSigAtr)
                    aux = new Atributo(sNomAtr30, 'C', Int32.Parse(txtBoxLong.Text), itipoInd, file.Length, nvll, nvll);
                }
                else
                {
                    Int32 itipoInd = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                    //(Nombre del atributo, Tipo, longitud,                  tipo de indice,  DirAtribut, DirIndice,                                                dirSigAtr)
                    aux = new Atributo(sNomAtr30, 'E', 4, itipoInd, file.Length, nvll, nvll);
                }

                /*Una vez identificada la entidad que antecede a la nueva, con el nombre de esta se actualizan
                * los apuntadores.
                * [anterior.dirSigAtr]->[nueva]
                * ***/
                ((Atributo)(Entaux.hsAtributos[nomAntAtr])).lDirSigAtrib = aux.lDirAtributo;

                /*Se inserta el nuevo atributo en la estructura hash.
                **************************************************/
                Entaux.hsAtributos.Add(sNombreAtr, aux);
                EscribeArchivo.escribeAtr(aux, fileNameDD);
                aux = ((Atributo)(Entaux.hsAtributos[nomAntAtr]));
                EscribeArchivo.escribeAtr(aux, fileNameDD);

                //dgAtributos.Rows.Add(aux.nombre, aux.cTipo, aux.iLongitud, aux.iTipoIndice, aux.lDirAtributo, aux.lDirIndice, aux.lDirSigAtrib);
            }
        }

        private void guardaEntidad(Entidad aux, string sNomEnt)
        {

            if (hsEntidades.Count == 0)
            {
                /*En este caso, no existe ninguna entidad dentro de la estructura que contiene las entidades,
                 * por lo que es la primera en insertarse
                 * *********************************************************/

                EscribeArchivo.escribeEnt(aux, fileNameDD);
                //Actualiza la Cabecera del archivo
                EscribeArchivo.escribeLong(aux.lDirEntidad, fileNameDD);
            }
            else
            {
                /*En este caso, ya existe almenos una entidad dentro del archivo,
                 * por lo que se inserta delante de otra.
                 **********************************************************/

                /*para este paso, la lista que contiene el nombre de las entidades tiene que estar previamente ordenada*/
                int pos = alNomEntSort.IndexOf(sNomEnt);/*despues de haber ordenado la lista (alNomEntSort)
                                                                * Se obtiene la posicion en donde quedo guardada la nueva entidad 
                                                                * *************************************************/
                /*Si dicha posicion es mayor que 0 significa que el nuevo elemento
                 *no sera el primero en orden logico.
                 ******************************************************************/
                if (pos > 0)
                {
                    /*En nuestra lista ordenada alfabeticamente se obtiene el nombre de la entidad que antecede a
                     * la entidad que esta por incenrtarse
                     * ******************************************************************************************/
                    string nomAntEnt = (alNomEntSort[pos - 1]).ToString();
                    aux.lDirSigEnt = ((Entidad)(hsEntidades[nomAntEnt])).lDirSigEnt;

                    /*se actualizan los apuntadores los apuntadores de la entidad angterior a la nueva.
                     * 
                     * [anterior.dirSigEnt]->[nueva]
                     * ***/
                    ((Entidad)(hsEntidades[nomAntEnt])).lDirSigEnt = aux.lDirEntidad;

                    EscribeArchivo.escribeEnt(((Entidad)(hsEntidades[nomAntEnt])), fileNameDD);
                    EscribeArchivo.escribeEnt(aux, fileNameDD);
                }
                else
                {
                    /*En el caso en el que pos es igual a 0, se sabe que sera el primer (ordenado logicamente)
                     *elemento de la lista de entidades.
                     * ***************************************************************************************/

                    /*Se obtiene el nombre de la que es la segunda entidad ordenada alfabeticamente.
                     * la variable que representa el nombre de esta entidad se llama (sPrimeraEnt)
                     * por que sigue siendo el primer elemento dentro del archivo y dentro de la estructura
                     * ************************************************************************************/
                    string sPrimeraEnt = (alNomEntSort[pos + 1]).ToString();

                    aux.lDirSigEnt = ((Entidad)(hsEntidades[sPrimeraEnt])).lDirEntidad;

                    EscribeArchivo.escribeEnt(aux, fileNameDD);
                    //Se Actualiza la cabecera
                    EscribeArchivo.escribeLong(aux.lDirEntidad, fileNameDD);
                }
            }
        }

        private string ajustaTam(string s, int n)
        {
            if (s.Length < n - 1)
            {
                int tam = s.Length;
                for (int i = 0; i < ((n - 1) - tam); i++)
                    s = s.Insert(s.Length, " ");
            }
            return s;
        }

        private string extraeNombre(string s)
        {
            int n = s.IndexOf(' ');
            string nombre = s.Substring(0, n);

            return nombre;
        }

        #endregion

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool bnd = false;

            //Abre la ventana de diaogo
            OpenFileDialog ofd = new OpenFileDialog();

            //Obtiene la ruta del archivo
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileNameDD = ofd.FileName;
                bnd = true;
            }
            else
            {
                MessageBox.Show("No fue posible abrir este archivo");
            }
            if (bnd)
            {
                cmbNomEntActual.Items.Clear();
                dgEntidades.Rows.Clear();
                dgAtributos.Rows.Clear();
                dgRegistros.Rows.Clear();
                dgForeanKey.Rows.Clear();
                dgPrimaryKey.Rows.Clear();
                dgÁrbol.Rows.Clear();
                hsEntidades.Clear();
                alNomEntSort.Clear();
                CargarArchivo();
                ((Control)tabEntidad).Enabled = true;
                actualizaDataGridEntidades();
                NewAdd.Enabled = true;
                EliminaRegistro.Enabled = true;
                Modifica.Enabled = true;
            }
            modificaCBoxTipoIndice();
        }

        private void CargarArchivo()
        {
            long lDirEnt = LeerCab();
            string s;
            if (lDirEnt != nvll)
            {
                Entidad auxEnt;
                do
                {
                    auxEnt = LeerEntidad(lDirEnt);
                    s = extraeNombre(auxEnt.nombre);
                    cmbNomEntActual.Items.Add(s);
                    lDirEnt = auxEnt.lDirSigEnt;
                } while (lDirEnt != nvll);
            }
        }

        private Entidad LeerEntidad(long dir)
        {
            Entidad aux = new Entidad();
            
            string s;
            using (BinaryReader read = new BinaryReader(File.Open(fileNameDD, FileMode.Open)))
            {
                read.BaseStream.Seek(dir, SeekOrigin.Begin);
                aux.nombre = read.ReadString();
                aux.lDirEntidad = read.ReadInt64();
                aux.lDirAtrib = read.ReadInt64();
                aux.lDirDatos = read.ReadInt64();
                aux.lDirSigEnt = read.ReadInt64();
            }

            if (aux.lDirAtrib != nvll)
            {
                long lDirAtr = aux.lDirAtrib;
                Atributo auxAtr;

                do
                {
                    auxAtr = LeerAtributo(lDirAtr);
                    s = extraeNombre(auxAtr.nombre);
                    aux.hsAtributos.Add(s, auxAtr);
                    aux.alNomAtributos.Add(s);
                    lDirAtr = auxAtr.lDirSigAtrib;
                } while (lDirAtr != nvll);
            }

            s = extraeNombre(aux.nombre);
            hsEntidades.Add(s, aux);
            alNomEntSort.Add(s);

            if (aux.lDirDatos != nvll)
            {
                long lDirDat = aux.lDirDatos;
                ArrayList alReg;
                s = extraeNombre(aux.nombre);
                fileNameIdx = fileNameDat = Path.GetDirectoryName(fileNameDD);
                fileNameDat += @"\" + s + ".dat";
                fileNameIdx += @"\" + s + ".idx";
                do
                {
                    alReg = LeerRegistro(lDirDat, s);
                    int posNombre = obtenerPosClaveBusqueda(s);
                    if (posNombre != -1)
                    {
                        ///////
                        if (aux.alCveBusqueda.Contains(alReg[posNombre].ToString()))
                        {
                            string cv = alReg[posNombre].ToString();

                            while (aux.alCveBusqueda.Contains(cv))
                            {
                                cv = cv + "A";
                            }
                            aux.alCveBusqueda.Add(cv);
                            aux.hsRegistros.Add(cv, alReg);
                        }
                        else
                        {
                            aux.alCveBusqueda.Add(alReg[posNombre].ToString());
                            aux.hsRegistros.Add(alReg[posNombre].ToString(), alReg);
                        }
                    }
                    else
                    {
                        string n = aux.hsRegistros.Count.ToString();
                        aux.hsRegistros.Add(n, alReg);
                        aux.alCveBusqueda.Add(n);
                    }
                    lDirDat = Convert.ToInt64((alReg[alReg.Count - 1]).ToString());
                } while (lDirDat != nvll);///leer clave prim
            }

            for (int i = 0; i < aux.alNomAtributos.Count; i++)
            {
                s = aux.alNomAtributos[i].ToString();
                Atributo auxAtr = ((Atributo)(aux.hsAtributos[s]));

                switch(auxAtr.iTipoIndice)
                {
                    case 2:

                        if (auxAtr.lDirIndice != nvll)
                        {
                            int inumPK = 0;
                            long lDirIndice = auxAtr.lDirIndice;
                            using (BinaryReader read = new BinaryReader(File.Open(fileNameIdx, FileMode.Open)))
                            {
                                read.BaseStream.Seek(lDirIndice, SeekOrigin.Begin);
                                inumPK = read.ReadInt32();
                                lDirIndice += sizeof(int);
                            }

                            for (int j = 0; j < inumPK; j++)
                            {
                                PrimaryKey auxPK = LeerPrimaryKey(lDirIndice, auxAtr.cTipo);
                                aux.listPrimaryKey.Add(auxPK);
                                lDirIndice += auxAtr.iLongitud;
                                lDirIndice += sizeof(long);
                            }
                        }

                    break;

                    case 3:

                        if (auxAtr.lDirIndice != nvll)
                        {
                            long lDirIndice = auxAtr.lDirIndice;//124

                            int inumClaves = 0;
                            List<ForeanKey> listForeanKey = new List<ForeanKey>();

                            using (BinaryReader read = new BinaryReader(File.Open(fileNameIdx, FileMode.Open)))
                            {
                                read.BaseStream.Seek(lDirIndice, SeekOrigin.Begin);
                                inumClaves = read.ReadInt32();//2
                                lDirIndice += sizeof(int);//132
                            }
                            for (int k = 0; k < inumClaves; k++)
                            {
                                ForeanKey auxFK = LeerForeanKey(lDirIndice, auxAtr.cTipo);
                                listForeanKey.Add(auxFK);
                                lDirIndice += auxAtr.iLongitud + sizeof(int) + (sizeof(long) * 10);
                            }///seguir aqui

                            aux.listsForeanKey.Add(listForeanKey);
                        }

                    break;

                    case 4:
                        if (auxAtr.lDirIndice != nvll)
                        {
                            Nodo n;
                            Nodo nuevo = LeerNodo(auxAtr.lDirIndice);
                            aux.listNod.Add(nuevo);
                            if (nuevo.cTipo == 'R')
                            {
                                for (int l = 0; l < nuevo.liClaves.Count + 1; l++)
                                {
                                    n = LeerNodo(nuevo.llDirecciones[l]);
                                    aux.listNod.Add(n);
                                    if (n.cTipo == 'I')
                                    {
                                        for (int j = 0; j < n.llDirecciones.Count; j++)
                                        {
                                            Nodo nh = LeerNodo(n.llDirecciones[j]);
                                            aux.listNod.Add(nh);
                                        }
                                    }
                                }
                            }
                        }
                    break;
                }
            }
            
            return aux;
        }

        public Nodo LeerNodo(long dirIndice)
        {
            Nodo nodo;
            long dir;
            int dato;
            nodo = new Nodo();
            using (BinaryReader read = new BinaryReader(File.Open(fileNameIdx, FileMode.Open)))
            {
                read.BaseStream.Seek(dirIndice, SeekOrigin.Begin);
                nodo.lDirNod = read.ReadInt64();
                nodo.cTipo = read.ReadChar();
                if (nodo.cTipo == 'H')
                {
                    for (int i = 0; i < 4; i++)
                    {
                        dir = read.ReadInt64();
                        dato = read.ReadInt32();
                        if (dato != 0)
                        {
                            nodo.llDirecciones.Add(dir);
                            nodo.liClaves.Add(dato);
                        }
                    }
                }
                else
                {
                    dir = read.ReadInt64();
                    nodo.llDirecciones.Add(dir);
                    for (int i = 0; i < 4; i++)
                    {
                        dato = read.ReadInt32();
                        dir = read.ReadInt64();
                        if (dato != 0)
                        {
                            nodo.liClaves.Add(dato);
                            nodo.llDirecciones.Add(dir);
                        }
                    }
                }
            }

            return nodo;
        }

        private PrimaryKey LeerPrimaryKey(long dir, char cTipo)
        {
            PrimaryKey aux = new PrimaryKey();

            using (BinaryReader read = new BinaryReader(File.Open(fileNameIdx, FileMode.Open)))
            {
                read.BaseStream.Seek(dir, SeekOrigin.Begin);
                if(cTipo == 'E')
                    aux.iClave = read.ReadInt32();
                else
                    if(cTipo == 'C')
                        aux.sClave = read.ReadString();

                aux.lDirección = read.ReadInt64();
            }
            return aux;
        }

        private ForeanKey LeerForeanKey(long dir, char cTipo)
        {
            ForeanKey aux = new ForeanKey();
            int numDirecciónes = 0;
            long direc = 0;

            using (BinaryReader read = new BinaryReader(File.Open(fileNameIdx, FileMode.Open)))
            {
                read.BaseStream.Seek(dir, SeekOrigin.Begin);
                if (cTipo == 'E')
                {
                    aux.iClave = read.ReadInt32();//15
                    dir += sizeof(int);
                }
                else
                    if (cTipo == 'C')
                    {
                        aux.sClave = read.ReadString();
                        dir += aux.sClave.Length + 1;
                    }

                read.BaseStream.Seek(dir, SeekOrigin.Begin);
                numDirecciónes = read.ReadInt32();//2

                for (int i = 0; i < numDirecciónes; i++)
                {
                    direc = read.ReadInt64();
                    aux.listDirecciónes.Add(direc);
                }
            }
            return aux;
        }

        private Atributo LeerAtributo(long dir)
        {
            Atributo aux;

            using (BinaryReader read = new BinaryReader(File.Open(fileNameDD, FileMode.Open)))
            {
                read.BaseStream.Seek(dir, SeekOrigin.Begin);
                aux = new Atributo(read.ReadString(), read.ReadChar(), read.ReadInt32(), validaIndices(read.ReadInt32()), read.ReadInt64(), read.ReadInt64(), read.ReadInt64());
            }
            return aux;
        }

        private ArrayList LeerRegistro(long dir, string nombreEnt)
        {
            ArrayList alReg = new ArrayList();
            string s, val, sCade;
            char ctip;
            long lDr, apuntad = dir;
            int iEnteros;

            using (BinaryReader read = new BinaryReader(File.Open(fileNameDat, FileMode.Open)))
            {
                int num = ((Entidad)hsEntidades[nombreEnt]).alNomAtributos.Count;
                /////////////
                //read.BaseStream.Seek(apuntad, SeekOrigin.Begin);

                for (int i = 0; i < num + 2; i++)
                {
                    if (i == 0 || i == num + 1)
                    {
                        read.BaseStream.Seek(apuntad, SeekOrigin.Begin);
                        lDr = read.ReadInt64();
                        val = lDr.ToString();
                        alReg.Add(val);
                        apuntad += sizeof(long);
                    }
                    else
                    {
                        s = ((Entidad)(hsEntidades[nombreEnt])).alNomAtributos[i - 1].ToString();
                        ctip = ((Atributo)(((Entidad)hsEntidades[nombreEnt]).hsAtributos[s])).cTipo;
                        ///////////
                        switch (ctip)
                        {
                            case 'E':
                                read.BaseStream.Seek(apuntad, SeekOrigin.Begin);
                                iEnteros = read.ReadInt32();
                                val = iEnteros.ToString();
                                alReg.Add(val);
                                apuntad += sizeof(int);
                            break;
                            case 'C':
                                read.BaseStream.Seek(apuntad, SeekOrigin.Begin);
                                sCade = read.ReadString();
                                val = sCade;
                                alReg.Add(val);
                                apuntad += ((Atributo)(((Entidad)hsEntidades[nombreEnt]).hsAtributos[s])).iLongitud;
                            break;
                        }
                    }
                }
            }

            return alReg;
        }

        private long LeerCab()
        {
            long lpC;

            using (BinaryReader read = new BinaryReader(new FileStream(fileNameDD, FileMode.Open)))
            {
                read.BaseStream.Seek(0, SeekOrigin.Begin);
                lpC = read.ReadInt64();
                read.Close();
            }

            return lpC;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Diccionario de Datos|*.dd";
            saveFileDialog1.Title = "Guardar Como";
            saveFileDialog1.ShowDialog();
            long cabecera = -1;

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                fileNameDD = saveFileDialog1.FileName;
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileNameDD, FileMode.Create)))
                {
                    Writ.Seek(0, SeekOrigin.Begin);
                    Writ.Write(cabecera);
                }

                ((Control)tabEntidad).Enabled = true;
            }
        }

        private void dgAtributos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bndModfica = true;
                string s = dgAtributos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                s = extraeNombre(s);

                txtBoxNomAtribut.Text = sNombreAtr = s;
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (bndModfica && validarCampos())
            {
                Entidad Entaux = ((Entidad)(hsEntidades[sNomEntidad]));
                Atributo auxAtr = ((Atributo)(Entaux.hsAtributos[sNombreAtr]));

                Entaux.hsAtributos.Remove(sNombreAtr);
                Entaux.alNomAtributos.Remove(sNombreAtr);

                if (txtBoxLong.Enabled)
                {
                    string s = txtBoxNomAtribut.Text;
                    s = ajustaTam(s, 30);
                    auxAtr.nombre = s;
                    auxAtr.cTipo = 'C';
                    auxAtr.iLongitud = Int32.Parse(txtBoxLong.Text);
                    auxAtr.iTipoIndice = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                }
                else
                {
                    string s = txtBoxNomAtribut.Text;
                    s = ajustaTam(s, 30);
                    auxAtr.nombre = s;
                    auxAtr.cTipo = 'E';
                    auxAtr.iLongitud = 4;
                    auxAtr.iTipoIndice = validaIndices(Int32.Parse(cmbtipoIndice.Text));
                }

                EscribeArchivo.escribeAtr(auxAtr, fileNameDD);
                Entaux.hsAtributos.Add(txtBoxNomAtribut.Text, auxAtr);
                Entaux.alNomAtributos.Add(txtBoxNomAtribut.Text);


                borrarErrorProviders();
                txtBoxNomAtribut.Clear();
                txtBoxNomAtribut.Focus();
                cmbTipo.SelectedIndex = -1;
                cmbtipoIndice.SelectedIndex = -1;
                txtBoxLong.Clear();
                txtBoxLong.Focus();
                txtBoxLong.Enabled = false;

                modificaCBoxTipoIndice();

                actualizaDataGridAtributos();
                actualizaDataGridEntidades();
                bndModfica = false;
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (bndElimina)
            {
                Entidad Entaux = ((Entidad)(hsEntidades[sNomEntidad]));
                Atributo auxAtr = ((Atributo)(Entaux.hsAtributos[sNombreAtr]));

                validaIndices(auxAtr.iTipoIndice);

                int pos = Entaux.alNomAtributos.IndexOf(sNombreAtr);
                /*Si dicha posicion es mayor que 0 significa que el nuevo elemento
                 *no es el primero.
                 ******************************************************************/
                if (pos > 0)
                {
                    string nomAntAtr = (Entaux.alNomAtributos[pos - 1]).ToString();

                    ((Atributo)(Entaux.hsAtributos[nomAntAtr])).lDirSigAtrib = auxAtr.lDirSigAtrib;
                    auxAtr = ((Atributo)(Entaux.hsAtributos[nomAntAtr]));

                    EscribeArchivo.escribeAtr(auxAtr, fileNameDD);
                }
                else
                {
                    Entaux.lDirAtrib = auxAtr.lDirSigAtrib;
                    EscribeArchivo.escribeEnt(Entaux, fileNameDD);
                }
                Entaux.hsAtributos.Remove(sNombreAtr);
                Entaux.alNomAtributos.Remove(sNombreAtr);
                actualizaDataGridAtributos();
                bndElimina = false;
                modificaCBoxTipoIndice();
            }
        }

        private void dgAtributos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bndElimina = true;
                sNombreAtr = dgAtributos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                sNombreAtr = extraeNombre(sNombreAtr);
            }
        }

        private void ModificaEnt_Click(object sender, EventArgs e)
        {
            if (bndModfica)
            {

                Entidad Entaux = ((Entidad)(hsEntidades[sNomEntidad]));

                ///

                int pos = alNomEntSort.IndexOf(sNomEntidad);


                if (pos > 0)
                {
                    string nomAntEnt = (alNomEntSort[pos - 1]).ToString();

                    ((Entidad)(hsEntidades[nomAntEnt])).lDirSigEnt = Entaux.lDirSigEnt;
                    EscribeArchivo.escribeEnt(((Entidad)(hsEntidades[nomAntEnt])), fileNameDD);
                }
                //////

                hsEntidades.Remove(sNomEntidad);
                alNomEntSort.Remove(sNomEntidad);
                cmbNomEntActual.Items.Remove(sNomEntidad);

                string s = txtBIngNoment.Text;
                s = ajustaTam(s, 30);
                Entaux.nombre = s;
                Entaux.lDirSigEnt = nvll;

                hsEntidades.Add(txtBIngNoment.Text, Entaux);
                alNomEntSort.Add(txtBIngNoment.Text);
                cmbNomEntActual.Items.Add(txtBIngNoment.Text);
                alNomEntSort.Sort();

                guardaEntidad(Entaux, txtBIngNoment.Text);

                txtBIngNoment.Clear();
                txtBIngNoment.Focus();

                actualizaDataGridEntidades();
                bndModfica = false;
            }
        }

        private void dgEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bndModfica = true;
                string s = dgEntidades.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                s = extraeNombre(s);

                txtBIngNoment.Text = sNomEntidad = s;
            }
        }

        private void EliminaEnt_Click(object sender, EventArgs e)
        {

            if (bndElimina)
            {
                Entidad Entaux = ((Entidad)(hsEntidades[sNomEntidad]));

                int pos = alNomEntSort.IndexOf(sNomEntidad);
                /*Si dicha posicion es mayor que 0 significa que el nuevo elemento
                 *no es el primero.
                 ******************************************************************/
                if (pos > 0)
                {
                    string nomEntAnt = alNomEntSort[pos - 1].ToString();

                    ((Entidad)(hsEntidades[nomEntAnt])).lDirSigEnt = Entaux.lDirSigEnt;

                    Entaux = ((Entidad)(hsEntidades[nomEntAnt]));

                    EscribeArchivo.escribeEnt(Entaux, fileNameDD);
                }
                else
                {
                    Cab = Entaux.lDirSigEnt;
                    EscribeArchivo.escribeLong(Cab, fileNameDD);
                }
                hsEntidades.Remove(sNomEntidad);
                alNomEntSort.Remove(sNomEntidad);
                cmbNomEntActual.Items.Remove(sNomEntidad);
                actualizaDataGridEntidades();

                bndElimina = false;
            }
        }

        private void dgEntidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                bndElimina = true;
                sNomEntidad = dgEntidades.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                sNomEntidad = extraeNombre(sNomEntidad);
            }
        }

        private void modificaCBoxTipoIndice()
        {
            if (bndCveBus)
            {
                cmbtipoIndice.Items.Remove("1");
            }
            else
            {
                if (!cmbtipoIndice.Items.Contains("1"))
                    cmbtipoIndice.Items.Add("1");
            }
            if (bndPK)
            {
                cmbtipoIndice.Items.Remove("2");
            }
            else
            {
                if (!cmbtipoIndice.Items.Contains("2"))
                    cmbtipoIndice.Items.Add("2");
            }
        }

        private Int32 validaIndices(Int32 i)
        {
            if (i == 1)
            {
                if (bndCveBus)
                    bndCveBus = false;
                else
                    bndCveBus = true;
            }
            if (i == 2)
            {
                if (bndPK)
                    bndPK = false;
                else
                    bndPK = true;
            }
            return i;
        }

        private void GeneraReg_Click(object sender, EventArgs e)
        {
            GeneraColumnas();
            creaArchivo();
            //Solo se inicializa si es que existe un tipo de indice Arbol
            InicializaArbol();
        }

        private void InicializaArbol()
        {
            int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;
            string inom;
            FileInfo f = new FileInfo(fileNameIdx);

            for (int i = 0; i < iNumAtr; i++)
            {
                inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                if (auxAt.iTipoIndice == 4)
                {
                    nodo = new Nodo(f.Length, 'H');
                    ((Entidad)(hsEntidades[sNomEntidad])).listNod.Add(nodo);
                    auxAt.lDirIndice = f.Length;
                    EscribeArchivo.escribeAtr(auxAt, fileNameDD);
                }
            }
        }

        private void GeneraColumnas()
        {
            int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;
            string inom;

            dgRegistros.Columns.Add("DRegistro", "DRegistro");

            for (int i = 0; i < iNumAtr; i++)
            {
                inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];
                if(auxAt.iTipoIndice == 5)
                {
                    DataGridViewColumn col = new DataGridViewColumn();
                    col.Name = inom + "=>>";
                    col.HeaderText = inom + "=>>";
                    col.ReadOnly = true;
                    col.CellTemplate = dgRegistros.Columns[0].CellTemplate;
                    dgRegistros.Columns.Add(inom, inom);
                    dgRegistros.Columns.Add(col);
                }
                else
                {
                    dgRegistros.Columns.Add(inom, inom);
                }
            }

            dgRegistros.Columns.Add("DSigRegistro", "DSigRegistro");

            dgRegistros.Columns[0].ReadOnly = true;
            dgRegistros.Columns[dgRegistros.Columns.Count - 1].ReadOnly = true;

            GeneraReg.Enabled = false;
            NewAdd.Enabled = true;
        }

        private void creaArchivo()
        {
            fileNameDat = fileNameIdx = Path.GetDirectoryName(fileNameDD);
            fileNameDat += @"\" + sNomEntidad + ".dat";
            fileNameIdx += @"\" + sNomEntidad + ".idx";
            long dir = 0;
            using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileNameDat, FileMode.Create)))
            {
                Writ.Seek(0, SeekOrigin.Begin);
            }

            using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileNameIdx, FileMode.Create)))
            {
                Writ.Seek(0, SeekOrigin.Begin);
            }

            NumClavesPKYFK nkey = VerificaClavesPKFK();

            if (nkey.iPK != 0)
            {
                dir = generaBloque((int)dir, 2, nkey.tamPK);
            }

            if (nkey.iFK != 0)
            {
                for (int i = 0; i < nkey.iFK; i++)
                {
                    dir = generaBloque((int)dir, 3, nkey.listamFK[i]);
                }
            }
        }

        private long generaBloque(int lDir, int tIndice, int tamClve)
        {
            long lRelleno = -1;
            long iRelleno = -1;
            string sRelleno = "C";
            int dir = lDir, tamBloqueClaves = 20 * tamClve;

            
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileNameIdx, FileMode.Open)))
                {
                    ///Se reserva espacio de 4 bytes para almacenar el numero de claves que se guardaran
                    Writ.Seek(dir, SeekOrigin.Begin);
                    Writ.Write(iRelleno);
                    dir += sizeof(int);

                    ///Se reserva espacio para almacenar las claves que se, esto es en funcion del tamaño de de la clave
                    for (int i = 0; i < tamBloqueClaves; i++)
                    {
                        Writ.Seek(dir, SeekOrigin.Begin);
                        Writ.Write(sRelleno);
                        dir += sRelleno.Length;
                    }

                    if (tIndice == 3)
                    {
                        ///Espacio para almacenar la cantidad de direcciones y se reserva espacio para 10 direcciones sin importar si se usan o no las 10
                        ///por ejemplo  int(4)  long(8) long(8) long(8) long(8) long(8)  long(8)    long(8)   long(8)   long(8)   long(8)
                        ///                 5  {[dir1]  [dir2]  [dir3]  [dir4]  [dir5]} {[bacio6]  [bacio7]  [bacio8]  [bacio9]  [bacio10]
                        ///                     Direcciones usadas
                        for (int j = 0; j < 20; j++)
                        {
                            Writ.Seek(dir, SeekOrigin.Begin);
                            Writ.Write(iRelleno);
                            dir += sizeof(int);
                            for (int i = 0; i < 10; i++)
                            {
                                Writ.Seek(dir, SeekOrigin.Begin);
                                Writ.Write(lRelleno);
                                dir += sizeof(long);
                            }
                        }
                    }
                    if (tIndice == 2)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Writ.Seek(dir, SeekOrigin.Begin);
                            Writ.Write(lRelleno);
                            dir += sizeof(long);
                        }
                    }
                    Writ.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dir;
        }

        private Atributo identificaTipoIndice(int tipoInd, ref string Indice)
        {
            string s;
            int tipoIndice = 0;
            int i = 0;
            Atributo aux = new Atributo();

            while (tipoIndice != tipoInd && i < ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos.Count)
            {
                s = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                aux = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s]));
                tipoIndice = aux.iTipoIndice;
                if (tipoIndice == tipoInd)
                    Indice = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                i++;
            }

            return aux;
        }

        private List<string> identificaFK()
        {
            string s, IndiceSec;
            List<string> lIndiceFK = new List<string>();
            int tipoIndice = 0;


            for (int i = 0; i < ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos.Count; i++)
            {
                s = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                tipoIndice = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iTipoIndice;
                if (tipoIndice == 3)
                {
                    IndiceSec = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                    lIndiceFK.Add(IndiceSec);
                }
            }
            return lIndiceFK;
        }


        private NumClavesPKYFK VerificaClavesPKFK()
        {
            string s;
            int tipoIndice = 0;

            NumClavesPKYFK nKey = new NumClavesPKYFK();

            for (int i = 0; i < ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos.Count; i++)
            {
                s = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                tipoIndice = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iTipoIndice;

                switch (tipoIndice)
                {
                    case 2:
                        nKey.iPK++;
                        nKey.tamPK = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iLongitud;
                    break;
                    case 3:
                        nKey.iFK++;
                        nKey.listamFK.Add(((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iLongitud);
                    break;
                    case 5:
                        nKey.iML++;
                        nKey.listamML.Add(((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iLongitud);
                    break;
                }
            }
            return nKey;
        }


        private int obtenerPosClaveBusqueda(string sNomEnt)
        {
            string s;
            int tipoIndice = 0;
            int pos = -1;

            for(int i = 0; i < ((Entidad)(hsEntidades[sNomEnt])).alNomAtributos.Count; i++)
            {
                s = ((Entidad)(hsEntidades[sNomEnt])).alNomAtributos[i].ToString();
                tipoIndice = ((Atributo)(((Entidad)hsEntidades[sNomEnt]).hsAtributos[s])).iTipoIndice;
                if (tipoIndice == 1)
                    pos = i + 1;
            }
            return pos;
        }

        private int getLongitudRegistro(string nomAtr)
        {
            string s = "";
            int iLong = 0;
            int i = 0;

            while (nomAtr != s)
            {
                s = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                if (nomAtr == s)
                    iLong = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iLongitud;
                i++;
            }
            return iLong;
        }

        private void dgRegistros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void MyDataGridViewInitializationMethod()
        {
            dgRegistros.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgRegistros_EditingControlShowing);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cTip == 'E')
                ValidaciónTextBoxs.onlyNumbers(e);
            else
                if (cTip == 'C')
                ValidaciónTextBoxs.onlyLetters(e);
        }

        private void dgRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgRegistros.Columns[e.ColumnIndex].ReadOnly)
            {
                string s = dgRegistros.Columns[e.ColumnIndex].Name;
                cTip = ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).cTipo;

                if (bandModifRegTem)
                {
                    renglonSeleccionado = e.RowIndex;
                    //bandModifRegTem = false;
                }
            }
        }

        private bool validaDgRegistros()
        {
            bool ban = false;
            for (int i = 0; i < dgRegistros.RowCount; i++)
            {
                for (int j = 0; j < dgRegistros.ColumnCount; j++)
                {
                    if (Convert.ToString(dgRegistros[j, i].Value) == "")
                        ban = true;
                }
            }
            return ban;
        }

        private void NewAdd_Click(object sender, EventArgs e)
        {
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            FileInfo file = new FileInfo(fileNameDat);
            //Nuevo
            if (!bandAddReg)
            {
                if(!file.Exists)
                {
                    creaArchivo();
                    InicializaArbol();
                    file = new FileInfo(fileNameDat);
                }
                dgRegistros.Rows.Add();
                for(int i = 0; i < dgRegistros.ColumnCount; i++)
                {
                    if(dgRegistros.Columns[i].ReadOnly == true)
                    {
                        dgRegistros[i, dgRegistros.RowCount - 1].Value = "-1";
                    }
                }
                dgRegistros["DRegistro", dgRegistros.RowCount - 1].Value = (file.Length).ToString();
                dgRegistros["DSigRegistro", dgRegistros.RowCount - 1].Value = "-1";
                NewAdd.Text = "Agrega";
                bandAddReg = true;
            }//Agrega
            else
            {
                if (!validaDgRegistros())
                {
                    NewAdd.Text = "Nuevo";
                    guardaRegistroMemoria();

                    if (aux.listPrimaryKey.Count != 0)
                    {
                        if (aux.listPrimaryKey[0].iClave != -1)
                            aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.iClave).ToList();
                        else
                            aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.sClave).ToList();

                        guardaClavePrimaria();
                        actualizaDataGridPrimaryKey();
                    }

                    if (aux.listsForeanKey.Count != 0)
                    {
                        for (int i = 0; i < aux.listsForeanKey.Count; i++)
                            if (aux.listsForeanKey[i].Count != 0)
                                if (aux.listsForeanKey[i][0].iClave != -1)
                                    aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.iClave).ToList();
                                else
                                    aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.sClave).ToList();
                        if(aux.listPrimaryKey.Count != 0)
                            guardaClaveSecundaria(244);
                        else
                            guardaClaveSecundaria(0);
                        actualizaDataGridForeanKey();
                    }


                    actualizaDataGridEntidades();
                    actualizaDataGridAtributos();
                    EscribeRegistros();
                    actualizaDataGridRegistros();
                    actualizaDataGridÁrbol();
                    bandAddReg = false;
                }
                else
                    MessageBox.Show("llene todos los campos");
            }
        }

        //ModificaRegistros
        private void Modifica_Click(object sender, EventArgs e)
        {
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            if (!bandModifReg)
            {
                Modifica.Text = "Actualiza";
                bandModifReg = true;
                bandModifRegTem = true;

            }//Actualiza
            else
            {
                Modifica.Text = "Modifica";
                guardaRegistroMemoria();

                if (aux.listPrimaryKey.Count != 0)
                {
                    if (aux.listPrimaryKey[0].iClave != -1)
                        aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.iClave).ToList();
                    else
                        aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.sClave).ToList();

                    guardaClavePrimaria();
                    actualizaDataGridPrimaryKey();
                }

                if (aux.listsForeanKey.Count != 0)
                {
                    for (int i = 0; i < aux.listsForeanKey.Count; i++)
                        if (aux.listsForeanKey[i].Count != 0)
                            if (aux.listsForeanKey[i][0].iClave != -1)
                                aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.iClave).ToList();
                            else
                                aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.sClave).ToList();

                    if (aux.listPrimaryKey.Count != 0)
                        guardaClaveSecundaria(244);
                    else
                        guardaClaveSecundaria(0);

                    actualizaDataGridForeanKey();
                }

                actualizaDataGridEntidades();
                EscribeRegistros();
                actualizaDataGridRegistros();
                bandModifReg = false;
                bandModifRegTem = false;
            }
        }

        private void guardaClavePrimaria()
        {
            long lDir = 0;
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));

            actualizaDirIndice(lDir, 2);

            EscribeArchivo.escribeValor(aux.listPrimaryKey.Count, lDir, fileNameIdx);
            lDir += sizeof(int);

            for (int i = 0; i < aux.listPrimaryKey.Count; i++)
            {
                if (aux.listPrimaryKey[i].iClave != -1)
                {
                    EscribeArchivo.escribeValor(aux.listPrimaryKey[i].iClave, lDir, fileNameIdx);
                    lDir += sizeof(int);
                }
                else
                {
                    string s = "";
                    Atributo auxAtr = (Atributo)identificaTipoIndice(2, ref s);

                    EscribeArchivo.escribeValor(aux.listPrimaryKey[i].sClave, lDir, fileNameIdx);
                    lDir += auxAtr.iLongitud;
                }

                EscribeArchivo.escribeValor(aux.listPrimaryKey[i].lDirección, lDir, fileNameIdx);
                lDir += sizeof(long);
            }
        }

        private void guardaClaveSecundaria(int idr)
        {
            long tam = 0;
            long lDir = idr;
            long limite;
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));

            actualizaDirIndice(lDir, 3);

            for (int k = 0; k < aux.listsForeanKey.Count; k++)
            {
                EscribeArchivo.escribeValor(aux.listsForeanKey[k].Count, lDir, fileNameIdx);
                lDir += sizeof(int);

                for (int i = 0; i < aux.listsForeanKey[k].Count; i++)
                {
                    limite = lDir + 84;
                    if (aux.listsForeanKey[k][i].iClave != -1)
                    {
                        EscribeArchivo.escribeValor(aux.listsForeanKey[k][i].iClave, lDir, fileNameIdx);
                        lDir += sizeof(int);
                        tam = sizeof(int);
                        limite += sizeof(int);
                    }
                    else
                    {
                        EscribeArchivo.escribeValor(aux.listsForeanKey[k][i].sClave, lDir, fileNameIdx);
                        lDir += aux.listsForeanKey[k][i].sClave.Length+1;
                        tam = aux.listsForeanKey[k][i].sClave.Length+1;
                        limite += aux.listsForeanKey[k][i].sClave.Length + 1;
                    }

                    EscribeArchivo.escribeValor(aux.listsForeanKey[k][i].listDirecciónes.Count, lDir, fileNameIdx);
                    lDir += sizeof(int);

                    for (int j = 0; j < aux.listsForeanKey[k][i].listDirecciónes.Count; j++)
                    {
                        EscribeArchivo.escribeValor(aux.listsForeanKey[k][i].listDirecciónes[j], lDir, fileNameIdx);
                        lDir += sizeof(long);
                    }
                    lDir = limite;
                }
                lDir = idr + (sizeof(int) + (tam + sizeof(int) + (sizeof(long) * 10)) * 20) * (k + 1);
            }
        }

        private void actualizaDirIndice(long lDir, int tipoIndice)
        {
            Atributo auxAtr;
            int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;
            string inom;

            for (int i = 0; i < iNumAtr; i++)
            {
                inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                auxAtr = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                if (auxAtr.iTipoIndice == tipoIndice)
                {
                    if (tipoIndice != 3)
                    {
                        auxAtr.lDirIndice = lDir;
                        EscribeArchivo.escribeAtr(auxAtr, fileNameDD);
                        actualizaDataGridAtributos();
                        i = iNumAtr;
                    }
                    else
                    {
                        auxAtr.lDirIndice = lDir;
                        EscribeArchivo.escribeAtr(auxAtr, fileNameDD);
                        lDir += sizeof(int) + (auxAtr.iLongitud * 20) + (sizeof(int) * 20) + ((sizeof(long) * 10) * 20);
                        actualizaDataGridAtributos();
                    }
                }
            }
        }

        private void EscribeRegistros()
        {
            string sNomCveBus;
            ArrayList alRegistro;
            Int32 iEsNum = 0;
            bool result;
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));

            for (int i = 0; i < aux.alCveBusqueda.Count; i++)
            {
                sNomCveBus = (aux.alCveBusqueda[i]).ToString();
                alRegistro = (ArrayList)aux.hsRegistros[sNomCveBus];
                long lDir = Convert.ToInt64((alRegistro[0]).ToString());
                int k = 0;
                for (int j = 0; j < alRegistro.Count; j++)
                {
                    result = Int32.TryParse((alRegistro[j]).ToString(), out iEsNum);
                    if (result)
                    {
                        if (j == 0 || j == alRegistro.Count - 1)
                        {
                            if (i == 0 & j == 0)
                                actualizaDirIndice(Convert.ToInt64(iEsNum), 1);

                            EscribeArchivo.escribeValor(Convert.ToInt64(iEsNum), lDir, fileNameDat);
                            lDir += sizeof(long);
                        }
                        else
                        {
                            EscribeArchivo.escribeValor(iEsNum, lDir, fileNameDat);
                            lDir += sizeof(int);
                            k++;
                        }
                    }
                    else
                    {
                        string nomAtr = aux.alNomAtributos[k].ToString();
                        Atributo auxAtr = (Atributo)aux.hsAtributos[nomAtr];
                        EscribeArchivo.escribeValor((string)alRegistro[j], lDir, fileNameDat);
                        lDir += auxAtr.iLongitud;
                        k++;
                    }
                }
            }
        }

        private void guardaRegistroMemoria()//modificar los indices
        {
            string sCveB = "", sAtrCveBus = "", sPrimaryKey = "", sArbol = "", val, sNomAt;
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            int i, tamCad, renglon = aux.alCveBusqueda.Count;
            long lDirRegistro = nvll;
            char tipo = '\0';
            ArrayList alRegistroActual = new ArrayList();
            FileInfo fileidx = new FileInfo(fileNameIdx);

            if(bandModifReg)
            {
                renglon = renglonSeleccionado;
                string nomReg = (aux.alCveBusqueda[renglon]).ToString();
                int pos = aux.alCveBusqueda.IndexOf(nomReg);

                long direc = Convert.ToInt64(((ArrayList)aux.hsRegistros[nomReg])[0]);
                int ps = aux.listPrimaryKey.FindIndex(x => x.lDirección == direc);
                aux.listPrimaryKey.RemoveAt(ps);
                for (int j = 0; j < aux.listsForeanKey.Count; j++)
                {
                    for (int k = 0; k < aux.listsForeanKey[j].Count; k++)
                    {
                        aux.listsForeanKey[j][k].listDirecciónes.Remove(direc);
                        if(aux.listsForeanKey[j][k].listDirecciónes.Count == 0)
                        {
                            aux.listsForeanKey[j].RemoveAt(k);
                        }
                    }
                }

                int t = ((ArrayList)aux.hsRegistros[nomReg]).Count;

                if (pos > 0)
                {
                    string nomantReg = (aux.alCveBusqueda[pos - 1]).ToString();
                    ((ArrayList)aux.hsRegistros[nomantReg])[t - 1] = ((ArrayList)aux.hsRegistros[nomReg])[t - 1];

                }
                else
                {
                    aux.lDirDatos = Convert.ToInt64(((ArrayList)aux.hsRegistros[nomReg])[t - 1]);
                    EscribeArchivo.escribeEnt(aux, fileNameDD);
                }

                aux.alCveBusqueda.Remove(nomReg);
                aux.hsRegistros.Remove(nomReg);
            }

            identificaTipoIndice(1, ref sAtrCveBus);
            identificaTipoIndice(2, ref sPrimaryKey);
            identificaTipoIndice(4, ref sArbol);
            List<string> lsForeanKey = identificaFK();

            for (i = 0; i < dgRegistros.Columns.Count; i++)
            {
                sNomAt = dgRegistros.Columns[i].Name.ToString();

                val = (dgRegistros.Rows[renglon].Cells[i].Value.ToString());
                
                if (i == 0)
                {
                    lDirRegistro = Convert.ToInt64(val);
                }

                if (!dgRegistros.Columns[i].ReadOnly)
                {
                    tipo = ((Atributo)(aux.hsAtributos[sNomAt])).cTipo;//
                    if (tipo == 'C')
                    {
                        tamCad = ((Atributo)(aux.hsAtributos[sNomAt])).iLongitud;
                        val = ajustaTam(val, tamCad);
                    }
                }

                //Problema: llenar la lista de listas de claves secundarias
                if (aux.listsForeanKey.Count != 0 && lsForeanKey.Contains(sNomAt) && renglon != 0)
                    for (int k = 0; k < lsForeanKey.Count; k++)
                    {
                        if (lsForeanKey[k] == sNomAt)
                        {
                            bool bnde = false;
                            for (int j = 0; j < aux.listsForeanKey[k].Count; j++)
                            {
                                switch (tipo)
                                {
                                    case 'E':
                                        if (aux.listsForeanKey[k][j].iClave == Convert.ToInt32(val))
                                        {
                                            aux.listsForeanKey[k][j].listDirecciónes.Add(lDirRegistro);
                                            aux.listsForeanKey[k][j].listDirecciónes.Sort();
                                            bnde = true;
                                        }
                                    break;
                                    case 'C':
                                        if (aux.listsForeanKey[k][j].sClave == val)
                                        {
                                            aux.listsForeanKey[k][j].listDirecciónes.Add(lDirRegistro);
                                            aux.listsForeanKey[k][j].listDirecciónes.Sort();
                                            bnde = true;
                                        }
                                    break;
                                }
                            }
                            if (!bnde)
                            {
                                if (tipo == 'E')
                                {
                                    ForeanKey fK = new ForeanKey(Convert.ToInt32(val));
                                    fK.listDirecciónes.Add(lDirRegistro);
                                    aux.listsForeanKey[k].Add(fK);
                                }
                                else
                                    if (tipo == 'C')
                                    {
                                        ForeanKey fK = new ForeanKey(val);
                                        fK.listDirecciónes.Add(lDirRegistro);
                                        aux.listsForeanKey[k].Add(fK);
                                    }
                            }
                        }
                    }
                else
                {
                    if (lsForeanKey.Contains(sNomAt))
                    {
                        List<ForeanKey> auxListForeanKey = new List<ForeanKey>();

                        if (tipo == 'E')
                        {
                            ForeanKey fK = new ForeanKey(Convert.ToInt32(val));
                            fK.listDirecciónes.Add(lDirRegistro);
                            auxListForeanKey.Add(fK);
                        }
                        else
                            if (tipo == 'C')
                            {
                                ForeanKey fK = new ForeanKey(val);
                                fK.listDirecciónes.Add(lDirRegistro);
                                auxListForeanKey.Add(fK);
                            }

                        aux.listsForeanKey.Add(auxListForeanKey);
                    }
                }

                if (sPrimaryKey == sNomAt)
                {
                    PrimaryKey pK = new PrimaryKey(Convert.ToInt32(val), lDirRegistro);
                    aux.listPrimaryKey.Add(pK);
                }

                if (sArbol == sNomAt)
                {//Supuestamente bueno
                    InserciónÁrbol(Convert.ToInt32(val), lDirRegistro);
                    for (int Dustin = 0; Dustin < aux.listNod.Count; Dustin++)
                    {
                        EscribeArchivo.escribeNodo(aux.listNod[Dustin], fileNameIdx);
                    }
                }

                if (sAtrCveBus != "")
                {
                    if (sAtrCveBus == sNomAt)
                    {
                        
                        sCveB = val;

                        if (aux.alCveBusqueda.Contains(sCveB))
                        {
                            while (aux.alCveBusqueda.Contains(sCveB))
                            {
                                sCveB = sCveB + "A";
                            }
                            aux.alCveBusqueda.Add(sCveB);
                            aux.alCveBusqueda.Sort();
                        }
                        else
                        {
                            aux.alCveBusqueda.Add(sCveB);
                            aux.alCveBusqueda.Sort();
                        }
                        
                        int pos = aux.alCveBusqueda.IndexOf(sCveB);

                        if (pos == 0)
                        {
                            aux.lDirDatos = Convert.ToInt64(alRegistroActual[0]);
                            EscribeArchivo.escribeEnt(aux, fileNameDD);
                        }
                    }
                }
                else
                {
                    if(i == 0)
                    {
                        sCveB = renglon.ToString();
                        aux.alCveBusqueda.Add(sCveB);
                        int pos = aux.alCveBusqueda.IndexOf(sCveB);

                        if (pos == 0 && i == 0)
                        {
                            aux.lDirDatos = lDirRegistro;
                            EscribeArchivo.escribeEnt(aux, fileNameDD);
                        }
                    }
                }

                if (i == dgRegistros.Columns.Count - 1)
                {
                    insertaRegistroEnorden(ref aux, ref sCveB, ref val, ref alRegistroActual);
                }
                alRegistroActual.Add(val);
            }
                aux.hsRegistros.Add(sCveB, alRegistroActual);
        }

        private void insertaRegistroEnorden(ref Entidad aux,ref string sCveB, ref string val, ref ArrayList alRegistroActual)
        {
            if (aux.hsRegistros.Count != 0)
            {
                int pos = aux.alCveBusqueda.IndexOf(sCveB);
                if (pos > 0)
                {
                    string nomAntCveBus = (aux.alCveBusqueda[pos - 1]).ToString();
                    val = ((ArrayList)aux.hsRegistros[nomAntCveBus])[dgRegistros.Columns.Count - 1].ToString();
                    ((ArrayList)aux.hsRegistros[nomAntCveBus])[dgRegistros.Columns.Count - 1] = alRegistroActual[0];
                }
                else
                {
                    string nomSegCveBus = (aux.alCveBusqueda[pos + 1]).ToString();
                    ///Aqui se modifica la dir sig
                    val = ((ArrayList)aux.hsRegistros[nomSegCveBus])[0].ToString();
                }
            }
        }


        private void actualizaDataGridRegistros()
        {
            Entidad auxEnt = ((Entidad)(hsEntidades[sNomEntidad]));
            dgRegistros.Rows.Clear();
            //////////
            if (auxEnt.hsRegistros.Count != 0)
            {
                string sNom;
                ArrayList aux;
                for (int i = 0; i < auxEnt.alCveBusqueda.Count; i++)
                {
                    sNom = (auxEnt.alCveBusqueda[i]).ToString();
                    aux = (ArrayList)(auxEnt.hsRegistros[sNom]);
                    dgRegistros.Rows.Add();
                    for (int j = 0; j < dgRegistros.ColumnCount; j++)
                    {
                        dgRegistros.Rows[i].Cells[j].Value = aux[j];
                    }
                }
            }
        }
        
        private void actualizaDataGridÁrbol()
        {
            Entidad auxEnt = ((Entidad)(hsEntidades[sNomEntidad]));
            dgÁrbol.Rows.Clear();
            int j = 0, i = 0;
            //////////
            if (auxEnt.listNod.Count != 0)
            {
                for (i = 0; i < auxEnt.listNod.Count; i++)
                {

                    dgÁrbol.Rows.Add();
                    int n = 0;
                    int m = 0;
                    for (j = 0; j < dgÁrbol.ColumnCount; j++)
                    {
                        if (j < 2)
                        {
                            dgÁrbol.Rows[i].Cells[j].Value = auxEnt.listNod[i].lDirNod;
                            j++;
                            dgÁrbol.Rows[i].Cells[j].Value = auxEnt.listNod[i].cTipo;
                            j++;
                        }
                        
                            if (n < auxEnt.listNod[i].llDirecciones.Count)
                            {
                                dgÁrbol.Rows[i].Cells[j].Value = auxEnt.listNod[i].llDirecciones[n];
                                n++;
                                j++;
                            }
                            if (m < auxEnt.listNod[i].liClaves.Count)
                            {
                                dgÁrbol.Rows[i].Cells[j].Value = auxEnt.listNod[i].liClaves[m];
                                m++;
                            }
                        
                    }
                }
            }
        }

        private int calculaTamañoRegistro()
        {
            string s;
            int tam = 0;

            for(int i = 0; i < ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos.Count; i++)
            {
                s = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                tam += ((Atributo)(((Entidad)hsEntidades[sNomEntidad]).hsAtributos[s])).iLongitud;
            }

            return tam;
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmbNomEntActual.Items.Clear();
            dgEntidades.Rows.Clear();
            dgAtributos.Rows.Clear();
            dgRegistros.Rows.Clear();
            dgRegistros.Columns.Clear();
            dgForeanKey.Rows.Clear();
            dgPrimaryKey.Rows.Clear();
            hsEntidades.Clear();
            alNomEntSort.Clear();
            ((Control)tabEntidad).Enabled = false;
            ((Control)tabAtributo).Enabled = false;
            ((Control)tabRegistros).Enabled = false;

        }

        private void EliminaRegistro_Click(object sender, EventArgs e)
        {
            Entidad aux = ((Entidad)(hsEntidades[sNomEntidad]));
            int renglon;

            if (bandModifReg)
            {
                renglon = renglonSeleccionado;
                string nomReg = (aux.alCveBusqueda[renglon]).ToString();
                int pos = aux.alCveBusqueda.IndexOf(nomReg);

                int t = ((ArrayList)aux.hsRegistros[nomReg]).Count;

                //Elimina las claves que contienen la direccion del registro que se ha de eliminar
                long direc = Convert.ToInt64(((ArrayList)aux.hsRegistros[nomReg])[0]);
                if (aux.listPrimaryKey.Count != 0)
                {
                    int ps = aux.listPrimaryKey.FindIndex(x => x.lDirección == direc);
                    aux.listPrimaryKey.RemoveAt(ps);
                }
                if (aux.listsForeanKey.Count != 0)
                {
                    for (int j = 0; j < aux.listsForeanKey.Count; j++)
                    {
                        for (int k = 0; k < aux.listsForeanKey[j].Count; k++)
                        {
                            aux.listsForeanKey[j][k].listDirecciónes.Remove(direc);
                            if (aux.listsForeanKey[j][k].listDirecciónes.Count == 0)
                            {
                                aux.listsForeanKey[j].RemoveAt(k);
                            }
                        }
                    }
                }
                ///////////////
                if (pos > 0)
                {
                    string nomantReg = (aux.alCveBusqueda[pos - 1]).ToString();
                    ((ArrayList)aux.hsRegistros[nomantReg])[t - 1] = ((ArrayList)aux.hsRegistros[nomReg])[t - 1];

                }
                else
                {
                    aux.lDirDatos = Convert.ToInt64(((ArrayList)aux.hsRegistros[nomReg])[t - 1]);
                    EscribeArchivo.escribeEnt(aux, fileNameDD);
                }

                ///////
                if (aux.listPrimaryKey.Count != 0)
                {
                    if (aux.listPrimaryKey[0].iClave != -1)
                        aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.iClave).ToList();
                    else
                        aux.listPrimaryKey = aux.listPrimaryKey.OrderBy(p => p.sClave).ToList();

                    guardaClavePrimaria();
                    actualizaDataGridPrimaryKey();
                }

                if (aux.listsForeanKey.Count != 0)
                {
                    for (int i = 0; i < aux.listsForeanKey.Count; i++)
                        if (aux.listsForeanKey[i].Count != 0)
                            if (aux.listsForeanKey[i][0].iClave != -1)
                                aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.iClave).ToList();
                            else
                                aux.listsForeanKey[i] = aux.listsForeanKey[i].OrderBy(p => p.sClave).ToList();
                    if (aux.listPrimaryKey.Count != 0)
                        guardaClaveSecundaria(244);
                    else
                        guardaClaveSecundaria(0);
                    actualizaDataGridForeanKey();
                }

                if (aux.listNod.Count != 0)
                {
                    int iNumAtr = aux.hsAtributos.Count;
                    int dato = 0;
                    for (int i = 0; i < iNumAtr; i++)
                    {
                        string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                        Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                        if (auxAt.iTipoIndice == 4)
                        {
                            auxAt.lDirIndice = nvll;
                            dato = Convert.ToInt32(((ArrayList)aux.hsRegistros[nomReg])[i+1]);
                            i = iNumAtr;
                        }
                    }

                    EliminarA(dato);
                    for(int i = 0; i < aux.listNod.Count; i++)
                    {
                        EscribeArchivo.escribeNodo(aux.listNod[i], fileNameIdx);                        
                    }
                }
                aux.alCveBusqueda.Remove(nomReg);
                aux.hsRegistros.Remove(nomReg);


                if (aux.hsRegistros.Count == 0)
                {
                    File.Delete(fileNameDat);

                    int iNumAtr = aux.hsAtributos.Count;
                    int inIndices = 0;
                    for (int i = 0; i < iNumAtr; i++)
                    {
                        string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                        Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                        if (auxAt.iTipoIndice != 0)
                            inIndices++;
                    }
                    if(inIndices == 1)
                        File.Delete(fileNameIdx);
                }

                EscribeRegistros();
                actualizaDataGridAtributos();
                actualizaDataGridEntidades();
                actualizaDataGridRegistros();
                actualizaDataGridForeanKey();
                actualizaDataGridPrimaryKey();
                actualizaDataGridÁrbol();
                bandModifReg = false;
                Modifica.Text = "Modifica";
            }
        }

        private void OrdenaDatosNodo(Nodo nod)
        {
            List<Pares> lpares = new List<Pares>();
            bool eq = false;
            int m;

            if (nod.cTipo == 'H')
            {
                for (int i = 0; i < nod.liClaves.Count; i++)
                {
                    Pares p = new Pares(nod.llDirecciones[i], nod.liClaves[i]);
                    lpares.Add(p);
                }

                lpares = lpares.OrderBy(p => p.iDato).ToList();

                for (int i = 0; i < nod.liClaves.Count; i++)
                {
                    nod.llDirecciones[i] = lpares[i].lDir;
                    nod.liClaves[i] = lpares[i].iDato;
                }
            }
            else
            {
                if (nod.liClaves.Count == nod.llDirecciones.Count)
                {
                    m = 0;
                    eq = true;
                }
                long tem = 0;
                for (int i = 0; i < nod.liClaves.Count; i++)
                {
                    if (i == 0 && !eq)//&& !(nod.liClaves.Count == nod.llDirecciones.Count))
                    {
                        tem = nod.llDirecciones[i];
                        nod.llDirecciones.RemoveAt(i);
                    }
                    Pares p = new Pares(nod.llDirecciones[i], nod.liClaves[i]);
                    lpares.Add(p);
                }

                lpares = lpares.OrderBy(p => p.iDato).ToList();

                for (int i = 0; i < nod.liClaves.Count; i++)
                {
                    nod.llDirecciones[i] = lpares[i].lDir;
                    nod.liClaves[i] = lpares[i].iDato;
                }
                if(!eq)
                    nod.llDirecciones.Insert(0,tem);
            }
        }

        private void Mitosis(Nodo auxNod, Nodo nde)
        {
            int j = 0;

            while (auxNod.liClaves.Count != 2)
            {

                int n = 2;
                nde.liClaves.Add(auxNod.liClaves[n]);

                if (nde.cTipo == 'I')
                {
                    if (j == 0)
                    {
                        nde.llDirecciones.Add(auxNod.llDirecciones[n]);
                        nde.llDirecciones.Add(auxNod.llDirecciones[n+1]);
                    }
                    else
                        if (j < 2) 
                            nde.llDirecciones.Add(auxNod.llDirecciones[n+1]);
                }
                else
                    nde.llDirecciones.Add(auxNod.llDirecciones[n]);
                auxNod.liClaves.RemoveAt(n);
                if (nde.cTipo == 'I')
                {
                    if (j < 2)
                        auxNod.llDirecciones.RemoveAt(n + 1);
                }
                else
                {
                    auxNod.llDirecciones.RemoveAt(n);
                }
                j++;
            }
        }

        private Nodo InsertarEn(Nodo Naux, int clave)
        {
            Nodo aux = new Nodo();
            for (int i = 0; i < Naux.liClaves.Count; i++)
            {
                if (clave > Naux.liClaves[i])
                {
                    for (int ni = 0; ni < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; ni++)
                    {
                        if (((Entidad)hsEntidades[sNomEntidad]).listNod[ni].lDirNod == Naux.llDirecciones[i + 1])
                        {
                            aux = ((Entidad)hsEntidades[sNomEntidad]).listNod[ni];
                            indListNodo = ni;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; j++)
                    {
                        if (((Entidad)hsEntidades[sNomEntidad]).listNod[j].lDirNod == Naux.llDirecciones[i])
                        {
                            aux = ((Entidad)hsEntidades[sNomEntidad]).listNod[j];
                            indListNodo = j;
                        }
                    }
                    i = Naux.liClaves.Count;
                }
            }
            return aux;
        }
        private void MenosDe4(int clave, long dir)
        {
            nodo.AddCveDir(clave, dir);
            if (nodo.liClaves.Count > 1)
                OrdenaDatosNodo(nodo);
            ((Entidad)hsEntidades[sNomEntidad]).listNod[0] = nodo;
        }

        private void IgualOMAy(int clave, long dir, ref long pos, ref Nodo auxR)
        {
            Nodo auxNod = nodo;
            nodo = new Nodo(pos, 'H');
            pos += 65;
            auxNod.AddCveDir(clave, dir);
            OrdenaDatosNodo(auxNod);
            Mitosis(auxNod, nodo);
            OrdenaDatosNodo(nodo);
            ((Entidad)hsEntidades[sNomEntidad]).listNod[0] = auxNod;
            ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(nodo);
            auxR = new Nodo(pos, 'R');
            pos += 65;
            auxR.llDirecciones.Add(auxNod.lDirNod);
            auxR.llDirecciones.Add(nodo.lDirNod);
            auxR.liClaves.Add(nodo.liClaves[0]);
            ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(auxR);
            indR = ((Entidad)hsEntidades[sNomEntidad]).listNod.Count - 1;
        }

        private void InserciónÁrbol(int clave, long dir)
        {
            Nodo auxR = null;
            FileInfo fileidx = new FileInfo(fileNameIdx);
            long pos = fileidx.Length;

            for (int i = 0; i < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; i++)//Checa si existe la Raiz
            {
                if (((Entidad)hsEntidades[sNomEntidad]).listNod[i].cTipo == 'R')
                    auxR = ((Entidad)hsEntidades[sNomEntidad]).listNod[i];
            }

            if (auxR == null)
            {
                if (nodo != null)
                {
                    if (!nodo.liClaves.Contains(clave))
                    {
                        if (nodo.liClaves.Count < 4)
                        {
                            MenosDe4(clave, dir);
                        }
                        else
                        {
                            IgualOMAy(clave, dir, ref pos, ref auxR);
                        }
                    }
                }
                else
                {
                    InicializaArbol();
                }
                if (auxR != null)
                {
                    /////
                    int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;

                    for (int i = 0; i < iNumAtr; i++)
                    {
                        string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                        Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                        if (auxAt.iTipoIndice == 4)
                        {
                            auxAt.lDirIndice = auxR.lDirNod;
                            EscribeArchivo.escribeAtr(auxAt, fileNameDD);
                        }
                    }
                }

            }
            else
            {
                Nodo itNod, ndMan, nodAuxr = InsertarEn(auxR, clave);
                ndMan = auxR;
                if (nodAuxr.cTipo == 'I')
                {
                    ndMan = nodAuxr;
                    itNod = InsertarEn(nodAuxr, clave);
                    nodAuxr = itNod;
                }

                if (nodAuxr.liClaves.Count < 4)
                {
                    nodAuxr.AddCveDir(clave, dir);

                    if (nodAuxr.liClaves.Count > 1)
                        OrdenaDatosNodo(nodAuxr);

                    ((Entidad)hsEntidades[sNomEntidad]).listNod[indListNodo] = nodAuxr;
                }
                else
                {
                    if (ndMan.Equals(auxR))
                    {
                        Nodo auxNod = nodAuxr;
                        nodo = new Nodo(pos, 'H');
                        pos += 65;
                        auxNod.AddCveDir(clave, dir);
                        OrdenaDatosNodo(auxNod);
                        Mitosis(auxNod, nodo);
                        OrdenaDatosNodo(nodo);
                        ((Entidad)hsEntidades[sNomEntidad]).listNod[indListNodo] = auxNod;
                        ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(nodo);
                        

                        if (auxR.liClaves.Count < 4)
                        {
                            auxR.AddCveDir(nodo.liClaves[0], nodo.lDirNod);
                            OrdenaDatosNodo(auxR);
                            ((Entidad)hsEntidades[sNomEntidad]).listNod[indR] = auxR;
                        }
                        else
                        {
                            Nodo nint = new Nodo(pos, 'I');
                            pos += 65;
                            Nodo nAux = auxR;
                            nAux.liClaves.Add(nodo.liClaves[0]);
                            OrdenaDatosNodo(nAux);
                            Mitosis(nAux, nint);
                            OrdenaDatosNodo(nint);
                            nAux.cTipo = 'I';
                            for (int i = 0; i < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; i++)
                            {
                                if (((Entidad)hsEntidades[sNomEntidad]).listNod[i].lDirNod == auxR.lDirNod)
                                    ((Entidad)hsEntidades[sNomEntidad]).listNod[i] = nAux;
                            }
                            
                            auxR = new Nodo();
                            auxR.cTipo = 'R';
                            auxR.llDirecciones.Add(nAux.lDirNod);
                            auxR.AddCveDir(nint.liClaves[0], nint.lDirNod);
                            indR = ((Entidad)hsEntidades[sNomEntidad]).listNod.Count - 1;
                            nint.liClaves.RemoveAt(0);
                            nint.llDirecciones.RemoveAt(0);
                            nint.llDirecciones.Add(nodo.lDirNod);
                            
                            auxR.lDirNod = pos;
                            pos += 65;
                            ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(nint);
                            ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(auxR);
                        }
                    }
                    else
                    {
                        Nodo auxNod = nodAuxr;
                        nodo = new Nodo(pos, 'H');
                        pos += 65;
                        auxNod.AddCveDir(clave, dir);
                        OrdenaDatosNodo(auxNod);
                        Mitosis(auxNod, nodo);
                        OrdenaDatosNodo(nodo);
                        ((Entidad)hsEntidades[sNomEntidad]).listNod[indListNodo] = auxNod;
                        ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(nodo);
                        

                        if (ndMan.liClaves.Count < 4)
                        {
                            Nodo nMid = ndMan;
                            nMid.AddCveDir(nodo.liClaves[0], nodo.lDirNod);
                            OrdenaDatosNodo(nMid);
                            for (int i = 0; i < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; i++)
                            {
                                if (((Entidad)hsEntidades[sNomEntidad]).listNod[i].lDirNod == nMid.lDirNod)
                                    ((Entidad)hsEntidades[sNomEntidad]).listNod[i] = nMid;
                            }

                            nMid = ndMan;
                        }
                        else
                        {
                            Nodo Nodnint = new Nodo(pos, 'I');
                            pos += 65;

                            ndMan.liClaves.Add(nodo.liClaves[0]);
                            OrdenaDatosNodo(ndMan);
                            auxR.AddCveDir(ndMan.liClaves[2], Nodnint.lDirNod);
                            Mitosis(ndMan, Nodnint);
                            Nodnint.llDirecciones.Add(nodo.lDirNod);
                            Nodnint.llDirecciones.RemoveAt(0);
                            Nodnint.liClaves.RemoveAt(0);

                            OrdenaDatosNodo(Nodnint);
                            OrdenaDatosNodo(auxR);

                            ((Entidad)hsEntidades[sNomEntidad]).listNod.Add(Nodnint);

                            for (int i = 0; i < ((Entidad)hsEntidades[sNomEntidad]).listNod.Count; i++)
                            {
                                if (((Entidad)hsEntidades[sNomEntidad]).listNod[i].lDirNod == ndMan.lDirNod)
                                    ((Entidad)hsEntidades[sNomEntidad]).listNod[i] = ndMan;
                                if (((Entidad)hsEntidades[sNomEntidad]).listNod[i].lDirNod == auxR.lDirNod)
                                    ((Entidad)hsEntidades[sNomEntidad]).listNod[i] = auxR;

                            }
                        }
                    }
                }
            }
            if (auxR != null)
            {
                int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;

                for (int i = 0; i < iNumAtr; i++)
                {
                    string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                    Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                    if (auxAt.iTipoIndice == 4)
                    {
                        auxAt.lDirIndice = auxR.lDirNod;
                        EscribeArchivo.escribeAtr(auxAt, fileNameDD);
                    }
                }
            }
        }

        public void EliminarA(int dato)
         {
            bool apiz = false;
            auxRa = null;
            foreach (Nodo r in ((Entidad)(hsEntidades[sNomEntidad])).listNod)//Busca la raiz
                 if (r.cTipo == 'R')
                     auxRa = r;

             Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);//.listNod

             Nodo elim;
             Nodo Anterior = auxRa;
             Nodo Izq; Nodo Der;
             int lugar = 0, lugR = 0;
             Nodo aIzq;
             Nodo aDer;
             bool fusion = false;
             if (auxRa != null)//si hay raiz
             {
                 elim = new Nodo();
                 Izq = Der = aIzq = aDer = null;

                for (int j = 0; j < auxRa.liClaves.Count; j++)//Recorre los datos para ver en que nodo se eliminará
                {
                    aDer = aIzq = null;
                    if (dato < auxRa.liClaves[j])//si el dato es mas pequeño
                    {
                        int ps = auxRa.llDirecciones.IndexOf(elim.lDirNod);
                        

                        for (int x = 0; x < auxEnt.listNod.Count; x++)//Recorre la lista de nodos
                        {
                            if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j])//busca el en donde se encuentra el dato a eliminar
                                elim = Busca(auxRa.llDirecciones[j], auxEnt.listNod);
                            if (j != 0)//si no es el mas a la izquierda
                                if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j - 1])//busca el izquierdo
                                    aIzq = Izq = Busca(auxRa.llDirecciones[j - 1], auxEnt.listNod);
                            if (j < auxRa.liClaves.Count)//si no es el más a la derecha
                                if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j + 1])//busca el derecho
                                    aDer = Der = Busca(auxRa.llDirecciones[j + 1], auxEnt.listNod);
                            if (j != 0)
                                lugar = lugR = j - 1;
                        }
                        j = auxRa.liClaves.Count + 3;
                    }
                    else//si es mas grande
                    {
                        apiz = true;
                        for (int x = 0; x < auxEnt.listNod.Count; x++)//Recorre la lista de nodos
                        {
                            if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j + 1])//busca el en donde se encuentra el dato a eliminar
                                elim = Busca(auxRa.llDirecciones[j + 1], auxEnt.listNod);
                            if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j])//busca el izquierdo
                                aIzq = Izq = Busca(auxRa.llDirecciones[j], auxEnt.listNod);
                            if ((j + 1) < auxRa.liClaves.Count)//si no es el más a la derecha
                                if (auxEnt.listNod[x].lDirNod == auxRa.llDirecciones[j + 2])//busca el derecho
                                    aDer = Der = Busca(auxRa.llDirecciones[j + 2], auxEnt.listNod);
                            lugar = lugR = j;
                        }
                    }
                    
                 }

                 if (elim.cTipo == 'I')//recorre mientras sean nodos intermedios
                 {
                     Anterior = elim; lugar = 0;
                     Nodo Aux = new Nodo(); lugar = 0;
                     for (int j = 0; j < elim.liClaves.Count; j++)//Recorre los datos del nodo intermedio para ver en que nodo se eliminará
                     {
                         Izq = Der = null;
                         if (dato < elim.liClaves[j])//si el dato es mas pequeño
                         {
                             for (int x = 0; x < auxEnt.listNod.Count; x++)//Recorre la lista de nodos
                             {
                                 if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j])//busca el en donde se encuentra el dato a eliminar
                                     Aux = Busca(elim.llDirecciones[j], auxEnt.listNod);
                                 if (j != 0)//si no es el mas a la izquierda
                                     if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j - 1])//busca el izquierdo
                                         Izq = Busca(elim.llDirecciones[j - 1], auxEnt.listNod);
                                 if (j < elim.liClaves.Count)//si no es el más a la derecha
                                     if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j + 1])//busca el derecho
                                         Der = Busca(elim.llDirecciones[j + 1], auxEnt.listNod);
                                 if (j != 0)
                                     lugar = j - 1;
                             }
                             j = elim.liClaves.Count + 3;
                         }
                         else//si es mas grande
                             for (int x = 0; x < auxEnt.listNod.Count; x++)//Recorre la lista de nodos
                             {
                                 if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j + 1])//busca el en donde se encuentra el dato a eliminar
                                     Aux = Busca(elim.llDirecciones[j + 1], auxEnt.listNod);
                                 if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j])//busca el izquierdo
                                     Izq = Busca(elim.llDirecciones[j], auxEnt.listNod);
                                 if ((j + 1) < elim.liClaves.Count)//si no es el más a la derecha
                                     if (auxEnt.listNod[x].lDirNod == elim.llDirecciones[j + 2])//busca el derecho
                                         Der = Busca(elim.llDirecciones[j + 2], auxEnt.listNod);
                                 lugar = j;
                             }
                     }
                     elim = Aux;//Encontramos el nodo que contiene la clave
                 }//Perro
                ///////Eliminar
                if (elim.liClaves.Contains(dato))
                {
                    int pos = elim.liClaves.IndexOf(dato);
                    elim.liClaves.RemoveAt(pos);//Elimina dato
                    elim.llDirecciones.RemoveAt(pos);//remueve apuntador del dato
                    int i = 0;

                    if (elim.cTipo == 'H'&& Anterior.cTipo == 'R' && pos == 0 && Izq == null)
                    {

                        for (int j = 0; j < auxRa.liClaves.Count; j++)//Recorre los datos para ver en que nodo se eliminará
                        {
                            if (dato < auxRa.liClaves[j])//si el dato es mas pequeño
                            {
                                i = j - 1;
                                j = auxRa.liClaves.Count;
                            }
                        }
                        if (i >= 0)
                        {
                            auxRa.liClaves.RemoveAt(i);
                            auxRa.liClaves.Insert(i, elim.liClaves[0]);
                        }
                    }
                }

                if (elim.liClaves.Count < 2)//si quedó insuficiente 
                {
                     if (Izq != null)//si tiene izquiero
                     {
                         if (Izq.liClaves.Count > 2)// si puede donar
                             DonaIzq(elim, Izq, Anterior, lugar);
                         else
                         {
                             if (Der != null)//existe
                                 if (Der.liClaves.Count > 2)//si puede donar
                                     DonaDer(elim, Der, Anterior, lugar);
                                 else
                                     fusion = true;
                             else
                                 fusion = true;
                         }
                         if (fusion)
                             FusionIzq(elim, Izq, Anterior, lugar, aIzq, aDer, lugR);
                     }
                     else//Derecho
                     {/////
                        
                            if (Der.liClaves.Count > 2)
                                DonaDer(elim, Der, Anterior, lugar);
                            else//fusion con derecho
                                FusionDer(elim, Der, Anterior, lugar, aIzq, aDer, lugR);
                        
                    }
                 }
             }
             else//solo hay un nodo, como solo es un nodo, este es de tipo hoja
             {
                if(auxEnt.listNod[0].liClaves.Contains(dato))
                {
                    int pos = auxEnt.listNod[0].liClaves.IndexOf(dato);
                    auxEnt.listNod[0].liClaves.RemoveAt(pos);//Elimina dato
                    auxEnt.listNod[0].llDirecciones.RemoveAt(pos);//remueve apuntador del dato
                }

                 if (auxEnt.listNod[0].liClaves.Count == 0)//si el nodo esta vacio
                 {
                     auxEnt.listNod.RemoveAt(0);//elimina nodo
                    int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;

                    for (int i = 0; i < iNumAtr; i++)
                    {
                        string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                        Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                        if (auxAt.iTipoIndice == 4)
                        {
                            auxAt.lDirIndice = nvll;
                            EscribeArchivo.escribeAtr(auxAt, fileNameDD);
                            i = iNumAtr;
                        }
                    }
                 }
             }
         }

         public Nodo Busca(long Apuntador, List<Nodo> nod)
         {
             Nodo Res = new Nodo();
             for (int x = 0; x < nod.Count; x++)
                 if (nod[x].lDirNod == Apuntador)
                {
                    Res = nod[x];
                    break;
                }
                     

             return Res;
         }

         public void DonaIzq(Nodo elim, Nodo Izq, Nodo Anterior, int lugar)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            Nodo Aux = new Nodo(); Aux.lDirNod = elim.lDirNod; Aux.cTipo = elim.cTipo;
            Aux.liClaves.Add(Izq.liClaves[Izq.liClaves.Count - 1]);//agrega ultimo dato
            Aux.llDirecciones.Add(Izq.llDirecciones[Izq.liClaves.Count - 1]);
            Aux.llDirecciones.Add(elim.llDirecciones[0]);
            Aux.liClaves.Add(elim.liClaves[0]);
            elim = Aux;//Agrega dato a derecho

            Anterior.liClaves[lugar] = Izq.liClaves[Izq.liClaves.Count - 1]; //modifica anterior
            Izq.llDirecciones.RemoveAt(Izq.liClaves.Count - 1);//Elimina dato del izquierdo
            Izq.liClaves.RemoveAt(Izq.liClaves.Count - 1);

            for (int x = 0; x < auxEnt.listNod.Count; x++)//Guarda en memoria
             {
                 if (auxEnt.listNod[x].lDirNod == elim.lDirNod)
                     auxEnt.listNod[x] = elim;
                 if (auxEnt.listNod[x].lDirNod == Anterior.lDirNod)
                     auxEnt.listNod[x] = Anterior;
                 if (auxEnt.listNod[x].lDirNod == Izq.lDirNod)
                     auxEnt.listNod[x] = Izq;
             }

         }
        public void DonaIzqInter(Nodo elim, Nodo Izq, Nodo Anterior, int lugar)
        {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);

            elim.liClaves.Insert(0, Anterior.liClaves[Anterior.liClaves.Count - 1]);
            elim.llDirecciones.Insert(0, Izq.llDirecciones[Izq.llDirecciones.Count - 1]);
            Anterior.liClaves.RemoveAt(Anterior.liClaves.Count - 1);
            Izq.llDirecciones.RemoveAt(Izq.llDirecciones.Count - 1);
            Anterior.liClaves.Add(Izq.liClaves[Izq.liClaves.Count - 1]);
            Izq.liClaves.RemoveAt(Izq.liClaves.Count - 1);

        }

        public void DonaDerInter(Nodo elim, Nodo Der, Nodo Anterior, int lugar)
        {
            /////

            int i = 0;
            for (int j = 0; j < auxRa.liClaves.Count; j++)//Recorre los datos para ver en que nodo se eliminará
            {
                if (elim.liClaves[0] < auxRa.liClaves[j])//si el dato es mas pequeño
                {
                    i = j;
                    j = auxRa.liClaves.Count;
                }

            }


            elim.AddCveDir(Anterior.liClaves[i], Der.llDirecciones[0]);
            Anterior.liClaves.RemoveAt(i);

            Anterior.liClaves.Insert(i, Der.liClaves[0]);
            Der.liClaves.RemoveAt(0);
            Der.llDirecciones.RemoveAt(0);
        }
        public void DonaDer(Nodo elim, Nodo Der, Nodo Anterior, int lugar)
        {
            
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            elim.AddCveDir(Der.liClaves[0], Der.llDirecciones[0]);
            Der.liClaves.RemoveAt(0);//elimina delnodo el primer dato junto con su apuntador
            Der.llDirecciones.RemoveAt(0);
            if (elim.liClaves[0] != Anterior.liClaves[lugar])
            {
                Anterior.liClaves.RemoveAt(lugar);
                Anterior.liClaves.Insert(lugar, elim.liClaves[0]);
            }
            Anterior.liClaves[Anterior.liClaves.Count - 1] = Der.liClaves[0];//cambia valor y apuntador del anterior
            //Anterior.llDirecciones[lugar + 1] = Der.llDirecciones[0];
        }

        public void FusionIzq(Nodo elim, Nodo Izq, Nodo Anterior, int lugar, Nodo aIzq, Nodo aDer, int lugR)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            Izq.AddCveDir(elim.liClaves[0], elim.llDirecciones[0]);

            Anterior.liClaves.RemoveAt(lugar);//elimina de anterir
            Anterior.llDirecciones.RemoveAt(lugar + 1);

            int pos = auxEnt.listNod.IndexOf(elim);
            auxEnt.listNod.RemoveAt(pos);

            EliminaInterA(Anterior, auxRa, aIzq, aDer, lugR);
         }

         public void FusionaIzq(Nodo elim, Nodo Anterior, Nodo Izq, int lugar, Nodo aIzq, Nodo aDer, int lugR)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            Izq.liClaves.Add(Anterior.liClaves[lugar]);//agrega 
            Izq.llDirecciones.Add(elim.llDirecciones[0]);
            Izq.liClaves.Add(elim.liClaves[0]);
            Izq.llDirecciones.Add(elim.llDirecciones[1]);

            Anterior.liClaves.RemoveAt(lugar);//elimina de anterir
            Anterior.llDirecciones.RemoveAt(lugar + 1);

            int pos = auxEnt.listNod.IndexOf(elim);
            auxEnt.listNod.RemoveAt(pos);
            EliminaInterA(Anterior, auxRa, aIzq, aDer, lugR);
         }

         public void FusionDer(Nodo elim, Nodo Der, Nodo Anterior, int lugar, Nodo aIzq, Nodo aDer, int lugR)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            for (int n = 0; n < Der.liClaves.Count; n++)//pasa datos 
             {
                 elim.liClaves.Add(Der.liClaves[n]);
                 elim.llDirecciones.Add(Der.llDirecciones[n]);
             }
             Anterior.liClaves.RemoveAt(lugar);//elimina del anterior
             Anterior.llDirecciones.RemoveAt(lugar + 1);

            int pos = auxEnt.listNod.IndexOf(Der);
             auxEnt.listNod.RemoveAt(pos);//Elimina de la lista el derecho
             EliminaInterA(Anterior, auxRa, aIzq, aDer, lugR);
         }

         public void FusionaDer(Nodo elim, Nodo Anterior, Nodo Der, int lugar, Nodo aIzq, Nodo aDer, int lugR)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            for(int i = 0; i < auxEnt.listNod.Count; i++)
            {
                if (auxEnt.listNod[i].cTipo == 'H' && auxEnt.listNod[i].liClaves[0] > elim.liClaves[elim.liClaves.Count - 1] && Der.liClaves[0] > auxEnt.listNod[i].liClaves[0])
                {
                    //auxEnt.listNod[i].liClaves[0]
                    elim.liClaves.Add(auxEnt.listNod[i].liClaves[0]);
                    i = auxEnt.listNod.Count;
                }
            }
             for (int n = 0; n < Der.liClaves.Count; n++)//pasa datos 
             {
                 elim.liClaves.Add(Der.liClaves[n]);
                 elim.llDirecciones.Add(Der.llDirecciones[n]);
             }
             elim.llDirecciones.Add(Der.llDirecciones[Der.liClaves.Count]);

             Anterior.liClaves.RemoveAt(lugar);//elimina del anterior
             Anterior.llDirecciones.RemoveAt(lugar + 1);

            int pos = auxEnt.listNod.IndexOf(Der);
            auxEnt.listNod.RemoveAt(pos);
            EliminaInterA(Anterior, auxRa, aIzq, aDer, lugR);
         }

         public void EliminaInterA(Nodo elim, Nodo Raiz, Nodo aIzq, Nodo aDer, int lugR)
         {
            Entidad auxEnt = (Entidad)(hsEntidades[sNomEntidad]);
            bool fusion = false;  //nodo auxiliar
             if (elim.lDirNod != Raiz.lDirNod)//si no es la raiz 
             {
                 if (elim.liClaves.Count < 2)//si es insuficiente
                 {
                     if (aIzq != null)//si existe un izquierdo
                     {
                         if (aIzq.liClaves.Count > 2)//si puede dondar
                             DonaIzqInter(elim, aIzq, Raiz, lugR);
                         else
                         {
                             if (aDer != null)
                             {
                                 if (aDer.liClaves.Count > 2)//si puede donar
                                     DonaDerInter(elim, aDer, Raiz, lugR);
                                 else
                                     fusion = true;
                             }
                             else
                                 fusion = true;
                             if (fusion)
                                 FusionaIzq(elim, Raiz, aIzq, lugR, null, null, -1);
                         }
                     }
                     else
                     {
                        if (aDer != null)
                        {
                            if (aDer.liClaves.Count > 2)
                                DonaDer(elim, Raiz,aDer , lugR);
                            else
                                fusion = true;
                        }
                        else
                            fusion = true;
                        if(fusion)
                            FusionaDer(elim, Raiz, aDer, lugR, null, null, -1); //fucion derecho
                     }
                 }
             }
             else
             {
                 if (Raiz.liClaves.Count == 0)
                 {
                    long posi = Raiz.llDirecciones[0];
                    int pos = auxEnt.listNod.IndexOf(Raiz);
                    auxEnt.listNod.RemoveAt(pos);
                    
                     for (int x = 0; x < auxEnt.listNod.Count; x++)
                         if (auxEnt.listNod[x].lDirNod == posi)
                         {
                            int iNumAtr = ((Entidad)(hsEntidades[sNomEntidad])).hsAtributos.Count;
                            for (int i = 0; i < iNumAtr; i++)
                            {
                                string inom = ((Entidad)(hsEntidades[sNomEntidad])).alNomAtributos[i].ToString();
                                Atributo auxAt = (Atributo)((Entidad)(hsEntidades[sNomEntidad])).hsAtributos[inom];

                                if (auxAt.iTipoIndice == 4)
                                {
                                    auxAt.lDirIndice = auxEnt.listNod[x].lDirNod;
                                    EscribeArchivo.escribeAtr(auxAt, fileNameDD);
                                    i = iNumAtr;
                                }
                            }

                             if (auxEnt.listNod[x].cTipo == 'I')
                             {
                                 auxEnt.listNod[x].cTipo = 'R';
                            }
                         }
                }
             }
         }
    }
}