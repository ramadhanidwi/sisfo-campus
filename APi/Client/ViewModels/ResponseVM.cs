namespace Client.ViewModels;

public class ResponseVM<Entity>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public Entity? Data { get; set; }
}
