namespace MessageBroker;

public static class EventQueue
{
    public static string ValidateProductQueue = "ValidateProductQueue";
    public static string CreatePaymentQueue = "CreatePaymentQueue";
    public static string RollbackProductQueue = "RollbackProductQueue";
    public static string RollbackPaymentQueue = "RollbackPaymentQueue";
}

public static class QueueExchange
{
    public static string PaymentExchange = "Payment Exchange";
    public static string OrderExchange = "Order Exchange";
    public static string ProductExchange = "Product Exchange";
}