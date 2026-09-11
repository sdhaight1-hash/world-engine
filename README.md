# World Engine

World Engine is a world-first simulation architecture for persistent, spatially grounded environments, agents, computation, and AI research.

The repository separates authoritative world state from representations, computation, perception, experimentation, and implementation details. The system is intended to evolve through explicit research, architectural decisions, specifications, implementation, and validation.

## Current architectural principles

- World state is authoritative and independent of any particular representation.
- Algorithms are replaceable behind runtime capabilities and contracts.
- Storage is not automatically world authority.
- Agents receive only state they are authorized to perceive or access.
- Counterfactual branches must not mutate their parent timelines.
- Authoritative transitions require provenance.
- Research findings do not become architecture automatically.
- Implementation details must not silently become architectural requirements.
- The system should support both human and AI implementation agents over long-lived development.

## Development rule

When in doubt, return to first principles: define the invariant, identify the authority, separate capability from implementation, and preserve provenance.

## Repository status

This repository is being established incrementally. Green-light material is committed first. Yellow-light material is documented as provisional or research-backed design guidance. Red-light ideas remain intentionally outside production architecture until validated.
