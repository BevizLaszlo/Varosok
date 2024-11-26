using System.Text;
using Varosok;

List<Varos> varosok = [];

using (StreamReader sr = new StreamReader(path: @"..\..\..\src\varosok.csv", encoding: Encoding.UTF8))
{
    _ = sr.ReadLine();
    while (!sr.EndOfStream)
        varosok.Add(new Varos(sr.ReadLine()));
}

Console.WriteLine($"A kollekció hossza: {varosok.Count}");

Console.WriteLine($"1) {varosok.Where(o => o.Orszag == "Kína").Sum(x => x.LakossagMillio):.00} millió fő él összesen kínai nagyvárosokban");
Console.WriteLine($"2) {varosok.Where(o => o.Orszag == "India").Average(x => x.LakossagMillio):.00} millió az indiai nagyvárosok átlaglélekszáma");
Console.WriteLine($"3) {varosok.OrderByDescending(x => x.LakossagMillio).First().Nev} a legnépesebb nagyváros");
Console.WriteLine("4) 20M lakos feletti nagyvárosok, népesség szerint csökkenő sorrendben:");

foreach (Varos v in varosok.Where(x => x.LakossagMillio > 20).OrderByDescending(x => x.LakossagMillio))
    Console.WriteLine($"\t{v.ToString()}");

Console.WriteLine($"5) {varosok.GroupBy(x => x.Orszag).Count(o => o.Count() > 1)} olyan ország van, ami több nagyávárossal is szerepel a listában.");

// Ellenőrzés:
//foreach (IGrouping<string, Varos> orszag in varosok.GroupBy(x => x.Orszag).Where(o => o.Count() > 1))
//    Console.WriteLine($"\t{orszag.Key}: {orszag.Count()} db ({string.Join(", ", orszag.Select(x => x.Nev))})");

int legtobbElofordulas = varosok.GroupBy(x => x.Nev[0]).OrderByDescending(x => x.Count()).First().Count();
List<IGrouping<char, Varos>> legtobbElofordulasos = varosok.GroupBy(x => x.Nev[0]).Where(x => x.Count() == legtobbElofordulas).ToList();

Console.WriteLine($"6) {string.Join(" és ", legtobbElofordulasos.Select(x => x.First().Nev[0]))} betűvel kezdődik a legtöbb nagyváros neve.");


// Ellenőrzés:
//foreach (IGrouping<char, Varos> betusvaros in varosok.GroupBy(x => x.Nev[0]).OrderByDescending(x => x.Count()))
//    Console.WriteLine($"\t{betusvaros.First().Nev[0]}: {betusvaros.Count()} db ({string.Join(", ", betusvaros.Select(x => x.Nev))})");
