
namespace Meeting_6
{
    class TeamLeader : IWorker
    {//------------------------------------------------------------------------
        public void Work(IPart part)
        {
            part.Completed(this);
        }
    }//------------------------------------------------------------------------
}
