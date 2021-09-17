using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
    // 與JAVA的Iterator寫法不同，應該有錯
    public class PositionIEnumerator : IEnumerator<Position>
    {
        private int rowIncrement, colIncrement, size;

        public Position Current { get; private set; }

        object IEnumerator.Current => throw new NotImplementedException();


        public PositionIEnumerator(Position p, int rowIncrement, int colIncrement, int size)
        {
            this.rowIncrement = rowIncrement;
            this.colIncrement = colIncrement;
            this.size = size;
            Current = new Position(p.Row - rowIncrement, p.Column - colIncrement);
        }

        private bool HasNext()
        {
            return Current.Row + rowIncrement < size && Current.Column + colIncrement < size;
        }

        private Position Next()
        {
            Current = new Position(Current.Row + rowIncrement, Current.Column + colIncrement);
            return Current;
        }

        public bool MoveNext()
        {
            var ans = HasNext();
            if (ans) Next();
            return ans;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
