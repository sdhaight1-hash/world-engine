# Research Topic 005 Addendum: GitHub Discussions as a Deliberation Layer

**Status:** GREEN
**Parent:** Research Topic 005, GitHub Practices and the Green / Yellow / Red Push Gate
**Decision:** Adopt GitHub Discussions as the permissive deliberation layer of the World Engine development process.
**Authority:** Development-process architecture, not runtime architecture.

## Core rule

> Discussion is deliberation, not authority.

A Discussion may generate evidence, a research topic, a proposal, an experiment, a decision candidate, or negative evidence. Its existence, popularity, or apparent consensus does not grant architectural authority.

## Process

```text
Discussion
  -> Question / Hypothesis / Concern
  -> Research
  -> Evidence
  -> Experiment
  -> Evaluation
  -> Decision
  -> Specification
  -> Implementation
  -> Validation
  -> Authority
```

Not every Discussion must progress through every stage. It may be closed with no action or retained as negative evidence.

## Allowed Discussion material

- questions and open problems
- architectural hypotheses
- speculative ideas
- competing designs
- objections and challenges
- research leads
- external references
- implementation observations
- negative evidence
- unresolved design tensions

Discussions should remain permissive. Formalization belongs at the point where an idea becomes consequential.

## Authority boundary

| Source | Role | Authority |
|---|---|---|
| Discussion | Deliberation | None by itself |
| Research | Evidence and analysis | Non-authoritative unless explicitly promoted |
| Proposal | Candidate design | Non-authoritative until accepted |
| Experiment | Feasibility evidence | Non-authoritative until accepted |
| Decision | Explicit project decision | Authoritative when designated so |
| Specification | Contract | Authoritative |
| Validated implementation | Realized behavior | Authoritative within its contract |

## Green / Yellow / Red

- **GREEN:** sufficiently established for authoritative implementation or permanent project documentation.
- **YELLOW:** worth preserving but provisional and non-authoritative.
- **RED:** rejected or insufficient for authority, while potentially useful as negative evidence.

A Discussion can contribute to a Green decision, but cannot itself confer Green status.

## AI implementation-agent rule

AI agents may mine Discussions for intent, context, research leads, objections, failed approaches, and alternatives.

AI agents must not treat Discussions as implementation specifications. Before making an authoritative change, the agent must identify the explicit Decision or Specification that grants authority.

## Recommended Discussion anatomy

When a Discussion becomes consequential, capture:

1. Question or problem
2. Current understanding
3. Hypotheses or candidate approaches
4. Evidence and references
5. Objections and failure modes
6. Experiments needed
7. Open uncertainty
8. Proposed next step
9. Promotion target, if any

This is guidance, not a mandatory form.

## First-principles test

Before promoting an idea out of Discussion:

1. What invariant are we preserving or establishing?
2. Who or what is authoritative?
3. Are capability and implementation separated?
4. What evidence supports the claim?
5. What remains uncertain?
6. What would falsify the claim?
7. Is the proposed change reversible?
8. Where is the resulting decision or contract recorded?
