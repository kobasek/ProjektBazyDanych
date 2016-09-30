using System;
using System.IO;
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
			try
			{   // Open the text file using a stream reader.
				using (StreamReader sr = new StreamReader("ConnectionString.txt"))
				{
					// Read the stream to a string, and write the string to the console.
					String line = sr.ReadToEnd();
					return line;
				}
			}
			catch (Exception e)
			{
				MessageBox.Show("Błąd wczytywania connestion stringa!");
			}

			return "server=127.0.0.1;uid=root;" +
				"pwd=root;database=projekt_bazy_danych";
		}
	}

}
