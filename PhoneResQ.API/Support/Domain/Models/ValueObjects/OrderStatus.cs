namespace PhoneResQ.API.Support.Domain.Models.ValueObjects
{
    public enum OrderStatus
    {
        Received,
        OnProcess,
        OnHold,
        Ready,
        Completed,
        Cancelled,
        Escalated
    }
}
