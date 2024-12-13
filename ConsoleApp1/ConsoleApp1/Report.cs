using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Nodes;

public class BaseReport
{
    public BaseReport() { }

    private List<DetailedReport> _reports = new List<DetailedReport>();
    private Dictionary<int, int> avg = new Dictionary<int, int>();
    private int count = 0;


    private Dictionary<int, int> GenDictionary()
    {
        var at = new Dictionary<int, int>();

        for (int i = 1; i <= 9; i++)
        {
            at.Add(i, 0);
        }

        return at;
    }
    private void GenAVG(Dictionary<int, Table> kvp)
    {
        avg = GenDictionary();

        foreach(var kv in kvp)
        {
            avg[kv.Key] += kv.Value.Count;  
        }
    }

    public void Logic(Dictionary<int, Table> kvp)
    {
        count++;
        GenAVG(kvp);
        _reports.Add(new DetailedReport(count, kvp));
    }

    public void Briefing()
    {
        Console.WriteLine();
        Console.WriteLine($"총 실행횟수는 {count}회 입니다.");
        Console.WriteLine("----------------------------------------------------------------------");
        foreach (var kv in avg)
        {
            Console.WriteLine($"앞자리가 {kv.Key}인 수가 나온 횟수의 평균 : {kv.Value / count}회");
        }
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Protocol Out.");
    }
    public void DetBriefing()
    {
        foreach(var kv in _reports)
        {
            Console.WriteLine();
            kv.Briefing();
            Console.WriteLine();
        }
    }

    public void Save(string filePath)
    {
        string path = filePath + "Benford's_Law_MainReport.json";

        var at = JsonSerializer.Serialize(avg);
        var ct = $"총 반복 횟수 : {count}\n" + $"각 수의 첫 자릿수 별 도출 평균값 : {at}";
        FileSave.SaveData(ct, path);
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("메인 리포트 데이터 저장 성공");
        Console.ForegroundColor = ConsoleColor.White;


        foreach(var kv in _reports)
        {
            kv.Save(filePath);
        }
    }
}

public class DetailedReport
{
    public DetailedReport(int count, Dictionary<int, Table> kvp)
    {
        Time = count;
        detData = kvp;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Time}회차 세부리포트 생성됨.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private int Time;
    private Dictionary<int, Table> detData = new Dictionary<int, Table>();

    public void Briefing()
    {
        Console.WriteLine($"{Time}회차 데이터 입니다.");
        Console.WriteLine("----------------------------------------------------------------------");
        foreach (var kv in detData)
        {
            Console.WriteLine($"앞자리가 {kv.Key}인 수가 나온 횟수 : {kv.Value.Count}회");
        }
        Console.WriteLine("----------------------------------------------------------------------");
    }
    public void Save(string filePath)
    {
        string path = filePath + $"Benford's_Law_DetailedReport_{Time}.json";
        var at = JsonSerializer.Serialize(detData);
        var ct = $"{Time}회차 데이터 입니다.\n" + at;
        FileSave.SaveData(ct, path);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Time}회차 세부 리포트 데이터 저장 성공");
        Console.ForegroundColor = ConsoleColor.White;
    }

}