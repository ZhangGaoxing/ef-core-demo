using Pandemic.Models;

PandemicContext context = new PandemicContext();

//var types = context.ReportTypes.ToList();
//var type = context.ReportTypes.Find("COVID-1");

var type = new ReportType
{
    Cd = "COVID",
    Name = "sdfwe"
};

var a = context.Attach(type);
var b = context.Entry(type);
b.State = Microsoft.EntityFrameworkCore.EntityState.Added;

type.Name = "asd1";
//context.ReportTypes.Update(type);
//context.ChangeTracker.DetectChanges();
//Console.WriteLine(context.ChangeTracker.DebugView.LongView);
context.SaveChanges();

Console.Read();