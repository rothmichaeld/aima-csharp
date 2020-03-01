using aima.core.logic.fol.kb.data;
using aima.core.logic.fol.parsing.ast;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace aima.core.logic.fol.inference.proof
{
    /**
     * @author Ciaran O'Reilly
     * 
     */
    public class ProofStepChainReduction : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Chain reduction = null;
        private readonly Chain nearParent, farParent = null;
        private readonly Dictionary<Variable, Term> subst = null;

        public ProofStepChainReduction(Chain reduction, Chain nearParent,
            Chain farParent, Dictionary<Variable, Term> subst)
        {
            this.reduction = reduction;
            this.nearParent = nearParent;
            this.farParent = farParent;
            this.subst = subst;
            predecessors.Add(farParent.getProofStep());
            predecessors.Add(nearParent.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return reduction.ToString();
        }

        public override String getJustification()
        {
            return "Reduction: " + nearParent.getProofStep().getStepNumber() + ","
                + farParent.getProofStep().getStepNumber() + " " + subst;
        }

        // END-ProofStep
    }
}