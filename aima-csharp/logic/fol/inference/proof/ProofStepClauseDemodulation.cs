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
    public class ProofStepClauseDemodulation : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Clause demodulated = null;
        private readonly Clause origClause = null;
        private readonly TermEquality assertion = null;

        public ProofStepClauseDemodulation(Clause demodulated, Clause origClause,
                TermEquality assertion)
        {
            this.demodulated = demodulated;
            this.origClause = origClause;
            this.assertion = assertion;
            predecessors.Add(origClause.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return demodulated.ToString();
        }

        public override String getJustification()
        {
            return "Demodulation: " + origClause.getProofStep().getStepNumber()
                    + ", [" + assertion + "]";
        }

        // END-ProofStep
    }
}