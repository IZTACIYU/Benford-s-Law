using System.Text.Json;
using System.Text.Json.Serialization;

static public class Static
{
    public enum PathWay
    {
        Reports = 0,
        Data
    };

    static public Random rnd = new Random();

    static private string basePath = AppDomain.CurrentDomain.BaseDirectory;
    static private string restPath = Path.Combine(basePath, @"..\..\..\..\..\");

    static public string? FilePath(PathWay pathWay)
    {
        switch(pathWay)
        {
            case PathWay.Reports:
                string reposPath = restPath + @"Reports\";
                return Path.GetFullPath(reposPath);
            case PathWay.Data:
                string dataPath = restPath + @"Data\";
                return Path.GetFullPath(dataPath);
            default:
                Error("CRIT ERROR : NULL PATH DETECTED");
                return null;
        }
    }
    static public void Error(string? message = null, Exception? ex = null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message + ex?.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}


public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Static.FilePath(Static.PathWay.Data));

        Benford ben = new Benford();
        BaseReport report = new BaseReport();
        List<int> numbers;

        for(int i = 0; i < 10; i++)
        {
            var data = ben.Logic(100000, out numbers);
            report.Logic(data);
            SaveNum(numbers, i, Static.FilePath(Static.PathWay.Data));
        }

        report.Briefing();
        report.DetBriefing();

        report.Save(Static.FilePath(Static.PathWay.Reports));
    }

    static void SaveNum(List<int> at, int time, string? filePath)
    {
        var rt = filePath + $"Table_{time}.json";
        var ct = JsonSerializer.Serialize(at);
        var pt = $"{time}회차 넘버 테이블 - \n" + ct;
        FileSave.SaveData(pt, rt);
    }
}