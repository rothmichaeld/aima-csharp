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
    public class ProofStepClauseParamodulation : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Clause paramodulated = null;
        private readonly Clause topClause = null;
        private readonly Clause equalityClause = null;
        private readonly TermEquality assertion = null;

        public ProofStepClauseParamodulation(Clause paramodulated,
            Clause topClause, Clause equalityClause, TermEquality assertion)
        {
            this.paramodulated = paramodulated;
            this.topClause = topClause;
            this.equalityClause = equalityClause;
            this.assertion = assertion;
            predecessors.Add(topClause.getProofStep());
            predecessors.Add(equalityClause.getProofStep());
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return paramodulated.ToString();
        }

        public override String getJustification()
        {
            return "Paramodulation: " + topClause.getProofStep().getStepNumber()
                + ", " + equalityClause.getProofStep().getStepNumber() + ", ["
                + assertion + "]";

        }

        // END-ProofStep
    }
}