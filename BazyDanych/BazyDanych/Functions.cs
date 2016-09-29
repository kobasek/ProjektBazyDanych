using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazyDanych
{
    /// <summary>
    /// Klasa zawirająca często używane metody
    /// </summary>
	class Functions
	{
        /// <summary>
        /// Metoda zwracająca łańcuch znakowy zawierający dane do łączenia z bazą danych
        /// </summary>
        /// <returns></returns>
		public static string GetConnectionString()
		{
			return "server=127.0.0.1;uid=root;" +
				"pwd=root;database=projekt_bazy_danych";
		}
	}

}
