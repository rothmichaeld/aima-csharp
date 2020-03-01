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
    public class ProofStepChainDropped : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Chain dropped = null;
        private readonly Chain droppedOff = null;

        public ProofStepChainDropped(Chain dropped, Chain droppedOff)
        {
            this.dropped = dropped;
            this.droppedOff = droppedOff;
            predecessors.Add(droppedOff.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return dropped.ToString();
        }

        public override String getJustification()
        {
            return "Dropped: " + droppedOff.getProofStep().getStepNumber();
        }

        // END-ProofStep
    }
}