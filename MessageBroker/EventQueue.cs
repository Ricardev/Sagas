namespace MessageBroker;

public static class EventQueue
{
    public static string ValidateProductQueue = "ValidateProductQueue";
    public static string ValidatePaymentQueue = "ValidatePaymentQueue";
    public static string CreatePaymentQueue = "CreatePaymentQueue";
    public static string RollbackProductQueue = "RollbackProductQueue";
    public static string RollbackPaymentQueue = "RollbackPaymentQueue";
}