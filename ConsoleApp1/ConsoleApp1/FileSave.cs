using System.Text.Json;

static public class FileSave
{
    static public void SaveData(string data, string filePath)
    {
        try
        {
            File.WriteAllText(filePath, data);
        }
        catch(Exception e)
        {
            Static.Error("CRIT ERROR :", e);
        }
    }
}