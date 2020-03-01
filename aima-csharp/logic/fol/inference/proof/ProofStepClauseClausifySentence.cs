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
    public class ProofStepClauseClausifySentence : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Clause clausified = null;

        public ProofStepClauseClausifySentence(Clause clausified,
                Sentence origSentence)
        {
            this.clausified = clausified;
            predecessors.Add(new ProofStepPremise(origSentence));
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return clausified.ToString();
        }

        public override String getJustification()
        {
            return "Clausified " + predecessors[0].getStepNumber();
        }

        // END-ProofStep
    }
}