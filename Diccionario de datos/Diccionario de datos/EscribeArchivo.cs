using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diccionario_de_datos
{
    class EscribeArchivo
    {
        static public void escribeAtr(Atributo at, String nom)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(nom, FileMode.Open)))
                {
                    Writ.Seek((int)at.lDirAtributo, SeekOrigin.Begin);
                    Writ.Write(at.nombre);
                    Writ.Write(at.cTipo);
                    Writ.Write(at.iLongitud);
                    Writ.Write(at.iTipoIndice);
                    Writ.Write(at.lDirAtributo);
                    Writ.Write(at.lDirIndice);
                    Writ.Write(at.lDirSigAtrib);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeEnt(Entidad en, String nom)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(nom, FileMode.Open)))
                {
                    Writ.Seek((int)en.lDirEntidad, SeekOrigin.Begin);
                    Writ.Write(en.nombre);
                    Writ.Write(en.lDirEntidad);
                    Writ.Write(en.lDirAtrib);
                    Writ.Write(en.lDirDatos);
                    Writ.Write(en.lDirSigEnt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeLong(long lDir, String nom)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(nom, FileMode.Open)))
                {
                    Writ.Seek(0, SeekOrigin.Begin);
                    Writ.Write(lDir);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeValor(string val, long dir, string fileName)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
                {
                    Writ.Seek((int)dir, SeekOrigin.Begin);
                    Writ.Write(val);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeValor(long val, long dir, string fileName)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
                {
                    Writ.Seek((int)dir, SeekOrigin.Begin);
                    Writ.Write(val);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeValor(int val, long dir, string fileName)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
                {
                    Writ.Seek((int)dir, SeekOrigin.Begin);
                    Writ.Write(val);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeNodo(Nodo n, string fileName)
        {
            long lnvll = -1;
            int invll = 0;
            
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
                {
                    Writ.Seek((int)n.lDirNod, SeekOrigin.Begin);
                    Writ.Write(n.lDirNod);
                    Writ.Write(n.cTipo);

                    if (n.cTipo == 'H')
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (n.liClaves.Count > i)
                            {
                                Writ.Write(n.llDirecciones[i]);
                                Writ.Write(n.liClaves[i]);
                            }
                            else
                            {
                                Writ.Write(lnvll);
                                Writ.Write(invll);
                            }
                        }
                        Writ.Write(lnvll);
                    }
                    else
                    {
                        Writ.Write(n.llDirecciones[0]);
                        for (int i = 0; i < 4; i++)
                        {
                            if (n.liClaves.Count > i)
                            {
                                Writ.Write(n.liClaves[i]);
                                Writ.Write(n.llDirecciones[i + 1]);
                            }
                            else
                            {
                                Writ.Write(invll);
                                Writ.Write(lnvll);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void escribeValor(byte[] val, long dir, string fileName)
        {
            try
            {
                using (BinaryWriter Writ = new BinaryWriter(new FileStream(fileName, FileMode.Open)))
                {
                    Writ.Seek((int)dir, SeekOrigin.Begin);
                    Writ.Write(val);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
