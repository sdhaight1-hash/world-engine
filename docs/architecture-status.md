# Architecture Status

## Green: safe to establish now

These are architectural principles and documentation structures that do not require committing to a particular implementation technology.

- Authoritative state is distinct from representation.
- Runtime capabilities should be expressed as replaceable contracts rather than named algorithms.
- Research follows an explicit question -> evidence -> findings -> engineering implication -> decision -> specification -> implementation -> validation chain.
- Research provenance and implementation provenance are first-class concerns.
- Counterfactual execution must be isolated from parent authoritative state.
- Agent access must be mediated by an explicit authority/perception boundary.
- Storage and transport mechanisms are implementation concerns unless explicitly promoted by an ADR.
- Architectural decisions require explicit ADR handoff.

## Yellow: useful direction, not yet a production contract

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

Yellow items require experiments, benchmarks, or ADRs before they become binding contracts.

## Red: do not commit as architecture yet

- A specific ML model family as a mandatory engine dependency.
- A specific database as the authoritative world-state mechanism.
- A specific distributed/sharding implementation as foundational architecture.
- A claim that the proposed JEPA stack is already validated for the intended world simulation workload.
- A claim that a particular representation-switching algorithm provides sufficient correctness or error guarantees without experimental validation.
- Production-scale MMO capacity claims before measured implementation evidence exists.

Red items may be researched or prototyped in isolated experiments, but must not be represented as settled architecture.

## Promotion rule

Yellow becomes green only when the relevant invariant, contract, evidence, and validation criteria are explicit. Red becomes yellow when a falsifiable research question and bounded experiment exist. Neither transition should occur merely because an approach is attractive or technically fashionable.
