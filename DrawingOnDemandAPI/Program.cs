using BusinessObject.Entities;
using DrawingOnDemandAPI.Utils;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
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

// Add Firebase auth and author
builder.Services.AddSingleton(FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromJson(builder.Configuration["FirebaseService"])
}));

builder.Services.AddFirebaseAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Account>("Accounts");
    odataBuilder.EntitySet<AccountReview>("AccountReviews");
    odataBuilder.EntitySet<AccountRole>("AccountRoles");
    odataBuilder.EntitySet<Art>("Arts");
    odataBuilder.EntitySet<Artwork>("Artworks");
    odataBuilder.EntitySet<ArtworkReview>("ArtworkReviews");
    odataBuilder.EntitySet<Category>("Categories");
    odataBuilder.EntitySet<Certificate>("Certificates");
    odataBuilder.EntitySet<Discount>("Discounts");
    odataBuilder.EntitySet<HandOver>("HandOvers");
    odataBuilder.EntitySet<HandOverItem>("HandOverItems");
    odataBuilder.EntitySet<Invite>("Invites");
    odataBuilder.EntitySet<Material>("Materials");
    odataBuilder.EntitySet<Order>("Orders");
    odataBuilder.EntitySet<OrderDetail>("OrderDetails");
    odataBuilder.EntitySet<Payment>("Payments");
    odataBuilder.EntitySet<Proposal>("Proposals");
    odataBuilder.EntitySet<Rank>("Ranks");
    odataBuilder.EntitySet<Requirement>("Requirements");
    odataBuilder.EntitySet<Role>("Roles");
    odataBuilder.EntitySet<Size>("Sizes");
    odataBuilder.EntitySet<Step>("Steps");
    odataBuilder.EntitySet<Surface>("Surfaces");
    return odataBuilder.GetEdmModel();
}
