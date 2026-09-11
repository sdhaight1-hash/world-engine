# Issue Examination Protocol

**Status:** GREEN
**Related:** Work Order #10, Issue #11, Development Governance

## Purpose

Define how a World Engine Issue is examined before it is resolved, rejected, deferred, superseded, or converted into authorized work.

An Issue is a tracked claim, problem, concern, defect, uncertainty, proposal, or negative-evidence record. It is not authority.

## First-principles rule

> Define the claim. Identify the authority. Separate evidence from interpretation. Separate capability from implementation. Preserve provenance.

## Examination lifecycle

```text
INTAKE -> TRIAGE -> EXAMINATION -> EVIDENCE -> EVALUATION -> CLASSIFICATION -> RESOLUTION PLAN
```

Stages may be combined for trivial work when the resulting record remains understandable and auditable. Consequential work must not skip examination merely for convenience.

## 1. Intake

Record, as applicable:

- Issue identity and origin
- Claim, question, defect, or problem
- Reporter or originating agent when relevant
- Related Discussion, research, experiment, Decision, Contract, or implementation
- Initial scope

## 2. Triage

Determine:

- whether the Issue is actionable;
- whether it is duplicate, obsolete, superseded, or already governed elsewhere;
- whether it crosses the threshold for consequential tracking;
- whether it is primarily a defect, uncertainty, research question, proposal, process problem, or negative-evidence record;
- what authority boundary may be affected.

Trivial uncertainty may remain conversational. Consequential uncertainty should be tracked.

## 3. Examination

Identify:

- exact proposition or failure;
- current authoritative artifacts;
- established invariants;
- affected authority boundaries;
- competing interpretations or solutions;
- assumptions;
- risk, impact, and reversibility;
- what would falsify the proposition.

Distinguish observed fact from inference and proposed solution.

## 4. Evidence

Classify relevant evidence using E0-E6:

- E0: speculation
- E1: literature / external evidence
- E2: reasoned architectural analysis
- E3: prototype
- E4: controlled experiment
- E5: reproducible validation
- E6: integrated validation

Evidence level describes evidence strength. It does not automatically determine Green, Yellow, Red, Issue state, or authority.

## 5. Evaluation

Compare evidence against:

- invariants;
- acceptance criteria;
- risk and impact;
- reversibility;
- reproducibility;
- provenance requirements;
- alternatives;
- capability versus implementation boundaries.

## 6. Classification

Record a substantive outcome separately from promotion status. Useful outcomes include:

- unresolved;
- supported;
- experimentally supported;
- validated;
- contradicted;
- rejected;
- duplicate / superseded;
- deferred.

**Insufficient evidence is not synonymous with rejected.** If evidence does not establish acceptance or rejection, the proposition normally remains unresolved and Yellow.

## 7. Resolution plan

State:

- proposed resolution class;
- required research, experiment, decision, or implementation;
- acceptance criteria;
- required authority artifact;
- provenance links;
- responsible person or agent if delegation is needed;
- conditions for reopening.

Create an Order only when bounded delegation, accountability, scheduling, parallelism, or provenance provides real value.

## Minimum examination record

```text
Issue: #...
Type: defect | uncertainty | research | proposal | process | negative-evidence | other
Current state: ...
Claim / problem: ...
Authority consulted: ...
Evidence: E0-E6 + references
Invariants affected: ...
Risk: LOW | MEDIUM | HIGH
Impact: LOW | MEDIUM | HIGH
Reversibility: HIGH | MEDIUM | LOW
Evaluation: ...
Substantive outcome: ...
Remaining uncertainty: ...
Resolution class: ...
Required authority artifact: ...
Provenance: ...
Reopen condition: ...
```

## AI examination rule

An AI agent must examine before implementing consequential Issue content. It must locate current authority, identify the claim and evidence, detect contradictions, and determine whether authority is sufficient.

The agent should create or update Yellow tracking when consequential uncertainty is discovered, and Red tracking only when sufficient evidence establishes rejection.

If no authoritative basis exists for the requested implementation, the agent must stop and preserve the unresolved question rather than invent authority.
