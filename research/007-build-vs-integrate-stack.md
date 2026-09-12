# Research 007: Build vs Integrate World Engine Stack

**ID:** R-STACK-002
**Status:** YELLOW / PRELIMINARY
**Type:** Architecture research
**Scope:** First-principles stack ownership and external dependency policy
**Date:** 2026-09-11

## 1. Research Question

Given the first-principles definition of World Engine and the current repository direction, which parts of the stack should World Engine build and own, which parts should initially be integrated from existing software, and where should external software be treated only as replaceable substrate?

## 2. Executive Finding

The strongest preliminary finding is that World Engine should **own the semantic and algorithmically distinctive machinery of the world**, while using external software selectively for commodity primitives and interoperability standards.

This is not a prohibition on dependencies. It is an ownership rule.

> **Own the abstractions, invariants, data model, world-specific algorithms, and pipelines that constitute World Engine's unique behavior. Integrate mature commodity mechanisms where rebuilding them would add little strategic value, but place them behind World Engine-owned interfaces.**

The repository's existing first-principles document already separates world state, process, representation, observation, and computation, and explicitly warns against treating a database, ECS, voxel representation, or JEPA as the definition of the world. This research therefore evaluates technologies against those principles rather than using technology names as premises.

## 3. Scope of Analysis

The stack is decomposed into these capability families:

1. Semantic world model
2. World state storage model
3. Database / persistence engine
4. Transaction and transition system
5. Spatial data system
6. Temporal execution and scheduler
7. Simulation pipeline
8. World generation pipeline
9. Physics and numerical primitives
10. Representation and projection
11. Networking and subscriptions
12. Experimentation, snapshots, branching and replay
13. Provenance and observability
14. Rendering
15. AI / agent runtime
16. Machine learning and learned world models
17. Analytics and data interchange
18. Build, test and development infrastructure
19. Distributed execution

## 4. Method

The analysis follows the project research discipline:

```text
FIRST PRINCIPLE
    ↓
CAPABILITY REQUIRED
    ↓
INVARIANTS / CONTRACTS
    ↓
BUILD OR INTEGRATE HYPOTHESIS
    ↓
EXTERNAL EVIDENCE
    ↓
ENGINEERING IMPLICATION
    ↓
EXPERIMENT
    ↓
DECISION
```

Research findings are separated from architectural authority. No component is promoted to GREEN merely because it appears in this document.

Evidence classes used here:

- **E1:** external primary/authoritative evidence
- **E2:** reasoning from first principles
- **E3:** evidence from World Engine prototypes/repository experiments
- **E4:** future controlled benchmark or experiment

This document contains E1 and E2 findings and identifies E4 work still required.

---

# 5. The Ownership Test

For each subsystem, ask five questions.

### Q1. Is this part of World Engine's unique semantic model?

If yes, strong presumption to own it.

### Q2. Does its implementation determine World Engine's behavior or invariants?

If yes, strong presumption to own the abstraction and probably the core implementation.

### Q3. Is the problem a mature commodity with stable interfaces and little project-specific differentiation?

If yes, integration is favored.

### Q4. Would replacing the dependency be practical if the project later outgrows it?

If no, dependency risk is high and the boundary should be especially strong.

### Q5. Would implementing it ourselves produce strategic knowledge needed to solve the actual World Engine problem?

If yes, building it is favored even if an external implementation exists.

The last question is important. For World Engine, implementation itself is part of the research process. A subsystem that looks like a generic database may actually be one of the central research problems.

---

# 6. Preliminary Ownership Classification

| Capability | Preliminary stance | Confidence | Reason |
|---|---|---:|---|
| Semantic world model | BUILD | High | Core identity of project |
| World state abstraction | BUILD | High | Must remain independent of storage |
| World database semantics | BUILD | High | Potentially unique workload and temporal/spatial semantics |
| Database physical storage engine | BUILD, investigate carefully | Medium | High strategic value, but large implementation scope |
| Transaction/transition semantics | BUILD | High | Directly tied to world authority |
| Spatial abstraction | BUILD | High | Space affects causality, simulation and streaming |
| Spatial index implementation | BUILD selectively | Medium | May need project-specific structures |
| Simulation scheduler | BUILD | High | World-time and process semantics are core |
| Simulation pipeline | BUILD | High | Core project behavior |
| World generation pipeline | BUILD | High | Major project differentiation |
| Procedural algorithms | BUILD/RESEARCH | High | Domain-specific world behavior |
| Physics abstraction | BUILD | High | Keep engine independent of solver |
| Physics solver | Integrate initially, possibly build later | Medium | Mature but potentially strategically important |
| Projection model | BUILD | High | Observer-specific world representation is core |
| Network protocol | BUILD | Medium-High | World-specific projection and synchronization semantics |
| Network transport | INTEGRATE | High | Commodity substrate |
| Snapshot/branch semantics | BUILD | High | Required for experimental world evolution |
| Replay/provenance model | BUILD | High | Core research and debugging requirement |
| Renderer abstraction | BUILD | High | Must consume projections rather than define world truth |
| Graphics API bindings | INTEGRATE | High | Commodity interface to hardware |
| Rendering algorithms | BUILD selectively | Medium | World-specific representation/rendering may matter |
| Agent interface | BUILD | High | Core observation/action boundary |
| Agent inference runtime | Integrate selectively | Medium | Depends on model workloads |
| ML model implementations | INTEGRATE/RESEARCH | Medium | Rapidly changing research area |
| World-model orchestration | BUILD | High | Integration semantics are project-specific |
| Data interchange | INTEGRATE standards | High | Interoperability is valuable |
| Analytics pipelines | BUILD orchestration, integrate formats | High | Research workflow is project-specific |
| Compiler/runtime | INTEGRATE | High | Not strategic to rebuild initially |
| OS/filesystem/network primitives | INTEGRATE | High | Commodity substrate |
| Distributed world execution model | BUILD | High | Core semantic problem |
| Cluster/orchestration substrate | INTEGRATE initially | Medium-High | Commodity infrastructure, defer custom infrastructure |

This table is a hypothesis, not a final dependency manifest.

---

# 7. Semantic World Model: BUILD

## First principle

The world must exist conceptually before its storage, rendering, or network representations.

## Required capability

A formal model of:

- identity
- entities
- components/state
- relationships
- location
- time
- processes
- transitions
- authority
- observation
- provenance
- versions/branches

## Finding

This is unquestionably World Engine-owned territory.

If an external database schema, ECS framework, game engine object model, or networking protocol defines the semantic world, the project has effectively outsourced its central architecture.

## Recommendation

Build the semantic model as a small, dependency-light C# library with explicit contracts. Keep storage, execution, rendering and networking adapters outside it.

**Promotion:** GREEN candidate after formal contract review.

---

# 8. World Database: BUILD, But Start With the Semantic Database Before the Storage Engine

This is the most important correction to the earlier stack analysis.

## First principle

Persistence is not merely storage. The system must preserve semantic continuity of a world through state, transitions, versions, provenance and recovery.

## Required capability

A World Engine database potentially needs to support:

```text
entity identity
component/state storage
relationships
spatial locality
versioning
world time
transactional transitions
snapshots
branches
provenance
recovery
incremental observation
bulk simulation access
analytical export
```

## External evidence

SpacetimeDB demonstrates a useful existing model in which databases contain tables and server-side reducers, with reducers providing atomic state-changing transactions. It also supports client-side state mirroring through subscriptions. This makes it a useful comparison target, not a reason to adopt it. [SpacetimeDB key architecture](https://spacetimedb.com/docs/intro/key-architecture/), [reducers](https://spacetimedb.com/docs/functions/reducers/).

RocksDB demonstrates a mature embedded LSM key-value engine optimized around fast persistent storage and tunable read/write/space amplification. [RocksDB](https://github.com/facebook/rocksdb).

SQLite demonstrates the value of an embedded database as an application-local storage engine, emphasizing simplicity, reliability and independence. [SQLite appropriate uses](https://www.sqlite.org/whentouse.html).

## First-principles finding

None of these systems directly defines the database semantics World Engine appears to need.

The critical research question is therefore not "which database should we use?" but:

> **What is a World Engine database?**

Only after that question is answered should physical storage be selected.

## Preliminary recommendation

**BUILD the database abstraction and semantic storage layer.**

Investigate a custom storage engine rather than assuming a conventional database should be the foundation.

However, do not immediately write a production database. First build a minimal experimental storage substrate that can answer whether World Engine's access patterns actually justify a custom engine.

Potential architecture to investigate:

```text
World Database API
        ↓
Semantic State Layer
        ↓
Transaction / Commit Layer
        ↓
Index Layer
        ↓
Storage Engine
        ↓
Files / SSD / Memory
```

This permits the storage engine to evolve without contaminating semantic contracts.

**Promotion:** YELLOW pending database workload characterization and benchmark.

---

# 9. Transaction and Transition System: BUILD

## First principle

The world changes through authoritative transitions.

The ALPHA prototype provides E3 evidence supporting an explicit transition contract and separation of proposal from authorization.

## Finding

A generic database transaction is not necessarily equivalent to a World Engine transition.

A database transaction answers questions such as atomicity and isolation. A world transition must additionally answer questions such as:

```text
what world process caused it?
what authority permitted it?
what actor proposed it?
what state was observed?
what time was it evaluated at?
what dependencies were used?
what resulted?
```

## Recommendation

Build the transition system ourselves, potentially using an external transactional storage primitive underneath it.

Do not make the external transaction model the definition of world causality.

**Promotion:** GREEN candidate for semantic transition contracts, YELLOW for physical implementation.

---

# 10. Spatial System: BUILD THE ABSTRACTION AND LIKELY CORE STRUCTURES

## First principle

Space affects interaction and causality, not merely rendering.

## Required capability

The spatial system must eventually support combinations of:

```text
location
containment
adjacency
distance
neighborhood queries
visibility
collision queries
streaming
simulation locality
world generation locality
partitioning
migration
```

## Finding

A generic spatial index is unlikely to cover all of these semantics.

A conventional database spatial index may be useful for queries, while a physics engine may maintain another structure, and the renderer may maintain another representation. World Engine should therefore own the semantic spatial abstraction.

## Recommendation

Build:

```text
WorldSpatial API
Spatial regions / cells
Neighborhood semantics
Locality contracts
Spatial identity
```

Then research specialized structures underneath it:

```text
uniform grids
hierarchical grids
BVH
octree / sparse voxel structures
R-tree variants
Morton / Hilbert layouts
custom region/chunk indexes
```

Do not assume one structure must serve every workload.

**Promotion:** YELLOW until representative spatial workloads exist.

---

# 11. Temporal Runtime and Scheduler: BUILD

## First principle

World time is semantic state. Execution time is an implementation concern.

## Finding

A conventional game loop is unlikely to be sufficient as the final abstraction because World Engine potentially needs:

- multiple temporal scales;
- inactive regions advancing without direct observation;
- causal dependencies;
- scheduled processes;
- deterministic or reproducible execution;
- branch execution;
- catch-up/reconciliation.

## Recommendation

Build the World Engine scheduler abstraction.

The first implementation can be simple and single-process. Do not prematurely design a distributed scheduler.

Candidate model:

```text
World Clock
    ↓
Process Eligibility
    ↓
Dependency Ordering
    ↓
Process Execution
    ↓
Transitions
    ↓
Commit
    ↓
Observation / Projection
```

**Promotion:** YELLOW pending prototype.

---

# 12. Simulation Pipeline: BUILD

This is one of the areas where external engines should be treated as subordinate components.

## First principle

The world is defined by its processes and transition semantics, not by a generic game-engine update loop.

## Recommendation

Build a World Engine process pipeline with explicit stages and contracts.

A process should declare enough information to determine:

```text
inputs
read set
write set
spatial scope
temporal scope
dependencies
authority requirements
output transitions
```

The exact contract remains experimental.

The purpose is to permit different execution implementations without changing world semantics.

**Promotion:** YELLOW pending design prototype.

---

# 13. World Generation: BUILD

## First principle

World generation is not simply content creation. It establishes initial conditions and relationships from which subsequent world processes operate.

## Preliminary pipeline

```text
cosmology / planetary conditions
        ↓
tectonics / geology
        ↓
terrain
        ↓
hydrology
        ↓
atmosphere / climate
        ↓
erosion / soil
        ↓
biomes / ecology
        ↓
organisms
        ↓
settlement
        ↓
culture / history
```

The actual dependency graph is a research question.

## Finding

Existing terrain-generation libraries may be useful for individual algorithms, but outsourcing the overall generation pipeline would undermine one of the project's primary differentiators.

## Recommendation

Build the pipeline and domain models. Integrate mathematical/numerical primitives where appropriate.

**Promotion:** YELLOW because the pipeline itself is not yet formally specified.

---

# 14. Physics: BUILD THE INTERFACE, INTEGRATE A SOLVER INITIALLY

## First principle

Physics is a capability of the world, not the identity of the world.

## External evidence

BEPUphysics v2 is a pure C# 3D rigid-body simulation library targeting .NET 8, with collision detection, constraints, sleeping and spatial queries. It is a strong candidate for experimental integration. [BEPUphysics2](https://github.com/bepu/bepuphysics2).

## Finding

Building a complete rigid-body solver from scratch immediately would consume substantial effort before we know whether rigid-body physics is the dominant research bottleneck.

However, the World Engine physics abstraction should belong to us.

```text
World Physics API
       ↓
Physics Adapter
       ↓
BEPU / custom solver / other solver
```

## Recommendation

Integrate BEPUphysics initially behind our interface. Maintain the option to develop custom solvers for domain-specific phenomena later.

This is a deliberate example of **not reinventing a mature commodity subsystem before the project has evidence that doing so matters**.

**Promotion:** YELLOW.

---

# 15. Representation and Projection: BUILD

## First principle

Representation is not reality. Observation is a projection of world state.

## Finding

This is central to the project's unusual design because the same world may need multiple representations for:

```text
simulation
physics
rendering
AI perception
networking
analytics
experimentation
```

A single universal representation is likely to impose unnecessary coupling.

## Recommendation

Build the representation/projection interfaces and transformation pipelines ourselves.

External serialization libraries and data formats may be used underneath them.

**Promotion:** GREEN conceptually, YELLOW for implementation.

---

# 16. Networking: BUILD WORLD PROTOCOL, INTEGRATE TRANSPORT

## First principle

The network should communicate observations and authorized actions, not expose storage implementation as the protocol.

## Finding

SpacetimeDB's state mirroring is a useful reference implementation: clients can subscribe to selected data and receive live updates, while database mutations occur through server-side requests. This is valuable evidence for the usefulness of reactive projections, but not evidence that its protocol should become World Engine's protocol.

## Recommendation

Build:

```text
World Projection Protocol
Observation subscriptions
Action proposal protocol
Authority responses
Versioning
Delta semantics
```

Integrate:

```text
TCP/UDP/QUIC
TLS
HTTP tooling where useful
socket primitives
```

The transport should be replaceable.

**Promotion:** YELLOW.

---

# 17. Experimentation, Snapshots, Branches and Replay: BUILD

## First principle

Counterfactual execution must be isolated from authoritative reality.

## Finding

This is too tightly coupled to World Engine semantics to outsource wholesale.

A generic database snapshot may not understand:

```text
world time
transition lineage
agent state
simulation configuration
model versions
branch identity
provenance
```

## Recommendation

Build a World Engine experiment layer.

```text
Authoritative World
        ↓
Checkpoint
        ↓
Branch
        ↓
Experimental Runtime
        ↓
Result Set
        ↓
Compare / Promote / Discard
```

Storage primitives can be external or custom.

**Promotion:** YELLOW.

---

# 18. Provenance and Observability: BUILD SEMANTICS, INTEGRATE TELEMETRY PRIMITIVES

## First principle

The project needs to know not merely what happened but enough about why and from which inputs to reconstruct consequential behavior.

## Finding

Generic logging/metrics systems are useful but do not define World Engine provenance.

## Recommendation

Build a semantic provenance model:

```text
Event / Transition ID
World / Branch ID
World time
Actor
Authority
Inputs
Dependencies
Algorithm/model versions
Result
Parent lineage
```

Integrate commodity exporters and telemetry backends where useful.

**Promotion:** GREEN for provenance requirement, YELLOW for implementation.

---

# 19. Rendering: BUILD THE WORLD RENDERING LAYER, INTEGRATE THE HARDWARE API

## First principle

Rendering is a consumer of world representations.

## External evidence

OpenTK provides C# bindings and windowing facilities around graphics APIs such as OpenGL. Its documentation makes clear that OpenGL itself is a specification while implementations vary. [OpenTK](https://opentk.net/), [OpenGL introduction](https://opentk.net/learn/chapter1/0-opengl.html).

## Finding

There is little strategic value in implementing GPU driver interfaces or a graphics API.

There is substantial value in owning the mapping from World Engine representations to rendering representations.

## Recommendation

Build:

```text
World Render Model
Scene extraction / projection
LOD policy
Streaming policy
World-specific rendering pipeline
```

Integrate:

```text
OpenGL / Vulkan / DirectX / GPU APIs
windowing primitives
shader toolchains where useful
```

OpenTK remains a reasonable early integration candidate because the project is C#-first.

**Promotion:** YELLOW.

---

# 20. Agent Runtime: BUILD THE WORLD INTERFACE

## First principle

Agents are participants, not the world.

## Required boundary

```text
World
 ↓
Observation
 ↓
Agent
 ↓
Decision
 ↓
Action Proposal
 ↓
Authorization
 ↓
Transition
```

## Finding

This interface is a World Engine-specific capability and should be owned by the project.

The agent's internal reasoning stack can remain replaceable.

## Recommendation

Build the agent API and observation/action contracts.

Integrate model runtimes as adapters.

**Promotion:** GREEN conceptually, YELLOW implementation.

---

# 21. AI and Learned World Models: BUILD ORCHESTRATION, INTEGRATE MODELS

## First principle

Prediction is not simulation.

## External evidence

V-JEPA 2 research demonstrates that learned video representations can support visual understanding, prediction and action-conditioned planning in specific workloads. This is evidence for learned predictive capabilities, not evidence that a learned model should become authoritative world state. [V-JEPA 2](https://arxiv.org/abs/2506.09985).

## Finding

The model ecosystem changes much faster than the semantic architecture should.

Therefore:

```text
World Engine AI Interface
          ↓
Model Adapter
          ↓
JEPA / transformer / diffusion / symbolic / hybrid model
```

The orchestration, observation contracts, action contracts, training data interfaces, evaluation harnesses and provenance should be World Engine-owned.

The individual model implementation can be external or separately developed.

**Promotion:** YELLOW.

---

# 22. Analytics and Data Interchange: BUILD PIPELINES, USE STANDARDS

## First principle

Research requires moving large quantities of structured data between runtime, experiments and analysis environments.

## External evidence

Apache Arrow defines a language-independent columnar in-memory format with data adjacency, O(1) random access and SIMD/vectorization-friendly properties. It is explicitly designed as an interoperable data representation rather than as a World Engine database. [Apache Arrow columnar format](https://arrow.apache.org/docs/format/Columnar.html).

## Finding

There is little benefit in inventing a proprietary analytical interchange format unless research establishes a specific need.

## Recommendation

Own:

```text
World Engine dataset semantics
experiment dataset schema
export/import pipelines
provenance metadata
```

Integrate:

```text
Arrow
Parquet
CSV where useful
standard compression
Python analytical ecosystem
```

This preserves interoperability without surrendering semantic ownership.

**Promotion:** YELLOW.

---

# 23. C# / .NET: INTEGRATE AS FOUNDATIONAL SUBSTRATE

## Finding

.NET 10 is an LTS release supported through November 2028. Microsoft reports runtime improvements including JIT inlining, devirtualization, stack allocation improvements, AVX10.2 support and NativeAOT improvements. [Microsoft .NET lifecycle](https://learn.microsoft.com/en-us/lifecycle/products/microsoft-net-and-net-core), [.NET 10](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10/overview).

## Recommendation

Continue with C#/.NET as the implementation substrate.

There is no strategic reason to build a language runtime for World Engine.

The project should instead exploit the runtime while owning the domain-specific libraries above it.

**Preliminary stance:** GREEN as development substrate, subject to repository implementation state.

---

# 24. Distributed Execution: BUILD THE SEMANTIC MODEL, DEFER INFRASTRUCTURE

## First principle

Distribution must preserve world semantics. Distribution itself is not a goal.

## External evidence

IEEE HLA provides an established architecture for distributed simulation and emphasizes explicit responsibilities and coordinated exchange between simulations. It is evidence that distributed simulation needs explicit coordination semantics, not evidence that World Engine should implement HLA. [IEEE 1516](https://standards.ieee.org/ieee/1516/6687/).

## Finding

World Engine's likely distributed problem is sufficiently specialized that the project should own:

```text
world partition semantics
authority locality
migration semantics
cross-boundary transitions
causal dependencies
consistency policy
failure semantics
```

But infrastructure such as service discovery, container scheduling and cloud deployment can initially be external.

## Recommendation

Do not build a distributed production system yet.

First build a single-process implementation whose semantic boundaries make distribution possible later.

Then research distributed execution experimentally.

**Promotion:** YELLOW.

---

# 25. What We Should NOT Build Yet

The build-first philosophy does not mean writing everything immediately.

Avoid premature implementation of:

```text
custom distributed cluster manager
custom GPU driver layer
custom operating system
custom network transport
custom TLS
custom general-purpose ML framework
custom rigid-body solver
custom analytical file format
custom container orchestration system
```

These are not currently where World Engine's unique research value lies.

Likewise, avoid building a giant custom database before measuring actual World Engine workloads.

**Own the database architecture and semantics first. Prove the storage engine second.**

---

# 26. The Proposed World Engine Ownership Boundary

```text
┌──────────────────────────────────────────────────────────────┐
│                     WORLD ENGINE OWNED                      │
│                                                              │
│ Semantic World Model                                         │
│ World State                                                  │
│ Authority                                                    │
│ Transition System                                            │
│ World Database API                                           │
│ Spatial Semantics                                            │
│ Temporal Runtime                                             │
│ Simulation Pipeline                                          │
│ World Generation                                             │
│ Projection / Observation                                     │
│ Experiment / Branch / Replay                                │
│ Provenance                                                   │
│ Agent Interface                                              │
│ AI/ML Orchestration                                          │
│ World-specific Rendering Pipeline                            │
│ Distributed World Semantics                                  │
│                                                              │
├──────────────────────────────────────────────────────────────┤
│                     ADAPTER BOUNDARY                         │
│                                                              │
│ Storage engines                                              │
│ Physics solvers                                              │
│ Graphics APIs                                                │
│ ML runtimes/models                                           │
│ Network transports                                           │
│ Analytics formats                                            │
│ Telemetry backends                                           │
│                                                              │
├──────────────────────────────────────────────────────────────┤
│                     EXTERNAL SUBSTRATE                       │
│                                                              │
│ .NET / CLR                                                   │
│ OS / filesystem                                              │
│ CPU / SIMD                                                   │
│ GPU drivers                                                  │
│ TCP/UDP/QUIC/TLS                                             │
│ Standard data formats                                        │
│                                                              │
└──────────────────────────────────────────────────────────────┘
```

This boundary is a preliminary architecture hypothesis.

---

# 27. Strategic Consequence: The Database Becomes a Research Program

The database question is now elevated because it touches nearly every unique part of the system.

A conventional database optimizes for generic data persistence.

World Engine potentially needs a system optimized for:

```text
mutable world state
high-frequency transitions
spatial locality
temporal locality
branching
snapshots
replay
causal provenance
mixed simulation and analytical workloads
partial observation
large state with localized active computation
```

That combination is sufficiently unusual to justify investigating a World Engine-specific database.

But the research should proceed from workloads, not implementation enthusiasm.

### Database research sequence

```text
R-DB-001
Define World Engine data model

R-DB-002
Characterize read/write/query patterns

R-DB-003
Characterize transaction semantics

R-DB-004
Characterize snapshot/branch requirements

R-DB-005
Characterize spatial locality

R-DB-006
Characterize persistence/recovery requirements

R-DB-007
Design minimal storage substrate

R-DB-008
Benchmark storage strategies

R-DB-009
Evaluate custom storage engine

R-DB-010
Promote database architecture if justified
```

---

# 28. Strategic Consequence: Libraries Should Be First-Class World Engine Products

Rather than one monolithic engine, the project should probably evolve as a family of World Engine-owned libraries.

A preliminary decomposition is:

```text
WorldEngine.Core
WorldEngine.World
WorldEngine.State
WorldEngine.Database
WorldEngine.Spatial
WorldEngine.Time
WorldEngine.Simulation
WorldEngine.WorldGen
WorldEngine.Physics
WorldEngine.Projection
WorldEngine.Network
WorldEngine.Experiment
WorldEngine.Provenance
WorldEngine.Agents
WorldEngine.AI
WorldEngine.Analytics
WorldEngine.Rendering
```

These names are illustrative, not final package names.

The purpose is architectural ownership, not package proliferation.

Each library should have a narrow capability boundary and avoid unnecessary dependencies upward into unrelated layers.

---

# 29. Preliminary Dependency Direction

The dependency direction should trend toward:

```text
                 Core
                  │
        ┌─────────┼─────────┐
        ▼         ▼         ▼
      State      Time     Spatial
        │         │         │
        └────┬────┴────┬────┘
             ▼         ▼
         Simulation  Database
             │         │
             ├────┬────┤
             ▼    ▼    ▼
          Physics WorldGen Experiment
             │    │      │
             └────┼──────┘
                  ▼
              Projection
             /     |      \
          Network Agents Rendering
                     │
                     ▼
                    AI
```

The exact graph requires design work.

The critical constraint is that the semantic core should not depend on a database vendor, graphics API, physics solver or ML framework.

---

# 30. External Dependency Policy

Every external dependency should be classified before becoming foundational.

### Class A: Commodity substrate

Use freely where appropriate.

Examples:

```text
.NET
OS APIs
filesystem
standard networking
GPU APIs
standard compression
```

### Class B: Interoperability standard

Prefer standards where they provide broad interoperability without defining World Engine semantics.

Examples:

```text
Arrow
Parquet
OpenGL/Vulkan/etc.
standard network protocols
```

### Class C: Replaceable implementation

Integrate behind a World Engine interface.

Examples:

```text
BEPUphysics
SpacetimeDB
RocksDB
SQLite
ML runtimes
telemetry systems
```

### Class D: Strategic semantic dependency

Avoid making external software authoritative.

If a dependency belongs here, reconsider whether World Engine should own the implementation.

### Class E: World Engine invention

Build it.

Examples are likely to include:

```text
world-state semantics
transition semantics
world database semantics
spatial/temporal world semantics
projection semantics
experiment semantics
world-generation pipeline
agent/world boundary
```

---

# 31. Contradictions Identified

The current project direction contains several tensions that should remain explicit.

## 31.1 "Build our own database" vs development velocity

A custom database can become a multi-year project. The solution is not abandoning the idea, but separating semantic ownership from storage implementation and proving the workload first.

## 31.2 "Own the spatial system" vs physics-specific spatial structures

One spatial structure probably should not be forced to serve every workload. World Engine should own spatial semantics while allowing specialized indexes internally or through adapters.

## 31.3 "Own the AI pipeline" vs rapidly changing ML ecosystem

The stable thing should be the World Engine AI interface and dataset/evaluation semantics, not a specific model architecture.

## 31.4 "Build our own networking" vs mature transport protocols

The World Engine protocol can be novel while TCP/UDP/QUIC/TLS remain external substrate.

## 31.5 "Own the renderer" vs graphics complexity

The world-to-render representation and streaming model are strategic. The GPU API is not.

---

# 32. What We Now Believe With Reasonable Confidence

### High confidence

1. World Engine should own its semantic world model.
2. World Engine should own authoritative transition semantics.
3. World Engine should own observation/projection semantics.
4. World Engine should own agent/world boundaries.
5. World Engine should own its simulation and world-generation pipeline architecture.
6. External technologies should not silently define world semantics.
7. Commodity substrate should generally be integrated rather than rebuilt.
8. External implementations should sit behind replaceable boundaries when they perform strategic functions.

### Medium confidence

1. A custom World Engine database may be justified.
2. A custom spatial data system may be justified.
3. A custom simulation scheduler is likely justified.
4. A custom network protocol is likely justified.
5. Custom physics may eventually become strategically useful.
6. The JEPA/world-model stack should be developed as an experiment-driven subsystem rather than a foundational dependency.

### Low confidence / unresolved

1. Exact database physical architecture.
2. Exact spatial index architecture.
3. Exact execution/data layout architecture.
4. Exact temporal scheduling model.
5. Exact distributed partitioning model.
6. Exact learned world-model architecture.
7. Exact representation hierarchy.
8. Exact persistence format.

---

# 33. Required Experiments Before Major Commitments

The next stage should be empirical.

## E4-1: World state layout benchmark

Compare representative World Engine workloads using:

```text
AoS
SoA
archetype/ECS
hybrid
```

Measure:

- update throughput
- query throughput
- memory footprint
- cache behavior
- allocation rate
- parallel scaling
- mutation cost

## E4-2: Storage benchmark

Compare:

```text
custom append/segment store
RocksDB
SQLite
SpacetimeDB
possibly PostgreSQL as a control
```

Do not benchmark generic CRUD only.

Use representative world workloads:

```text
localized high-frequency mutation
spatial queries
component queries
snapshot
branch
recovery
bulk simulation reads
```

## E4-3: Spatial benchmark

Compare candidate spatial organizations against actual world workloads.

## E4-4: Transition benchmark

Measure the cost of:

```text
validate
execute
record provenance
commit
project
```

## E4-5: Snapshot/branch benchmark

Determine whether copy-on-write, immutable segments, delta logs, structural sharing, or another strategy best fits the world.

## E4-6: Scheduler benchmark

Test:

```text
fixed timestep
variable timestep
priority queue
dependency graph
region-local scheduling
multi-rate scheduling
```

## E4-7: Physics adapter benchmark

Compare BEPU integration against a minimal custom physics workload. The goal is to determine whether physics is actually a strategic bottleneck.

## E4-8: Projection benchmark

Measure the cost of maintaining multiple observer-specific representations from common authoritative state.

---

# 34. Immediate Implementation Order

The stack should now be implemented in this order, subject to research findings:

```text
1. WorldEngine.Core semantic primitives

2. WorldEngine.State
   authoritative state model

3. WorldEngine.Database experimental abstraction
   in-memory first

4. WorldEngine.Time
   world clock and scheduling contract

5. WorldEngine.Simulation
   transition/process execution

6. WorldEngine.Spatial
   spatial semantics + first implementation

7. WorldEngine.Provenance
   transition lineage

8. WorldEngine.Experiment
   snapshot / branch / replay substrate

9. WorldEngine.Projection
   observer-specific representations

10. WorldEngine.Physics
    adapter + BEPU experiment

11. WorldEngine.WorldGen

12. WorldEngine.Network

13. WorldEngine.Agents

14. WorldEngine.AI

15. WorldEngine.Rendering

16. Distributed execution
```

This is not a claim that all layers must be complete before work can begin on another. It is the dependency logic for minimizing architectural rework.

---

# 35. Final Preliminary Recommendation

World Engine should pursue a **build-first, integrate-where-commodity, adapter-oriented architecture**.

The most important ownership decisions are:

```text
BUILD / OWN
───────────
world semantics
world state model
authority
transitions
world database semantics
spatial semantics
time semantics
simulation pipeline
world generation
projection semantics
experiment semantics
provenance
agent interface
AI orchestration
world-specific rendering
world-specific distributed semantics

INTEGRATE / ADAPT
─────────────────
.NET
OS
GPU APIs
network transports
TLS
commodity compression
physics solver initially
storage engine initially
ML runtimes
Arrow / Parquet
telemetry backends
```

The most consequential recommendation is:

> **Do not make an external database the foundation of World Engine. Build the World Engine database contract and semantics first, then determine experimentally whether its physical storage engine should also be entirely custom.**

This preserves the possibility that we eventually own the complete database engine without forcing us to write thousands of lines of storage-engine code before understanding the workload.

The same principle applies to physics, networking, rendering and AI.

---

# 36. Research Conclusion

The earlier assumption that the next step should be "select the best existing technology for each subsystem" is rejected.

The better model is:

```text
                 FIRST PRINCIPLES
                        ↓
                WORLD ENGINE NEEDS
                        ↓
             CAPABILITY DEFINITIONS
                        ↓
              OWNERSHIP ANALYSIS
                    ↙       ↘
                 BUILD     INTEGRATE
                   ↓           ↓
             OUR LIBRARIES   ADAPTERS
                    \         /
                     \       /
                     EXPERIMENTS
                         ↓
                    MEASURED FIT
                         ↓
                     DECISION
```

World Engine is sufficiently unusual that its distinctive value is likely to reside not in assembling existing engines, but in creating a coherent system whose **world model, database, simulation, representation, experimentation and agent interfaces are designed as one conceptual system**.

That hypothesis is now strong enough to guide the next research phase, but it remains a hypothesis until the relevant workload experiments validate it.

> **Build what defines the world. Integrate what merely operates the machine.**

---

# 37. Sources

Primary/authoritative sources consulted during this research:

1. Microsoft, .NET lifecycle and .NET 10 documentation.
2. SpacetimeDB, architecture, reducers and transaction documentation.
3. RocksDB project documentation.
4. SQLite, Appropriate Uses for SQLite.
5. Apache Arrow, Columnar Format specification.
6. OpenTK documentation.
7. BEPUphysics2 repository and documentation.
8. IEEE 1516 HLA standard overview.
9. V-JEPA 2 research paper.

External sources inform findings but do not constitute World Engine architecture.

---

# 38. Status

**Research status:** Preliminary complete.

**Architectural status:** YELLOW.

**No final stack selection has been promoted.**

**Next research:** World Engine database data model and workload characterization.

**Next implementation:** Minimal semantic core and in-memory state/database prototype, not a production database.
