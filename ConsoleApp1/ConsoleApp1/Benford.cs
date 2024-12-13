using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Benford
{
    public Dictionary<int, Table> Logic(int times, out List<int> numbers)
    {
        Dictionary<int, Table> field = GenDictionary();
        numbers = new List<int>();

        for (int i = 0; i < times; i++)
        {
            int a = Static.rnd.Next(1, int.MaxValue);
            int fir = GetLevel(a);
            numbers.Add(a);
            SetData(ref field, fir);
        }

        return field;
    }
    private Dictionary<int, Table> GenDictionary()
    {
        var at = new Dictionary<int, Table>();

        for(int i = 1; i <= 9; i++)
        {
            at.Add(i, new Table(i));
        }

        return at;
    }
    private int GetLevel(int at)
    {
        string pt = at.ToString();

        return int.Parse(pt[0].ToString());
    }
    private void SetData(ref Dictionary<int, Table> dic, int data)
    {
        dic[data].IncCount();
    }
}
