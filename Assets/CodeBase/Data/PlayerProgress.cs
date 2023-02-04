using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Level;

        public PlayerProgress(int defaultLevel)
        {
            Level = defaultLevel;
        }
    }
}