using System;
namespace SLIDING_PUZZLE
{
    public class TilePuzzleAction
    {
        public int From { get; set; }
        public int To { get; set; }

        public TilePuzzleAction()
        {
            From = 0;
            To = 0;
        }

        public TilePuzzleAction(int inFrom,int inTo)
        {
            From = inFrom;
            To = inTo;
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", From, To);
        }
    }
}
