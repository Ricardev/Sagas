using MessageBroker.EventModels;

namespace Application.Payment;

public interface IPaymentApplication
{
    public void CreatePayment(ValidateProductEventModel validateProductEvent);
    public void RollbackCreatePayment();
}