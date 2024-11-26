using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varosok;
internal class Varos
{
    public string Nev { get; set; }
    public string Orszag { get; set; }
    public double LakossagMillio { get; set; }

    public Varos(string sor)
    {
        string[] data = sor.Split(';');
        Nev = data[0];
        Orszag = data[1];
        LakossagMillio = double.Parse(data[2]);
    }

    public override string ToString() => $"{Nev} ({Orszag}) - {LakossagMillio:.00} millió fő";
}
