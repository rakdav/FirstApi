using FirstApi.Models;
using FirstApi.Services;

//List<Person> users = new List<Person>
//{
//    new(){Id=Guid.NewGuid().ToString(),Name="Tom",Age=40},
//    new(){Id=Guid.NewGuid().ToString(),Name="Bob",Age=19},
//    new(){Id=Guid.NewGuid().ToString(),Name="Sam",Age=26},
//};
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IService<Person>, PersonService>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
//#region GET
////api/users
//app.MapGet("/api/users", () => users);
////api/users/id
//app.MapGet("/api/users/{id}", (string id) => 
//{
//    Person? user = users.FirstOrDefault(u=>u.Id==id);
//    if (user == null) return Results.NotFound(new { message="Пользователь не найден"});
//    return Results.Json(user);
//});
//#endregion
//#region POST
////api/users
//app.MapPost("/api/users", (Person user) => {
//    user.Id = Guid.NewGuid().ToString();
//    users.Add(user);
//    return Results.Json(user);
//});
//#endregion
//#region PUT
////api/users
//app.MapPut("/api/users", (Person user) =>
//{
//    Person person=users.FirstOrDefault(p=>p.Id==user.Id)!;
//    if (person == null) return Results.NotFound(new { message="Пользователь не найден!" });
//    person.Name = user.Name;
//    person.Age = user.Age;
//    return Results.Json(person);
//});
//#endregion
//#region DELETE
//app.MapDelete("/api/users/{id}", (string id) => {
//    Person person = users.FirstOrDefault(p => p.Id == id)!;
//    if (person == null) return Results.NotFound(new { message = "Пользователь не найден!" });
//    users.Remove(person);
//    return Results.Ok();
//});
//#endregion
app.Run();

//public class Person
//{
//    public string Id { get; set; } = "";
//    public string Name { get; set; } = "";
//    public int Age { get; set; }
//}
