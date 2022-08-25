var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

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




//Console.WriteLine("Please enter in your specific flight number.");
//var flightNumber = Console.ReadLine();

//Console.WriteLine("Please enter in your flight date in YYYY-MM-DD.");
//var date = Console.ReadLine();

//var client = new HttpClient();
//var request = new HttpRequestMessage
//{
//    Method = HttpMethod.Get,
//    RequestUri = new Uri($"https://aerodatabox.p.rapidapi.com/flights/%7BsearchBy%7D/{flightNumber}/{date}"),
//    Headers =
//    {
//        { "X-RapidAPI-Key", "fa96296f46mshcae55558b128d47p1b35d1jsn2a266e359194" },
//        { "X-RapidAPI-Host", "aerodatabox.p.rapidapi.com" },
//    },
//};
//using (var response = await client.SendAsync(request))
//{
//    response.EnsureSuccessStatusCode();
//    var body = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(body);
//}

