

using Visit.Commodity.Calculation.Business.Manager;
using Visit.Commodity.Calculation.Business.Manager.Comodity;
using Visit.Commodity.Calculation.Contract;
using Visit.Commodity.Calculation.Entities.Enum;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ITaxCalculator, TaxCalculator>();

//var client = new TaxCalculator();
//client.Run<AlcoholCommodityFactory, Commodities>(Commodities.Alcohol);
//client.Run<DefaultCommodityFactory, Commodities>(Commodities.Default);

var deliveryType = typeof(BaseComodityFactory).Assembly.ExportedTypes.Where(x=>x.IsClass && !x.IsAbstract && x.GetInterface(nameof(IComodityService))!=null);
foreach (var type in deliveryType)
{
    builder.Services.AddSingleton(typeof(IComodityService), type);
}
builder.Services.AddTransient<IBaseComodityFactory, BaseComodityFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
