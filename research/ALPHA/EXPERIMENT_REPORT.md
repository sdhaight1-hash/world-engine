# ALPHA Order / Transition Prototype v0.1

## Execution status

ALPHA-RO-001 reached `SUFFICIENT_FOR_SECOND_PROTOTYPE`.

## Implemented behaviors

The prototype tests a shared Order substrate across Research, Work, Investigation, Experiment, and Validation. It also exercises deterministic and threshold exit triggers, proposal/authorization separation, provenance, debugging investigations, virtual snapshot branching, and methodology self-monitoring.

## Findings

1. Orders can be represented as transition contracts.
2. Auditable transitions require reconstructable context, evidence, actor, authority, trigger, and lineage.
3. Exit detection can be automated for deterministic, threshold, invariant, and related machine-observable conditions. Semantic exits still require interpretation or policy.
4. Agents can propose transitions without possessing authorization to execute them.
5. Authorization should depend on risk, impact, reversibility, scope, and authority, not merely a flat role hierarchy.
6. Transition quality is measurable independently of final task success.
7. Retrospective bad-transition detection requires causal/reconstructive analysis, not simply checking whether the downstream outcome failed.
8. Order/report trajectories are potentially valuable training and evaluation data, subject to provenance and data-quality controls.
9. Exit criteria can be evaluated against downstream success.
10. Methodology degradation can generate a bounded methodology research order rather than silently self-modifying.
11. Debugging maps naturally onto Investigation → Experiment → Work → Validation, making debugging a specialized application of the generalized order/transition substrate.

## Architectural constraints exposed

- Detection and authorization must remain separate.
- Observability bounds what exit conditions and causal claims can be established.
- Evidence, Hypothesis, Snapshot, Verification, and Transition should eventually become first-class graph objects rather than incidental IDs.
- Authority should evolve from scalar levels to scoped capabilities and policy.
- Reproducible debugging requires capturing sufficient state, inputs, randomness, agent state, and order lineage.

## Generated next orders

- `ALPHA-WO-003`: Replace scalar authority levels with scoped capability/policy authorization.
- `ALPHA-WO-004`: Promote Evidence, Hypothesis, Snapshot, Verification, and Transition into first-class graph objects.
- `ALPHA-EX-001+`: Controlled experiments around unified order types, exit detection, authorization, transition quality, and virtual snapshot debugging.
