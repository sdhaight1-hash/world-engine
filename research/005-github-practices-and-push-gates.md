# Research Topic 005: GitHub Practices and the Green / Yellow / Red Push Gate

**Status:** GREEN
**Research ID:** 005
**Type:** Development process / repository governance
**Decision:** Adopt a formal Green / Yellow / Red admission and promotion gate for World Engine.
**Authority:** Development-process architecture, not runtime architecture.

## 1. Purpose

Define how research, proposals, experiments, documentation, and implementation become part of the authoritative World Engine repository without allowing speculation or provisional ideas to silently become architecture.

## 2. Core principle

Nothing becomes authoritative merely because it has been discussed, researched, implemented, or committed.

Authority is granted through an explicit validation and promotion decision.

Every authoritative architectural change should be traceable to its evidence, decision, implementation, and validation.

## 3. Evidence pipeline

```text
Question
  -> Research
  -> Hypothesis
  -> Evidence
  -> Experiment
  -> Evaluation
  -> Decision
  -> Specification
  -> Implementation
  -> Validation
  -> Authority
```

Research can establish plausibility. Experiments establish feasibility. Integration establishes architectural validity.

## 4. Gate states

### GREEN: Accepted

Green material is sufficiently established for authoritative implementation or permanent project documentation.

Typical criteria:

- purpose is explicit
- affected architectural boundary is known
- established invariants are preserved
- dependencies and assumptions are understood
- required validation exists or is appropriate to the claim
- documentation is updated when architecture changes
- provenance/evidence is recorded where applicable
- no unresolved high-risk assumption is silently promoted
- the change is reasonably reversible
- the change is reviewable as a focused unit

**Disposition:** merge / authoritative.

### YELLOW: Provisional

Yellow material is worth preserving but is not authoritative architecture.

Typical examples:

- architectural hypotheses
- research findings needing validation
- candidate implementations
- untested performance assumptions
- alternative designs
- experimental algorithms
- uncertain dependencies

Yellow material must be explicitly marked provisional, state its uncertainty and assumptions, define validation criteria, and identify a path toward Green or Red.

**Disposition:** document / experiment / prototype.

### RED: Rejected or insufficient

Red material must not enter authoritative architecture.

Reasons may include:

- violation of an established invariant
- inadequate evidence for architectural impact
- unacceptable coupling
- falsified central assumption
- inability to validate the claim
- unacceptable security or supply-chain risk
- premature optimization or premature architecture
- speculative implementation presented as established design

Red material may still be preserved as negative evidence or historical record.

**Disposition:** reject / quarantine / record.

## 5. Repository admission is not architectural truth

A useful distinction is:

| State | May exist in GitHub | Authoritative architecture |
|---|---:|---:|
| Green | Yes | Yes |
| Yellow | Yes, controlled and explicit | No |
| Red | Possibly, explicitly quarantined | No |
| Unclassified | No | No |

A committed artifact is not authoritative merely because it exists in the repository.

Status must be explicit and must not be inferred from location, filename, commit existence, or implementation completeness.

## 6. Evidence levels

Use the following evidence scale when evaluating consequential claims:

- **E0: Speculation** — unsupported hypothesis. Never Green by itself.
- **E1: Literature / external evidence** — others have demonstrated something related. Usually Yellow.
- **E2: Reasoned architectural analysis** — explicit reasoning under stated assumptions. May support low-risk Green documentation, otherwise Yellow.
- **E3: Prototype** — working implementation demonstrates feasibility. Normally Yellow.
- **E4: Controlled experiment** — defined hypothesis tested under defined conditions.
- **E5: Reproducible validation** — result can be independently reproduced and meets acceptance criteria.
- **E6: Integrated validation** — result works within World Engine while preserving architectural invariants.

Evidence level does not automatically determine status. Risk, impact, reversibility, and architectural authority must also be considered.

## 7. Confidence and risk are separate

Do not collapse confidence and risk into one score.

Examples:

- high confidence + high risk: known requirement with large architectural blast radius
- low confidence + low risk: isolated experiment
- low confidence + high risk: candidate architecture requiring strong evidence before adoption

Minimum useful gate dimensions are:

- confidence
- risk
- impact
- reversibility
- evidence level
- architectural authority

## 8. Yellow promotion lifecycle

Yellow is not a permanent junk drawer.

```text
YELLOW
  |\
  | \ evidence improves
  |  -> GREEN
  |
  | evidence fails
  v
 RED

Unresolved evidence keeps the item YELLOW.
```

A research item should record its promotion target and validation requirements.

## 9. Pull request gate

Meaningful changes should be evaluated as focused changes, preferably through a pull request or equivalent review record.

Recommended PR fields:

```text
## Gate
Status: GREEN / YELLOW / RED
Evidence: E0-E6
Risk: LOW / MEDIUM / HIGH
Impact: LOW / MEDIUM / HIGH
Reversibility: HIGH / MEDIUM / LOW
Authority: AUTHORITATIVE / NON-AUTHORITATIVE

## Purpose

## Evidence

## Invariants affected

## Assumptions

## Validation

## Documentation

## Remaining uncertainty

## Proposed disposition
MERGE / DOCUMENT / EXPERIMENT / REJECT
```

## 10. Commit taxonomy

Use focused, searchable commit types where useful:

```text
feat(scope): description
fix(scope): description
docs(scope): description
research(scope): description
experiment(scope): description
test(scope): description
refactor(scope): description
decision(scope): description
revert(scope): description
```

The taxonomy is a convention, not a substitute for the gate.

Prefer commits that express one meaningful architectural or implementation claim over large undifferentiated commits.

## 11. Documentation coupling

When a change affects an architectural invariant, authority boundary, lifecycle, public API, persistence semantics, agent permissions, experiment methodology, or reproducibility, documentation is part of the change.

Documentation should not be deferred as unrelated cleanup when the change alters what the system means.

## 12. AI implementation-agent rule

AI implementation agents must not treat Yellow or Red material as architectural authority.

The agent should identify the authoritative contract before implementing a research proposal.

This prevents the following failure mode:

```text
AI generates plausible idea
  -> idea enters research
  -> agent mistakes research for specification
  -> implementation occurs
  -> documentation describes implementation
  -> speculation becomes apparent architecture
```

The gate exists specifically to prevent this epistemic drift.

## 13. Recommended repository organization

Target structure:

```text
world-engine/
├── README.md
├── docs/
│   ├── architecture/
│   ├── contracts/
│   ├── decisions/
│   ├── implementation/
│   └── operations/
├── research/
│   ├── active/
│   ├── completed/
│   ├── experiments/
│   └── rejected/
├── proposals/
├── src/
├── tests/
├── tools/
└── .github/
    ├── pull_request_template.md
    ├── CODEOWNERS
    ├── workflows/
    └── ISSUE_TEMPLATE/
```

This is a target, not a requirement to create all directories immediately.

## 14. Main-branch policy

`main` is the authoritative branch.

As the project matures, protect `main` with appropriate controls such as required review, required validation checks, no force pushes, and no branch deletion.

The repository should enforce the principle that authoritative state cannot be changed casually.

## 15. Security and dependency checks

Security and supply-chain concerns are part of the Green gate. Where available, use repository automation for secret detection, push protection, dependency review, and validation checks.

A change is not Green merely because it compiles.

## 16. First-principles rule

The World Engine development process follows:

> Define the invariant. Identify the authority. Separate capability from implementation. Preserve provenance.

The Green / Yellow / Red gate operationalizes that rule for repository changes.

## 17. Decision

**GREEN: Adopt as World Engine development-process architecture.**

The system should be implemented incrementally. The first practical repository additions should be the gate definition itself, a pull-request template, and machine-readable status conventions. Automated enforcement should be added after the conventions have been exercised against real changes.

## 18. References

- GitHub documentation: managing and standardizing pull requests, branch protection/rulesets, security and dependency review.
- Git documentation: branching workflows and rebasing/history management.
- Google Engineering Practices: code review standards, review checklist, and small change guidance.
- Conventional Commits specification.

These references inform the process but do not override World Engine's own architectural principles. External practice establishes precedent; World Engine's invariants determine applicability.
