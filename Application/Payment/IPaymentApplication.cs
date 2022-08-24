using MessageBroker.EventModels;

namespace Application.Payment;

public interface IPaymentApplication
{
    public void CreatePayment(CreatePaymentEventModel validateProductEvent);
    public void RollbackCreatePayment(RollbackPaymentEventModel paymentEvent);
}