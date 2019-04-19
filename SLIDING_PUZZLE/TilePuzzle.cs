using System;

namespace Sliding_Puzzle
{
    class TilePuzzle
    {
        public const int DEFAULT_SIZE = 3;

        private int[] board;
        private int emptyPos;

        public TilePuzzle()
        {
            board = new int[(int)Math.Pow(DEFAULT_SIZE, 2)];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = i;
            }

            emptyPos = 0;
        }

        public TilePuzzle(int inSize)
        {
            board = new int[(int)Math.Pow(inSize, 2)];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = i;
            }

            emptyPos = 0;
        }


        public int GetSize()
        {
            return (int) Math.Sqrt(board.Length);
        }

        public int GetEmptyPos()
        {
            return emptyPos;
        }

        public void SwapTile(int from, int to)
        {
            int temp;

            if(from < 0 || from >= board.Length || to < 0 || to > board.Length)
            {
                String message = "Index Out of Bounds";
                throw new IndexOutOfRangeException(message);
            }

            if (!(from == emptyPos || to == emptyPos))
            {
                String message = "Illegal Move, non-empty tiles";
                throw new ArgumentException(message);
            }

            if(!IsAdj(from, to))
            {
                String message = "Illegal Move, non-adjacent tiles";
                throw new ArgumentException(message);
            }

            temp = board[from];
            board[from] = board[to];
            board[to] = temp;

            if(board[from] == 0)
            {
                emptyPos = from;
            }
            else
            {
                emptyPos = to;
            }

        }

        public void ShuffleBoard()
        {
            //References: Fisher-Yates shuffle 
            //https://www.dotnetperls.com/fisher-yates-shuffle

            Random _random = new Random();
            int n = board.Length;

            for (int i = 0; i < n; i++)
            {
                // Use Next on random instance with an argument.
                // ... The argument is an exclusive bound.
                //     So we will not go past the end of the array.
                int r = i + _random.Next(n - i);
                int t = board[r];

                if (t == 0)
                {
                    emptyPos = i;
                }

                board[r] = board[i];
                board[i] = t;
            }
        }

        public override String ToString()
        {
            String str = "[";

            for(int i = 0; i < board.Length - 1; i++)
            {
                str += board[i] + " ";
            }

            str += board[board.Length - 1] + "]";

            return str;
        }

        //Private Methods

        private Boolean IsAdj(int from, int to)
        {
            double dist = 0;

            dist += Math.Pow((GetRow(from) - GetRow(to)),2);
            dist += Math.Pow((GetCol(from) - GetCol(to)), 2);

            return (int)dist == 1;
        }

        private int GetRow(int idx)
        {
            return idx / GetSize();
        }

        private int GetCol(int idx)
        {
            return idx % GetSize();
        }
    }
}
