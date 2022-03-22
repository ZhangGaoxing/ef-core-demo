using Pandemic.Models;

PandemicContext context = new PandemicContext();

var types = context.ReportTypes.ToList();

Console.Read();