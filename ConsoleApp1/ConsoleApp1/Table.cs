using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Table
{
    public Table(int data)
    {
        Data = data;
        Count = 0;
    }
    public Table(int data, int count)
    {
        Data = data;
        Count = count;
    }

    readonly public int Data;
    public int Count { get; private set; }

    public void IncCount()
    {
        this.Count++;
    }

    public void DecCount()
    {
        this.Count--;
    }
}