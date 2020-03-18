using GrupoIDAII.Administración_IDAII;
using GrupoIDAII.Cátalogos;
using System;
using System.Windows.Forms;

namespace GrupoIDAII
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IniciarSesion());
        }
    }
}
