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
    public class ProofStepClauseBinaryResolvent : AbstractProofStep
    {
        private readonly List<ProofStep> predecessors = new List<ProofStep>();
        private readonly Clause resolvent = null;
        private readonly Literal posLiteral = null;
        private readonly Literal negLiteral = null;
        private readonly Clause parent1, parent2 = null;
        private readonly Dictionary<Variable, Term> subst = new Dictionary<Variable, Term>();
        private readonly Dictionary<Variable, Term> renameSubst = new Dictionary<Variable, Term>();
        private readonly Clause c;
        private readonly Clause clause;
        private readonly Clause othC;
        private readonly Dictionary<Variable, Term> copyRBindings;
        private readonly Dictionary<Variable, Term> renameSubstitituon;

        public ProofStepClauseBinaryResolvent(Clause resolvent, Literal pl,
            Literal nl, Clause parent1, Clause parent2,
            Dictionary<Variable, Term> subst, Dictionary<Variable, Term> renameSubst)
        {
            this.resolvent = resolvent;
            posLiteral = pl;
            negLiteral = nl;
            this.parent1 = parent1;
            this.parent2 = parent2;

            foreach (Variable key in subst.Keys)
            {
                this.subst.Add(key, subst[key]);
            }

            foreach (Variable key in renameSubst.Keys)
            {
                this.renameSubst.Add(key, renameSubst[key]);
            }

            predecessors.Add(parent1.getProofStep());
            predecessors.Add(parent2.getProofStep());
        }

        public ProofStepClauseBinaryResolvent(Clause c, Clause clause, Clause othC, Dictionary<Variable, Term> copyRBindings, Dictionary<Variable, Term> renameSubstitituon)
        {
            this.c = c;
            this.clause = clause;
            this.othC = othC;
            this.copyRBindings = copyRBindings;
            this.renameSubstitituon = renameSubstitituon;
        }

        // START-ProofStep

        public override List<ProofStep> getPredecessorSteps()
        {
            return new ReadOnlyCollection<ProofStep>(predecessors).ToList<ProofStep>();
        }

        public override String getProof()
        {
            return resolvent.ToString();
        }

        public override String getJustification()
        {
            int lowStep = parent1.getProofStep().getStepNumber();
            int highStep = parent2.getProofStep().getStepNumber();

            if (lowStep > highStep)
            {
                lowStep = highStep;
                highStep = parent1.getProofStep().getStepNumber();
            }

            return "Resolution: " + lowStep + ", " + highStep + "  [" + posLiteral
                    + ", " + negLiteral + "], subst=" + subst + ", renaming="
                    + renameSubst;
        }

        // END-ProofStep
    }
}