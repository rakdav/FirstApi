List<Person> users = new List<Person>
{
    new(){Id=Guid.NewGuid().ToString(),Name="Tom",Age=40},
    new(){Id=Guid.NewGuid().ToString(),Name="Bob",Age=19},
    new(){Id=Guid.NewGuid().ToString(),Name="Sam",Age=26},
};
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
#region GET
//api/users
app.MapGet("/api/users", () => users);
//api/users/id
app.MapGet("/api/users/{id}", (string id) => 
{
    Person? user = users.FirstOrDefault(u=>u.Id==id);
    if (user == null) return Results.NotFound(new { message="Пользователь не найден"});
    return Results.Json(user);
});
#endregion
#region POST
//api/users
app.MapPost("/api/users", (Person user) => {
    user.Id = Guid.NewGuid().ToString();
    users.Add(user);
    return Results.Json(user);
});

#endregion

app.Run();

public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
