internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        var hotel = new Hotel();
        hotel.Id = 1;
        hotel.Name = "AAA";
        hotel.Longitude = 12.12;
        hotel.Latitude = 13.13;

        var hotels = new List<Hotel>();
        hotels.Add(hotel);


        app.MapGet("/hotels", () => hotels);
        app.MapGet("/hotels/{id}", (int id) => hotels.FirstOrDefault(h => h.Id == id ));
        app.MapPost("/hotels", (Hotel hotel) => hotels.Add(hotel));
        app.MapPut("/hotels", (Hotel hotel) =>
        {
            var index = hotels.FindIndex(h => h.Id == hotel.Id);
            if (index == -1)
            {
                throw new Exception("Not Found");
            }
            hotels[index] = hotel;

        });
        app.MapDelete("/hotels/{id}", (int id) =>
        {
            var index = hotels.FindIndex(h => h.Id == id);
            if (index == -1)
            {
                throw new Exception("Not Found");
            }
            hotels.RemoveAt(index);
        });

        app.Run();
    }
}
public class Hotel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Longitude { get; set; }
    public double Latitude { get; set; }

}