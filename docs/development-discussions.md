# World Engine Development Discussions

## Purpose

GitHub Discussions are the permissive deliberation layer of the World Engine development process. They provide a place to explore ideas before they become formal research, proposals, experiments, decisions, or implementation.

## Core rule

> Discussion is deliberation, not authority.

A Discussion does not become authoritative because it exists, receives agreement, or is widely discussed. Architectural authority requires explicit validation and promotion.

## What belongs in Discussions

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

Discussions should be allowed to be messy. Exploration should not require premature formalization.

## Epistemic flow

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

Not every Discussion needs to complete the entire flow. It may simply be closed with no action, or preserved as negative evidence.

## Promotion rules

A Discussion may generate:

- a research topic
- a candidate proposal
- an experiment
- a decision candidate
- a specification
- negative evidence
- no further action

Promotion must preserve relevant reasoning, evidence, assumptions, uncertainty, and provenance.

## Authority boundaries

| Source | Role | Authority |
|---|---|---|
| Discussion | Deliberation | None by itself |
| Research | Evidence and analysis | Non-authoritative unless explicitly promoted |
| Proposal | Candidate design | Non-authoritative until accepted |
| Experiment | Feasibility evidence | Non-authoritative until accepted |
| Decision | Explicit project decision | Authoritative when designated so |
| Specification | Contract | Authoritative |
| Validated implementation | Realized system behavior | Authoritative within its contract |

The Green / Yellow / Red gate applies when material is promoted into the formal repository process.

## Green / Yellow / Red relationship

- **GREEN:** sufficiently established for authoritative implementation or permanent project documentation.
- **YELLOW:** worth preserving, but provisional and non-authoritative.
- **RED:** rejected or insufficient for authority, but potentially valuable as negative evidence or historical reasoning.

A Discussion can contribute evidence to a Green decision. It cannot itself confer Green status.

## AI implementation-agent rule

AI agents may mine Discussions for intent, context, research leads, objections, failed approaches, and alternative designs.

AI agents must not treat a Discussion as an implementation specification. Before making an authoritative change, an agent must identify the explicit contract, decision, or specification that grants authority.

## Recommended Discussion anatomy

When a Discussion is likely to become consequential, capture:

1. Question or problem
2. Current understanding
3. Hypotheses or candidate approaches
4. Evidence and references
5. Objections and failure modes
6. Experiments needed
7. Open uncertainty
8. Proposed next step
9. Promotion target, if any

This is guidance, not a mandatory form. The purpose of Discussions is to make exploration easier, not bureaucratic.

## First-principles test

Before promoting an idea out of Discussion, ask:

1. What invariant are we trying to preserve or establish?
2. Who or what is authoritative?
3. Are we distinguishing capability from implementation?
4. What evidence supports the claim?
5. What remains uncertain?
6. What would falsify the claim?
7. Is the proposed change reversible?
8. Where is the resulting decision or contract recorded?
