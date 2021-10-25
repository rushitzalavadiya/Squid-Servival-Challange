using BeautifulTransitions.Scripts.Helper;
using System;
using System.Collections;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses
{
	public class TransitionStep
	{
		public enum TimeUpdateMethodType
		{
			GameTime,
			UnscaledGameTime
		}

		public enum CoordinateSpaceType
		{
			Global,
			Local,
			AnchoredPosition
		}

		public enum TransitionModeType
		{
			Specified,
			ToOriginal,
			FromCurrent,
			FromOriginal,
			ToCurrent
		}

		public enum LoopModeType
		{
			None,
			Loop,
			PingPong
		}

		private TransitionHelper.TweenType _tweenType;

		private TweenMethods.TweenFunction _tweenFunction;

		public GameObject Target
		{
			get;
			private set;
		}

		public float Progress
		{
			get;
			private set;
		}

		public float ProgressTweened
		{
			get;
			private set;
		}

		public float Delay
		{
			get;
			set;
		}

		public float Duration
		{
			get;
			set;
		}

		public TransitionHelper.TweenType TweenType
		{
			get
			{
				return _tweenType;
			}
			set
			{
				_tweenType = value;
				_tweenFunction = TransitionHelper.GetTweenFunction(TweenType);
			}
		}

		public TimeUpdateMethodType TimeUpdateMethod
		{
			get;
			set;
		}

		public LoopModeType LoopMode
		{
			get;
			set;
		}

		public TransitionModeType TransitionMode
		{
			get;
			set;
		}

		public AnimationCurve AnimationCurve
		{
			get;
			set;
		}

		public CoordinateSpaceType CoordinateSpace
		{
			get;
			set;
		}

		public TransitionStep Parent
		{
			get;
			set;
		}

		public Action<TransitionStep> OnStart
		{
			get;
			set;
		}

		public Action<TransitionStep> OnUpdate
		{
			get;
			set;
		}

		public Action<TransitionStep> OnComplete
		{
			get;
			set;
		}

		public object UserData
		{
			get;
			set;
		}

		public bool IsStopped
		{
			get;
			protected set;
		}

		public bool IsPaused
		{
			get;
			protected set;
		}

		public TransitionStep(GameObject target = null, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			Target = target;
			Delay = delay;
			Duration = duration;
			TransitionMode = transitionMode;
			TimeUpdateMethod = timeUpdateMethod;
			TweenType = tweenType;
			AnimationCurve = (animationCurve ?? AnimationCurve.EaseInOut(0f, 0f, 1f, 1f));
			CoordinateSpace = coordinateSpace;
			AddOnStartAction(onStart);
			AddOnUpdateAction(onUpdate);
			AddOnCompleteAction(onComplete);
		}

		public TransitionStep SetDelay(float delay)
		{
			Delay = delay;
			return this;
		}

		public TransitionStep SetDuration(float duration)
		{
			Duration = duration;
			return this;
		}

		public TransitionStep SetTweenType(TransitionHelper.TweenType tweenType)
		{
			TweenType = tweenType;
			return this;
		}

		public TransitionStep SetTimeUpdateMethod(TimeUpdateMethodType timeUpdateMethod)
		{
			TimeUpdateMethod = timeUpdateMethod;
			return this;
		}

		public TransitionStep SetLoopMode(LoopModeType loopMode)
		{
			LoopMode = loopMode;
			return this;
		}

		public TransitionStep SetTransitionMode(TransitionModeType transitionMode)
		{
			TransitionMode = transitionMode;
			return this;
		}

		public TransitionStep SetAnimationCurve(AnimationCurve animationCurve)
		{
			AnimationCurve = animationCurve;
			return this;
		}

		public TransitionStep SetCoordinateMode(CoordinateSpaceType coordinateMode)
		{
			CoordinateSpace = coordinateMode;
			return this;
		}

		public TransitionStep AddOnStartAction(Action<TransitionStep> action)
		{
			OnStart = (Action<TransitionStep>)Delegate.Combine(OnStart, action);
			return this;
		}

		public TransitionStep AddOnUpdateAction(Action<TransitionStep> action)
		{
			OnUpdate = (Action<TransitionStep>)Delegate.Combine(OnUpdate, action);
			return this;
		}

		public TransitionStep AddOnCompleteAction(Action<TransitionStep> action)
		{
			OnComplete = (Action<TransitionStep>)Delegate.Combine(OnComplete, action);
			return this;
		}

		public TransitionStep AddOnCompleteAction(Action<TransitionStep> action, object userData)
		{
			OnComplete = (Action<TransitionStep>)Delegate.Combine(OnComplete, action);
			UserData = userData;
			return this;
		}

		public TransitionStep AddOnStartTransitionStep(TransitionStep transitionStep)
		{
			if (transitionStep != null)
			{
				OnStart = (Action<TransitionStep>)Delegate.Combine(OnStart, new Action<TransitionStep>(transitionStep.Start));
			}
			return this;
		}

		public TransitionStep AddOnCompleteTransitionStep(TransitionStep transitionStep)
		{
			if (transitionStep != null)
			{
				OnComplete = (Action<TransitionStep>)Delegate.Combine(OnComplete, new Action<TransitionStep>(transitionStep.Start));
			}
			return this;
		}

		public TransitionStep ChainCustomTransitionStep(float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			TransitionStep transitionStep = new TransitionStep(Target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete);
			transitionStep.AddToChain(this, runAtStart);
			return transitionStep;
		}

		public TransitionStep GetChainRoot()
		{
			TransitionStep transitionStep = this;
			while (transitionStep.Parent != null)
			{
				transitionStep = transitionStep.Parent;
			}
			return transitionStep;
		}

		public void AddToChain(TransitionStep parent, bool runAtStart)
		{
			if (runAtStart)
			{
				parent.AddOnStartTransitionStep(this);
			}
			else
			{
				parent.AddOnCompleteTransitionStep(this);
			}
			Parent = parent;
		}

		public virtual void Start()
		{
			IsStopped = false;
			IsPaused = false;
			TransitionController.Instance.StartCoroutine(TransitionLoop());
		}

		public virtual void Start(TransitionStep transitionStep)
		{
			Start();
		}

		public virtual void Stop()
		{
			IsStopped = true;
		}

		public virtual void Pause()
		{
			IsPaused = true;
		}

		public virtual void Resume()
		{
			IsPaused = false;
		}

		public virtual void Complete()
		{
			SetProgressToEnd();
		}

		protected virtual IEnumerator TransitionLoop()
		{
			if (Mathf.Approximately(Delay + Duration, 0f))
			{
				SetProgressToEnd();
				TransitionStarted();
			}
			else
			{
				SetProgressToStart();
				TransitionStarted();
				if (!Mathf.Approximately(Delay, 0f))
				{
					float delayTime = 0f;
					while (delayTime < Delay)
					{
						if (!IsPaused)
						{
							delayTime += ((TimeUpdateMethod == TimeUpdateMethodType.GameTime) ? Time.deltaTime : Time.unscaledDeltaTime);
						}
						yield return 0;
					}
				}
				float normalisedFactor = Mathf.Approximately(Duration, 0f) ? float.MaxValue : (1f / Duration);
				while (!IsStopped)
				{
					if (!IsPaused)
					{
						Progress += normalisedFactor * ((TimeUpdateMethod == TimeUpdateMethodType.GameTime) ? Time.deltaTime : Time.unscaledDeltaTime);
						if (LoopMode == LoopModeType.Loop && Progress >= 1f)
						{
							Progress = 0f;
						}
						if (LoopMode == LoopModeType.PingPong && Progress >= 1f)
						{
							normalisedFactor *= -1f;
							Progress = 1f;
						}
						if (LoopMode == LoopModeType.PingPong && Progress <= 0f)
						{
							normalisedFactor *= -1f;
							Progress = 0f;
						}
						SetProgress(Progress);
						if (LoopMode == LoopModeType.None && Progress >= 1f)
						{
							break;
						}
					}
					yield return 0;
				}
			}
			if (Mathf.Approximately(Progress, 1f) && !IsStopped)
			{
				TransitionCompleted();
			}
		}

		protected virtual void TransitionStarted()
		{
			if (OnStart != null)
			{
				OnStart(this);
			}
		}

		protected virtual void TransitionCompleted()
		{
			if (OnComplete != null)
			{
				OnComplete(this);
			}
		}

		public void SetProgressToStart()
		{
			SetProgress(0f);
		}

		public void SetProgressToEnd()
		{
			SetProgress(1f);
		}

		public void SetProgress(float progress)
		{
			try
			{
				Progress = Mathf.Max(0f, Mathf.Min(1f, progress));
				ProgressTweened = ValueFromProgress(0f, 1f);
				ProgressUpdated();
				if (OnUpdate != null)
				{
					OnUpdate(this);
				}
			}
			catch (Exception)
			{
				Stop();
			}
		}

		protected virtual void ProgressUpdated()
		{
		}

		protected float ValueFromProgressTweened(float start, float end)
		{
			return ProgressTweened * (end - start) + start;
		}

		protected float ValueFromProgress(float start, float end)
		{
			if (TweenType == TransitionHelper.TweenType.AnimationCurve)
			{
				return ValueFromProgressAnimationCurve(start, end);
			}
			if (_tweenFunction != null)
			{
				return _tweenFunction(start, end, Progress);
			}
			return end;
		}

		private float ValueFromProgressAnimationCurve(float start, float end)
		{
			float time = AnimationCurve.keys[0].time;
			float num = AnimationCurve.keys[AnimationCurve.keys.Length - 1].time - time;
			return start + (end - start) * AnimationCurve.Evaluate(time + num * Progress);
		}
	}
}
