using aima.core.logic.fol.kb.data;
using aima.core.logic.fol.parsing.ast;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace aima.core.logic.fol.inference.proof
{
    /**
     * @author Ciaran O'Reilly
     * 
     */
    public class ProofStepFoChAssertFact : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Clause implication = null;
        private readonly Literal fact = null;
        private readonly Dictionary<Variable, Term> bindings = null;

        public ProofStepFoChAssertFact(Clause implication, Literal fact,
            Dictionary<Variable, Term> bindings, ProofStep predecessor)
        {
            this.implication = implication;
            this.fact = fact;
            this.bindings = bindings;
            if (null != predecessor)
            {
                predecessors.Add(predecessor);
            }
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            StringBuilder sb = new StringBuilder();
            List<Literal> nLits = implication.getNegativeLiterals();
            for (int i = 0; i < implication.getNumberNegativeLiterals(); i++)
            {
                sb.Append(nLits[i].getAtomicSentence());
                if (i != (implication.getNumberNegativeLiterals() - 1))
                {
                    sb.Append(" AND ");
                }
            }
            sb.Append(" => ");
            sb.Append(implication.getPositiveLiterals()[0]);
            return sb.ToString();
        }

        public override String getJustification()
        {
            return "Assert fact " + fact.ToString() + ", " + bindings;
        }

        // END-ProofStep	
    }
}