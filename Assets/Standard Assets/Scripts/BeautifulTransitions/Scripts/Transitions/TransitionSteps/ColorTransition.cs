using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class ColorTransition : TransitionStep
	{
		private Color _startValue;

		private Color _endValue;

		private Image[] _images = new Image[0];

		private RawImage[] _rawImages = new RawImage[0];

		private Text[] _texts = new Text[0];

		private SpriteRenderer[] _spriteRenderers = new SpriteRenderer[0];

		private Material[] _materials = new Material[0];

		private bool _hasComponentReferences;

		public Color StartValue
		{
			get
			{
				return _startValue;
			}
			set
			{
				_startValue = value;
				if (Gradient == null)
				{
					Gradient = new Gradient();
				}
				List<GradientColorKey> list = new List<GradientColorKey>(Gradient.colorKeys);
				if (Mathf.Approximately(Gradient.colorKeys[0].time, 0f))
				{
					list[0] = new GradientColorKey(EndValue, 0f);
				}
				else
				{
					list.Insert(0, new GradientColorKey(StartValue, 0f));
				}
				Gradient.colorKeys = list.ToArray();
				List<GradientAlphaKey> list2 = new List<GradientAlphaKey>(Gradient.alphaKeys);
				if (Mathf.Approximately(Gradient.alphaKeys[0].time, 0f))
				{
					list2[0] = new GradientAlphaKey(EndValue.a, 0f);
				}
				else
				{
					list2.Insert(0, new GradientAlphaKey(StartValue.a, 0f));
				}
				Gradient.alphaKeys = list2.ToArray();
			}
		}

		public Color EndValue
		{
			get
			{
				return _endValue;
			}
			set
			{
				_endValue = value;
				if (Gradient == null)
				{
					Gradient = new Gradient();
				}
				List<GradientColorKey> list = new List<GradientColorKey>(Gradient.colorKeys);
				if (Mathf.Approximately(Gradient.colorKeys[Gradient.colorKeys.Length - 1].time, 1f))
				{
					list[list.Count - 1] = new GradientColorKey(EndValue, 1f);
				}
				else
				{
					list.Add(new GradientColorKey(EndValue, 1f));
				}
				Gradient.colorKeys = list.ToArray();
				List<GradientAlphaKey> list2 = new List<GradientAlphaKey>(Gradient.alphaKeys);
				if (Mathf.Approximately(Gradient.alphaKeys[Gradient.alphaKeys.Length - 1].time, 1f))
				{
					list2[Gradient.alphaKeys.Length - 1] = new GradientAlphaKey(EndValue.a, 1f);
				}
				else
				{
					list2.Add(new GradientAlphaKey(EndValue.a, 1f));
				}
				Gradient.alphaKeys = list2.ToArray();
			}
		}

		public Color Value
		{
			get;
			set;
		}

		public Color OriginalValue
		{
			get;
			set;
		}

		public Gradient Gradient
		{
			get;
			set;
		}

		public ColorTransition(GameObject target, Color startColor, Color endColor, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
			Gradient = new Gradient();
			StartValue = startColor;
			EndValue = endColor;
			OriginalValue = GetCurrent();
		}

		public ColorTransition(GameObject target, Gradient gradient = null, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
			Gradient = gradient;
			OriginalValue = GetCurrent();
		}

		private TransitionStep SetStartValue(Color value)
		{
			StartValue = value;
			return this;
		}

		private TransitionStep SetEndValue(Color value)
		{
			EndValue = value;
			return this;
		}

		public Color GetCurrent()
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			if (_images.Length != 0)
			{
				return _images[0].color;
			}
			if (_rawImages.Length != 0)
			{
				return _rawImages[0].color;
			}
			if (_texts.Length != 0)
			{
				return _texts[0].color;
			}
			if (_spriteRenderers.Length != 0)
			{
				return _spriteRenderers[0].color;
			}
			if (_materials.Length != 0)
			{
				return _materials[0].color;
			}
			return Color.black;
		}

		public void SetCurrent(Color color)
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			Image[] images = _images;
			for (int i = 0; i < images.Length; i++)
			{
				images[i].color = color;
			}
			RawImage[] rawImages = _rawImages;
			for (int i = 0; i < rawImages.Length; i++)
			{
				rawImages[i].color = color;
			}
			Text[] texts = _texts;
			for (int i = 0; i < texts.Length; i++)
			{
				texts[i].color = color;
			}
			SpriteRenderer[] spriteRenderers = _spriteRenderers;
			for (int i = 0; i < spriteRenderers.Length; i++)
			{
				spriteRenderers[i].color = color;
			}
			Material[] materials = _materials;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i].color = color;
			}
		}

		private void SetupComponentReferences()
		{
			_images = new Image[0];
			_rawImages = new RawImage[0];
			_texts = new Text[0];
			_spriteRenderers = new SpriteRenderer[0];
			_materials = new Material[0];
			Image component = base.Target.GetComponent<Image>();
			if (component != null)
			{
				_images = _images.Concat(Enumerable.Repeat(component, 1)).ToArray();
			}
			RawImage component2 = base.Target.GetComponent<RawImage>();
			if (component2 != null)
			{
				_rawImages = _rawImages.Concat(Enumerable.Repeat(component2, 1)).ToArray();
			}
			Text component3 = base.Target.GetComponent<Text>();
			if (component3 != null)
			{
				_texts = _texts.Concat(Enumerable.Repeat(component3, 1)).ToArray();
			}
			SpriteRenderer component4 = base.Target.GetComponent<SpriteRenderer>();
			if (component4 != null)
			{
				_spriteRenderers = _spriteRenderers.Concat(Enumerable.Repeat(component4, 1)).ToArray();
			}
			MeshRenderer component5 = base.Target.GetComponent<MeshRenderer>();
			if (component5 != null && component5.material != null)
			{
				_materials = _materials.Concat(Enumerable.Repeat(component5.material, 1)).ToArray();
			}
			_hasComponentReferences = true;
		}

		public override void Start()
		{
			if (base.TransitionMode == TransitionModeType.ToOriginal)
			{
				EndValue = OriginalValue;
			}
			else if (base.TransitionMode == TransitionModeType.ToCurrent)
			{
				EndValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromCurrent)
			{
				StartValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromOriginal)
			{
				StartValue = OriginalValue;
			}
			base.Start();
		}

		protected override void ProgressUpdated()
		{
			SetCurrent(Gradient.Evaluate(base.ProgressTweened));
		}
	}
}
