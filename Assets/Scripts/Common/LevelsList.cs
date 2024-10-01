using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    public class LevelsList
    {

        private List<LevelInfo> _levels;

        public int GetCountLevel()
        {
            return _levels.Count;
        }

        public LevelInfo GetLevel(int level) 
        {
            return _levels[level];
        }

    }
}
