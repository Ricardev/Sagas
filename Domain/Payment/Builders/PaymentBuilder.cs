namespace Domain.Payment.Builders;

public class PaymentBuilder
{
    private readonly Payment _payment;

    public PaymentBuilder()
    {
        _payment = new Payment();
    }

    public PaymentBuilder SetPaymentValue(int paymentValue)
    {
        _payment.SetPaymentValue(paymentValue);
        return this;
    }

    public PaymentBuilder SetPaymentOrderId(int orderId)
    {
        _payment.SetOrderId(orderId);
        return this;
    }

    public Payment Build() => _payment;
}