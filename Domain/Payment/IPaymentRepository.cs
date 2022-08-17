namespace Domain.Payment;

public interface IPaymentRepository
{
    public Payment CreatePayment(Payment payment);
}