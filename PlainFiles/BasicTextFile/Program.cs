using BasicTextFile;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Xml.Linq;

var textFile = new SimpleTextFile("data.txt");
var lines = textFile.ReadLines();   
var opc= "0";

do
{
    opc = Menu();
    Console.WriteLine("====================================================");
    switch (opc)

    {
        case "1":
            if (lines.Length == 0)
            {
                Console.WriteLine("Archivo vacio.");
                break;
            }
            foreach (var Line in lines)
            {
                Console.WriteLine(Line);
            }
            break;

        case "2":
            Console.WriteLine("Ingrese el texto a agregar: ");
            var newLine = Console.ReadLine();
            if (!string.IsNullOrEmpty(newLine))
            {
                lines = lines.Append(newLine).ToArray();
            }
            break;

        case "3":
            break;
            Console.WriteLine("Ingrese la linea a eliminar:");
            var LineToRemove = Console.ReadLine();
            if (!string.IsNullOrEmpty(LineToRemove))
            {
                lines = lines.Where(line => line != LineToRemove).ToArray();
            }
            break;

        case "4":
            SaveChanges();
            break;

        case "0":
            Console.WriteLine("Saliendo...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }
    } while (opc != "0");
    SaveChanges();

void SaveChanges()
{
    Console.WriteLine("Guardando cambios...");
    textFile.WriteLines(lines); 
    Console.WriteLine("Cambios guardados correctamente.");
}
string Menu()
{
    Console.WriteLine("==============================================");
    Console.WriteLine("1. Ver contenido del archivo");
    Console.WriteLine("2. Agregar linea");
    Console.WriteLine("3. Eliminar linea");
    Console.WriteLine("4. Guardar cambios");
    Console.WriteLine("0. Salir");
    Console.WriteLine("Seleccione una opción: ");
    return Console.ReadLine() ?? "0";
}














