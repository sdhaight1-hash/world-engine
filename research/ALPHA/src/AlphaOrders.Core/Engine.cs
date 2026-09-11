namespace AlphaOrders.Core;

public sealed class OrderRuntime
{
    private readonly Dictionary<string, Order> _orders = new();
    private readonly List<Transition> _transitions = new();

    public IReadOnlyCollection<Order> Orders => _orders.Values;
    public IReadOnlyCollection<Transition> Transitions => _transitions;

    public void Register(Order order)
    {
        if (_orders.ContainsKey(order.Id)) throw new InvalidOperationException($"Order already exists: {order.Id}");
        _orders.Add(order.Id, order);
    }

    public Transition ProposeTransition(
        string orderId,
        string to,
        ExitTrigger trigger,
        Authority proposedBy,
        DateTimeOffset timestamp,
        string rationale)
    {
        if (!_orders.TryGetValue(orderId, out var order)) throw new KeyNotFoundException(orderId);
        var required = order.RequiredAuthorization;
        var transition = new Transition(
            Guid.NewGuid().ToString("N"), order.State, to, orderId, trigger,
            proposedBy, required is null ? proposedBy : null, timestamp, rationale);
        _transitions.Add(transition);
        return transition;
    }

    public Transition Authorize(string transitionId, Authority authority)
    {
        var index = _transitions.FindIndex(t => t.Id == transitionId);
        if (index < 0) throw new KeyNotFoundException(transitionId);
        var current = _transitions[index];
        var order = _orders[current.OrderId];
        if (order.RequiredAuthorization is not null && authority != order.RequiredAuthorization)
            throw new UnauthorizedAccessException($"Transition requires {order.RequiredAuthorization}, got {authority}.");

        var authorized = current with { AuthorizedBy = authority };
        _transitions[index] = authorized;
        _orders[order.Id] = order with { State = current.To };
        return authorized;
    }
}
