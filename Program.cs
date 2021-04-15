using System;
using System.Windows.Forms;

namespace Scanare_Angajati
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        public static string myConnectionString = string.Concat(new string[]
		{
			"Data Source=",
			SetariInitiale.Default.serverIP,
			",",
			SetariInitiale.Default.portNo,
			";Network Library=DBMSSOCN;Initial Catalog=",
			SetariInitiale.Default.databaseName,
			";User ID=",
			SetariInitiale.Default.dUsername,
			";Password=",
			SetariInitiale.Default.dPassword,
			";"
		});

		[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
