# Yellow and Red Issue Policy

## Status

**GREEN**

This document defines a development-process rule for World Engine. It does not define runtime architecture.

## Purpose

Discussion is the permissive deliberation function for open-ended questions, ideas, hypotheses, objections, and exploration.

Because the current ChatGPT GitHub integration does not expose GitHub Discussion creation or management, consequential provisional work must be trackable through GitHub Issues when direct repository tracking is required.

This document establishes when World Engine uses **Yellow Issues** and **Red Issues**.

## Core rule

> **Discussion is deliberation. Yellow and Red Issues are tracked epistemic conditions. Green is a promotion state, not a synonym for Issue state.**

An Issue does not become authoritative merely because it exists in the repository.

## State model

```text
Discussion
    |
    | consequential uncertainty, research need, experiment, or objection
    v
Issue
    |
    +--> Yellow: unresolved / provisional / not ready
    |
    +--> Green promotion path: sufficiently established for stated target
    |
    +--> Red: sufficiently evidenced rejection / negative knowledge
```

Evidence level, Issue workflow state, promotion status, authority, and provenance remain separate dimensions.

## When to Create a Yellow Issue

The assistant should create a Yellow Issue proactively when an idea or uncertainty crosses the threshold from ordinary conversation into consequential tracked work.

Create a Yellow Issue when one or more of the following applies:

- An unresolved architectural question could materially affect World Engine.
- A hypothesis may affect an architectural invariant or major subsystem.
- Research, an experiment, or a prototype is needed before a responsible decision can be made.
- Competing architectural candidates require explicit evaluation.
- An implementation exists but its architectural validity has not been established.
- External research appears promising but lacks World Engine-specific validation.
- A previously accepted assumption is being challenged.
- A provisional direction must be preserved so it is not accidentally treated as authoritative.
- Failure to track the uncertainty could plausibly cause duplicated work, premature commitment, or architectural error.

Do not create a Yellow Issue merely because an idea was mentioned or a trivial uncertainty exists. The threshold is **consequential uncertainty**.

### Yellow meaning

> **This deserves active attention, but we have not earned authority yet.**

## When to Create a Red Issue

Create a Red Issue when sufficient evidence or reasoning establishes that an approach should not become authoritative for its documented scope.

Examples:

- an experiment falsifies the hypothesis;
- a design violates an established invariant;
- an approach creates unacceptable authority coupling;
- a security, correctness, reproducibility, provenance, or integrity problem is established;
- an implementation works technically but is fundamentally incompatible with the architecture;
- a material assumption is shown to be false;
- a candidate is deliberately rejected after meaningful evaluation;
- a previously Green assumption is overturned;
- continuing to treat the approach as viable would create material architectural risk.

### Red meaning

> **Do not promote this. Preserve why.**

A Red Issue is negative knowledge, not a trash bin.

## Insufficient evidence

**Insufficient evidence is not rejection.**

If the project cannot yet establish whether a proposition should be accepted or rejected, it remains Yellow unless there is an independent reason for rejection.

## Promotion and reconsideration

### Yellow -> Green

Promotion requires, as applicable:

- the question has been answered sufficiently;
- relevant invariants remain preserved;
- assumptions and dependencies are understood;
- validation is appropriate to the risk;
- the resulting Decision, Specification, validated implementation, or other authoritative artifact is explicitly recorded;
- provenance and documentation are updated.

The Yellow Issue itself is not the authority.

### Yellow -> Red

Move toward Red when sufficient evidence establishes rejection. Preserve the reason, evidence, affected invariants, and reconsideration conditions.

### Yellow -> Yellow

Remaining unresolved is valid. Do not manufacture a conclusion merely to close the loop.

### Red -> Reconsideration

A Red conclusion may be revisited when genuinely new evidence changes its premises. Reconsideration does not erase the historical conclusion.

## Required Yellow Issue information

When practical, record:

- question or problem;
- current understanding;
- hypothesis or candidates;
- evidence and references;
- objections and failure modes;
- affected invariants;
- required experiment or validation;
- assumptions;
- remaining uncertainty;
- promotion target;
- provenance to originating discussion, research, experiment, decision, or implementation.

## Required Red Issue information

Record:

- rejected proposition or approach;
- reason for rejection;
- evidence supporting rejection;
- affected invariants or risks;
- experiment or evaluation when applicable;
- alternatives considered when material;
- conditions for reconsideration, if any;
- provenance to the originating work.

## Labels

Minimum state labels:

- `yellow`
- `red`

Additional labels may describe subject matter but do not replace the state label.

## Assistant operating rule

The assistant must evaluate whether new conclusions have crossed the threshold for tracked Yellow or Red status.

The assistant must not:

- treat a Yellow Issue as an architectural specification;
- treat a Red Issue as an authoritative prohibition outside its documented scope;
- silently promote Yellow material into implementation authority;
- erase negative evidence;
- use absence of a Yellow or Red Issue as evidence that no uncertainty or rejection exists.

## Relationship to governance

The canonical process model is defined in `docs/development-governance.md`.

The Issue Examination and Issue Resolution Protocols define how tracked Issues are examined and resolved.

The Green / Yellow / Red gate in Research Topic 005 defines repository promotion semantics. This policy supplies the threshold for creating explicit Yellow and Red Issue records.

## First-principles test

Before creating or promoting a Yellow or Red Issue, ask:

1. What is the invariant?
2. Who or what is authoritative?
3. Is this a capability, or merely one implementation?
4. What evidence exists?
5. What remains uncertain?
6. What would falsify the hypothesis or justify rejection?
7. What would be required for promotion?
8. Can the result be reversed without corrupting authority?
9. Where is the provenance recorded?

## Final principle

> **Nothing becomes authoritative merely because it was discussed, researched, implemented, or committed. Authority is granted through explicit validation and promotion.**
