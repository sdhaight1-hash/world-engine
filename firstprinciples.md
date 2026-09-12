# World Engine: First Principles

**Status:** PRELIMINARY / NON-AUTHORITATIVE
**Purpose:** Establish a first-principles description of what World Engine must be before committing to particular technologies, algorithms, data structures, or machine-learning architectures.
**Scope:** Foundational conceptual architecture.

> **This document is a working synthesis, not a final architecture specification. It records principles and deductions that should constrain future research and design. A principle becomes authoritative only through the project's normal decision, specification, and validation process.**

---

## 1. Why First Principles

World Engine has accumulated ideas from several domains: game engines, persistent worlds, distributed simulation, procedural world generation, databases, AI agents, world models, and experimental research.

The danger is allowing the implementation vocabulary of one domain to become the architecture of the whole system.

The project therefore begins from a simpler question:

> **What must be true of a system whose purpose is to maintain and expose a persistent, spatially grounded world in which processes, agents, representations, computation, and experiments can operate?**

The repository already establishes a related development rule:

> Define the invariant. Identify the authority. Separate capability from implementation. Preserve provenance.

This document applies that rule to the system itself.

---

# 2. First Principle: A World Is a State That Changes

A world simulation requires some state that represents the condition of the world and some process by which that state changes.

At minimum:

```text
World State
    +
Transition / Process
    +
Time
    =
Evolving World
```

A rendered scene is not sufficient. A database record is not sufficient. A machine-learning latent is not sufficient. A procedural generator is not sufficient.

Each may represent, store, approximate, observe, or transform world state, but none is automatically identical to the world itself.

### Deduction

World Engine should distinguish:

```text
WORLD STATE
    what is true within the simulated world

PROCESS
    how state is allowed to change

REPRESENTATION
    how state is encoded or viewed

OBSERVATION
    what a particular observer can obtain from state

COMPUTATION
    what can be derived from state
```

These distinctions already appear in the repository's architectural status: authoritative world state is distinct from representation, and storage is not automatically world authority.

---

# 3. First Principle: Authority Must Have a Single Meaning at Each Scope

If two systems can independently declare contradictory facts about the same authoritative quantity, the world has no well-defined truth.

Therefore, for every authoritative fact or transition, there must be an identifiable authority within the relevant scope.

This does **not** imply one physical server, one database, or one process.

Authority is a semantic property before it is an implementation property.

```text
Who can establish this fact?
        ↓
What scope does that authority cover?
        ↓
What evidence or transition establishes it?
        ↓
Who is allowed to observe or modify it?
```

### Deduction

World Engine must not make the following substitutions without an explicit decision:

```text
Database       = world authority
Server         = world authority
Client         = world authority
AI model       = world authority
Renderer       = world authority
Cache          = world authority
Storage format = world authority
```

A storage or execution technology may implement authority, but it does not receive authority merely by being selected.

---

# 4. First Principle: Representation Is Not Reality

The same world state can have many useful representations.

Examples include:

```text
exact state
spatial index
voxel representation
mesh
physics representation
agent-local scene
statistical summary
latent representation
historical snapshot
counterfactual branch
rendered image
```

A representation exists for some purpose. Its usefulness depends on the information required by that purpose.

This follows directly from the basic simulation distinction between a modeled system and any particular implementation of that model. IEEE's High Level Architecture likewise treats simulations as abstractions and is designed to allow different simulation implementations to interoperate rather than requiring one implementation to solve every need.

### Deduction

World Engine should make representation an explicit boundary rather than allowing an implementation representation to silently become authoritative state.

The repository currently treats representation/projection/bridge work as Yellow, which is appropriate. The principle is stronger than any particular representation mechanism.

---

# 5. First Principle: Observation Is a Projection of the World

An observer cannot necessarily access the complete world state.

An observation is produced from world state through some combination of:

```text
World State
    ↓
Authority / Access Policy
    ↓
Observation / Projection
    ↓
Observer State
```

Different observers can therefore possess different information about the same world without requiring multiple contradictory worlds.

This is fundamental for agents, clients, debugging tools, experiments, and human interfaces.

### Deduction

The system should distinguish at least:

```text
WORLD TRUTH
OBSERVATION
BELIEF / INTERNAL MODEL
PRESENTATION
```

An agent's belief about the world must not silently overwrite world truth merely because the agent believes it.

The repository already identifies explicit authority/perception boundaries as Green, while observer-centered collapse and reconstruction remain Yellow.

---

# 6. First Principle: Causality Matters More Than Snapshots

A persistent world is not merely a sequence of disconnected states. Meaningful simulation depends on changes having causes.

A useful conceptual model is:

```text
State(t)
   ↓
Allowed Transition
   ↓
State(t + Δt)
```

For consequential transitions, the system should be able to answer, as appropriate:

```text
What changed?
Why did it change?
What caused the change?
What authority permitted it?
What evidence existed at the time?
What prior state was involved?
```

The ALPHA prototype provides empirical support for treating Orders as transition contracts and for recording reconstructable context, evidence, actor, authority, trigger, and lineage.

### Deduction

A world engine should preserve causal/provenance information for transitions whose reconstruction, debugging, explanation, validation, or future research materially depends on it.

This does not mean every low-level operation must become a permanent event log. The required granularity remains an engineering question.

---

# 7. First Principle: Time Is Part of World State Semantics

A world that persists has a temporal dimension.

There is a meaningful distinction between:

```text
world time
execution time
observation time
storage time
render time
```

They may advance together in a simple implementation, but they are conceptually different quantities.

### Deduction

The engine must eventually define:

- what constitutes a world-time transition;
- what happens when computation is delayed;
- whether processes may advance without an observer present;
- how historical states are identified;
- how branches and counterfactuals relate to temporal state;
- how reproducible execution represents time-dependent randomness and scheduling.

The project's Abstract Drift and away-time simulation ideas are therefore mechanisms to investigate, not first principles themselves.

---

# 8. First Principle: Space Is Part of Causality

For a spatial world, location is not merely a rendering coordinate.

Distance, adjacency, containment, visibility, topology, locality, and movement can affect what can interact with what and how quickly information or physical influence propagates.

Therefore:

```text
Spatial Relationship
        ↓
Possible Interaction
        ↓
Causal Consequence
```

### Deduction

Spatial partitioning should ultimately serve the semantics of the simulated world rather than being chosen solely because a particular rendering or networking implementation prefers it.

This provides a first-principles reason to investigate spatial sharding, locality, and migration, while not assuming that Hadean-style sharding or any other particular scheme is correct.

---

# 9. First Principle: Computation Is a Transformation, Not Authority

A computation consumes information and produces a result.

```text
Inputs
  ↓
Algorithm
  ↓
Result
```

The result can be:

```text
authoritative transition
projection
prediction
estimate
classification
hypothesis
rendering data
experimental measurement
```

The algorithm itself does not determine which category the result belongs to.

### Deduction

World Engine should specify **capabilities** and their contracts where possible, rather than making a particular algorithm part of the foundational architecture.

For example:

```text
Error Estimation
    ≠
DWR

World Representation
    ≠
Voxel Grid

World Model
    ≠
JEPA

Persistence
    ≠
SpacetimeDB
```

A named technique can implement a capability without becoming the capability's definition.

---

# 10. First Principle: Approximation Must Be Goal-Relative

A representation is neither simply "accurate" nor "inaccurate" in the abstract.

Accuracy is relative to:

```text
quantity of interest
observer
spatial scale
temporal scale
allowed error
computational budget
consequence of error
```

This is a first-principles reason to investigate adaptive and goal-oriented representation selection.

It does **not** establish a particular error estimator or representation-switching algorithm.

### Deduction

Future runtime contracts may need to express something like:

```text
Representation Request
{
    subject
    purpose
    required quantities
    spatial scope
    temporal scope
    error tolerance
    latency / compute budget
}
```

Whether this exact schema is appropriate remains a research question.

---

# 11. First Principle: Agents Are Participants, Not the World

An agent exists within the world and acts upon it through permitted interfaces.

Conceptually:

```text
World
  ↓
Observation
  ↓
Agent State / Belief
  ↓
Decision
  ↓
Action Proposal
  ↓
Authorization / Validation
  ↓
World Transition
```

An agent should not be granted world authority merely because it can predict, reason, or produce an action.

This applies equally to human players and AI agents.

### Deduction

The architecture should preserve a boundary between:

```text
perception
belief
reasoning
proposal
authorization
execution
```

The ALPHA prototype provides direct experimental evidence for separating proposal from authorization and for moving toward scoped capability/policy authorization rather than a flat authority hierarchy.

---

# 12. First Principle: Prediction Is Not Simulation

A predictive model can estimate what is likely to happen without itself being the authority that determines what happens.

Likewise, a learned latent representation can capture useful regularities without containing every quantity required by an authoritative simulation.

This distinction is especially important for the project's JEPA/world-model research.

Current research demonstrates that V-JEPA 2 can learn representations useful for visual understanding and prediction, and that an action-conditioned V-JEPA 2 model can support robot planning. Those results establish useful evidence for learned predictive representations, not evidence that a JEPA model is sufficient to serve as World Engine's authoritative physical world.

### Deduction

The project should treat learned world models as candidate **predictive or inferential capabilities** until experiments establish stronger guarantees for a particular World Engine workload.

---

# 13. First Principle: Persistence Means Continuity, Not Merely Storage

A persistent world must maintain continuity of world identity and state across execution boundaries.

Persistence therefore includes more than writing bytes to disk.

A persistence mechanism must eventually answer:

```text
What state is being persisted?
When was it valid?
What transitions produced it?
Can it be recovered?
Can its identity be reconstructed?
Can its history be audited where required?
```

### Deduction

Storage technology is subordinate to persistence semantics.

SpacetimeDB is relevant because its architecture demonstrates a useful combination of in-memory state, durable commit logging, server-side logic, and real-time subscriptions. Its subscription model also demonstrates how a client can maintain a local mirror of selected server state.

Those are candidate mechanisms, not reasons to make SpacetimeDB foundational.

---

# 14. First Principle: Counterfactuals Must Be Isolated From Authority

A counterfactual asks:

> What would happen if the world were changed or acted upon under different conditions?

If the experiment modifies authoritative state, the distinction between reality and hypothesis is destroyed.

Therefore:

```text
Authoritative State
        ↓
Snapshot / Branch
        ↓
Counterfactual Execution
        ↓
Observation / Result
        ↓
Discard, Compare, or Explicitly Promote
```

A counterfactual result cannot silently become a real-world transition.

### Deduction

Snapshotting, branching, reconciliation, and virtual-world debugging are natural research areas, but the isolation invariant itself should remain independent of their implementation.

---

# 15. First Principle: Uncertainty Must Remain Visible

The system will contain different kinds of uncertainty:

```text
unknown world state
measurement uncertainty
model uncertainty
prediction uncertainty
incomplete observation
implementation uncertainty
architectural uncertainty
```

Collapsing all of these into a single value such as "unknown" or "confidence" loses information.

### Deduction

The engine and development process should preserve uncertainty explicitly where it affects decisions.

This aligns with the repository's Yellow status: insufficient evidence is not rejection. Uncertainty is a state to manage, not something to hide.

---

# 16. First Principle: Reproducibility Is a System Property

If two executions purport to represent the same experiment or authoritative process, we need a defined answer to whether they should produce the same result.

Reproducibility can require control of:

```text
initial state
inputs
randomness
ordering
time
configuration
algorithm version
model version
environment
external dependencies
```

Not every runtime workload requires bit-for-bit determinism. The required reproducibility level must instead be defined by the purpose of the execution.

### Deduction

The system should distinguish:

```text
replayable
reproducible
statistically reproducible
approximately equivalent
non-reproducible
```

The correct target is a contract question, not an implementation assumption.

---

# 17. First Principle: Observation and Simulation Need Not Run at the Same Resolution

A world can contain processes operating at different spatial and temporal scales.

For example:

```text
planetary climate
    ↓
regional weather
    ↓
local terrain
    ↓
individual object
    ↓
agent interaction
```

The computational representation appropriate to one scale may be wasteful or insufficient at another.

### Deduction

Multiscale simulation and adaptive resolution are legitimate consequences of the problem domain.

However, the existence of multiple scales does not prove that a particular hierarchy, voxel scheme, latent representation, or switching algorithm should be used.

The repository therefore correctly keeps adaptive representation selection and related mechanisms Yellow pending evidence.

---

# 18. First Principle: Complexity Should Be Paid Only Where It Changes Outcomes

A persistent world can contain vastly more information than any one observer needs at one moment.

Therefore the engine should avoid computing, storing, transmitting, or rendering information merely because it exists conceptually.

The relevant question is:

> **What information must be maintained or computed to preserve the required world invariants and answer the required queries?**

### Deduction

Optimization should follow causal and informational necessity rather than premature assumptions about scale.

This is one reason the project's future distributed architecture should be derived from workload, locality, authority, and consistency requirements rather than beginning with a claim such as "the world must support N players."

---

# 19. First Principle: Distribution Is an Implementation of a Semantic World

A distributed world is still one logical world if its partitions cooperate to preserve the required semantics.

Therefore the primary problem is not:

> How do we distribute the server?

It is:

> **What invariants must remain true when computation and state are partitioned?**

Potential invariants include:

```text
authority remains unambiguous
causal ordering is preserved where required
cross-boundary interactions remain valid
state migration does not duplicate authority
observers receive valid projections
failure does not silently corrupt world state
```

IEEE HLA provides established evidence that distributed simulations can be organized around explicit responsibilities and interoperability rules. That supports investigating distributed simulation as a relevant field, but it does not dictate World Engine's runtime architecture.

---

# 20. First Principle: Data Layout Serves Computation

The project currently considers a mutable ECS as one possible execution model.

ECS and data-oriented designs can provide useful separation between data and processing and can improve locality and scalability for suitable workloads. Modern engines such as Unity explicitly use data-oriented technology and ECS to target large-scale processing.

But ECS is a means, not a first principle.

### Deduction

The first-principles requirement is:

> World state must be representable and processable in a way that permits the required computations, queries, transitions, and locality constraints.

Whether that is best implemented as ECS, relational tables, graphs, archetypes, structures of arrays, or another representation depends on measured workload and contract requirements.

---

# 21. First Principle: The Engine Should Be Defined by Invariants and Capabilities

A durable architecture should specify what must be true and what the system can guarantee.

It should avoid specifying how every guarantee is implemented.

Therefore the architecture should trend toward:

```text
INVARIANT
    ↓
CAPABILITY
    ↓
CONTRACT
    ↓
IMPLEMENTATION
```

rather than:

```text
TECHNOLOGY
    ↓
ARCHITECTURE
    ↓
EVERYTHING ELSE
```

This principle is already Green in the repository: runtime capabilities should be expressed as replaceable contracts rather than named algorithms.

---

# 22. First Principle: Development Knowledge Is Part of the System's Long-Term Integrity

World Engine is intended to be developed over a long period by both humans and AI agents.

A future developer must be able to determine not merely what exists, but why it exists.

Therefore consequential development requires recoverable lineage:

```text
Origin
  ↓
Question / Issue
  ↓
Research / Experiment
  ↓
Evidence
  ↓
Decision
  ↓
Specification / Contract
  ↓
Implementation
  ↓
Validation
  ↓
Authority
```

The repository's research and governance documents explicitly establish this separation and require provenance to preserve the relevant lineage.

### Deduction

Documentation is not merely explanatory prose. For consequential architecture, it is part of the mechanism by which the project preserves institutional memory and prevents an implementation accident from becoming an undocumented law.

---

# 23. First Principle: Research Must Be Able to Falsify the Architecture

Research is useful only if the architecture can be changed when evidence demonstrates that an assumption is wrong.

Therefore:

```text
Principle
   ↓
Hypothesis
   ↓
Experiment
   ↓
Result
   ↓
Promotion / Rejection / Revision
```

A research system that can only confirm existing architecture is not a research system. It is a justification system.

The project's Green / Yellow / Red model is useful precisely because it preserves provisional work and negative knowledge separately from authority.

---

# 24. Preliminary World Engine Model

The first-principles deductions can be compressed into the following conceptual model:

```text
                         ┌─────────────────────┐
                         │   AUTHORITATIVE     │
                         │     WORLD STATE     │
                         └──────────┬──────────┘
                                    │
                ┌───────────────────┼───────────────────┐
                │                   │                   │
                ▼                   ▼                   ▼
           TRANSITIONS         REPRESENTATIONS      HISTORY
                │                   │                   │
                │                   ▼                   ▼
                │              PROJECTIONS          PROVENANCE
                │                   │
                ▼                   ▼
             TIME              OBSERVATIONS
                                    │
                                    ▼
                              AGENT / CLIENT
                                    │
                                    ▼
                              ACTION PROPOSAL
                                    │
                                    ▼
                           AUTHORIZATION / POLICY
                                    │
                                    └──────────► WORLD TRANSITION

                    ┌─────────────────────────────────┐
                    │       EXPERIMENTAL SPACE         │
                    │ snapshots / branches / models   │
                    │ predictions / hypotheses        │
                    └─────────────────────────────────┘
                                    │
                                    ▼
                              EVIDENCE / RESULTS
                                    │
                                    ▼
                           RESEARCH / DECISION
```

This is a conceptual map, not a runtime topology.

---

# 25. What This Means for Current World Engine Ideas

The repository's current Green / Yellow / Red classification is consistent with these principles.

## Already strongly supported

```text
authoritative state distinct from representation
replaceable capabilities rather than mandatory algorithms
explicit authority boundaries
counterfactual isolation
provenance for consequential development
research / decision / specification separation
```

## Plausible but still provisional

```text
representation / projection / bridge model
adaptive or goal-oriented representation selection
latent world representation
player-centered state collapse / reconstruction
Abstract Drift
JEPA-oriented agent/perception/reasoning stack
reactive subscription semantics
spatial sharding and migration
physical-process world generation
mutable ECS execution
```

The existence of a first-principles argument for investigating an idea does not promote the implementation of that idea.

---

# 26. Preliminary Architectural Consequences

These are **deductions for future research**, not binding contracts.

### 26.1 World truth should be representation-independent

Research should determine the minimum authoritative state required to reconstruct the representations and processes the engine promises.

### 26.2 Authority should be explicit and scoped

Research should replace simplistic role-based assumptions with a capability/policy model where the workload requires it.

### 26.3 Transitions should be inspectable

Research should determine the minimum information required to reconstruct consequential transitions without imposing unnecessary logging costs on all computation.

### 26.4 Observation should be mediated

Research should define how access policy, perception, projections, and agent-local state interact.

### 26.5 Counterfactual execution should be isolated

Research should determine practical snapshot, branch, and reconciliation mechanisms.

### 26.6 Representation changes should be justified by purpose

Research should investigate goal-oriented error, fidelity, switching cost, and validation.

### 26.7 Learned models should remain replaceable

JEPA, transformer, diffusion, graph, symbolic, or hybrid methods should be evaluated as implementations of capabilities rather than assumed architectural primitives.

### 26.8 Distribution should follow semantics

Research should establish locality, ownership, migration, synchronization, failure, and consistency requirements before selecting a distributed execution strategy.

### 26.9 Persistence should preserve semantic continuity

Research should establish which world state, history, provenance, and experiment artifacts require durable persistence.

### 26.10 Development should remain experimentally falsifiable

Architecture should provide explicit locations where prototypes and experiments can challenge assumptions without contaminating authoritative state.

---

# 27. Questions First Principles Do Not Answer

First principles constrain the search space. They do not eliminate engineering uncertainty.

The following remain open:

```text
What exact authoritative state representation should be used?
What temporal integration model is appropriate?
What spatial representation should be authoritative?
How much physics should be explicit versus emergent or approximate?
How should biological and social processes be represented?
What is the correct multiscale representation strategy?
How should representation error be estimated?
How should latent representations relate to authoritative state?
Can learned world models preserve the quantities the simulation requires?
What should run continuously when no observer is present?
How should away-time simulation work?
What snapshot/branch mechanism is sufficient?
What consistency guarantees are required across spatial boundaries?
What execution model gives the required performance?
What database or persistence architecture satisfies those semantics?
What workloads justify distribution?
What model architecture is appropriate for agents?
What level of determinism is required?
What provenance granularity is economically sustainable?
```

These should become research questions rather than assumptions.

---

# 28. Research Priorities Suggested by First Principles

A useful preliminary ordering is:

## P0: Define the world model itself

```text
world state
identity
time
space
transitions
authority
observation
provenance
```

Until these are sufficiently defined, technology selection is premature.

## P1: Determine representation and execution requirements

```text
state representation
multiscale representation
query model
process scheduling
simulation fidelity
reproducibility
persistence
```

## P1: Determine agent/world boundary

```text
perception
belief
action proposal
authorization
execution
learning
```

## P1: Determine counterfactual and experimental semantics

```text
snapshot
branch
isolation
replay
comparison
reconciliation
```

## P2: Evaluate implementation families

```text
ECS / data-oriented execution
relational state
graph state
spatial databases
distributed simulation
sharding
subscription / replication
learned world models
```

## P2+: Optimize and scale

```text
parallelism
GPU acceleration
remote execution
large-scale distribution
observability
deployment
```

The ordering is provisional. It exists to prevent premature optimization and premature technology commitment.

---

# 29. First-Principles Test for Any Proposed Feature

Before adding a consequential capability, ask:

```text
1. What real problem does this solve?
2. What invariant does it preserve or establish?
3. What is authoritative?
4. What is derived?
5. What information is actually required?
6. What can be approximated?
7. What error is acceptable, and relative to what purpose?
8. What causes the state transition?
9. What permissions are required?
10. What happens when the process fails?
11. Can the result be reproduced or reconstructed?
12. Can the idea be tested without contaminating authority?
13. What evidence would falsify the design?
14. Is this a capability or an implementation choice?
15. What existing contract or invariant does it affect?
```

If these questions cannot be answered, the idea should normally remain research or Yellow material rather than becoming architecture.

---

# 30. Relationship to Repository Governance

This document deliberately does not replace the existing governance system.

The repository already establishes that:

- authority is explicit rather than inferred from discussion or implementation;
- Green / Yellow / Red is a promotion/disposition dimension;
- evidence strength is independent of promotion status;
- research does not automatically become architecture;
- consequential changes preserve provenance;
- AI agents must identify authoritative contracts before implementing consequential changes.

This document instead supplies the **system-level conceptual foundation** that future architecture, contracts, and research can test against.

---

# 31. Preliminary Conclusion

World Engine should be understood first as:

> **A system that maintains an authoritative, persistent, spatially and temporally evolving world, exposes purpose-specific representations and observations of that world, permits agents and computations to act through explicit boundaries, supports isolated counterfactual and experimental execution, and preserves sufficient provenance to explain and reproduce consequential evolution.**

Everything else is subordinate to that problem definition.

In particular:

```text
World Engine
    is not fundamentally
        a voxel engine
        an ECS
        a database
        a distributed server
        a rendering engine
        an MMO backend
        a JEPA system
        an AI agent framework

Those are possible implementations or subsystems.
```

The fundamental engineering problem is the preservation and controlled evolution of world state under observation, computation, agency, approximation, experimentation, and eventually distribution.

That is the hypothesis the rest of the architecture should attempt to prove, refine, or falsify.

---

# 32. Preliminary Sources and Research Basis

This synthesis draws from the current World Engine repository plus first-principles comparison with established work in simulation, data-oriented execution, reactive state replication, and learned world models.

## Repository evidence

- `README.md`: current project definition and Green architectural principles.
- `docs/architecture-status.md`: current Green / Yellow / Red classification.
- `docs/development-governance.md`: authority, evidence, decision, contract, implementation, validation, and provenance model.
- `docs/development-provenance.md`: provenance requirements.
- `docs/research/README.md`: research methodology and evidence discipline.
- `research/005-github-practices-and-push-gates.md`: repository promotion and validation gate.
- `research/ALPHA/README.md`: Order / Transition prototype scope.
- `research/ALPHA/EXPERIMENT_REPORT.md`: controlled prototype findings.
- `research/ALPHA/spec/order-transition-schema.json`: prototype transition record schema.

## External research basis

- IEEE 1516 / HLA: distributed modeling and simulation architecture and explicit federation responsibilities.
- Unity DOTS: modern data-oriented game-engine architecture and ECS as an implementation approach.
- SpacetimeDB documentation: authoritative server-side state, transactional reducers, state mirroring, and real-time subscriptions as a concrete implementation model.
- Assran et al., *V-JEPA 2: Self-Supervised Video Models Enable Understanding, Prediction and Planning*: evidence that learned latent predictive models can support physical-world understanding, prediction, and action-conditioned planning in specific workloads.

These sources support individual claims and research directions. They do not by themselves establish World Engine architecture.

---

# 33. Status and Next Step

**Current status:** Preliminary synthesis.

**Evidence level:** Mixed. Repository governance principles are Green; system-level deductions are primarily E2 reasoning supported selectively by E1 external evidence and E3/E4 evidence from the ALPHA prototype where explicitly noted.

**Architectural authority:** None beyond principles already independently established elsewhere in the repository.

**Next step:** Convert the major unresolved first-principles questions into a prioritized research index, then investigate the highest-leverage questions before promoting implementation-specific architecture.

> **When in doubt, return to first principles.**
