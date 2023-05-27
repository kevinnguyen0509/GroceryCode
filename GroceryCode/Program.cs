using GroceryCode.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using GroceryCode;
using System.Text;
using static System.Console;
using GroceryCode.Models.Interfaces;
using GroceryCode.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthentication, Authentication>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

//Prompt();

//void Prompt()
//{
//    Clear();
//    WriteLine("[R] Register [L] Login");
//    var input = ReadLine().ToUpper()[0];
//    while (true)
//    {
//        if (input.Equals('R'))
//        {
//            Register();
//            break;
//        }
//        else if (input.Equals('L'))
//        {
//            Login();
//            break;
//        }
//        else
//            break;

//    }

//}


//void Login()
//{
//    Clear();
//    WriteLine("============ Login =============");
//    Write("User Name");
//    var username = ReadLine();
//    Write("Password");
//    var password = ReadLine();

//    using AppDataContext context = new AppDataContext();
//    var userFound = context.Users.Any(u => u.Name == username);

//    if (userFound)
//    {
//        var loginUser = context.Users.FirstOrDefault(u => u.Name == username);

//        if (HashPassword($"{password}{loginUser.Salt}") == loginUser.Password)
//        {
//            Clear();
//            ForegroundColor = ConsoleColor.Green;
//            WriteLine("Login Success");
//            ReadLine();
//        }
//        else
//        {
//            Clear();
//            ForegroundColor = ConsoleColor.Red;
//            WriteLine("Login Failed");
//            ReadLine();
//        }
//    }
//}

//void Register()
//{
//    Clear();
//    WriteLine("=========== Register =============");
//    Write("User Name");
//    var username = ReadLine();
//    Write("Password");
//    var password = ReadLine();

//    var salt = DateTime.Now.ToString();

    

//    using AppDataContext context = new AppDataContext();
//    var hashedPassword = HashPassword($"{password}{salt}");


//    context.Users.Add(new User() { Name = username, Password = hashedPassword, Salt = salt });
//    context.SaveChanges();
    

//    while (true)
//    {
//        Clear();
//        WriteLine("Registration Complete");
//        WriteLine("[B] Back");
//        if (ReadKey().Key == ConsoleKey.B)
//        {
//            Prompt();
//        }
        

//    }


//}

//string HashPassword(string password)
//{
//    SHA256 hash = SHA256.Create();
//    var passwordBytes = Encoding.Default.GetBytes(password);
    
//    var hashedPassword = hash.ComputeHash(passwordBytes);

//    return Convert.ToHexString(hashedPassword);

//}