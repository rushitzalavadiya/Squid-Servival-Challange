using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class ScreenFade : TransitionStepScreen
	{
		public Texture2D Texture;

		public Color Color;

		private readonly ScreenFadeComponents _screenFadeComponents;

		public ScreenFade(GameObject target, Color? color = default(Color?), Texture2D texture = null, float delay = 0f, float duration = 0.5f, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, SceneChangeModeType.None, null, skipOnCrossTransition: true, delay, duration, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, null, onComplete)
		{
			_screenFadeComponents = new ScreenFadeComponents
			{
				PersistantAcrossScenes = true
			};
			Color = (color.HasValue ? color.Value : Color.white);
			Texture = texture;
		}

		public override void Start()
		{
			SetConfiguration(Texture, Color);
			base.Start();
		}

		public override void SetCurrent(float progress)
		{
			TargetComponents().FadeRawImage.color = new Color(TargetComponents().FadeRawImage.color.r, TargetComponents().FadeRawImage.color.g, TargetComponents().FadeRawImage.color.b, base.Value);
		}

		private void SetConfiguration(Texture2D texture, Color color)
		{
			TargetComponents().FadeRawImage.texture = texture;
			TargetComponents().FadeRawImage.color = color;
		}

		protected override void SetTransitionDisplayedState(bool isDisplayed)
		{
			if (base.SiblingRawImage != null)
			{
				base.SetTransitionDisplayedState(isDisplayed);
			}
			else
			{
				TargetComponents().BaseGameObject.SetActive(isDisplayed);
			}
			if (base.SceneChangeMode == SceneChangeModeType.CrossTransition)
			{
				if (isDisplayed)
				{
					TargetComponents().FadeRawImage.texture = TransitionController.Instance.ScreenSnapshot;
				}
				else
				{
					TargetComponents().DeleteComponents();
				}
			}
		}

		private ScreenFadeComponents TargetComponents()
		{
			if (base.SceneChangeMode != SceneChangeModeType.CrossTransition)
			{
				return TransitionController.Instance.SharedScreenFadeComponents;
			}
			return _screenFadeComponents;
		}
	}
}
