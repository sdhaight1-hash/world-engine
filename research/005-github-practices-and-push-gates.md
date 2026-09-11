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

Every consequential authoritative architectural change should be traceable to its evidence, decision, implementation, and validation.

## 3. Evidence pipeline

```text
Question
  -> Research / Experiment / Direct Resolution
  -> Evidence
  -> Evaluation
  -> Decision
  -> Specification
  -> Implementation
  -> Validation
  -> Authority
```

Research and experiments are activities that produce evidence. They are not mandatory stages for every change.

## 4. Gate states

### GREEN: established

Green material is sufficiently established and validated for its stated promotion target.

### YELLOW: provisional

Yellow material is unresolved, provisional, insufficiently evidenced, experimental, or otherwise not ready for promotion.

### RED: rejected

Red material has sufficient evidence or an explicit decision establishing that the approach should not be promoted for its stated scope. Red is preserved as negative knowledge.

**Insufficient evidence is not, by itself, Red. It is normally Yellow.**

## 5. Repository admission is not architectural truth

A material can exist in GitHub without being authoritative architecture.

Status must be explicit and must not be inferred from location, filename, commit existence, or implementation completeness.

## 6. Evidence levels

Use the following evidence scale when evaluating consequential claims:

- **E0: Speculation**
- **E1: Literature / external evidence**
- **E2: Reasoned architectural analysis**
- **E3: Prototype**
- **E4: Controlled experiment**
- **E5: Reproducible validation**
- **E6: Integrated validation**

Evidence level does not automatically determine Green, Yellow, Red, Issue state, or authority.

## 7. Orthogonal dimensions

The governance model separates:

- evidence level
- Issue workflow state
- Green / Yellow / Red promotion disposition
- explicit authority
- provenance

Do not collapse these into one status machine.

## 8. Promotion lifecycle

```text
YELLOW
  |\
  | \ sufficient evidence / validation + decision
  |  -> GREEN
  |
  | sufficient evidence for rejection
  v
 RED

Unresolved evidence keeps the item YELLOW.

RED -> reconsideration is possible when genuinely new evidence changes the premises.
```

## 9. Pull request gate

Meaningful changes should be evaluated as focused changes, preferably through a pull request or equivalent review record.

Recommended fields:

```text
Status: GREEN / YELLOW / RED
Evidence: E0-E6
Risk: LOW / MEDIUM / HIGH
Impact: LOW / MEDIUM / HIGH
Reversibility: HIGH / MEDIUM / LOW
Authority: AUTHORITATIVE / NON-AUTHORITATIVE

Purpose
Evidence
Invariants affected
Assumptions
Validation
Documentation
Remaining uncertainty
Proposed disposition
```

These fields support review. They do not replace the underlying governance model.

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

## 11. Documentation coupling

When a change affects an architectural invariant, authority boundary, lifecycle, public API, persistence semantics, agent permissions, experiment methodology, or reproducibility, documentation is part of the change.

## 12. AI implementation-agent rule

AI implementation agents must not treat Yellow or Red material as architectural authority.

The agent should identify the authoritative contract before implementing a research proposal.

## 13. Repository organization

The repository may grow toward separate architecture, contracts, decisions, implementation, operations, research, proposals, source, tests, tools, and GitHub automation areas. This remains a target structure, not a requirement to create empty directories.

## 14. Main-branch policy

`main` is the authoritative repository branch. Protect it with appropriate review and validation controls as the project matures.

## 15. Security and dependency checks

Security, supply-chain, dependency, and validation concerns are part of the Green evaluation where applicable. A change is not Green merely because it compiles.

## 16. First-principles rule

> Define the invariant. Identify the authority. Separate capability from implementation. Preserve provenance.

## 17. Governance decision addendum

Subsequent governance analysis established the following refinements to the original gate vocabulary:

1. Green / Yellow / Red is a promotion and development-disposition dimension, not a universal state machine.
2. Evidence strength is represented independently by E0-E6.
3. Issue workflow state is independent of promotion status.
4. Authority is explicit and scoped.
5. Insufficient evidence remains Yellow unless evidence establishes rejection.
6. Research, Experiment, and Implementation are activities. Optional Orders may delegate bounded activities but are not mandatory process stages.
7. Discussion is a process function and is not dependent on a particular GitHub object.

These refinements preserve the original decision to use an explicit gate while removing semantic collisions identified during later examination.
