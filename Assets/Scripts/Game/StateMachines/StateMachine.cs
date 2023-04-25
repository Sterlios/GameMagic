using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.StateMachines
{
	class StateMachine
	{
		private readonly IState _firstState;

		private IState _currentState;

		public StateMachine(IState firstState)
		{
			_firstState = firstState;
		}

		public void Enter()
		{

		}
	}
}
