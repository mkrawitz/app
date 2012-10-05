using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.bowling
{
    public class Player
    {
        private int _score = 0;
        private IThrowBalls throwSimulator;

        public Player (IThrowBalls throwSimulator)
        {
            this.throwSimulator = throwSimulator;
        }

        public int score()
        {
            return this._score;
        }

        public void throw_ball()
        {
            this._score += throwSimulator.pins_knocked_down();
        }
    }
}
