using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public struct LevelInfo
    {
        private readonly int _number;
        private readonly bool _isAllow;
        private readonly bool _isComplete;
        private readonly int _stars;

        public int Number { get { return _number; } }
        public bool IsAllow { get { return _isAllow; } }
        public bool IsComplete { get { return _isComplete; } }
        public int Stars { get { return _stars; } }

        public LevelInfo(int number, bool isAllow, bool isComplete, int stars)
        {
            _number = number;
            _isAllow = isAllow;
            _isComplete = isComplete;
            _stars = stars;
        }
    }
}
