# World Engine Development Provenance

**Status:** GREEN
**Scope:** Development provenance requirements. This document does not define a final runtime provenance data model.

## Purpose

World Engine must preserve enough lineage to explain how consequential authoritative state was reached and to support reproducibility, review, debugging, and reconsideration.

## Core principle

> Provenance is part of the meaning of consequential development, not an administrative afterthought.

## Conceptual lineage

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

This is a possible lineage, not a mandatory sequence. Simple changes may omit stages that are not materially relevant.

## Required distinction

Provenance records **where a result came from**. It does not decide whether the result is authoritative.

Authority remains an explicit promotion decision.

## What should be traceable

For consequential changes, preserve links or identifiers for the applicable:

- originating discussion or rationale
- Issue or question
- research or experiment
- evidence and external references
- Decision
- Specification or Contract
- Order, when one was used
- Pull Request and implementation
- validation results
- final authority scope
- rejection, deferral, reopening, or supersession history

## Negative knowledge

Rejected approaches must remain traceable. Reopening a rejected approach creates new lineage rather than rewriting the original conclusion.

## Counterfactual and experimental work

Counterfactual, prototype, and experimental work must remain distinguishable from authoritative state. Its provenance should identify its parent context, scope, assumptions, and result without allowing the experiment to mutate the authority of its parent.

## AI-agent requirement

An AI agent promoting consequential work must preserve the lineage necessary for a later agent or human to answer:

1. What question or problem initiated this work?
2. What evidence supported the result?
3. What decision authorized the change?
4. What contract or invariant was affected?
5. What implementation produced the result?
6. What validation established correctness?
7. What authority was actually granted?

## Data-model boundary

This document establishes a provenance invariant, not a final schema.

A machine-readable provenance model should be researched and validated separately before becoming a runtime or repository-wide implementation requirement.
