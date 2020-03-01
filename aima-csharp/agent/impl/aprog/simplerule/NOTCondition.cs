using System;
using System.Diagnostics;
using System.Text;

namespace aima.core.agent.impl.aprog.simplerule
{
    /**
     * Implementation of a NOT condition.
     * 
     * @author Ciaran O'Reilly
     * 
     */
    public class NOTCondition : Condition
    {
        private readonly Condition con;

        public NOTCondition(Condition c)
        {
            Debug.Assert(null != con);

            con = c;
        }

        public override bool evaluate(ObjectWithDynamicAttributes p)
        {
            return (!con.evaluate(p));
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            return sb.Append("![").Append(con).Append("]").ToString();
        }
    }
}