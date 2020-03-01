using aima.core.logic.fol.parsing.ast;
using System.Collections.Generic;

namespace aima.core.logic.fol
{
    /**
     * @author Ciaran O'Reilly
     * 
     */
    public class StandardizeApartResult
    {
        private readonly Sentence originalSentence = null;
        private readonly Sentence standardized = null;
        private readonly Dictionary<Variable, Term> forwardSubstitution = null;
        private readonly Dictionary<Variable, Term> reverseSubstitution = null;

        public StandardizeApartResult(Sentence originalSentence,
            Sentence standardized, Dictionary<Variable, Term> forwardSubstitution,
            Dictionary<Variable, Term> reverseSubstitution)
        {
            this.originalSentence = originalSentence;
            this.standardized = standardized;
            this.forwardSubstitution = forwardSubstitution;
            this.reverseSubstitution = reverseSubstitution;
        }

        public Sentence getOriginalSentence()
        {
            return originalSentence;
        }

        public Sentence getStandardized()
        {
            return standardized;
        }

        public Dictionary<Variable, Term> getForwardSubstitution()
        {
            return forwardSubstitution;
        }

        public Dictionary<Variable, Term> getReverseSubstitution()
        {
            return reverseSubstitution;
        }
    }
}