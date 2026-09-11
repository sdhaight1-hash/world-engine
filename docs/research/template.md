# Research Record Template

## Metadata

```text
Research ID:
Title:
Status:
Priority:
Created:
Updated:
Researcher:
Reviewer:
Related ADRs:
Related Architecture Sections:
Related Contracts:
Related Schemas:
```

## Question

### Primary Question

What exactly are we trying to determine, and what decision could the answer eventually support?

## Context

```text
Current architecture:
Current implementation:
Current assumptions:
Current limitation:
Blocked decision:
```

## Scope

### In scope

- 

### Out of scope

- 

## Architectural Constraints

Record each constraint, source, reason, and whether it must be preserved.

## Research Questions

```text
RQ-001:
RQ-002:
RQ-003:
```

## Hypotheses

```text
H-001
Statement:
Reason:
Status: Untested | Supported | Weakly Supported | Contradicted | Rejected | Inconclusive
```

## Search Strategy

```text
Search Objective:
Search Terms:
Sources:
Date Range:
Standards Consulted:
Literature:
Documentation:
Implementations:
Benchmarks:
Experiments:
```

## Sources

For each meaningful source record title, author, organization, publication/access date, type, URL/DOI where applicable, relevance, reliability, claims supported, limitations, and provenance.

## Evidence

For each important claim record:

```text
Evidence ID:
Source ID:
Claim:
Evidence Type:
Exact Location:
Supporting Observation:
Strength:
Confidence:
Limitations:
Contradictory Evidence:
Interpretation:
```

## Findings

For each finding:

```text
Finding:
Evidence:
Conditions:
Limitations:
Confidence:
Architectural relevance:
```

## Method Comparison

Compare serious candidates using a common basis:

```text
Method
Problem Class
Inputs
Outputs
Assumptions
Guarantees
Accuracy
Stability
Complexity
Memory
Parallelism
Adaptivity
Incrementality
Composability
Error Estimation
Validation
Failure Modes
Implementation Difficulty
Maturity
References
```

## Contradictory Evidence

Record evidence that challenges the preferred conclusion. Classify resolution as condition difference, scope difference, definition difference, implementation difference, genuine contradiction, or unresolved.

## Unknowns

For each unknown record why it remains unknown, importance, required research/experiment, and whether it blocks implementation.

## Assumptions

For each assumption record reason, confidence, impact if false, validation method, and status.

## Engineering Implications

Translate findings into:

```text
Finding
  ↓
Implication
  ↓
Required Capability
  ↓
Contract Impact
  ↓
Schema Impact
  ↓
Implementation Impact
  ↓
Testing Impact
```

## Recommendation

```text
Recommendation:
Use:
Because:
Do not use:
Because:
Confidence:
```

It is valid to recommend no decision when evidence is insufficient. State the required next experiment or research.

## Architectural Impact

Choose one:

```text
No Architectural Impact
Implementation Detail
Existing Contract Extension
New Contract
Schema Extension
New Architectural Concept
Architectural Revision
Foundational Architectural Change
```

## Decision Boundary

Keep the research conclusion separate from the architectural decision. Research can establish that a method performs better under specified conditions without making that method a mandatory architectural dependency.

## Validation

```text
Validation Question:
Metric:
Threshold:
Reference Baseline:
Failure Condition:
```

## Reproducibility

Record source versions, dataset versions, code versions, configuration, hardware, random seeds/stream state, environment, dependencies, parameters, procedure, results, and limitations.

## Provenance

Preserve the lineage:

```text
Question
 ↓
Search
 ↓
Sources
 ↓
Evidence
 ↓
Analysis
 ↓
Finding
 ↓
Recommendation
 ↓
Decision
 ↓
Implementation
 ↓
Validation
```

## Quality Gate

```text
[ ] Question clearly defined
[ ] Scope defined
[ ] Existing architecture identified
[ ] Constraints identified
[ ] Search strategy documented
[ ] Sources recorded
[ ] Evidence separated from interpretation
[ ] Competing approaches considered
[ ] Contradictory evidence considered
[ ] Unknowns recorded
[ ] Assumptions recorded
[ ] Engineering implications identified
[ ] Recommendation explicit
[ ] Confidence stated
[ ] Validation plan defined
[ ] Provenance recorded
[ ] ADR requirement determined
[ ] Implementation impact identified
```
