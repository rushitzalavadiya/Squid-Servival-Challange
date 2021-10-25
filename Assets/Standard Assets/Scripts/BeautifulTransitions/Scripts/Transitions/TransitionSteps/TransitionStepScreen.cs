using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class TransitionStepScreen : TransitionStepFloat
	{
		public enum SceneChangeModeType
		{
			None,
			CrossTransition,
			End
		}

		protected RawImage SiblingRawImage
		{
			get;
			set;
		}

		public SceneChangeModeType SceneChangeMode
		{
			get;
			set;
		}

		public string SceneToLoad
		{
			get;
			set;
		}

		public bool SkipOnCrossTransition
		{
			get;
			set;
		}

		public TransitionStepScreen(GameObject target, SceneChangeModeType sceneChangeMode = SceneChangeModeType.None, string sceneToLoad = null, bool skipOnCrossTransition = true, float delay = 0f, float duration = 0.5f, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, TransitionStep onCompleteItem = null, Action<TransitionStep> onComplete = null, Action<object> onCompleteWithData = null, object onCompleteData = null)
			: base(target, null, null, delay, duration, TransitionModeType.Specified, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
			SceneChangeMode = sceneChangeMode;
			SceneToLoad = sceneToLoad;
			SkipOnCrossTransition = skipOnCrossTransition;
			SetupComponents();
		}

		protected override IEnumerator TransitionLoop()
		{
			if (SkipOnCrossTransition && TransitionController.Instance.IsInCrossTransition)
			{
				yield break;
			}
			if (Mathf.Approximately(base.Delay + base.Duration, 0f))
			{
				SetProgressToEnd();
				TransitionStarted();
			}
			else
			{
				TransitionStarted();
				if (!Mathf.Approximately(base.Delay, 0f))
				{
					yield return new WaitForSeconds(base.Delay);
				}
				if (SceneChangeMode == SceneChangeModeType.CrossTransition)
				{
					TransitionController.Instance.IsInCrossTransition = true;
					yield return TransitionController.Instance.StartCoroutine(TransitionController.Instance.TakeScreenshotCoroutine());
					SetTransitionDisplayedState(isDisplayed: true);
					base.StartValue = 1f;
					base.EndValue = 0f;
					SetProgressToStart();
					yield return TransitionController.Instance.StartCoroutine(TransitionController.Instance.LoadSceneAndWaitForLoad(SceneToLoad));
				}
				else
				{
					SetTransitionDisplayedState(isDisplayed: true);
					SetProgressToStart();
				}
				float normalisedFactor = Mathf.Approximately(base.Duration, 0f) ? float.MaxValue : (1f / base.Duration);
				while (base.Progress < 1f && !base.IsStopped)
				{
					if (!base.IsPaused)
					{
						SetProgress(base.Progress + normalisedFactor * Time.deltaTime);
					}
					yield return 0;
				}
			}
			if (Mathf.Approximately(base.Progress, 1f) && !base.IsStopped)
			{
				TransitionCompleted();
			}
		}

		protected override void TransitionCompleted()
		{
			if (Mathf.Approximately(base.EndValue, 0f))
			{
				SetTransitionDisplayedState(isDisplayed: false);
			}
			base.TransitionCompleted();
			if (SceneChangeMode == SceneChangeModeType.End)
			{
				TransitionHelper.LoadScene(SceneToLoad);
			}
			if (SceneChangeMode == SceneChangeModeType.CrossTransition)
			{
				TransitionController.Instance.IsInCrossTransition = false;
			}
		}

		protected virtual void SetupComponents()
		{
			SiblingRawImage = base.Target.GetComponent<RawImage>();
			if (SiblingRawImage != null)
			{
				SiblingRawImage.enabled = false;
			}
		}

		protected virtual void SetTransitionDisplayedState(bool isDisplayed)
		{
			if (SiblingRawImage != null)
			{
				SiblingRawImage.enabled = isDisplayed;
			}
		}
	}
}
