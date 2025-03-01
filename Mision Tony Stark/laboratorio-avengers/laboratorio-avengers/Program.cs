using System;
using System.IO;

class FileManager
{
    private string filePath = @"C:\\Mision Tony Stark\\inventos.txt";

    public void CreateFile()
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllLines(filePath, new string[] { "1. Traje Mark I", "2. Reactor Arc", "3. Inteligencia Artificial JARVIS" });
            Console.WriteLine("Archivo creado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void AddEntry(string entry)
    {
        try
        {
            File.AppendAllText(filePath, entry + Environment.NewLine);
            Console.WriteLine("Invento agregado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void ReadFile()
    {
        try
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void CopyFile(string destination)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Copy(filePath, destination, true);
            Console.WriteLine("Archivo copiado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void MoveFile(string destination)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Move(filePath, destination);
            Console.WriteLine("Archivo movido correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void DeleteFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Archivo eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {
        FileManager manager = new FileManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Crear archivo\n2. Agregar invento\n3. Leer archivo\n4. Copiar archivo\n5. Mover archivo\n6. Eliminar archivo\n7. Salir");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    manager.CreateFile();
                    break;
                case "2":
                    Console.Write("Ingrese el invento: ");
                    manager.AddEntry(Console.ReadLine());
                    break;
                case "3":
                    manager.ReadFile();
                    break;
                case "4":
                    Console.Write("Ingrese la ruta destino: ");
                    manager.CopyFile(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Ingrese la ruta destino: ");
                    manager.MoveFile(Console.ReadLine());
                    break;
                case "6":
                    manager.DeleteFile();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
