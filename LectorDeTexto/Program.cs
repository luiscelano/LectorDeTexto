using System;
using System.IO;

namespace LectorDeTexto
{
    class Program
    {
        public static string filename = "\\archivo.txt";
        public static string directory = Directory.GetCurrentDirectory();
        public static string path = directory + filename;
        static void Main(string[] args)
        {
            int opt = 0;

            do
            {
                Console.Clear();
                Menu();
                opt = int.Parse(Console.ReadLine());
                switch(opt)
                {
                    case 1:
                        CrearArchivo();
                        break;
                    case 2:
                        LeerArchivo();
                        break;
                    case 3:
                        Console.WriteLine("Ingrese la posicion a editar");
                        int linea = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el texto a reemplazar");
                        string nuevaLinea = Console.ReadLine();

                        EditarArchivo(linea, nuevaLinea);
                        break;
                    case 4:
                        Console.WriteLine(":)");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        Console.ReadKey();
                        break;
                }
            } while (opt != 4);
        }

        static void Menu()
        {
            Console.WriteLine("Menu de Archivos Secuenciales");
            Console.WriteLine("Opción 1: Crear y grabar un archivo");
            Console.WriteLine("Opción 2: Leer archivo");
            Console.WriteLine("Opción 3: Editar Linea");
            Console.WriteLine("Opción 4: Salir");
            Console.WriteLine("Seleccione una opción");
        }

        static void CrearArchivo()
        {
            if(!Directory.Exists(directory))
            {
                DirectoryInfo di = Directory.CreateDirectory(directory);
            }
            if(!File.Exists(path))
            {
                CrearArchivoEstatico();
            }
        }

        static void LeerArchivo()
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }

        static void CrearArchivoEstatico()
        {
            using StreamWriter stream = File.CreateText(path);
            for(int x=1; x<=20; x++)
            {
                stream.WriteLine("linea " +  x);
            }
            stream.Close();

            Console.ReadKey();
        }

        static void EditarArchivo(int linea, string nuevaLinea)
        {
            string[] lines = File.ReadAllLines(path);

            lines[linea - 1] = nuevaLinea;
            File.WriteAllLines(path, lines);


            Console.ReadKey();
        }
    }
}
