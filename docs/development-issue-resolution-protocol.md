# Issue Resolution Protocol

**Status:** GREEN
**Related:** Work Order #10, Issue #11, Development Governance

## Purpose

Define how an examined World Engine Issue becomes resolved, deferred, rejected, superseded, implemented and validated, or reopened.

## Core rule

> Resolve the claim, not merely the Issue record.

Closing an Issue is an administrative result. Resolution requires an explicit substantive outcome, evidence, provenance, and, where applicable, validated implementation or authoritative decision.

## Resolution model

```text
Examined Issue
    |
    +--> Documented
    +--> Researched
    +--> Experimentally resolved
    +--> Decided
    +--> Implemented + Validated
    +--> Rejected
    +--> Duplicate / Superseded
    +--> Deferred
```

Not every Issue requires every class or stage.

## Resolution classes

### DOCUMENTED

The Issue is resolved by clarifying existing behavior or authority without changing architecture or implementation.

### RESEARCHED

Evidence answers the question sufficiently for the stated purpose, with no implementation required.

### EXPERIMENTALLY RESOLVED

A bounded experiment answers the question or establishes a limitation. The result remains evidence until explicitly promoted.

### DECIDED

An explicit Decision resolves the Issue and identifies the authoritative artifact or authorized next step.

### IMPLEMENTED AND VALIDATED

A bounded implementation satisfies its authoritative contract or acceptance criteria and has appropriate validation evidence.

### REJECTED

Sufficient evidence establishes that the proposition or approach should not be promoted for its documented scope. Preserve the negative evidence and rationale.

### DUPLICATE / SUPERSEDED

The Issue is represented by another active or authoritative record. Preserve the historical link.

### DEFERRED

The Issue remains valid but is intentionally postponed. Record the reason and trigger for reconsideration.

## Orders are optional

Use the single conceptual **Order** only when a bounded activity needs explicit delegation, accountability, scheduling, parallelism, or provenance.

Possible types include:

```text
RESEARCH
EXPERIMENT
IMPLEMENTATION
VALIDATION
OTHER
```

A Research or Experiment Order authorizes the activity, not its conclusion. An Implementation Order authorizes bounded execution within existing authority. An Order cannot redefine its source Contract or Decision.

## Decision boundary

A Decision answers:

> Given the examined evidence and project constraints, what do we choose to do?

A consequential Decision should identify the proposition, evidence, material alternatives, affected invariants, chosen outcome, authority scope, implementation consequences, validation requirements, and provenance.

A Decision is authoritative only within its explicitly stated scope.

## Work boundary

Implementation answers:

> What bounded work is authorized because an appropriate Decision or Contract exists?

If implementation exposes an unresolved architectural question, pause the affected work and create or update an Issue. Do not invent architecture inside implementation work.

## Validation boundary

Validation answers:

> Did the result satisfy the authority and acceptance criteria it was supposed to satisfy?

Validation evidence must remain distinguishable from the implementation itself. Passing a test proves only what the test establishes.

## Closure requirements

An Issue may be closed when its substantive outcome is explicit and the record contains, as applicable:

- resolution class;
- evidence references;
- Decision or authority reference;
- Order reference when one exists;
- PR / implementation reference;
- validation reference;
- residual uncertainty;
- reason for deferral or rejection;
- reopen condition;
- provenance.

Closure must not erase negative evidence or unresolved assumptions.

## Reopening

Reopen an Issue when new evidence changes the premises, validation contradicts the resolution, a material assumption fails, a previously rejected approach becomes viable under materially changed conditions, or implementation exposes a deeper unresolved Issue.

Reopening creates new provenance. It does not rewrite history.

## AI-agent operating rules

AI agents must distinguish:

```text
Issue       = what needs examination
Research    = evidence gathering / analysis
Experiment  = bounded evidence generation
Decision    = what the project chooses
Order       = optional bounded delegation
PR          = proposed repository change
Validation  = whether criteria were met
Authority   = what is binding
```

The agent must not:

- implement an Issue merely because it is open;
- treat research findings as specifications;
- treat an Order as architectural authority;
- treat a successful experiment as production architecture without promotion;
- use implementation work to invent missing authority;
- treat a PR as authoritative before promotion;
- close an Issue merely because a PR was opened;
- convert insufficient evidence into rejection without justification;
- erase rejected approaches from provenance.

The agent should proactively create or update Yellow tracking for consequential uncertainty and Red tracking for sufficiently evidenced rejection.
