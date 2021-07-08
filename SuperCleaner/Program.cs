using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperCleaner
{
    class Program
    {
        public static string UsersPath = @"C:\Users";
        public static string TempPath = @"\AppData\Local\Temp";        
        static void Main(string[] args)
        {
            Console.WriteLine("Super Temporal Cleaner. Lluis Sanahuja 2021 Licencia CC BY-NC-SA");
            Console.WriteLine("Inicializando...");
            List<String> userList = new List<string>();

            if (!System.IO.Directory.Exists(UsersPath))
                Console.WriteLine("No existe el directorio de usuarios o es una version anterior a Windows 7");
            else
            {
                userList = System.IO.Directory.EnumerateDirectories(UsersPath).ToList();
                Console.WriteLine("Encontrados " + userList.Count + " usuarios. Limpiando...");
                foreach (string t in userList)
                {
                    if (System.IO.Directory.Exists(t + TempPath))
                    {
                        Console.Write("Limpiando... " + t);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(t + TempPath);
                        int dircount = 0;
                        int filecount = 0;
                        foreach (System.IO.FileInfo delfile in dir.GetFiles())
                        {
                            try
                            {
                                delfile.Delete();
                            }
                            catch (Exception) { }
                            filecount++;
                        }
                        foreach (System.IO.DirectoryInfo deldir in dir.GetDirectories())
                        {
                            try
                            {
                                deldir.Delete(true);
                            }
                            catch (Exception) { }
                            dircount++;
                        }
                        if (filecount == 0 && dircount == 0)
                            Console.WriteLine(" Directorio temporal vacío");
                        else
                            Console.WriteLine(" " + filecount + " archivos y " + dircount + " directorios");
                    }
                    else
                    {

                        Console.WriteLine("Usuario " + t + " no tiene directorio temporal");
                    }
                }
            }
            Console.WriteLine("Finalizado. Pulse cualquier tecla para cerrar");
            Console.ReadKey();
        }
    }
}
