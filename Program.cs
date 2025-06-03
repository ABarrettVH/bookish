using Bookish;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
try {

            using (var ctx = new BookishContext())
            {
                Console.WriteLine("get here 1");
                Console.WriteLine(ctx.Database.CanConnect() ? "Connected!" : "Connection failed!");
                //ctx.Database.EnsureCreated();
                Console.WriteLine("get here 2");

                var book = new Book ("Harry Potter", "Rowling" );
        
                ctx.Books.Add(book);
                ctx.SaveChanges();                
            
    foreach (var b in ctx.Books) {
        Console.WriteLine($"First Name: {b.Title}, Last Name: {b.Author}");
    }
            }
}catch(Exception e) {
    Console.WriteLine($"YOU HAVE AN ERROR, {e}");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
