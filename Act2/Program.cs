// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string folderPath = "D:\\Users\\Maurizio Patiño\\Desktop\\IDS 8 sem\\Proyectos de ingenieria de software\\Act2\\Act2\\Files";
string newFolderPath = "D:\\Users\\Maurizio Patiño\\Desktop\\IDS 8 sem\\Proyectos de ingenieria de software\\Act2\\Act2\\NewFiles";

string logFileName = "a2_matricula.txt";
string logFilePath = $"D:\\Users\\Maurizio Patiño\\Desktop\\IDS 8 sem\\Proyectos de ingenieria de software\\Act2\\Act2\\Log\\{logFileName}";

string newFile = "";

string[] files = Directory.GetFiles(folderPath);

Stopwatch tiempoTotal = Stopwatch.StartNew();

foreach (string file in files)
{
    Stopwatch tiempoArchivo = Stopwatch.StartNew();
    
    if (File.Exists(file))
    {
        string fileName = Path.GetFileName(file);
        string fileContent = File.ReadAllText(file);

        if (!fileContent.Any())
        {
            Console.WriteLine("No hay contenido en el archivo.");
            return;
        }

        RemoveHtmlTags(fileName, file);

        string logFile = GetOrCreateLogFile();


    }
}

void RemoveHtmlTags(string fileName, string file)
{
    newFile = Path.Combine(newFolderPath, fileName);

    File.Copy(file, newFile);

    string newFileContent = File.ReadAllText(newFile);

    newFileContent = Regex.Replace(newFileContent, "<.*?>", string.Empty);

    File.WriteAllText(newFile, newFileContent);

}

string GetOrCreateLogFile()
{
    if (File.Exists(logFilePath))
        return logFilePath;

    File.Create(logFilePath);
    return logFilePath;

}


