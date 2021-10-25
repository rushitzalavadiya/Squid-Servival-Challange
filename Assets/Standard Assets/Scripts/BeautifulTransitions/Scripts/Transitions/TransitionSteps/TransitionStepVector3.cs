using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class TransitionStepVector3 : TransitionStepValue<Vector3>
	{
		public TransitionStepVector3(GameObject target = null, Vector3? startValue = default(Vector3?), Vector3? endValue = default(Vector3?), float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateSpace, onStart, onUpdate, onComplete)
		{
			base.StartValue = startValue.GetValueOrDefault();
			base.EndValue = endValue.GetValueOrDefault();
			base.OriginalValue = GetCurrent();
		}

		private TransitionStep SetStartValue(Vector3 value)
		{
			base.StartValue = value;
			return this;
		}

		private TransitionStep SetEndValue(Vector3 value)
		{
			base.EndValue = value;
			return this;
		}

		public override void Start()
		{
			if (base.TransitionMode == TransitionModeType.ToOriginal)
			{
				base.EndValue = base.OriginalValue;
			}
			else if (base.TransitionMode == TransitionModeType.ToCurrent)
			{
				base.EndValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromCurrent)
			{
				base.StartValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromOriginal)
			{
				base.StartValue = base.OriginalValue;
			}
			base.Start();
		}

		protected override void ProgressUpdated()
		{
			base.Value = new Vector3(ValueFromProgressTweened(base.StartValue.x, base.EndValue.x), ValueFromProgressTweened(base.StartValue.y, base.EndValue.y), ValueFromProgressTweened(base.StartValue.z, base.EndValue.z));
			SetCurrent(base.Value);
		}
	}
}
