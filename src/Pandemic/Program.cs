using Pandemic.Models;

PandemicContext context = new PandemicContext();

var list = context.ReportTypes.ToList();

Console.Read();