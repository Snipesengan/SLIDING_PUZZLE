using System;
using System.Collections.Generic;

namespace SLIDING_PUZZLE
{
    class TilePuzzle : IAtomicStateModel<TilePuzzleAction>
    {
        public const int DEFAULT_SIZE = 3;
        public int EmptyPos { get; private set; }

        public string State
        {
            get
            {
                return ToString();
            }
        }

        private int[] _board;


        public TilePuzzle()
        {
            _board = new int[(int)Math.Pow(DEFAULT_SIZE, 2)];

            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = i;
            }

            EmptyPos = 0;
        }

        public TilePuzzle(int inSize)
        {
            _board = new int[(int)Math.Pow(inSize, 2)];

            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = i;
            }

            EmptyPos = 0;
        }

        public int GetSize()
        {
            return (int) Math.Sqrt(_board.Length);
        }

        public void SwapTile(int from, int to)
        {
            int temp;

            ValidateMove(from,to);

            temp = _board[from];
            _board[from] = _board[to];
            _board[to] = temp;

            if (_board[from] == 0)
            {
                EmptyPos = from;
            }
            else
            {
                EmptyPos = to;
            }

        }

        public void ShuffleBoard()
        {
            //References: Fisher-Yates shuffle 
            //https://www.dotnetperls.com/fisher-yates-shuffle

            Random _random = new Random();
            int n = _board.Length;

            for (int i = 0; i < n; i++)
            {
                // Use Next on random instance with an argument.
                // ... The argument is an exclusive bound.
                //     So we will not go past the end of the array.
                int r = i + _random.Next(n - i);
                int t = _board[r];

                if (t == 0)
                {
                    EmptyPos = i;
                }

                _board[r] = _board[i];
                _board[i] = t;
            }
        }

        public override String ToString()
        {
            String str = "[";

            for(int i = 0; i < _board.Length - 1; i++)
            {
                str += _board[i] + " ";
            }

            str += _board[_board.Length - 1] + "]";

            return str;
        }

        // Interface Methods

        List<TilePuzzleAction> IAtomicStateModel<TilePuzzleAction>.
        GenerateActions()
        {
            List<TilePuzzleAction> actionList = new List<TilePuzzleAction>();

            int emptyRow = GetRow(EmptyPos);
            int emptyCol = GetCol(EmptyPos);

            //Cell is not at left edge
            if(emptyCol > 0)
            {
                actionList.Add(new TilePuzzleAction(EmptyPos, EmptyPos - 1));
            }

            //Cell is not at right edge
            if (emptyCol < GetSize()-1)
            {
                actionList.Add(new TilePuzzleAction(EmptyPos, EmptyPos + 1));
            }

            //Cell is not at top edge
            if (emptyRow > 0)
            {
                actionList.Add(new TilePuzzleAction(EmptyPos, 
                EmptyPos - GetSize()));
            }

            //Cell is not at bottom edge
            if (emptyRow < GetSize() + 1)
            {
                actionList.Add(new TilePuzzleAction(EmptyPos, 
                EmptyPos + GetSize()));
            }

            return actionList;
        }

        public string TransitionState(TilePuzzleAction action)
        {
            string tranState;

            SwapTile(action.From, action.To);
            tranState = ToString();
            SwapTile(action.From, action.To);

            return tranState;
        }

        public double PathCost(TilePuzzleAction action)
        {
            ValidateMove(action.From, action.To);
            return 1.0;
        }

        //Private Methods

        private void ValidateMove(int from, int to)
        {
            if (from < 0||from >= _board.Length||to < 0||to > _board.Length)
            {
                String message = "Index Out of Bounds";
                throw new IndexOutOfRangeException(message);
            }

            if (!(from == EmptyPos||to == EmptyPos))
            {
                String message = "Illegal Move, non-empty tiles";
                throw new ArgumentException(message);
            }

            if (!IsAdj(from, to))
            {
                String message = "Illegal Move, non-adjacent tiles";
                throw new ArgumentException(message);
            }
        }

        private Boolean IsAdj(int from, int to)
        {
            double dist = 0;

            dist += Math.Pow((GetRow(from) - GetRow(to)), 2);
            dist += Math.Pow((GetCol(from) - GetCol(to)), 2);

            return Math.Abs(Math.Sqrt(dist) - 1.0) < 0.001;
        }

        private int GetRow(int idx)
        {
            return idx / this.GetSize();
        }

        private int GetCol(int idx)
        {
            return idx % this.GetSize();
        }
    }
}
