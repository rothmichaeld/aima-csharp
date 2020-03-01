using aima.core.logic.fol.kb.data;
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
    public class ProofStepChainContrapositive : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Chain contrapositive = null;
        private readonly Chain contrapositiveOf = null;

        public ProofStepChainContrapositive(Chain contrapositive,
            Chain contrapositiveOf)
        {
            this.contrapositive = contrapositive;
            this.contrapositiveOf = contrapositiveOf;
            predecessors.Add(contrapositiveOf.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return contrapositive.ToString();
        }

        public override String getJustification()
        {
            return "Contrapositive: "
                + contrapositiveOf.getProofStep().getStepNumber();
        }

        // END-ProofStep
    }
}