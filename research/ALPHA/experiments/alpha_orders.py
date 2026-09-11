from dataclasses import dataclass, field
from enum import Enum
from copy import deepcopy

class Kind(Enum):
    RESEARCH = "research"
    WORK = "work"
    INVESTIGATION = "investigation"
    EXPERIMENT = "experiment"
    VALIDATION = "validation"

class Authority(Enum):
    AGENT = "agent"
    DOMAIN_LEAD = "domain_lead"
    HUMAN = "human"

@dataclass
class Trigger:
    id: str
    kind: str
    description: str
    evidence: list[str] = field(default_factory=list)

@dataclass
class Order:
    id: str
    kind: Kind
    objective: str
    state: str = "active"
    required_authorization: Authority | None = None

@dataclass
class Transition:
    id: str
    order_id: str
    source: str
    target: str
    trigger: Trigger
    proposed_by: Authority
    authorized_by: Authority | None = None

class Runtime:
    def __init__(self):
        self.orders = {}
        self.transitions = []

    def register(self, order):
        assert order.id not in self.orders
        self.orders[order.id] = order

    def propose(self, order_id, target, trigger, proposer):
        order = self.orders[order_id]
        t = Transition(f"T-{len(self.transitions)+1:03d}", order_id, order.state,
                       target, trigger, proposer)
        self.transitions.append(t)
        return t

    def authorize(self, transition, authority):
        order = self.orders[transition.order_id]
        if order.required_authorization and authority != order.required_authorization:
            raise PermissionError(f"requires {order.required_authorization.value}")
        transition.authorized_by = authority
        order.state = transition.target


def run_experiments():
    results = []

    # Shared substrate across order kinds.
    runtime = Runtime()
    for i, kind in enumerate(Kind, 1):
        runtime.register(Order(f"O-{i:03d}", kind, f"Bounded {kind.value} objective"))
    results.append({"experiment": "unified_order_kinds", "passed": len(runtime.orders) == 5})

    # Agent proposal cannot authorize high-risk transition.
    high = Runtime()
    high.register(Order("O-HIGH", Kind.WORK, "Apply irreversible change", required_authorization=Authority.HUMAN))
    trigger = Trigger("X-HIGH", "evidence", "Required evidence present", ["E-1"])
    proposal = high.propose("O-HIGH", "exited", trigger, Authority.AGENT)
    rejected = False
    try:
        high.authorize(proposal, Authority.AGENT)
    except PermissionError:
        rejected = True
    high.authorize(proposal, Authority.HUMAN)
    results.append({"experiment": "proposal_authorization_separation", "passed": rejected and proposal.authorized_by == Authority.HUMAN})

    # Virtual branch preserves master state.
    master = {"chunk": {"bug": True, "value": 10}}
    branch = deepcopy(master)
    branch["chunk"]["value"] = 11
    branch["chunk"]["bug"] = False
    results.append({"experiment": "virtual_snapshot_branch", "passed": master["chunk"]["bug"] is True and branch["chunk"]["bug"] is False})

    # Methodology degradation generates research rather than self-modification.
    baseline = 0.90
    observed = 0.60
    methodology_research_required = observed < baseline - 0.10
    results.append({"experiment": "methodology_degradation", "passed": methodology_research_required,
                    "action": "create_methodology_research_order" if methodology_research_required else "continue"})

    return results

if __name__ == "__main__":
    import json
    print(json.dumps(run_experiments(), indent=2))
