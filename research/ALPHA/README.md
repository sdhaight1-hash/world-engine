# ALPHA Order / Transition Prototype

This directory contains the first executable implementation of the ALPHA research findings: Orders, exit triggers, transition proposals and authorization, reports, provenance, debugging investigations, and virtual branch experiments.

## Status

ALPHA-RO-001 reached `SUFFICIENT_FOR_SECOND_PROTOTYPE` after the first implementation and controlled experiment pass.

## Research scope

- ALPHA-RQ01: Order as a state-transition contract
- ALPHA-RQ02: Minimum auditable transition information
- ALPHA-RQ03: Automatic exit-trigger detection
- ALPHA-RQ04: Proposal vs authorization
- ALPHA-RQ05: Risk/reversibility-based authorization
- ALPHA-RQ06: Transition-quality evaluation
- ALPHA-RQ07: Retrospective bad-transition detection
- ALPHA-RQ08: Order/report lineage as training data
- ALPHA-RQ09: Predictive exit criteria
- ALPHA-RQ10: Methodology self-monitoring
- ALPHA-RQ11: Debugging and the Order/Transition model

## Prototype principle

> Observe → Form Order → Execute → Produce Evidence → Detect Exit Trigger → Report → Evaluate Transition → Create Next Order

The implementation is deliberately a prototype. It is not yet engine law.

## Next generated work

- ALPHA-WO-003: Replace scalar authority levels with scoped capability/policy authorization.
- ALPHA-WO-004: Promote Evidence, Hypothesis, Snapshot, Verification, and Transition into first-class graph objects.
- ALPHA-EX-001+: Controlled experiments around unified order types, exit detection, authorization, transition quality, and virtual snapshot debugging.
