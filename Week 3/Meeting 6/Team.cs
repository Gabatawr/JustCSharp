using System;
using System.Collections.Generic;

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
                if (worker is TeamLeader leader) _teamLeader = leader;
                else _listWorkers.Add(worker);
            }

            if (_listWorkers.Count == 0)
            {
                Console.WriteLine(" Request to [Central Office]: 'There are no workers in the team'\n" +
                                  " Reply from [Central Office]: 'Four workers rush to help you'");
                for (var i = 0; i < 4; i++) _listWorkers.Add(new Worker());
            }
            if (_teamLeader == null)
            {
                Console.WriteLine(" Request to [Central Office]: 'The team needs a leader'\n" +
                                  " Reply from [Central Office]: 'Trainee leader sent to you'");
                _teamLeader = new TeamLeader();
            }

            Length = _listWorkers.Count;
        }
        //---------------------------------------------------------------------
        public IWorker this[int index] => _listWorkers[index];
        public IWorker this[string tl] => tl == "leader" ? _teamLeader : null;
    }//------------------------------------------------------------------------
}
