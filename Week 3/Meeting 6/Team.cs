using System;
using System.Collections.Generic;
using Gab.Loger;

namespace Meeting_6
{
    class Team
    {//------------------------------------------------------------------------
        public int Length { get; private set; }
        //---------------------------------------------------------------------
        private readonly List<IWorker> _listWorkers = new List<IWorker>();
        private readonly TeamLeader _teamLeader;
        //---------------------------------------------------------------------
        public Team(params IWorker[] listWorkers)
        {
            foreach (var worker in listWorkers)
            {
                if (worker is TeamLeader leader)
                {
                    _teamLeader = leader;
                    Loger.Write("+New Team Leader", Loger.MessageType.Info);
                }
                else
                {
                    _listWorkers.Add(worker);
                    Loger.Write("+New Worker", Loger.MessageType.Info);
                }
            }

            if (_listWorkers.Count == 0)
            {
                Loger.Write("No workers in the team", Loger.MessageType.Warning);
                Console.WriteLine(" Request to [Central Office]: 'There are no workers in the team'\n" +
                                  " Reply from [Central Office]: 'Four workers rush to help you'");
                for (var i = 0; i < 4; i++)
                {
                    _listWorkers.Add(new Worker());
                    Loger.Write("+New Worker", Loger.MessageType.Info);
                }
            }
            if (_teamLeader == null)
            {
                Loger.Write("Team needs a leader", Loger.MessageType.Warning);
                Console.WriteLine(" Request to [Central Office]: 'The team needs a leader'\n" +
                                  " Reply from [Central Office]: 'Trainee leader sent to you'");
                _teamLeader = new TeamLeader();
                Loger.Write("+New Team Leader", Loger.MessageType.Info);
            }

            Length = _listWorkers.Count;
        }
        //---------------------------------------------------------------------
        public IWorker this[int index] => _listWorkers[index];
        public IWorker this[string tl] => tl == "leader" ? _teamLeader : null;
    }//------------------------------------------------------------------------
}
