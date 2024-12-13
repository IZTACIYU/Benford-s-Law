using System.Text.Json;

static public class FileSave
{
    static public void SaveData(string data, string filePath)
    {
        File.WriteAllText(filePath, data);
    }
}