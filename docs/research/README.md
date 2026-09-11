# Research Process

Research exists to reduce uncertainty about the system. It does not automatically modify the architecture.

The required chain is:

```text
QUESTION
  ↓
EVIDENCE
  ↓
FINDINGS
  ↓
COMPARISON
  ↓
ENGINEERING IMPLICATION
  ↓
ARCHITECTURAL DECISION
  ↓
ADR
  ↓
SPECIFICATION
  ↓
IMPLEMENTATION
  ↓
VALIDATION
```

The reverse lineage must remain recoverable:

```text
IMPLEMENTATION
  ↓
ARCHITECTURE
  ↓
DECISION
  ↓
RECOMMENDATION
  ↓
ANALYSIS
  ↓
EVIDENCE
  ↓
QUESTION
```

## Research requirements

A research record should identify the precise question, existing architectural constraints, scope, hypotheses where useful, search strategy, source provenance, evidence and evidence strength, competing approaches, contradictory evidence, unknowns and assumptions, engineering implications, recommendation and confidence, validation plan, ADR requirement, and implementation impact.

## Evidence discipline

The project must distinguish:

```text
Paper              != Requirement
Method             != Capability
Benchmark          != Universal Truth
Recommendation     != Architecture
Prototype          != Production
Research Finding   != Architectural Decision
```

Primary and authoritative sources should be preferred. Search snippets are not proof. Popularity is not correctness. Missing information must not be invented.

## Research depth

### Level 0
Existing architecture or implementation already answers the question.

### Level 1
Quick authoritative verification of a factual implementation detail.

### Level 2
Technical comparison of multiple implementation approaches.

### Level 3
Architectural research requiring alternatives, engineering implications, and normally an ADR.

### Level 4
Experimental research where literature cannot adequately answer the question.

## AI researcher requirements

AI research agents must state the question, identify constraints, separate facts from assumptions, search competing approaches, preserve provenance, record contradictory evidence, identify unknowns, translate findings into engineering implications, state confidence, and make unresolved questions explicit.

AI agents must not invent citations, treat snippets as proof, equate sophistication with suitability, silently change architectural definitions, hide contradictory evidence, or turn implementation preferences into architectural requirements.
