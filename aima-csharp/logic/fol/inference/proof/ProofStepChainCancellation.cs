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
    public class ProofStepChainCancellation : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Chain cancellation = null;
        private readonly Chain cancellationOf = null;
        private readonly Dictionary<Variable, Term> subst = null;

        public ProofStepChainCancellation(Chain cancellation, Chain cancellationOf,
            Dictionary<Variable, Term> subst)
        {
            this.cancellation = cancellation;
            this.cancellationOf = cancellationOf;
            this.subst = subst;
            predecessors.Add(cancellationOf.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return cancellation.ToString();
        }

        public override String getJustification()
        {
            return "Cancellation: " + cancellationOf.getProofStep().getStepNumber()
                + " " + subst;
        }

        // END-ProofStep
    }
}