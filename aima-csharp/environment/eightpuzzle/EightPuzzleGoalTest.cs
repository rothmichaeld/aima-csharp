using aima.core.search.framework.problem;
using System;

namespace aima.core.environment.eightpuzzle
{
    /**
     * @author Ravi Mohan
     * 
     */
    public class EightPuzzleGoalTest : GoalTest
    {
        private readonly EightPuzzleBoard goal = new EightPuzzleBoard(new int[] { 0, 1, 2, 3, 4, 5,
            6, 7, 8 });

        public bool isGoalState(Object state)
        {
            EightPuzzleBoard board = (EightPuzzleBoard)state;
            return board.Equals(goal);
        }
    }
}