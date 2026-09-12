# Research 006A: Stack Benchmark Order

**Status:** YELLOW
**Purpose:** Generate empirical evidence for the unresolved World Engine stack choices identified by Research 006.

## Objective

Build a small benchmark harness that tests the workload classes most likely to determine the core architecture before production-scale implementation begins.

## Required comparisons

### State execution

1. conventional object/reference state
2. Structure-of-Arrays state
3. archetype ECS
4. hybrid domain model + specialized SoA/ECS stores

### Persistence

1. engine-resident state + snapshots/log
2. database-centric state using a SpacetimeDB adapter
3. embedded durable store candidate

### Spatial

1. uniform grid
2. hierarchical tree/BVH
3. sparse spatial structure
4. hybrid spatial index

### Physics

1. BEPUphysics v2
2. alternative physics candidate
3. minimal custom specialized baseline where appropriate

## Workloads

```text
W1 state mutation
W2 spatial lookup
W3 neighbor interaction
W4 physics update
W5 snapshot/restore
W6 replay
W7 projection generation
W8 analytical export
W9 reproducible replay
W10 cross-partition interaction
```

## Required measurements

- throughput
- p50/p95/p99 latency where meaningful
- memory footprint
- allocation rate / GC pressure
- CPU utilization
- cache-sensitive behavior where measurable
- snapshot size/time
- recovery time
- replay time
- serialization/transport cost
- cross-boundary synchronization cost

## Gate

No benchmark result automatically becomes architecture. Results become E4 evidence that can support an explicit Decision and later ADR.

## Exit criterion

At least one candidate must demonstrate a clear workload-level advantage or disadvantage for each unresolved stack decision, or the result must explicitly remain inconclusive and identify the missing experiment.
