using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Move Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionMove : TransitionGameObjectBase
	{
		public enum MoveModeType
		{
			Global,
			Local,
			AnchoredPosition
		}

		public enum MoveType
		{
			FixedPosition,
			Delta
		}

		[Serializable]
		public class InSettings
		{
			[Tooltip("Movement type.")]
			public MoveType StartPositionType;

			[Tooltip("Starting position (end at the GameObjects initial position).")]
			public Vector3 StartPosition = new Vector3(0f, 0f, 0f);
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Movement type.")]
			public MoveType EndPositionType;

			[Tooltip("End position (end at the GameObjects current position).")]
			public Vector3 EndPosition = new Vector3(0f, 0f, 0f);
		}

		public MoveModeType MoveMode;

		public InSettings InConfig;

		public OutSettings OutConfig;

		private Vector3 _originalPosition;

		public override void SetupInitialState()
		{
			_originalPosition = ((Move)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new Move(Target, null, null, 0f, 0.5f, TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType.linear, null, ConvertMoveMode());
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			Move move = transitionStep as Move;
			if (move != null)
			{
				move.StartValue = ((InConfig.StartPositionType == MoveType.FixedPosition) ? InConfig.StartPosition : (_originalPosition + InConfig.StartPosition));
				move.EndValue = _originalPosition;
				move.CoordinateSpace = ConvertMoveMode();
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			Move move = transitionStep as Move;
			if (move != null)
			{
				move.StartValue = move.GetCurrent();
				move.EndValue = ((OutConfig.EndPositionType == MoveType.FixedPosition) ? OutConfig.EndPosition : (_originalPosition + OutConfig.EndPosition));
				move.CoordinateSpace = ConvertMoveMode();
			}
			base.SetupTransitionStepOut(transitionStep);
		}

		private TransitionStep.CoordinateSpaceType ConvertMoveMode()
		{
			if (MoveMode == MoveModeType.Global)
			{
				return TransitionStep.CoordinateSpaceType.Global;
			}
			if (MoveMode == MoveModeType.Local)
			{
				return TransitionStep.CoordinateSpaceType.Local;
			}
			return TransitionStep.CoordinateSpaceType.AnchoredPosition;
		}
	}
}
