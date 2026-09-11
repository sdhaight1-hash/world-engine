# Yellow and Red Issue Policy

## Status

**GREEN**

This document defines a development-process rule for World Engine. It does not define runtime architecture.

## Purpose

GitHub Discussions are the permissive deliberation layer for open-ended questions, ideas, hypotheses, objections, and exploration.

Because the current ChatGPT GitHub integration does not expose GitHub Discussion creation or management, consequential provisional work must be trackable through GitHub Issues when direct repository tracking is required.

This document therefore establishes when World Engine uses **Yellow Issues** and **Red Issues**.

## Core Rule

> **Discussion is deliberation. Yellow and Red Issues are tracked epistemic states. Green is authority.**

An Issue does not become authoritative merely because it exists in the repository.

## State Model

```text
Discussion
    |
    | consequential uncertainty, research need, experiment, or objection
    v
YELLOW Issue
    |
    | evaluation
    +-------------------+
    |                   |
    v                   v
GREEN               RED Issue
    |                   |
    v                   v
Authority        Negative evidence / rejection
```

## When to Create a Yellow Issue

The assistant should create a Yellow Issue proactively when an idea or uncertainty crosses the threshold from ordinary conversation into consequential tracked work.

Create a Yellow Issue when one or more of the following applies:

- A discussion produces an unresolved architectural question that could materially affect World Engine.
- A hypothesis may affect an architectural invariant or major subsystem.
- A research question, experiment, or prototype is needed before a decision can responsibly be made.
- Competing architectural candidates require explicit evaluation.
- An implementation exists but its architectural validity has not yet been established.
- External research appears promising but has not received World Engine-specific validation.
- A previously accepted assumption is being challenged and requires investigation.
- The project needs to preserve a provisional direction so it is not accidentally treated as authoritative.
- Failure to track the uncertainty could plausibly cause duplicated work, premature commitment, or an architectural mistake.

### Yellow does not mean

Do not create a Yellow Issue merely because an idea was mentioned, brainstormed, or remains uncertain in a trivial way.

The threshold is **consequential uncertainty**.

### Yellow meaning

> **This deserves active attention, but we have not earned authority yet.**

## When to Create a Red Issue

The assistant should create a Red Issue proactively when there is sufficient evidence or reasoning to conclude that an approach should not become authoritative, while preserving the conclusion as negative evidence.

Create a Red Issue when one or more of the following applies:

- An experiment falsifies the hypothesis.
- A proposed design violates a World Engine invariant.
- An approach creates unacceptable authority coupling.
- A security, correctness, reproducibility, provenance, or integrity problem is identified.
- An implementation works technically but is fundamentally incompatible with the architecture.
- Research demonstrates that a material assumption is false.
- A candidate has been deliberately rejected after meaningful evaluation.
- A previously Green assumption is overturned and should no longer be treated as authoritative.
- Continuing to treat the approach as viable would create a material risk of architectural drift.

### Red meaning

> **Do not promote this. Preserve why.**

A Red Issue is not a trash bin. It is part of the project's negative knowledge base.

## Promotion and Demotion

### Yellow -> Green

A Yellow Issue may move toward Green when:

- the question has been answered sufficiently;
- required experiments have passed;
- relevant invariants remain preserved;
- assumptions and dependencies are understood;
- validation is appropriate to the risk;
- the resulting decision or contract is explicitly recorded;
- authoritative documentation is updated.

The Yellow Issue itself is not the authority. The resulting Decision, Specification, validated implementation, or other explicitly authoritative artifact is.

### Yellow -> Red

A Yellow Issue should become Red when investigation establishes that the candidate should be rejected or cannot responsibly be promoted.

The Red record should preserve the reason, evidence, relevant experiment, affected invariants, and any conditions under which the conclusion might later be revisited.

### Yellow -> Yellow

Remaining Yellow is valid. Unresolved work does not need to be artificially promoted or rejected merely to close the process loop.

### Red -> Reconsideration

A Red conclusion may be revisited if genuinely new evidence changes the premises. Reopening a Red Issue does not erase the historical rejection. The new work must preserve the provenance of the original conclusion.

## Required Yellow Issue Information

When practical, a Yellow Issue should record:

- Question or problem
- Current understanding
- Hypothesis or candidate approaches
- Evidence and references
- Objections and failure modes
- Invariants potentially affected
- Experiment or validation required
- Assumptions
- Remaining uncertainty
- Promotion target
- Originating Discussion, research item, experiment, or decision when one exists

## Required Red Issue Information

A Red Issue should record:

- Rejected proposition or approach
- Reason for rejection
- Evidence supporting rejection
- Invariants violated or risks identified
- Experiment or evaluation that produced the result, when applicable
- Alternatives considered
- Conditions that would justify reconsideration, if any
- Originating Discussion, research item, experiment, or decision when one exists

## Labels

The minimum state labels are:

- `yellow`
- `red`

Additional labels such as `research`, `experiment`, `architecture`, `security`, or `process` may describe the subject, but must not replace the state label.

The state label describes epistemic status. Subject labels describe content.

## Assistant Operating Rule

When working on World Engine, the assistant must evaluate whether new conclusions have crossed the threshold for tracked Yellow or Red status.

The assistant should create a Yellow or Red Issue without waiting for the user to explicitly request an Issue when the criteria in this document are met.

The assistant must not:

- treat a Yellow Issue as an architectural specification;
- treat a Red Issue as an authoritative prohibition outside its documented scope;
- silently promote Yellow material into implementation authority;
- erase negative evidence because a candidate was rejected;
- use the absence of a Yellow or Red Issue as evidence that no uncertainty or rejection exists.

## Relationship to the Green / Yellow / Red Gate

This policy extends Research Topic 005, **GitHub Practices and the Green / Yellow / Red Push Gate**.

The same epistemic distinction applies regardless of where material originated:

- Discussion: permissive deliberation
- Research: evidence and analysis
- Experiment: feasibility or validation evidence
- Yellow Issue: consequential provisional work requiring tracking
- Red Issue: consequential rejection or negative evidence requiring preservation
- Decision: explicit project decision
- Specification: authoritative contract
- Implementation: realized behavior validated against authority
- Green: promotion into the appropriate authoritative repository artifact

## First-Principles Test

Before creating or promoting a Yellow or Red Issue, ask:

1. **What is the invariant?**
2. **Who or what is authoritative?**
3. **Is this a capability, or merely one implementation?**
4. **What evidence exists?**
5. **What remains uncertain?**
6. **What would falsify the current hypothesis or justify rejection?**
7. **What would be required for promotion?**
8. **Can the result be reversed without corrupting authority?**
9. **Where is the provenance recorded?**

## Final Principle

> **Nothing becomes authoritative merely because it was discussed, researched, implemented, or committed. Authority is granted through explicit validation and promotion.**
