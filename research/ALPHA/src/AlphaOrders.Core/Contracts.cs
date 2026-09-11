namespace AlphaOrders.Core;

public enum OrderKind { Research, Work, Investigation, Experiment, Validation }
public enum OrderState { Draft, Active, AwaitingAuthorization, Exited, Failed }
public enum Authority { Agent, DomainLead, Human }
public enum ExitTriggerKind { Deterministic, Threshold, Invariant, Evidence, Semantic, Human, Emergent }

public sealed record EvidenceRef(string Id, string Description);

public sealed record ExitTrigger(
    string Id,
    ExitTriggerKind Kind,
    string Description,
    IReadOnlyList<EvidenceRef> Evidence);

public sealed record Transition(
    string Id,
    string From,
    string To,
    string OrderId,
    ExitTrigger Trigger,
    Authority ProposedBy,
    Authority? AuthorizedBy,
    DateTimeOffset Timestamp,
    string Rationale);

public sealed record Order(
    string Id,
    OrderKind Kind,
    string Objective,
    string State,
    Authority ProposalAuthority,
    Authority? RequiredAuthorization,
    IReadOnlyList<string> ExitConditions,
    IReadOnlyList<EvidenceRef> Evidence);

public sealed record PostOrderReport(
    string OrderId,
    string ExitState,
    string ExitTriggerId,
    IReadOnlyList<string> TransitionIds,
    string Outcome,
    string Lessons,
    string NextAction);
