using System.Text.Json;
using System.Text.Json.Serialization;

public class Static
{
    static public Random rnd = new Random();
    public const string filePath = "C:\\Users\\Administrator\\Desktop\\새 폴더\\Reports\\";
    public const string dataPath = "C:\\Users\\Administrator\\Desktop\\새 폴더\\Data\\";
}


public class Program
{
    static void Main(string[] args)
    {
        Benford ben = new Benford();
        BaseReport report = new BaseReport();
        List<int> numbers;

        for(int i = 0; i < 10; i++)
        {
            var data = ben.Logic(100000, out numbers);
            report.Logic(data);
            SaveNum(numbers, i, Static.dataPath);
        }

        report.Briefing();
        report.DetBriefing();

        report.Save(Static.filePath);
    }

    static void SaveNum(List<int> at, int time, string filePath)
    {
        var rt = filePath + $"Table_{time}.json";
        var ct = JsonSerializer.Serialize(at);
        var pt = $"{time}회차 넘버 테이블 - \n" + ct;
        FileSave.SaveData(pt, rt);
    }
}