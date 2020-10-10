using System;

namespace Meeting_6
{
    abstract class Part : IPart
    {//------------------------------------------------------------------------
        private static readonly Random Rand = new Random();
        //---------------------------------------------------------------------
        public bool IsCompleted { get; private set; }
        public int Progress { get; private set; }
        //---------------------------------------------------------------------
        private readonly int _priority;
        //---------------------------------------------------------------------
        protected Part(int priority)
        {
            _priority = priority;
        }
        //---------------------------------------------------------------------
        public void Completed(IWorker teamLeader)
        {
            if (teamLeader.GetType() == Type.GetType("TeamLeader"))
                IsCompleted = true;
        }
        public static Part operator ++(Part part)
        {
            if (part.Progress < 100) part.Progress++;
            return part;
        }
        //---------------------------------------------------------------------
        public int GetPriority() { return _priority; }
        //---------------------------------------------------------------------
        public virtual void Build(IWorker worker)
        {
            int oldProgress = Progress;
            for (int i = 0, r = Rand.Next(25); i < r; i++)
            {
                worker.Work(this);
            }
            Draw(oldProgress, Progress);
        }
        //---------------------------------------------------------------------
        protected abstract void Draw(int oldProgress, int progress);
    }//------------------------------------------------------------------------
}
