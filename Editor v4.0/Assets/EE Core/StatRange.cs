using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EECore
{
    public class StatRange
    {
        private int _currentStat;
        private int _maxStat;

        public StatRange() : this(0) { }

        public StatRange(int max)
        {
            _currentStat = 0;
            _maxStat = max;
        }

        public int Max()
        {
            return _maxStat;
        }

        public int Current()
        {
            return _currentStat;
        }

        public void Cap()
        {
            _currentStat = _maxStat;
        }

        public void Modify(int delta)
        {
            _currentStat += delta;
            EnforceBounds();
        }

        public void SetCurrent(int current)
        {
            _currentStat = current;
            EnforceBounds();
        }

        public void UpdateMax(int val)
        {
            _maxStat = val;
            EnforceBounds();
        }

        public static implicit operator int(StatRange range)
        {
            return range.Current();
        }

        private void EnforceBounds()
        {
            if (_currentStat > _maxStat)
            {
                _currentStat = _maxStat;
            }
            if (_currentStat < 0)
            {
                _currentStat = 0;
            }
        }
    }
}
