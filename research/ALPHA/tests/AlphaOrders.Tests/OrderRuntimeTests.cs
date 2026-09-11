using AlphaOrders.Core;
using Xunit;

namespace AlphaOrders.Tests;

public class OrderRuntimeTests
{
    [Fact]
    public void AgentMayProposeButCannotAuthorizeHumanTransition()
    {
        var runtime = new OrderRuntime();
        runtime.Register(new Order(
            "O-001", OrderKind.Work, "Apply architectural change", "Active",
            Authority.Agent, Authority.Human, ["verified"], []));

        var trigger = new ExitTrigger("X-001", ExitTriggerKind.Evidence, "Evidence supports transition", []);
        var proposed = runtime.ProposeTransition("O-001", "Exited", trigger, Authority.Agent, DateTimeOffset.UtcNow, "Agent recommendation");

        Assert.Null(proposed.AuthorizedBy);
        Assert.Throws<UnauthorizedAccessException>(() => runtime.Authorize(proposed.Id, Authority.Agent));

        var authorized = runtime.Authorize(proposed.Id, Authority.Human);
        Assert.Equal(Authority.Human, authorized.AuthorizedBy);
        Assert.Equal("Exited", runtime.Orders.Single(o => o.Id == "O-001").State);
    }

    [Fact]
    public void LowRiskTransitionCanBeAuthorizedByProposer()
    {
        var runtime = new OrderRuntime();
        runtime.Register(new Order(
            "O-002", OrderKind.Research, "Answer bounded question", "Active",
            Authority.Agent, null, ["sufficient"], []));

        var trigger = new ExitTrigger("X-002", ExitTriggerKind.Deterministic, "Acceptance condition met", []);
        var proposed = runtime.ProposeTransition("O-002", "Exited", trigger, Authority.Agent, DateTimeOffset.UtcNow, "Acceptance met");
        var authorized = runtime.Authorize(proposed.Id, Authority.Agent);

        Assert.Equal("Exited", runtime.Orders.Single(o => o.Id == "O-002").State);
        Assert.Equal(Authority.Agent, authorized.AuthorizedBy);
    }
}
