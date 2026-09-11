# Architecture Status

## Scope

This document describes architectural promotion status. It does not replace the separate evidence-level, Issue-state, authority, or provenance dimensions defined by the development governance model.

## Green: established architecture

Green means a proposition, contract, or architectural principle is sufficiently established and validated for its stated promotion target.

Current Green principles:

- Authoritative state is distinct from representation.
- Runtime capabilities should be expressed as replaceable contracts rather than named algorithms.
- Research follows an explicit question -> evidence -> findings -> engineering implication -> decision -> specification -> implementation -> validation chain.
- Research provenance and implementation provenance are first-class concerns.
- Counterfactual execution must be isolated from parent authoritative state.
- Agent access must be mediated by an explicit authority/perception boundary.
- Storage and transport mechanisms are implementation concerns unless explicitly promoted by a Decision or Contract.
- Architectural decisions require explicit handoff into authoritative documentation.
- Development governance separates evidence, Issue state, promotion status, authority, and provenance.

## Yellow: provisional direction

Yellow means the material is unresolved, provisional, insufficiently evidenced, experimental, or otherwise not ready for architectural promotion.

Current Yellow directions:

- A representation/projection/bridge model for moving between world representations.
- Adaptive or goal-oriented representation selection.
- A latent world representation supporting abstract simulation and later reconciliation.
- Player-centered or observer-centered state collapse and reconstruction.
- Abstract Drift for away-time simulation.
- A JEPA-oriented agent/perception/reasoning stack.
- SpacetimeDB-like subscription semantics for reactive state delivery.
- Hadean-inspired spatial sharding and migration concepts.
- Voxel terrain generated from physical processes such as tectonics, climate, glaciation, erosion, temperature, and moisture.
- A mutable ECS as one possible execution model.

Yellow material requires appropriate research, experimentation, decision, or validation before becoming binding architecture.

## Red: rejected architecture

Red means sufficient evidence or an explicit decision establishes that the stated approach should not be promoted for its documented scope.

Examples of currently rejected or non-authoritative approaches include:

- treating a specific ML model family as a mandatory engine dependency without a World Engine-specific architectural basis;
- treating a specific database as the authoritative world-state mechanism without an explicit architectural decision;
- treating a specific distributed/sharding implementation as foundational architecture without sufficient validation;
- treating the proposed JEPA stack as already validated for the intended world simulation workload;
- treating a particular representation-switching algorithm as correct without the required experimental validation;
- making production-scale MMO capacity claims without measured implementation evidence.

Red items may still be researched or prototyped in isolation. Red preserves negative knowledge and must not be interpreted as a universal prohibition outside its documented scope.

## Important semantic rule

**Insufficient evidence is not rejection.**

When evidence is insufficient to establish a claim but does not establish that the approach should be rejected, the material remains Yellow.

## Promotion rules

```text
YELLOW -- sufficient evidence + decision/validation --> GREEN
YELLOW -- sufficient evidence for rejection ----------> RED
YELLOW -- unresolved ---------------------------------> YELLOW
RED    -- genuinely new evidence ---------------------> RECONSIDERATION
```

A status change must preserve the relevant provenance and must not erase earlier reasoning.

## Orthogonal dimensions

Do not infer any one of these from another:

- **Evidence:** E0-E6, describing evidence strength.
- **Issue state:** workflow state such as Open, Under Examination, Resolved, Deferred, Rejected, Superseded, or Reopened.
- **Green / Yellow / Red:** promotion or development disposition.
- **Authority:** explicit authorization within a defined scope.
- **Provenance:** lineage connecting origin, evidence, decision, implementation, and validation.

The purpose of this separation is to prevent a convenient status label from silently becoming architectural authority.
