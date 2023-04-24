using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Clases.MessageTemporal;

namespace HerramientaMoverArchivos
{
    public partial class Form1 : Form
    {
        private string RutaDestino;
        private string RutaOrigen;
        private bool cambiandoCheck = false;
        private List<DatoArchivo> archivosOrigen;
        private List<DatoArchivo> archivosTmp;
        //private List<DatoArchivo> archivosServidores;
        private List<DatoArchivo> archivos;
        private bool ExistenArchiosPendientes=false;
        private bool Cargando = false;
        public class DatoArchivo
        {
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Url { get; set; }
            public int Level { get; set; }
            public bool Archivo { get; set; }
            public string rutaBase { get; set; }
            public string rutaSinBase { get; set; }
            public bool SoloLectura { get; set; }

            public override string ToString()
            {
                string archivo = Archivo ? "1" : "0";
                string lectura = SoloLectura ? "1" : "0";
                return Nombre + "[" + Fecha.ToShortDateString() + "]" + "{" + archivo + "}" + "--->" + lectura;
                //return base.ToString(); 
            }
        }

        private string archivoLog = "LogMovimiento.txt";

        public Form1()
        {
            InitializeComponent();
            archivosOrigen = new List<DatoArchivo>();
            //archivosServidores = new List<DatoArchivo>();


            //txtOrigen.Text = @"C:\Users\Andres\Desktop\gd";
            //txtDestino.Text = @"C:\Users\Andres\Desktop\Gestor utilidades - copia";
            //chkActivarAjutes.Checked = true;
            //nBloque.Value = 5;
        }

        private void btCopiar_Click(object sender, EventArgs e)
        {
            if (ComprobarRutas())
            {
                Copiar();
            }
        }

        private void btMover_Click(object sender, EventArgs e)
        {
            if (ComprobarRutas())
            {
                Mover();
            }
        }

        private bool ComprobarRutas()
        {
            if (!string.IsNullOrEmpty(txtOrigen.Text))
            {
                RutaOrigen = txtOrigen.Text;
            }
            else
            {
                MessageBoxTemporal.Show("La carpeta Origen no puede estar vacia", "Comprobar Direcciones", 2);
                return false;
            }
            if (!string.IsNullOrEmpty(txtDestino.Text))
            {
                RutaDestino = txtDestino.Text;
            }
            else
            {
                MessageBoxTemporal.Show("La carpeta Destino no puede estar vacia", "Comprobar Direcciones", 2);
                return false;
            }
            return true;
        }

        private bool AccesoRutas()
        {
            if (System.IO.Directory.Exists(RutaOrigen) && System.IO.Directory.Exists(RutaDestino))
            {
                return true;
            }
            return false;
        }

        private void Copiar()
        {
            bool acceso = AccesoRutas();
            if (acceso)
            {

                //copiarBackground();
                cProgress.Start();
                copiarBackground();
                //cProgress.End();
                //if ( ExistenArvhiosPendientes)
                //{
                //    Accion("Esperando un tiempo de Demora");
                //    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                //    timer.Interval = (int)nTiempo.Value*1000;
                //    timer.Tick += Timer_Tick;
                //    timer.Start();
                //    //copiarBackground();
                //}
            }
            else
            {
                Accion("No hay Acceso a la Rutas");
                MessageBoxTemporal.Show("No hay Acceso a la Rutas", "Comprobar Actualizacion", 2);
                
            }
        }


        private void copiarBackground()
        {
            CheckForIllegalCrossThreadCalls = false;
           // cProgress.Start();
            Task.Factory.StartNew(() =>
            {
                Cargando = true;
                CargarListas();

            }).ContinueWith((t) =>
            {
                //COPIANDO DEL SERVIDOR A TEMPORAL
                Accion("\t\t ----> Copiar Archivos ");
                CopiarDeOrigenADestino();
                Accion("\t\t ----> Finalizar Copiado ");
            }).ContinueWith((t) =>
            {
                if (ExistenArchiosPendientes)
                {
                    Accion("Esperando un tiempo de Demora");
                    Thread.Sleep((int)nTiempo.Value*1000);
                }
                //ELIMINAR TEMPORAL
                //Accion("\t\t ----> Eliminar Residuos");
                //EliminarResiduos();
                //Accion("\t\t ----> Finalizar Eliminar ");
            }).ContinueWith((t) =>
            {
                if (!ExistenArchiosPendientes)
                {
                    CheckForIllegalCrossThreadCalls = true;
                    cProgress.End();
                    Accion("\t\t ----> Finalizado el proceso ");
                    MessageBoxTemporal.Show("Programa Actualzado", "Comprobar Actualizacion", 1);
                    Cargando = false;
                }
                else
                {
                    copiarBackground();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        private void Mover()
        {
            bool acceso = AccesoRutas();
            if (acceso)
            {

                cProgress.Start();
                moverBackground();
            }
            else
            {
                Accion("No hay Acceso a la Rutas");
                MessageBoxTemporal.Show("No hay Acceso a la Rutas", "Comprobar Actualizacion", 2);

            }
        }

        private void moverBackground()
        {
            CheckForIllegalCrossThreadCalls = false;
            //cProgress.Start();
            Task.Factory.StartNew(() =>
            {
                Cargando = true;
                CargarListas();

            }).ContinueWith((t) =>
            {
                //COPIANDO DEL SERVIDOR A TEMPORAL
                Accion("\t\t ----> Mover Archivos ");
                MoverDeOrigenADestino();
                Accion("\t\t ----> Finalizar Moviemiento de Archivos ");
            }).ContinueWith((t) =>
            {
                //ELIMINAR TEMPORAL
                Accion("\t\t ----> Eliminar Residuos de la carpeta Origen");
                EliminarResiduos();
                Accion("\t\t ----> Finalizar Eliminar ");
            }).ContinueWith((t) =>
            {
                if (ExistenArchiosPendientes)
                {
                    Accion("Esperando un tiempo de Demora");
                    Thread.Sleep((int)nTiempo.Value * 1000);
                }
                //ELIMINAR TEMPORAL
                //Accion("\t\t ----> Eliminar Residuos");
                //EliminarResiduos();
                //Accion("\t\t ----> Finalizar Eliminar ");
            }).ContinueWith((t) =>
            {
                if (!ExistenArchiosPendientes)
                {
                    CheckForIllegalCrossThreadCalls = true;
                    cProgress.End();
                    Accion("\t\t ----> Finalizado el proceso ");
                    MessageBoxTemporal.Show("Programa Actualzado", "Comprobar Actualizacion", 1);
                    Cargando = false;
                }
                else
                {
                    moverBackground();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Accion(string mensaje)
        {
            List<string> lineas = txtResultado.Lines.ToList();

            lineas.Insert(0, mensaje + Environment.NewLine);

            txtResultado.Lines = lineas.ToArray();
            Thread.Sleep(25);
            
            EscribirLog(mensaje);
        }

        private void EscribirLog(string mensaje)
        {
            string rutaLog = Path.Combine(System.IO.Directory.GetCurrentDirectory(), archivoLog);
            if (!System.IO.File.Exists(rutaLog))
            {
                System.IO.File.Create(rutaLog);
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(rutaLog, true))
            {
                string fecha = DateTime.Now.ToString();
                file.WriteLine(fecha + "->" + mensaje);
                file.Close();
            }
        }

        private void CargarListas(bool soloTemp = false)
        {
            archivosTmp = buscarArchivos(RutaOrigen);
            List<DatoArchivo> archivosTmpDestino = buscarArchivos(RutaDestino);
            archivosOrigen.Clear();
            if (chkActivarAjutes.Checked)
            {
                if (archivosTmpDestino.Count>0)
                {
                    foreach (DatoArchivo item in archivosTmpDestino)
                    {
                        if (archivosTmp.FirstOrDefault(x => x.ToString() == item.ToString()) != null)
                        {
                            archivosTmp.Remove(archivosTmp.First(x => x.ToString() == item.ToString()));
                        }
                    }
                }
                if (chkAsc.Checked)
                {
                    archivosTmp = archivosTmp.OrderBy(x => x.Fecha).ToList();
                }
                else
                {
                    archivosTmp = archivosTmp.OrderByDescending(x => x.Fecha).ToList();
                }
                for (int i = 0; i < archivosTmp.Count(); i++)
                {
                    if (nBloque.Value>i)
                    {
                        archivosOrigen.Add(archivosTmp[i]);
                    }
                    else
                    {
                        break;
                    }
                }
                ExistenArchiosPendientes = archivosTmp.Count() - archivosOrigen.Count() > 0;

               //ExistenArchiosPendientes = nBloque.Value < archivosTmp.Count()- archivosOrigen.Count();
                
            }
            else
            {
                archivosOrigen = archivosTmp;
            }
                //archivosServidores = buscarArchivos(RutaServidor);
        }

        private List<DatoArchivo> buscarArchivos(string directorio, int Level = 0, string rutaBase = "")
        {
            // string directorio = System.IO.Directory.GetCurrentDirectory();
            if (Level == 0) archivos = new List<DatoArchivo>();
            if (string.IsNullOrEmpty(rutaBase)) rutaBase = directorio;
           // string ultimaFecha = string.Empty;
           
            //foreach (string pathArchivo in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()))
            if (System.IO.Directory.Exists(directorio))
            {
                foreach (string pathArchivo in System.IO.Directory.GetFiles(directorio))
                {
                    if (System.IO.File.Exists(pathArchivo))
                    {
                        archivos.Add(new DatoArchivo
                        {
                            Nombre = System.IO.Path.GetFileName(pathArchivo),
                            Fecha = System.IO.File.GetLastWriteTime(pathArchivo),
                            Url = pathArchivo,
                            Archivo = true,
                            Level = Level,
                            SoloLectura = IsFileReadOnly(pathArchivo),
                            rutaBase = rutaBase,
                            rutaSinBase = pathArchivo.Substring(rutaBase.Length)

                        });
                        //if ()

                    }
                }

                foreach (string pathArchivo in System.IO.Directory.GetDirectories(directorio))
                {
                    if (System.IO.Directory.Exists(pathArchivo))
                    {
                        archivos.Add(new DatoArchivo
                        {
                            Nombre = System.IO.Path.GetFileName(pathArchivo),
                            Fecha = System.IO.File.GetLastWriteTime(pathArchivo),
                            Url = pathArchivo,
                            Level = Level,
                            rutaBase = rutaBase,
                            rutaSinBase = pathArchivo.Substring(rutaBase.Length)
                        });
                        if (chkRecursividad.Checked)
                        {
                            buscarArchivos(pathArchivo, Level + 1, rutaBase);
                        }

                    }
                }
            }

            return archivos;
        }

        public static bool IsFileReadOnly(string FileName)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);

            // Return the IsReadOnly property value.
            return fInfo.IsReadOnly;

        }
        
        private void CopiarDeOrigenADestino()
        {
            if (!System.IO.Directory.Exists(RutaDestino))
            {
                System.IO.Directory.CreateDirectory(RutaDestino);
            }

            foreach (DatoArchivo item in archivosOrigen)
            {
                if (item.Archivo)
                {
                    Accion(string.Format("Copiando -> {0}", item.Nombre));
                    System.IO.File.Copy(item.Url, Path.Combine(RutaDestino, item.Nombre), true);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(RutaDestino);
                    Accion(string.Format("Copiando -> {0}", item.Nombre));
                    
                }
            }
        }

        private void MoverDeOrigenADestino()
        {
            if (!System.IO.Directory.Exists(RutaDestino))
            {
                System.IO.Directory.CreateDirectory(RutaDestino);
            }

            foreach (DatoArchivo item in archivosOrigen)
            {
                if (item.Archivo)
                {
                    Accion(string.Format("Moviendo -> {0}", item.Nombre));
                    System.IO.File.Copy(item.Url, Path.Combine(RutaDestino, item.Nombre), true);
                    //System.IO.Directory.Move(item.Url, RutaDestino);
                }
            }
        }

        private void EliminarResiduos()
        {
            //if (System.IO.Directory.Exists(RutaOrigen))
            //{
            //    //System.IO.Directory.Move(RutaTemporal, RutaLocal);
            //    System.IO.Directory.Delete(RutaOrigen, true);
            //}
            if (System.IO.Directory.Exists(RutaOrigen))
            {
                foreach (DatoArchivo item in archivosOrigen)
                {
                    if (item.Archivo)
                    {
                        //System.IO.Directory.Move(RutaTemporal, RutaLocal);
                        System.IO.File.Delete(item.Url);
                    }
                }
            }
        }

        private void chkAsc_CheckedChanged(object sender, EventArgs e)
        {
            CambiarCheck(chkAsc.Checked,true);
        }

        private void CambiarCheck(bool chk,bool asc)
        {
            if (!cambiandoCheck)
            {
                cambiandoCheck = true;
                if (asc)
                {
                    chkDesc.Checked =!chk;
                }
                else
                {
                    chkAsc.Checked = !chk;
                }
                cambiandoCheck = false;
            }
        }

        private void chkDesc_CheckedChanged(object sender, EventArgs e)
        {
            CambiarCheck(chkAsc.Checked, false);
        }

        private void chkActivarAjutes_CheckedChanged(object sender, EventArgs e)
        {
            chkAsc.Enabled = chkActivarAjutes.Checked;
            chkDesc.Enabled = chkActivarAjutes.Checked;
            nBloque.Enabled = chkActivarAjutes.Checked;
            nTiempo.Enabled = chkActivarAjutes.Checked;
        }
    }
}
