using BookishDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



// using (var context = new BookishDBContext())
// {
    //creates db if not exists 
    //context.Database.EnsureCreated();

    //create entity objects
    // context.Books.Add(new Book() { Title="Harry Potter", Author="J. K. Rowling",Copies=6,AvailableCopies=4 });
    // context.Books.Add(new Book() { Title="The Bible", Author="Jesus",Copies=2,AvailableCopies=0 });
    // context.Books.Add(new Book() { Title="Winnie The Pooh", Author="A. A. Milne",Copies=3,AvailableCopies=3 });
    // context.Books.Add(new Book() { Title="Alice in Wonderland", Author="Lewis Caroll",Copies=7,AvailableCopies=3 });

    // context.Members.Add(new Member() {  Name="Alex", Phone="0204 524 5348", email = "Alex@gmail.com"});
    // context.Members.Add(new Member() {  Name="Betty", Phone="0201 234 5678", email = "betty@gmail.com"});
    // context.Members.Add(new Member() {  Name="Carol", Phone="0208 122 7631", email = "carol@gmail.com"});
    // context.Members.Add(new Member() {  Name="Dennis", Phone="0201 654 9872", email ="dennis@gmail.com"});

    //var bookOut = new BookOut() { BookID = 1, MemberID = 1, DueDate = new DateTime(2025, 7,3)};

    //add entitiy to the context
    //context.Books.Add(book);
    //context.Members.Add(member);  
    // context.BookOuts.Add(new BookOut() {MemberID=3, BookID=4 });

    //save data to the database tables
    //context.SaveChanges();

    //retrieve all the students from the database
    // foreach (var s in context.Books) {
    //     Console.WriteLine($"Title: {s.Title}, Author: {s.Author}");
    // }

    // foreach (var s in context.Members) {
    //     Console.WriteLine($"Name: {s.Name}, Phone: {s.Phone}, email: {s.email}");
    // }
/*
    foreach (var s in context.BookOuts) {
        Console.WriteLine($"Member ID: {s.MemberID}, Book ID: {s.BookID}, Due Date: {s.DueDate}");
    }
*/
//}   


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
