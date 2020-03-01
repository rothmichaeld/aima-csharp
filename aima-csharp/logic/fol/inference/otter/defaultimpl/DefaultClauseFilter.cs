using aima.core.logic.fol.kb.data;
using System.Collections.Generic;

namespace aima.core.logic.fol.inference.otter.defaultimpl
{
    /**
     * @author Ciaran O'Reilly
     * 
     */
    public class DefaultClauseFilter : ClauseFilter
    {
        public DefaultClauseFilter()
        {

        }

        // START-ClauseFilter

        public HashSet<Clause> filter(HashSet<Clause> clauses)
        {
            return clauses;
        }

        // END-ClauseFilter
    }
}