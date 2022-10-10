using Cekikila;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Xml;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


/*
using (var file = new FileStream("toto.txt"))
{
    using var xml = new XmlDocument(); // Evite l'imbrication excessive d'accolades
    
       

} // Appel auto du file.Dispose();
*/


if(int.TryParse("123", out var n) && n > 0)
{
    var valeur = n;

}

object o = n;

if(o is int val && val%2 == 0)
{

}

var obj = new Objet()
{
    Nom = "Broyeur de végétaux",
    Debut = new DateTime(2022, 09, 01)
};


switch (obj)
{
    case Objet when obj.Debut < DateTime.Now:
        n = 1;
        break;
    case { Valeur: < 2.0 }:
        n = 2;
        break;
    default:
        n = -1;
        break;
}

n = obj switch
{
    Objet when obj.Debut < DateTime.Now 
        => 1,
    { Valeur: < 2.0 } 
        => 2,
    _   => -1
};

(int entier, double reel) GetTuple()
{
    return (3, 5.2);
}

var (e, _) = GetTuple();

//var (n, d) = obj;
int[] t;


obj.Fin ??= DateTime.Now; // si Fin == null alors obj.Fin=DateTime.Now

string? s = "toto";

// ...

obj.Nom = s ?? "...";
obj.Nom = s != null ? s : "...";

var res = obj.Description?.TrimStart();

var tag = new Tag(null, "Sport", 1);
var (_, label, ordre) = tag;
var tag2 = new Tag(null, "Sport", 1);

if (tag2 == tag)
{

}

tag2 = tag with { Ordre = 2 };



await builder.Build().RunAsync();




