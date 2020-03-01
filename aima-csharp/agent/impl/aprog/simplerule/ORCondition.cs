using System;
using System.Diagnostics;
using System.Text;

namespace aima.core.agent.impl.aprog.simplerule
{
    /**
     * Implementation of an OR condition.
     * 
     * @author Ciaran O'Reilly
     * 
     */
    public class ORCondition : Condition
    {
        private readonly Condition left;

        private readonly Condition right;

        public ORCondition(Condition leftCon, Condition rightCon)
        {
            Debug.Assert(null != leftCon);
            Debug.Assert(null != rightCon);

            left = leftCon;
            right = rightCon;
        }

        public override bool evaluate(ObjectWithDynamicAttributes p)
        {
            return (left.evaluate(p) || right.evaluate(p));
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            return sb.Append("[").Append(left).Append(" || ").Append(right).Append(
                    "]").ToString();
        }
    }
}