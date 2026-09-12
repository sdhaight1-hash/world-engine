# Research 008: World Engine Database Research Order

**ID:** R-DB-001
**Status:** YELLOW / OPEN
**Parent:** R-STACK-002
**Purpose:** Determine what a World Engine database must be before selecting or implementing its physical storage engine.

## Research question

What database semantics and workload characteristics are required by World Engine, and do those requirements justify a World Engine-specific database/storage engine rather than adopting an existing database as the authoritative foundation?

## First-principles premise

The database must serve the world model. The world model must not be redesigned merely to fit a database.

A database for World Engine potentially needs to preserve:

- authoritative state
- entity/component state
- relationships
- spatial locality
- world time
- transitions
- versions
- snapshots
- branches
- provenance
- recovery state
- observer projections

## Required investigation

### 1. Define the semantic data model

Determine the minimum information required to represent authoritative world state independent of physical storage.

### 2. Define operations

Characterize:

- point reads
- component reads/writes
- bulk component updates
- relationship queries
- spatial queries
- temporal queries
- transition commits
- batch transitions
- snapshots
- branch creation
- branch comparison
- recovery
- historical reconstruction
- projection reads

### 3. Define consistency requirements

Determine which operations require:

- atomicity
- isolation
- ordering
- serializability
- causal consistency
- eventual consistency
- optimistic conflict detection

Do not assume all world operations require the strongest possible consistency.

### 4. Define physical workload

Measure representative distributions of:

- entity count
- component density
- mutation frequency
- read/write ratio
- locality
- hot/cold state
- object size
- temporal access
- snapshot frequency
- branch frequency
- recovery frequency

### 5. Compare storage families

Evaluate, at minimum:

```text
custom append/segment storage
LSM tree
B-tree / page-oriented storage
relational database
embedded database
in-memory + durable log
hybrid storage
```

Use existing systems as control implementations rather than architectural premises.

### 6. Determine whether a custom engine is justified

A custom storage engine should be justified only if measured requirements produce a material advantage that cannot reasonably be achieved through an existing substrate plus World Engine-owned semantic layers.

## Initial candidates

- custom World Engine storage engine
- RocksDB
- SQLite
- SpacetimeDB
- PostgreSQL as a conventional relational control

These are comparison targets, not selections.

## Required outputs

1. World Engine semantic database model.
2. Database operation contract.
3. Workload model.
4. Consistency matrix.
5. Storage-family comparison.
6. Benchmark specification.
7. Recommendation on custom storage engine.
8. If justified, preliminary storage architecture and implementation plan.
9. If not justified, explicit reasons and adapter boundary for external storage.

## Exit condition

We should be able to explain, from first principles and measurements:

> What must the World Engine database do, what does it not need to do, what workloads dominate, and why our chosen storage architecture is the simplest system that preserves the required invariants.

## Rule

Do not begin by implementing a production database.

Begin by defining the database semantics and measuring the workload.
