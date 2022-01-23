using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class StateRepositoryMock : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>()
            {
                new State
                {
                    StateId = 1,
                    StateName = "OH"
                },
                new State
                {
                    StateId = 2,
                    StateName = "KY"
                },
                new State
                {
                    StateId = 3,
                    StateName = "MN"
                }
            };
            return states;
        }
    }
}
