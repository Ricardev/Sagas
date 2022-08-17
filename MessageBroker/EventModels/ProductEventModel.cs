namespace MessageBroker.EventModels;

public class ValidateProductEventModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}