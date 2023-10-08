using BusinessObject.Entities;
using DrawingOnDemandAPI.Utils;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.EnableQueryFeatures();
        options.AddRouteComponents("OData", GetEdmModel());
    }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
    options.OperationFilter<AuthorizationOperationFilter>();
});

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

static IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Account>("Accounts");
    odataBuilder.EntitySet<Proposal>("Proposals");
    odataBuilder.EntitySet<Ranking>("Rankings");
    odataBuilder.EntitySet<Requirement>("Requirements");
    odataBuilder.EntitySet<Role>("Roles");
    odataBuilder.EntitySet<Size>("Sizes");
    odataBuilder.EntitySet<Timeline>("Timelines");
    odataBuilder.EntitySet<Payment>("Payments");
    odataBuilder.EntitySet<OrderDetail>("OrderDetails");
    odataBuilder.EntitySet<Order>("Orders");
    odataBuilder.EntitySet<Invite>("Invites");
    odataBuilder.EntitySet<HandOverItem>("HandOverItems");
    odataBuilder.EntitySet<HandOver>("HandOvers");
    odataBuilder.EntitySet<AccountReview>("AccountReviews");
    odataBuilder.EntitySet<AccountRole>("AccountRoles");
    odataBuilder.EntitySet<Art>("Arts");
    odataBuilder.EntitySet<Artwork>("Artworks");
    odataBuilder.EntitySet<ArtworkReview>("ArtworkReviews");
    odataBuilder.EntitySet<Attackment>("Attackments");
    odataBuilder.EntitySet<Category>("Categories");
    odataBuilder.EntitySet<DiscountByNumber>("DiscountByNumbers");
    odataBuilder.EntitySet<DiscountBySpecial>("DiscountBySpecials");
    odataBuilder.EntitySet<Fee>("Fees");
    return odataBuilder.GetEdmModel();
}
