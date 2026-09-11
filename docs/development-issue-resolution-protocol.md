# Issue Resolution Protocol

**Status:** YELLOW / DRAFT
**Work Order:** #10
**Related:** Issue #11, Research Topic 005, Yellow/Red Issue Policy, Issue Examination Protocol

## 1. Purpose

Define how an examined World Engine Issue proceeds to research, experimentation, decision, implementation, rejection, deferral, closure, or reopening.

This is a development-process protocol. It does not define runtime architecture.

## 2. Core rule

> Resolve the claim, not merely the Issue record.

Closing an Issue is an administrative result. Resolution requires an explicit substantive outcome, evidence, provenance, and, where applicable, validated implementation or authoritative decision.

## 3. Resolution lifecycle

```text
RESOLUTION PLAN
      |
      +--> RESEARCH ORDER -> RESEARCH ----+
      |                                    |
      +--> EXPERIMENT ORDER -> EXPERIMENT -+-> EVALUATION -> DECISION
      |                                                   |
      +-----------------------------------------------+   |
                                                      v   v
                                                  WORK ORDER
                                                      |
                                                      v
                                                     PR
                                                      |
                                                      v
                                                  VALIDATION
                                                      |
                                                      v
                                                   CLOSURE
                                                      |
                                                      v
                                                  PROVENANCE
```

Not every Issue requires every stage.

## 4. Resolution classes

### DOCUMENTED

The Issue is resolved by clarifying existing behavior or authority without changing architecture or implementation.

### RESEARCHED

Evidence resolves the question sufficiently for the stated purpose, but no implementation is required.

### EXPERIMENTALLY RESOLVED

A bounded experiment answers the question or establishes a validated limitation. The experiment result does not itself become architecture.

### DECIDED

An explicit project Decision resolves the Issue and identifies the authoritative artifact or next implementation step.

### IMPLEMENTED AND VALIDATED

A bounded change was implemented, reviewed, and validated against its authoritative contract or acceptance criteria.

### REJECTED

Sufficient evidence establishes that the proposition or approach should not be promoted. The negative evidence and rationale are preserved.

### DUPLICATE / SUPERSEDED

The Issue is already represented by another authoritative or active record. Preserve a link rather than silently deleting the historical trail.

### DEFERRED

The Issue remains valid but is intentionally postponed. Record the reason and trigger for reconsideration.

## 5. Orders are conditional delegation objects

A Research Order, Experiment Order, or Work Order should be created only when a distinct bounded task needs to be delegated, scheduled, tracked, or referenced.

They are not mandatory stages of every Issue.

### Research Order

Authorizes investigation of a defined question.

It should contain:
- source Issue
- research question
- scope
- evidence standard
- exclusions / non-goals
- expected output
- provenance requirement

It does **not** authorize architectural adoption.

### Experiment Order

Authorizes a bounded test intended to produce evidence.

It should contain:
- source hypothesis or Issue
- falsifiable hypothesis
- variables and conditions
- procedure
- acceptance/falsification criteria
- reproducibility requirements
- expected output

It does **not** authorize treating a successful experiment as production architecture.

### Work Order

Authorizes a bounded implementation or repository change after the required authority exists.

It should contain:
- source Decision / authoritative contract
- scope
- explicit non-goals
- acceptance criteria
- affected artifacts
- validation requirements
- provenance references
- rollback/reversal expectations where relevant

A Work Order must not silently expand the authority of the source Decision.

## 6. Anti-bloat rule

Orders are coordination tools, not additional epistemic states.

If an Issue can be safely resolved by a direct research note, experiment record, Decision, or PR without losing delegation, accountability, or provenance, no separate Order is required.

A process layer is justified only when it provides a capability that would otherwise be materially lost.

The protocol should prefer:

```text
Issue -> Research -> Decision
```

over:

```text
Issue -> Research Order -> Research Task -> Research Record -> Research Review -> Decision
```

unless the additional objects provide real operational value.

## 7. Decision boundary

A Decision answers:

> Given the examined evidence and project constraints, what do we choose to do?

A Decision must identify:
- proposition considered
- evidence relied upon
- alternatives considered where material
- affected invariants
- chosen outcome
- rejected alternatives where important
- authority granted, if any
- implementation consequences
- validation requirements
- provenance

A Decision is not automatically authoritative merely because it is written. Its authority scope must be explicit.

## 8. Work-order boundary

A Work Order answers:

> What bounded work is now authorized because an appropriate decision or contract exists?

A Work Order should not answer architectural questions that the source authority has not resolved.

If implementation reveals an unresolved architectural question, pause the affected work and create or update the relevant Issue rather than inventing a solution inside the Work Order.

## 9. Validation boundary

Validation answers:

> Did the result satisfy the authority and acceptance criteria it was supposed to satisfy?

Validation evidence must be distinguishable from the implementation itself.

Passing tests prove only what those tests establish. Broader architectural claims require broader evidence.

## 10. Closure requirements

An Issue may be closed when its substantive outcome is explicit and the record contains, as applicable:
- resolution class
- evidence references
- Decision or authority reference
- Work Order reference
- PR / implementation reference
- validation reference
- residual uncertainty
- reason for deferral or rejection
- reopen condition

Closure must not erase negative evidence or unresolved assumptions.

## 11. Reopening

An Issue may be reopened when:
- new evidence changes the premises;
- a validation result contradicts the resolution;
- an assumption previously treated as valid fails;
- a previously rejected approach becomes viable under materially changed conditions;
- the implemented result exposes a deeper unresolved Issue.

Reopening creates a new provenance edge. It does not rewrite history.

A Red/rejected conclusion may therefore be reconsidered without deleting its original evidence or pretending the original conclusion never occurred.

## 12. AI-agent operating rules

AI agents must distinguish:

```text
Issue        = what needs examination
Research     = evidence gathering / analysis
Experiment   = bounded evidence generation
Decision     = what the project chooses
Work Order   = what work is authorized
PR           = what change is proposed
Validation   = whether the change satisfies its authority
Authority    = what is actually binding
```

The agent must not:
- implement an Issue merely because it is open;
- treat research findings as specifications;
- treat a Research Order as architecture authority;
- treat an Experiment Order as permission to deploy its result;
- use a Work Order to invent missing architectural authority;
- treat a PR as authoritative before promotion;
- close an Issue solely because a PR was opened;
- convert insufficient evidence into rejection without justification;
- erase rejected approaches from the provenance chain.

The agent should proactively create or update a Yellow Issue when consequential uncertainty is discovered, and a Red Issue when sufficient evidence establishes rejection, according to the governing policy.

## 13. Resolution decision tree

```text
Is the Issue consequential?
  no -> handle locally; no process object required
  yes
   |
   v
Is existing authority sufficient?
  yes -> determine whether implementation/documentation is needed
  no  -> research / experiment / decision path

Does the question require delegated work?
  no  -> research or experiment directly
  yes -> create the smallest useful Order

Did evidence resolve the question?
  no  -> remain unresolved / defer / continue
  yes
   |
   v
Does a project choice need to be made?
  no  -> record research/experimental result
  yes -> Decision

Does implementation follow?
  no  -> close with decision/evidence
  yes -> Work Order -> PR -> Validation

Did validation pass?
  yes -> promote applicable artifact and close
  no  -> reopen/update Issue; preserve failure evidence
```

## 14. Required provenance

Where practical, maintain the chain:

```text
Discussion / Observation
        -> Issue
        -> Examination
        -> Research / Experiment
        -> Evaluation
        -> Decision
        -> Specification / Contract
        -> Work Order
        -> PR
        -> Validation
        -> Authority
```

Not every node is mandatory. The record must preserve the actual path taken rather than manufacture missing stages.

## 15. Process-level acceptance test

The protocol must be tested against at least:

1. ordinary implementation defect;
2. Yellow architectural uncertainty;
3. rejected approach with sufficient negative evidence;
4. research question with no implementation;
5. successful experiment that leads to a Work Order;
6. deferred Issue;
7. reopened Issue after new evidence;
8. trivial Issue that should bypass heavyweight process.

The protocol fails its own anti-bloat requirement if these cases cannot be represented without unnecessary duplicate objects.

## 16. Current status

This protocol remains YELLOW until Issue #11 and the related Green/Yellow/Red semantic questions are resolved and the protocol passes the acceptance cases above.

No runtime architecture is implied by this document.
