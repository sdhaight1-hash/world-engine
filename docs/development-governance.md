# World Engine Development Governance

**Status:** GREEN
**Scope:** Development governance only. This document does not define runtime architecture.

## Purpose

World Engine separates deliberation, evidence, decisions, implementation, validation, and authority so that plausible ideas cannot become architecture by accident.

## First-principles rule

> Define the invariant. Identify the authority. Separate capability from implementation. Preserve provenance.

Nothing becomes authoritative merely because it was discussed, researched, implemented, or committed. Authority is granted through an explicit decision, contract, validation, and promotion path appropriate to the claim.

## Minimum process model

```text
Discussion
    -> Issue, when uncertainty or work becomes consequential
    -> Examination
    -> Research / Experiment / Direct Resolution, as needed
    -> Evidence
    -> Decision, when a project choice is required
    -> Specification / Contract, when binding behavior must be defined
    -> Implementation, when work is required
    -> Validation
    -> Authority
```

This is a conceptual process, not a mandatory artifact chain. Simple work may use only the stages necessary to establish correctness and authority.

## Discussion is a process function

Discussion is the permissive deliberation layer. It may occur in the active ChatGPT project conversation, GitHub Discussions, or another explicitly recognized deliberative channel.

For the AI-assisted World Engine workflow, the active ChatGPT project conversation is the primary deliberation medium because the available GitHub integration does not expose GitHub Discussion operations.

GitHub Discussions remain useful for human repository-side deliberation, but the project process must not depend on them being available to an AI agent.

Discussion has no authority by itself. Consequential conclusions must be formally captured in the repository before they become authoritative.

## Core objects and roles

| Concept | Purpose | Authority by itself |
|---|---|---|
| Discussion | Deliberation, brainstorming, objections, alternatives | No |
| Issue | Track a consequential claim, problem, uncertainty, defect, or rejection | No |
| Examination | Determine what is claimed, known, uncertain, and affected | No |
| Research | Gather and analyze evidence | No |
| Experiment | Generate bounded empirical evidence | No |
| Decision | Record an explicit project choice | Only within explicit scope |
| Specification / Contract | Define binding behavior or boundary | Yes within scope |
| Order | Optional delegation wrapper for bounded work | Authorizes the stated activity, not architecture |
| Pull Request | Propose repository changes | No until promoted |
| Validation | Establish whether stated criteria were met | No by itself |
| Authority | Explicitly promoted binding project state | Yes |

These are semantic roles. They do not require a separate file, database object, or GitHub object for every occurrence.

## Orders are optional

Research Order, Experiment Order, and Work Order are not separate epistemic states or mandatory lifecycle stages.

Use one conceptual **Order** only when bounded work benefits from explicit delegation, scope, accountability, scheduling, parallelism, or provenance.

An Order may have a type such as `RESEARCH`, `EXPERIMENT`, `IMPLEMENTATION`, or `VALIDATION`.

An Order cannot grant authority that its source Decision or Contract does not already possess.

## Orthogonal dimensions

World Engine must not collapse different questions into one status value.

### Evidence level

```text
E0  Speculation
E1  Literature / external evidence
E2  Reasoned architectural analysis
E3  Prototype
E4  Controlled experiment
E5  Reproducible validation
E6  Integrated validation
```

Evidence level describes the strength of evidence. It does not automatically determine authority.

### Issue state

Issue state describes workflow, for example:

```text
OPEN
UNDER_EXAMINATION
RESOLVED
DEFERRED
REJECTED
SUPERSEDED
REOPENED
```

### Green / Yellow / Red

Green, Yellow, and Red describe promotion or development disposition:

- **GREEN:** sufficiently established and validated for the stated promotion target.
- **YELLOW:** unresolved, provisional, insufficiently evidenced, or otherwise not ready for promotion.
- **RED:** sufficiently evidenced rejection or negative knowledge for the stated scope.

Insufficient evidence is normally Yellow, not Red.

### Authority

Authority is explicit. It is not inferred from evidence level, Issue state, repository location, implementation completeness, or apparent consensus.

### Provenance

Provenance records lineage across these dimensions. It is cross-cutting, not another workflow stage.

## Promotion rule

A Yellow item may become Green when its question has been answered sufficiently, relevant invariants are preserved, assumptions are understood, validation is appropriate, and the resulting authoritative Decision, Specification, or validated implementation is explicitly recorded.

A Yellow item may become Red when sufficient evidence establishes rejection. The negative evidence and rationale must be preserved.

A Red conclusion may be reconsidered when genuinely new evidence changes its premises. Reconsideration does not erase history.

## AI-agent rule

AI agents must examine before implementing consequential Issue content.

They must:

1. locate the current authority;
2. distinguish claim, evidence, interpretation, and proposed solution;
3. identify affected invariants and authority boundaries;
4. create or update Yellow tracking when consequential uncertainty is discovered;
5. create Red tracking only when sufficient evidence establishes rejection;
6. stop rather than invent authority when the requested change lacks an authoritative basis;
7. preserve provenance when promoting research or implementation.

Yellow and Red material may inform work but cannot silently become authority.

## Anti-bloat rule

Do not create a new process object merely because another project uses one.

Before adding a new artifact or workflow stage, ask whether it preserves a genuinely different responsibility, authority boundary, provenance requirement, or operational capability that an existing object cannot provide.

If not, keep the distinction conceptual or express it as metadata.

## Repository authority

`main` is the authoritative repository branch. A committed artifact is not automatically authoritative architecture. The artifact's status and authority scope must be explicit.

Machine automation may check process invariants and metadata, but automation is not the source of architectural authority.

## Provenance invariant

Where consequential development produces an authoritative result, the project should be able to trace the relevant lineage:

```text
Discussion / Origin
    -> Issue / Question
    -> Research / Experiment
    -> Evidence
    -> Decision
    -> Specification / Contract
    -> Implementation
    -> Validation
    -> Authority
```

Not every path contains every node. Missing nodes are acceptable when they are not needed, but consequential authority must not lose the reasoning and evidence necessary to understand why it exists.

## Relationship to detailed protocols

The Issue Examination Protocol defines how claims and problems are examined.

The Issue Resolution Protocol defines how examined Issues are resolved, deferred, rejected, implemented, validated, reopened, or closed.

The Yellow and Red Issue Policy defines when consequential provisional or rejected work receives explicit Issue tracking.

The change gate operationalizes repository-level checks without replacing this governance model.
