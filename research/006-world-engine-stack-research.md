# Research 006: World Engine Stack, First-Principles Analysis

**Research ID:** 006
**Title:** World Engine Stack, First-Principles Analysis
**Status:** YELLOW
**Priority:** P0/P1
**Created:** 2026-09-11
**Updated:** 2026-09-11
**Researcher:** AI-assisted research
**Reviewer:** Pending
**Related Issue:** #20, R-STACK-001
**Related Architecture:** `firstprinciples.md`, `docs/architecture-status.md`

## Question

What technology stack should World Engine use to implement the capabilities required by its first-principles model, while keeping authoritative semantics independent of implementation choices?

## Context

The repository currently contains architecture/governance documentation and the ALPHA Order/Transition prototype, but not yet a production engine implementation. The current repository definition is world-first, persistent, spatially grounded, and explicitly separates authoritative world state from representation, computation, perception, experimentation, and implementation.

Current Green principles include representation-independent authority, replaceable runtime capabilities, mediated agent access, isolated counterfactual execution, transition provenance, and separation of research from architecture. Current Yellow directions include representation/projection/bridge, adaptive representations, latent world representation, Abstract Drift, JEPA, SpacetimeDB-like subscriptions, Hadean-inspired sharding, physical-process terrain, and mutable ECS.

The ALPHA prototype provides E3/E4 evidence that Orders can act as transition contracts, consequential transitions need reconstructable context and lineage, proposal and authorization should remain separate, and scoped capability/policy authorization is preferable to a flat scalar hierarchy for the tested workload.

## Scope

### In scope

- Core runtime language/runtime
- authoritative state and execution model
- memory/data layout
- persistence
- spatial representation/indexing
- physics
- networking and observation delivery
- distributed execution
- rendering/client layer
- research/analytics data path
- AI/ML integration
- testing/reproducibility/observability

### Out of scope

- final production-scale capacity claims
- final voxel/world-generation algorithm
- final JEPA architecture
- final database selection as authoritative state
- detailed game design
- content pipelines

## First-Principles Requirements

| Requirement | Consequence for stack | Evidence/status |
|---|---|---|
| Authoritative state must be explicit | Core runtime needs a clear authority boundary | Green repository principle |
| Representation is not authority | Rendering, agent views, caches, and analytics must consume projections rather than define truth | Green repository principle |
| Transitions need controlled mutation | Mutation should pass through explicit transition/process interfaces | ALPHA E3/E4 |
| Causality/provenance matters | Consequential transitions need reconstructable metadata | ALPHA E3/E4 |
| Time is semantic | Scheduler/time model must be engine-level, not hidden inside storage/networking | First-principles inference |
| Space affects interaction | Spatial indexing/locality must be a core capability | First-principles inference |
| Agents are bounded participants | Observation and action APIs need mediation | Green + ALPHA E3/E4 |
| Approximation is purpose-relative | Multiple representations may coexist | First-principles inference |
| Counterfactuals must be isolated | Snapshot/branch capability must not mutate parent authority | Green repository principle |
| Reproducibility depends on more than source code | State, inputs, randomness, versions, and configuration must be capturable for experiments | First-principles + ALPHA |
| Distribution follows semantics | Partitioning/sharding is downstream of authority, locality, consistency, and failure requirements | First-principles inference |
| Algorithms are replaceable | APIs should expose capabilities/contracts | Green repository principle |

## Research Questions

```text
RQ-006-01: Is C#/.NET a suitable primary runtime for the core simulation?
RQ-006-02: What execution/data-layout model should sit inside the .NET runtime?
RQ-006-03: Should authoritative world state be database-resident, engine-resident, or hybrid?
RQ-006-04: What persistence model best preserves semantic continuity and recovery?
RQ-006-05: What spatial data structures are required for world locality and interaction?
RQ-006-06: What physics implementation best fits a C#-native engine without becoming architectural law?
RQ-006-07: What transport/replication model should expose projections to clients and agents?
RQ-006-08: What distribution model should be investigated before committing to sharding?
RQ-006-09: What rendering API/client framework should be coupled, and what should remain independent?
RQ-006-10: What data/analytics format should connect simulation output to research and ML?
RQ-006-11: How should learned models integrate without becoming world authority?
RQ-006-12: What development/validation infrastructure is needed to make the system experimentally falsifiable?
```

## Hypotheses

### H-006-01
**Statement:** C#/.NET is a viable primary implementation environment for the core engine.
**Status:** Supported, with unresolved performance validation.
**Reason:** The existing prototype already uses C#; current .NET provides JIT improvements, SIMD/hardware-intrinsic support, channels, dataflow, and Native AOT options. citehttps://learn.microsoft.com/en-us/dotnet/core/releases-and-support

### H-006-02
**Statement:** A custom engine-resident authoritative state layer should remain distinct from any persistence database.
**Status:** Supported as an architectural direction, implementation unresolved.
**Reason:** This preserves the repository's explicit principle that storage is not automatically world authority. SpacetimeDB demonstrates a strong alternative in which reducers are the only mutation path and execute transactionally, but adopting that model would make database semantics central to the engine and therefore requires explicit evaluation. citehttps://spacetimedb.com/docs/functions/reducers/https://spacetimedb.com/docs/databases/transactions-atomicity/

### H-006-03
**Statement:** A data-oriented execution model is likely to outperform object-heavy general-purpose simulation code for the project's large-scale homogeneous workloads.
**Status:** Plausible, not validated.
**Reason:** Unity DOTS and Apache Arrow provide evidence that contiguous/columnar data can improve locality and vectorization for appropriate workloads. This does not establish ECS as the correct World Engine architecture. citehttps://unity.com/dotshttps://arrow.apache.org/docs/format/Columnar.html

### H-006-04
**Statement:** A C#-native physics engine should be evaluated before introducing a foreign-language physics dependency.
**Status:** Supported as a research priority.
**Reason:** BEPUphysics v2 is a pure C# 3D real-time physics library targeting .NET 8 and using System.Numerics vectors. It is therefore a strong integration candidate for controlled comparison. citehttps://github.com/bepu/bepuphysics2

### H-006-05
**Statement:** Learned world models should initially be treated as predictive/inferential subsystems rather than authoritative simulation engines.
**Status:** Supported.
**Reason:** V-JEPA 2 demonstrates useful understanding, prediction, and planning capabilities in physical-world tasks, while Google DeepMind's Genie 3 demonstrates increasingly capable interactive generated worlds but explicitly reports limitations including limited action space, multi-agent interaction, and interaction duration. These are evidence for research value, not sufficient evidence that a learned model should own authoritative world state. citehttps://arxiv.org/abs/2506.09985https://deepmind.google/models/genie/

## Search Strategy

**Objective:** Compare implementation families against semantic requirements rather than selecting by popularity.

**Primary sources searched:** IEEE Standards, Microsoft Learn, official SpacetimeDB documentation, Apache Arrow documentation, Unity documentation, BEPUphysics repository/documentation, primary ML research and research-lab sources.

**Research areas:** distributed simulation, .NET runtime/performance, data-oriented execution, databases, persistence, spatial data, physics, networking, rendering, analytics, and world models.

**Date:** 2026-09-11.

## Sources

### S-006-01: IEEE 1516-2025 HLA Framework and Rules
Organization: IEEE Standards Association
Type: Standard
Relevance: Provides established architecture for distributed modeling and simulation, including explicit responsibilities of federates/federations and coordinated exchange through an RTI.
Limitation: HLA solves interoperability/coordination of distributed simulations, not the specific World Engine problem.
URL: https://standards.ieee.org/ieee/1516/6687/

### S-006-02: .NET releases and support
Organization: Microsoft
Type: Official platform documentation
Relevance: .NET 10 is currently LTS through November 2028; .NET 8 and 9 have shorter remaining support windows.
Limitation: Support lifetime does not establish runtime suitability.
URL: https://learn.microsoft.com/en-us/dotnet/core/releases-and-support

### S-006-03: .NET SIMD and hardware intrinsics
Organization: Microsoft
Type: Official platform documentation
Relevance: Documents System.Numerics and fixed-width hardware intrinsic options for vectorized algorithms and notes that complexity should be justified by measurement.
URL: https://learn.microsoft.com/en-us/dotnet/standard/simd

### S-006-04: .NET Channels
Organization: Microsoft
Type: Official platform documentation
Relevance: Provides producer/consumer synchronization structures for asynchronous message passing within .NET.
URL: https://learn.microsoft.com/en-us/dotnet/core/extensions/channels

### S-006-05: SpacetimeDB Reducers and Transactions
Organization: SpacetimeDB
Type: Official documentation
Relevance: Reducers are the mutation mechanism, execute in transactions, and provide isolation/atomicity/consistency. Useful reference architecture for state mutation and reactive application backends.
Limitation: Its database-centered model may not match the semantic needs of a simulation authority.
URL: https://spacetimedb.com/docs/functions/reducers/

### S-006-06: Apache Arrow Columnar Format
Organization: Apache Arrow
Type: Specification
Relevance: Language-independent columnar representation designed for sequential access, vectorization, and zero-copy/shared-memory use cases.
Limitation: Arrow is primarily a data representation/interchange technology, not a world-state database or simulation scheduler.
URL: https://arrow.apache.org/docs/format/Columnar.html

### S-006-07: Unity DOTS
Organization: Unity
Type: Official technology documentation
Relevance: Demonstrates a mature data-oriented/ECS approach and native-code optimization from .NET/IL through Burst/LLVM.
Limitation: Unity's game-engine workload and architecture differ from World Engine's world-first simulation goals.
URL: https://unity.com/dots

### S-006-08: BEPUphysics v2
Author/organization: BEPU / Ian? [repository attribution requires verification before formal citation]
Type: Open-source implementation
Relevance: Pure C# 3D rigid-body physics targeting .NET 8, with collision, constraints, continuous collision detection, sleeping, spatial queries, and voxel-collidable examples.
Limitation: Physics engine suitability for World Engine's exact world/process model remains untested.
URL: https://github.com/bepu/bepuphysics2

### S-006-09: V-JEPA 2
Authors: Mido Assran et al.
Type: Peer-reviewed/preprint research
Relevance: Demonstrates learned latent representations capable of physical-world understanding, prediction, and action-conditioned planning.
Limitation: Workload differs from authoritative symbolic/stateful simulation and does not establish long-horizon persistent-world correctness.
URL: https://arxiv.org/abs/2506.09985

### S-006-10: Genie 3
Organization: Google DeepMind
Type: Research/model documentation
Relevance: Demonstrates real-time interactive generated environments and increasingly explicit world-model behavior.
Limitation: DeepMind itself identifies limited action space, ongoing multi-agent interaction challenges, imperfect real-world location accuracy, and limited continuous interaction duration.
URL: https://deepmind.google/models/genie/

## Evidence

### E-006-01
**Claim:** .NET 10 is the currently supported LTS .NET release through November 2028.
**Type:** Official platform documentation
**Source:** S-006-02
**Strength:** E1
**Confidence:** High
**Interpretation:** If starting the production engine today, .NET 10 is a more rational baseline than beginning new work on .NET 8 solely because the existing prototype uses it.

### E-006-02
**Claim:** .NET provides multiple native vectorization layers, including fixed-width intrinsics.
**Type:** Official platform documentation
**Source:** S-006-03
**Strength:** E1
**Confidence:** High
**Interpretation:** The runtime does not force us to abandon C# for performance-sensitive numeric work. Actual World Engine workloads still require measurement.

### E-006-03
**Claim:** .NET Channels provide asynchronous producer/consumer primitives suitable for in-process pipelines.
**Type:** Official platform documentation
**Source:** S-006-04
**Strength:** E1
**Confidence:** High
**Interpretation:** The initial engine can use ordinary .NET concurrency primitives before introducing a specialized actor/distributed runtime.

### E-006-04
**Claim:** SpacetimeDB reducers provide transactional mutation and rollback behavior.
**Type:** Official database documentation
**Source:** S-006-05
**Strength:** E1
**Confidence:** High
**Interpretation:** SpacetimeDB is a serious candidate for a persistence/reactive backend or prototype authority implementation, but the database's semantics should not automatically define World Engine semantics.

### E-006-05
**Claim:** Columnar layouts can provide data locality and vectorization advantages, while mutation is comparatively more expensive.
**Type:** Specification/documentation
**Source:** S-006-06
**Strength:** E1
**Confidence:** High
**Interpretation:** Columnar structures are attractive for simulation subsystems and research/analytics, especially for large homogeneous datasets, but not every world object should automatically become columnar.

### E-006-06
**Claim:** Mature ECS/data-oriented systems can scale processing through data-oriented organization and optimized native execution.
**Type:** Official implementation documentation
**Source:** S-006-07
**Strength:** E1
**Confidence:** Medium-High
**Interpretation:** ECS/data-oriented execution deserves direct benchmarking against alternatives rather than dismissal or automatic adoption.

### E-006-07
**Claim:** BEPUphysics v2 provides a C#-native 3D physics implementation with broad rigid-body and spatial query functionality.
**Type:** Open-source implementation documentation
**Source:** S-006-08
**Strength:** E1
**Confidence:** High
**Interpretation:** It is a strong first physics candidate for a .NET prototype, subject to license, correctness, determinism, and workload benchmarking.

### E-006-08
**Claim:** V-JEPA 2 demonstrates useful physical-world prediction/planning capabilities.
**Type:** Research paper
**Source:** S-006-09
**Strength:** E1
**Confidence:** High for stated experiments
**Interpretation:** Learned predictive representations are increasingly relevant to World Engine's AI research layer, but this is not evidence that learned latent state can replace authoritative simulation state.

### E-006-09
**Claim:** Genie 3 can generate and maintain interactive environments for minutes at real-time rates, while its documented limitations include action-space and multi-agent constraints.
**Type:** Primary research-lab documentation
**Source:** S-006-10
**Strength:** E1
**Confidence:** High for stated system
**Interpretation:** Learned generative worlds are advancing quickly, making continued world-model research strategically important. They currently look more suitable as a separate research capability than as the authoritative World Engine substrate.

## Findings

### F-006-01: Core language/runtime
The current repository and ALPHA prototype make C# a low-friction starting point. Current .NET 10 LTS provides sufficient systems-level facilities for concurrency, vector math, native deployment, and high-performance code paths. This supports retaining C#/.NET as the primary runtime pending benchmark evidence.

**Confidence:** High for development suitability; Medium for final performance suitability.

### F-006-02: Execution model
The first-principles requirement is data-oriented execution where the workload benefits from it, not ECS as an ideology. A hybrid model is currently the strongest hypothesis: explicit domain/state contracts combined with data-oriented storage and systems for hot homogeneous workloads.

**Confidence:** Medium.

### F-006-03: Authoritative state
The architecture should retain an engine-level semantic authority boundary. A database can implement persistence, transactional mutation, replication, or even a prototype authority, but the World Engine contract should not be defined by a database's table model.

**Confidence:** High as a first-principles constraint; low-to-medium regarding the best implementation.

### F-006-04: Persistence
The research does not yet justify a final database. Embedded key-value stores, relational databases, append-only logs, and database-centric systems each solve different parts of the persistence problem. A staged prototype should test recovery, snapshotting, mutation throughput, random access, and provenance requirements before selecting one.

**Confidence:** High.

### F-006-05: Physics
BEPUphysics v2 is the strongest immediate C#-native candidate identified in this pass. It should be benchmarked against a small native/custom physics baseline and, where useful, alternatives such as Jolt. Physics should remain a replaceable capability.

**Confidence:** Medium-High for candidate selection; low for final adoption.

### F-006-06: Data interchange and research path
Apache Arrow is attractive for simulation-to-analysis boundaries because it provides a standardized columnar representation and zero-copy-oriented data movement. It is better viewed as a research/data interchange layer than as the authoritative world representation.

**Confidence:** Medium-High.

### F-006-07: Networking
The repository's projection/perception principle implies that networking should expose authorized projections rather than replicate arbitrary internal state. A concrete transport remains unresolved. This should be researched after the observation contract is defined.

**Confidence:** High on the requirement, low on the technology.

### F-006-08: Distribution
HLA confirms that distributed simulation is a mature field with explicit federation responsibilities and coordinated exchange, but this does not establish HLA as the runtime model. World Engine should first measure locality, cross-boundary interaction frequency, authority migration cost, and failure semantics in a single-process prototype.

**Confidence:** High.

### F-006-09: AI/world models
The external state of the field has moved materially toward interactive world models. V-JEPA 2 and Genie 3 make the AI research layer more strategically important, but neither provides evidence sufficient to replace explicit authoritative state for a persistent simulation. The correct architecture is currently a bounded model interface around the engine, not model-defined reality.

**Confidence:** High.

## Candidate Stack, Preliminary

### Core

**Recommended now:**

```text
C#
.NET 10 LTS
System.Numerics
System.Threading.Channels
```

.NET 10 is currently LTS through November 2028. The existing ALPHA prototype already demonstrates C# integration, while current .NET provides native vectorization and asynchronous pipeline primitives. citehttps://learn.microsoft.com/en-us/dotnet/core/releases-and-supporthttps://learn.microsoft.com/en-us/dotnet/standard/simdhttps://learn.microsoft.com/en-us/dotnet/core/extensions/channels

### Simulation execution

**Preliminary direction:** custom domain contracts + data-oriented storage/systems.

**Do not yet commit to:** a specific ECS framework.

Test:

```text
A. object/component baseline
B. archetype ECS
C. SoA/columnar custom storage
D. hybrid ECS + specialized stores
```

### Physics

**First candidate:** BEPUphysics v2.

**Alternatives for comparison:** Jolt Physics, custom specialized simulation components, and other C#-accessible engines.

The initial requirement is a replaceable physics capability, not a physics engine dependency.

### Persistence

**Preliminary architecture:** separate semantic world authority from durable persistence.

Candidates requiring controlled comparison:

```text
SpacetimeDB
PostgreSQL
RocksDB
SQLite / embedded relational
custom append-only transition log + snapshots
hybrid state + log
```

RocksDB is an embeddable persistent key-value store optimized for fast storage and exposes flexible write/compaction behavior. DuckDB is compelling for analytical workloads because its execution engine is vectorized, but it should not be confused with an authoritative transactional simulation store. citehttps://rocksdb.org/https://duckdb.org/docs/current/internals/vector

### Spatial representation

**Preliminary direction:** hierarchical spatial indexing with representation-specific structures.

No final choice yet between:

```text
uniform grids
sparse voxel structures
BVH / dynamic trees
octrees
Morton/Z-order structures
spatial database indexes
hybrid locality structures
```

The spatial layer should be driven by interaction/query patterns rather than terrain rendering alone.

### Networking / projection

**Preliminary direction:** capability-scoped projection layer above transport.

Transport candidates should be compared only after the observation contract is specified. QUIC, WebSockets, UDP-based game networking, and reliable message transports remain candidates.

### Rendering

**Preliminary direction:** keep renderer separate from simulation.

OpenTK remains a reasonable C# OpenGL/Vulkan-oriented implementation candidate, but renderer choice should not constrain world state representation.

### Research / analytics

**Preliminary direction:** Arrow/Parquet-compatible research data path.

Simulation should be able to export structured observations, transitions, snapshots, and experiment results into formats optimized for analysis and ML without coupling the authoritative runtime to the analytics stack.

### AI / ML

**Preliminary direction:** separate AI research runtime connected through explicit observation/action/model interfaces.

Potential stack:

```text
Python
PyTorch ecosystem
Hugging Face ecosystem
JEPA-family models
other learned world models
```

The engine remains authoritative. Models predict, infer, compress, classify, propose, or plan through explicit contracts.

## Current Stack Recommendation

### Keep / strengthen

```text
C# / .NET as core runtime
GitHub as source/research/provenance repository
OpenTK as renderer candidate
```

### Adopt as immediate research candidates

```text
BEPUphysics v2
Apache Arrow
SpacetimeDB
RocksDB
PostgreSQL
DuckDB
```

### Keep explicitly provisional

```text
ECS framework selection
voxel authority
adaptive representation algorithm
SpacetimeDB as authoritative database
Hadean-style sharding
JEPA stack as world model
Abstract Drift
```

## Serious Alternatives and Contradictory Evidence

### Database-centric authority
SpacetimeDB provides a compelling model in which reducers are transactional mutation boundaries. This is a legitimate argument for using a database-centric authority. The counterargument is that World Engine's authoritative state may need simulation semantics, scheduling, spatial locality, branching, and multiscale representations that do not map cleanly onto database tables. This is unresolved, not rejected.

### ECS-first architecture
Unity demonstrates that ECS/data-oriented architecture can scale large game workloads. The counterargument is that World Engine's state may be heterogeneous, spatially structured, and process-centric enough that a single ECS abstraction becomes constraining. This requires workload experiments.

### Learned world as simulator
V-JEPA 2 and Genie 3 show rapid progress toward learned predictive and interactive worlds. The counterargument is that current systems have explicit task/domain limitations and do not establish durable symbolic authority, arbitrary state mutation, exact recovery, or long-horizon persistence. The present recommendation is therefore to integrate models around the simulator rather than replacing the simulator with them.

### Distributed-first architecture
HLA demonstrates mature distributed simulation principles. The counterargument is economic: distribution adds consistency, synchronization, migration, and failure complexity. Until measured workloads require it, a single-process architecture is the correct baseline for establishing semantics.

## Unknowns

| Unknown | Importance | What resolves it | Blocks implementation? |
|---|---|---|---|
| authoritative state physical representation | Critical | workload-driven prototype | Yes for final core architecture |
| ECS vs custom SoA vs hybrid | Critical | benchmark | No for semantic prototypes |
| persistence technology | Critical | recovery/snapshot benchmark | No for prototype, yes for durable system |
| spatial structure | Critical | query/locality benchmark | No for early contracts |
| scheduler model | Critical | simulation semantics + load tests | Yes for production simulation |
| distributed partition strategy | High | single-process locality measurements + distributed prototype | No for first prototype |
| network transport | Medium | observation contract + latency tests | No for core simulation |
| physics engine | High | physics correctness/performance tests | Yes for physical simulation prototype |
| learned model integration | High | task-specific experiments | No for core runtime |
| long-horizon learned world-model viability | High | controlled experiments | No, unless architecture changes to learned authority |

## Assumptions

1. The first production-oriented prototype can run as a single process.
2. The core simulation can be written in C# without sacrificing required performance.
3. Most high-frequency simulation workloads will benefit from data-oriented memory organization.
4. Not all world information needs to be represented at maximum fidelity at all times.
5. AI models can operate through explicit observation/action boundaries.
6. Distributed execution can be added after semantic contracts are established.

All six assumptions require eventual validation; none is architectural authority yet.

## Engineering Implications

```text
First principle
  ↓
Required capability
  ↓
Likely implementation direction
```

**Authority →** engine-level authoritative state boundary → persistence/database remains replaceable.

**High-throughput state processing →** data-oriented storage → benchmark ECS/SoA/hybrid.

**Temporal evolution →** explicit scheduler/process model → do not hide time inside database or networking.

**Spatial causality →** dedicated spatial index/locality layer → benchmark grid/tree/hierarchy structures.

**Physics →** replaceable physics capability → BEPUphysics v2 first benchmark candidate.

**Observation →** projection layer → transport becomes an implementation detail.

**Persistence →** snapshots + durable transition/recovery mechanism → compare database/log/embedded approaches.

**Research →** Arrow/Parquet-compatible export → analytics and ML remain decoupled from runtime authority.

**AI →** explicit model interfaces → JEPA/world models remain replaceable research components.

**Distribution →** partitionable authority and locality contracts → defer implementation until workload data exists.

## Preliminary Recommendation

### Recommendation
Proceed with a **C#/.NET 10 core simulation runtime**, built around explicit semantic contracts and a data-oriented/hybrid execution strategy, with separate layers for persistence, spatial indexing, physics, projection/networking, rendering, analytics, and AI.

### Use now

```text
C#
.NET 10 LTS
System.Numerics
System.Threading.Channels
GitHub
```

### Prototype next

```text
BEPUphysics v2
custom SoA/archetype data layouts
SpacetimeDB adapter
embedded persistence adapter
Arrow/Parquet export
OpenTK rendering adapter
```

### Do not lock yet

```text
specific ECS framework
specific database as world authority
specific sharding architecture
specific voxel representation
specific adaptive representation algorithm
specific JEPA model/stack
```

### Confidence

**Overall:** Medium.

The confidence is high for the semantic separation and the decision to keep implementation choices replaceable. It is only medium for the concrete technology choices because the repository does not yet contain the production workload needed to benchmark them.

## Architectural Impact

**Existing Contract Extension / Implementation Detail**, with several future ADR candidates.

This research should not itself promote a specific database, ECS, physics engine, spatial structure, or AI model to Green architecture.

## ADR Candidates

Do not create final ADRs yet for every item. The following deserve ADRs after validation:

1. Core runtime language/platform
2. authoritative state boundary
3. execution/data layout model
4. persistence architecture
5. spatial architecture
6. simulation scheduler/time semantics
7. physics capability boundary and implementation
8. observation/projection protocol
9. distribution/sharding architecture
10. AI/model interface

## Validation Plan

The next implementation should produce a **stack benchmark harness** rather than prematurely building the whole engine.

Required workloads:

```text
W1: entity/state mutation throughput
W2: spatial query throughput
W3: neighbor/interaction update throughput
W4: physics step throughput
W5: snapshot creation/restoration
W6: transition-log/replay cost
W7: projection generation cost
W8: Arrow export cost
W9: deterministic/reproducible replay
W10: cross-boundary interaction simulation
```

Compare at minimum:

```text
managed object baseline
SoA baseline
ECS/archetype baseline
hybrid baseline
```

For persistence compare at least one database-centric implementation and one engine-resident state + durable log/snapshot design.

The benchmark must report workload definition, data size, hardware, runtime version, build mode, configuration, random seeds, operation counts, latency/throughput, memory use, and failure/recovery behavior.

## Reproducibility

For future benchmark runs record:

```text
repository commit
.NET SDK/runtime version
compiler configuration
OS
CPU
GPU where relevant
RAM
dataset/world seed
simulation seed
benchmark parameters
candidate versions
build configuration
results
```

## Provenance

```text
Issue #20 / R-STACK-001
        ↓
Repository inspection
        ↓
First-principles requirements
        ↓
External standards / documentation / research
        ↓
Candidate comparison
        ↓
Preliminary stack recommendation
        ↓
Benchmark harness
        ↓
ADR(s)
        ↓
Specification(s)
        ↓
Implementation
        ↓
Validation
```

## Quality Gate

- [x] Question clearly defined
- [x] Scope defined
- [x] Existing architecture identified
- [x] Constraints identified
- [x] Search strategy documented
- [x] Sources recorded
- [x] Evidence separated from interpretation
- [x] Competing approaches considered
- [x] Contradictory evidence considered
- [x] Unknowns recorded
- [x] Assumptions recorded
- [x] Engineering implications identified
- [x] Recommendation explicit
- [x] Confidence stated
- [x] Validation plan defined
- [x] Provenance recorded
- [x] ADR requirement determined
- [x] Implementation impact identified

## Bottom Line

The research does **not** justify declaring a final World Engine stack yet.

It does justify a concrete starting posture:

> **Build the semantic core in C#/.NET 10, keep authority inside an explicit engine contract, use data-oriented execution where measurements justify it, treat persistence/physics/spatial indexing/networking/rendering/AI as replaceable capabilities, and use controlled benchmarks to determine the concrete implementations.**

The most important unresolved question is no longer "which technology sounds best?" It is:

> **What actual World Engine workload and state model must the stack optimize for?**

That question should drive the next prototype.
