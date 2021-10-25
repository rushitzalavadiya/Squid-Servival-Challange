using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Rotate Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionRotate : TransitionGameObjectBase
	{
		public enum RotationModeType
		{
			Global,
			Local
		}

		[Serializable]
		public class InSettings
		{
			[Tooltip("Start rotation (end at the GameObjects initial rotation).")]
			public Vector3 StartRotation = new Vector3(0f, 0f, 0f);
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("End rotation (starts at the GameObjects current position).")]
			public Vector3 EndRotation = new Vector3(0f, 0f, 0f);
		}

		public RotationModeType RotationMode = RotationModeType.Local;

		public InSettings InConfig;

		public OutSettings OutConfig;

		private Vector3 _originalRotation;

		public override void SetupInitialState()
		{
			_originalRotation = ((Rotate)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new Rotate(Target, null, null, 0f, 0.5f, TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType.linear, null, ConvertRotationMode());
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			Rotate rotate = transitionStep as Rotate;
			if (rotate != null)
			{
				rotate.StartValue = InConfig.StartRotation;
				rotate.EndValue = _originalRotation;
				rotate.CoordinateSpace = ConvertRotationMode();
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			Rotate rotate = transitionStep as Rotate;
			if (rotate != null)
			{
				rotate.StartValue = rotate.GetCurrent();
				rotate.EndValue = OutConfig.EndRotation;
				rotate.CoordinateSpace = ConvertRotationMode();
			}
			base.SetupTransitionStepOut(transitionStep);
		}

		private TransitionStep.CoordinateSpaceType ConvertRotationMode()
		{
			if (RotationMode == RotationModeType.Global)
			{
				return TransitionStep.CoordinateSpaceType.Global;
			}
			return TransitionStep.CoordinateSpaceType.Local;
		}
	}
}
