# Issue Examination Protocol

**Status:** YELLOW / DRAFT
**Work Order:** #10
**Related:** Issue #11, Research Topic 005, Yellow/Red Issue Policy

## 1. Purpose

Define how a World Engine Issue is examined before it is resolved, rejected, deferred, or converted into executable work.

An Issue is a tracked object, not authority. Its existence must never be treated as permission to implement its proposed solution.

This protocol is a development-process protocol. It does not define runtime architecture.

## 2. First-principles rule

> Define the claim. Identify the authority. Separate evidence from interpretation. Separate capability from implementation. Preserve provenance.

The examiner must first determine what is actually being claimed before deciding what should happen to it.

## 3. Object boundaries

| Object | Purpose | Authority |
|---|---|---|
| Discussion | Open deliberation, brainstorming, objections, competing ideas | None |
| Issue | Track a consequential question, problem, concern, defect, uncertainty, or rejected proposition | None |
| Research | Gather and analyze evidence | Evidence, not authority |
| Experiment | Produce bounded empirical evidence | Evidence, not authority |
| Decision | Record an explicit project choice | Authority only when explicitly designated |
| Specification / Contract | Define authoritative behavior or boundary | Authoritative |
| Research Order | Delegate a bounded investigation when delegation/traceability is useful | Authorizes investigation, not architecture |
| Experiment Order | Delegate a bounded experiment | Authorizes the experiment, not its conclusion |
| Work Order | Delegate an authorized implementation or other concrete project change | Authorizes execution within stated scope, not authority to redefine the contract |
| Pull Request | Propose repository changes | None until accepted through the applicable gate |
| Validation | Demonstrate that a result satisfies stated criteria | Evidence for promotion |
| Authority | Explicitly promoted project artifact or contract | Authoritative |

These are semantic roles, not a requirement that every role become a separate file, database object, or workflow.

## 4. Anti-bloat test

Before introducing a new process object, ask:

1. Does it represent a genuinely different responsibility or authority boundary?
2. Does it preserve information or provenance that an existing object cannot cleanly preserve?
3. Does it enable useful delegation, parallelism, review, or automation?
4. Can its lifecycle be expressed as metadata on an existing object without losing meaning?
5. Would removing it make the process materially less safe or less understandable?

If the answer to the final question is no, do not create the additional object.

A Research Order, Experiment Order, or Work Order is therefore optional as a distinct artifact. It is justified when an actual bounded task must be assigned, tracked, delegated, or referenced independently.

## 5. Examination lifecycle

```text
INTAKE
  -> TRIAGE
  -> EXAMINATION
  -> EVIDENCE
  -> EVALUATION
  -> CLASSIFICATION
  -> RESOLUTION PLAN
```

Stages may be combined when the Issue is trivial and the combined record remains auditable. A stage must not be skipped merely to accelerate a consequential decision.

### 5.1 INTAKE

Record:
- Issue identity and origin
- Claim/question/problem
- Reporter or originating agent where relevant
- Related Discussion, research, experiment, decision, contract, or implementation
- Initial scope

### 5.2 TRIAGE

Determine:
- Is the Issue actionable?
- Is it duplicate, obsolete, or already authoritative elsewhere?
- Is it consequential enough to require active tracking?
- Is it primarily a defect, uncertainty, research question, proposal, process problem, or negative-evidence record?
- What authority boundary could be affected?

Trivial uncertainty may be handled conversationally. Consequential uncertainty should remain tracked.

### 5.3 EXAMINATION

Identify:
- exact proposition or failure
- established invariants
- authoritative artifacts currently governing the area
- affected boundaries
- competing interpretations or solutions
- assumptions
- reversibility
- risk and impact
- what would falsify the proposition

The examiner must distinguish an observed fact from an inference and from a proposed solution.

### 5.4 EVIDENCE

Classify evidence using E0-E6 from Research Topic 005:

- E0 speculation
- E1 literature / external evidence
- E2 reasoned architectural analysis
- E3 prototype
- E4 controlled experiment
- E5 reproducible validation
- E6 integrated validation

Evidence level is descriptive. It does not automatically confer authority or determine Green/Yellow/Red status.

### 5.5 EVALUATION

Compare evidence against:
- invariants
- acceptance criteria
- risk
- impact
- reversibility
- implementation cost where relevant
- reproducibility
- provenance requirements
- alternative approaches

For architecture, ask whether the result establishes a capability/contract or merely validates one implementation.

### 5.6 CLASSIFICATION

Classify the Issue's substantive outcome separately from any repository promotion gate.

Possible outcomes include:
- unresolved
- supported
- experimentally supported
- validated
- contradicted
- rejected
- duplicate / superseded
- deferred

Do not use "insufficient evidence" as a synonym for "rejected." Insufficient evidence normally means the proposition remains unresolved unless evidence establishes a reason for rejection.

The exact relationship between this classification and Green/Yellow/Red remains subject to Issue #11.

### 5.7 RESOLUTION PLAN

State:
- proposed resolution class
- required research, experiment, decision, or implementation
- acceptance criteria
- required authority artifact
- provenance links
- responsible agent/person if delegation is needed
- conditions for reopening

If implementation is required, create a Work Order only when there is an actual bounded implementation task to execute.

## 6. Evidence and authority are independent

A strong evidence result does not automatically become architecture.

Likewise, a low-risk documentation change may be authoritative without requiring E6 experimentation.

The examiner must therefore record both:
- what is known and how strongly it is supported;
- what, if anything, has been explicitly authorized.

## 7. AI examination rule

An AI agent must examine before implementing consequential Issue content.

The agent must:
1. locate the current authoritative contract;
2. identify the Issue's claim and evidence;
3. detect contradictions;
4. determine whether existing authority is sufficient;
5. create or update Yellow tracking when consequential uncertainty is discovered;
6. create Red tracking only when sufficient evidence establishes rejection;
7. stop rather than invent authority when the requested change lacks an authoritative basis.

The agent may perform research or experiments within an authorized order, but must not convert their results into architecture without the required decision and promotion path.

## 8. Minimum examination record

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

## 9. Relationship to other processes

```text
Discussion
   |
   v
Issue
   |
   v
Examination
   |
   +--> Research Order -> Research --+
   |                                  |
   +--> Experiment Order -> Experiment +--> Evaluation -> Decision
   |                                                   |
   +-----------------------------------------------+   |
                                                   v   v
                                               Work Order
                                                   |
                                                   v
                                                  PR
                                                   |
                                                   v
                                               Validation
                                                   |
                                                   v
                                                Authority
```

The diagram describes possible relationships, not mandatory object creation.

## 10. Promotion gate boundary

Green/Yellow/Red is a promotion/development-control mechanism unless Issue #11 establishes a more precise scoped definition.

It must not be used to collapse all of the following into one meaning:
- evidence confidence
- issue state
- architectural authority
- implementation readiness
- repository disposition

## 11. Acceptance

This protocol is not authoritative until:
- Issue #11 is resolved;
- the protocol has been tested against existing Issues #5-#9;
- redundant process layers have been identified and removed where unnecessary;
- the final relationship between Issue state, Green/Yellow/Red, Orders, Decisions, Specifications, PRs, and Validation is documented;
- the resulting protocol passes its own consistency review.
