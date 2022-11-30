namespace MessageBroker;

public static class EventQueue
{
    public static string ValidateProductQueue = "ValidateProductQueue";
    public static string CreatePaymentQueue = "CreatePaymentQueue";
    public static string RollbackProductQueue = "RollbackProductQueue";
}

public static class QueueExchange
{
    public static string CreatePaymentExchange = "Create Payment Exchange";
    public static string CreateProductExchange = "Create Product Exchange";
    public static string RollbackProductExchange = "Rollback Product Exchange";
}