using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Move Target Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionMoveTraget : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("GameObject used as a starting position (end at the GameObjects initial position).")]
			public UnityEngine.GameObject StartTarget;

			[Tooltip("Whether to move in the X direction. Clear this to keep the gameobjects original X position.")]
			public bool MoveX = true;

			[Tooltip("Whether to move in the Y direction. Clear this to keep the gameobjects original Y position.")]
			public bool MoveY = true;

			[Tooltip("Whether to move in the Z direction. Clear this to keep the gameobjects original Z position.")]
			public bool MoveZ = true;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("GameObject used as the ending position (starts at the GameObjects current position).")]
			public UnityEngine.GameObject EndTarget;

			[Tooltip("Whether to move in the X direction. Clear this to keep the gameobjects original X position.")]
			public bool MoveX = true;

			[Tooltip("Whether to move in the Y direction. Clear this to keep the gameobjects original Y position.")]
			public bool MoveY = true;

			[Tooltip("Whether to move in the Z direction. Clear this to keep the gameobjects original Z position.")]
			public bool MoveZ = true;
		}

		public InSettings MoveInConfig;

		public OutSettings MoveOutConfig;

		private Vector3 _originalPosition;

		public override void SetupInitialState()
		{
			_originalPosition = ((Move)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new Move(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			Move move = transitionStep as Move;
			if (move != null)
			{
				move.StartValue = new Vector3(MoveInConfig.MoveX ? MoveInConfig.StartTarget.transform.position.x : _originalPosition.x, MoveInConfig.MoveY ? MoveInConfig.StartTarget.transform.position.y : _originalPosition.y, MoveInConfig.MoveZ ? MoveInConfig.StartTarget.transform.position.z : _originalPosition.z);
				move.EndValue = _originalPosition;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			Move move = transitionStep as Move;
			if (move != null)
			{
				move.StartValue = move.GetCurrent();
				move.EndValue = new Vector3(MoveOutConfig.MoveX ? MoveOutConfig.EndTarget.transform.position.x : move.GetCurrent().x, MoveOutConfig.MoveY ? MoveOutConfig.EndTarget.transform.position.y : move.GetCurrent().y, MoveOutConfig.MoveZ ? MoveOutConfig.EndTarget.transform.position.z : move.GetCurrent().z);
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
