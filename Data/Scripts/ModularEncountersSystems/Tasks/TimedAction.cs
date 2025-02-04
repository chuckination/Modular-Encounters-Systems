﻿using ModularEncountersSystems.Entities;
using ModularEncountersSystems.Helpers;
using ModularEncountersSystems.Logging;
using ModularEncountersSystems.Watchers;
using Sandbox.Game.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using VRageMath;

namespace ModularEncountersSystems.Tasks {

	public class TimedAction : TaskItem, ITaskItem {

		internal int _secondsToTrigger;
		internal int _elapsedTime;
		internal Action _action;

		public TimedAction(int secondsToTrigger, Action action) {

			_tickTrigger = 60;
			_isValid = true;
			_secondsToTrigger = secondsToTrigger;
			_elapsedTime = 0;
			_action += action;

		}

		public override void Run() {

			_elapsedTime++;

			if (_elapsedTime < _secondsToTrigger)
				return;

			_action?.Invoke();
			_isValid = false;


		}

	}

}
