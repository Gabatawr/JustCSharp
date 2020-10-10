using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting_6
{
    class Plan
    {//------------------------------------------------------------------------
        public int Length { get; private set; }
        //---------------------------------------------------------------------
        private readonly ILookup<int, IPart> _listParts;
        //---------------------------------------------------------------------
        public IEnumerable<IPart> this[int index] => _listParts[index];
        //---------------------------------------------------------------------
        public Plan(params IPart[] listParts)
        {
            _listParts = listParts.ToLookup(part => part.GetPriority());
            Length = listParts.Length;
        }
    }//------------------------------------------------------------------------
}