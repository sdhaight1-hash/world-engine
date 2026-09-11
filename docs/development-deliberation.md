# World Engine Development Deliberation

**Status:** GREEN
**Scope:** Development governance only.

## Purpose

Discussion is the permissive deliberation function of World Engine development. It allows ideas to be explored before they are treated as consequential project work or authority.

## Core rule

> **Discussion is deliberation, not authority.**

Discussion may contain questions, hypotheses, speculative ideas, competing designs, objections, research leads, external references, implementation observations, negative evidence, and unresolved tensions.

## Where discussion occurs

Discussion is a process function, not a specific repository object.

It may occur through:

- the active ChatGPT project conversation;
- GitHub Discussions;
- other explicitly recognized collaborative deliberation channels.

For the AI-assisted World Engine workflow, the active ChatGPT project conversation is the primary deliberation medium because the available GitHub integration does not expose GitHub Discussion creation or management.

GitHub Discussions remain available for human repository-side deliberation, but the project process does not depend on them.

## Boundary to formal project status

Discussion becomes part of the formal development record when a consequential conclusion is captured in the appropriate repository artifact, such as an Issue, research record, Decision, Specification, Pull Request, validation record, or other explicitly authorized artifact.

Consensus in conversation does not itself create authority.

## Recommended anatomy for consequential discussion

When discussion is likely to become consequential, preserve as applicable:

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

## AI-agent rule

AI agents may use discussion to recover intent, context, alternatives, objections, research leads, and negative evidence.

AI agents must not treat conversational discussion as an implementation specification. Before making an authoritative change, an agent must identify the explicit Decision, Specification, Contract, or other authority that permits it.

## Deliberation flow

```text
Discussion
   -> consequential Issue, when needed
   -> Examination
   -> Research / Experiment / Direct Resolution
   -> Evidence
   -> Decision
   -> Specification / Contract
   -> Implementation
   -> Validation
   -> Authority
```

The flow is conceptual. Not every discussion requires every stage.

## First-principles test

Before promoting an idea out of discussion, ask:

1. What invariant are we preserving or establishing?
2. Who or what is authoritative?
3. Are capability and implementation separated?
4. What evidence supports the claim?
5. What remains uncertain?
6. What would falsify the claim?
7. Is the proposed change reversible?
8. Where is the resulting decision or contract recorded?
