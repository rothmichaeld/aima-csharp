using System;

namespace aima.core.search.local
{
    /**
     * @author Ravi Mohan
     * 
     */
    public class Scheduler
    {
        private readonly int k, limit;
        private readonly double lam;

        public Scheduler(int k, double lam, int limit)
        {
            this.k = k;
            this.lam = lam;
            this.limit = limit;
        }

        public Scheduler()
        {
            k = 20;
            lam = 0.045;
            limit = 100;
        }

        public double getTemp(int t)
        {
            if (t < limit)
            {
                double res = k * Math.Exp((-1) * lam * t);
                return res;
            }
            else
            {
                return 0.0;
            }
        }
    }
}