using BeautifulTransitions.Scripts.Helper;
using BeautifulTransitions.Scripts.Transitions.Components;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeautifulTransitions.Scripts.Transitions
{
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionHelper
	{
		public enum TweenType
		{
			none = 0,
			easeInQuad = 1,
			easeOutQuad = 2,
			easeInOutQuad = 3,
			easeInCubic = 4,
			easeOutCubic = 5,
			easeInOutCubic = 6,
			easeInQuart = 7,
			easeOutQuart = 8,
			easeInOutQuart = 9,
			easeInQuint = 10,
			easeOutQuint = 11,
			easeInOutQuint = 12,
			easeInSine = 13,
			easeOutSine = 14,
			easeInOutSine = 0xF,
			easeInExpo = 0x10,
			easeOutExpo = 17,
			easeInOutExpo = 18,
			easeInCirc = 19,
			easeOutCirc = 20,
			easeInOutCirc = 21,
			linear = 22,
			spring = 23,
			easeInBounce = 24,
			easeOutBounce = 25,
			easeInOutBounce = 26,
			easeInBack = 27,
			easeOutBack = 28,
			easeInOutBack = 29,
			easeInElastic = 30,
			easeOutElastic = 0x1F,
			easeInOutElastic = 0x20,
			AnimationCurve = 999
		}

		public static TweenMethods.TweenFunction GetTweenFunction(TweenType progressMode)
		{
			TweenMethods.TweenFunction result = null;
			switch (progressMode)
			{
			case TweenType.easeInQuad:
				result = TweenMethods.easeInQuad;
				break;
			case TweenType.easeOutQuad:
				result = TweenMethods.easeOutQuad;
				break;
			case TweenType.easeInOutQuad:
				result = TweenMethods.easeInOutQuad;
				break;
			case TweenType.easeInCubic:
				result = TweenMethods.easeInCubic;
				break;
			case TweenType.easeOutCubic:
				result = TweenMethods.easeOutCubic;
				break;
			case TweenType.easeInOutCubic:
				result = TweenMethods.easeInOutCubic;
				break;
			case TweenType.easeInQuart:
				result = TweenMethods.easeInQuart;
				break;
			case TweenType.easeOutQuart:
				result = TweenMethods.easeOutQuart;
				break;
			case TweenType.easeInOutQuart:
				result = TweenMethods.easeInOutQuart;
				break;
			case TweenType.easeInQuint:
				result = TweenMethods.easeInQuint;
				break;
			case TweenType.easeOutQuint:
				result = TweenMethods.easeOutQuint;
				break;
			case TweenType.easeInOutQuint:
				result = TweenMethods.easeInOutQuint;
				break;
			case TweenType.easeInSine:
				result = TweenMethods.easeInSine;
				break;
			case TweenType.easeOutSine:
				result = TweenMethods.easeOutSine;
				break;
			case TweenType.easeInOutSine:
				result = TweenMethods.easeInOutSine;
				break;
			case TweenType.easeInExpo:
				result = TweenMethods.easeInExpo;
				break;
			case TweenType.easeOutExpo:
				result = TweenMethods.easeOutExpo;
				break;
			case TweenType.easeInOutExpo:
				result = TweenMethods.easeInOutExpo;
				break;
			case TweenType.easeInCirc:
				result = TweenMethods.easeInCirc;
				break;
			case TweenType.easeOutCirc:
				result = TweenMethods.easeOutCirc;
				break;
			case TweenType.easeInOutCirc:
				result = TweenMethods.easeInOutCirc;
				break;
			case TweenType.linear:
				result = TweenMethods.linear;
				break;
			case TweenType.spring:
				result = TweenMethods.spring;
				break;
			case TweenType.easeInBounce:
				result = TweenMethods.easeInBounce;
				break;
			case TweenType.easeOutBounce:
				result = TweenMethods.easeOutBounce;
				break;
			case TweenType.easeInOutBounce:
				result = TweenMethods.easeInOutBounce;
				break;
			case TweenType.easeInBack:
				result = TweenMethods.easeInBack;
				break;
			case TweenType.easeOutBack:
				result = TweenMethods.easeOutBack;
				break;
			case TweenType.easeInOutBack:
				result = TweenMethods.easeInOutBack;
				break;
			case TweenType.easeInElastic:
				result = TweenMethods.easeInElastic;
				break;
			case TweenType.easeOutElastic:
				result = TweenMethods.easeOutElastic;
				break;
			case TweenType.easeInOutElastic:
				result = TweenMethods.easeInOutElastic;
				break;
			}
			return result;
		}

		public static bool ContainsTransition(GameObject gameObject)
		{
			return gameObject.GetComponents<TransitionBase>().Length != 0;
		}

		public static List<TransitionBase> TransitionIn(GameObject gameObject, Action onComplete = null)
		{
			List<TransitionBase> list = TransitionIn(gameObject, isRecursiveCall: false);
			if (onComplete != null && list.Count > 0)
			{
				TransitionController.Instance.StartCoroutine(CallActionAfterDelay(GetTransitionInTime(list), onComplete));
			}
			return list;
		}

		private static List<TransitionBase> TransitionIn(GameObject gameObject, bool isRecursiveCall)
		{
			TransitionBase[] components = gameObject.GetComponents<TransitionBase>();
			List<TransitionBase> list = new List<TransitionBase>();
			bool flag = false;
			TransitionBase[] array = components;
			foreach (TransitionBase transitionBase in array)
			{
				if (transitionBase.isActiveAndEnabled && (!isRecursiveCall || !transitionBase.TransitionInConfig.MustTriggerDirect))
				{
					transitionBase.TransitionIn();
					list.Add(transitionBase);
					if (transitionBase.TransitionInConfig.TransitionChildren)
					{
						flag = true;
					}
				}
			}
			if ((components.Length == 0) | flag)
			{
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					Transform child = gameObject.transform.GetChild(j);
					list.AddRange(TransitionIn(child.gameObject, isRecursiveCall: true));
				}
			}
			return list;
		}

		public static List<TransitionBase> TransitionOut(GameObject gameObject, Action onComplete = null)
		{
			List<TransitionBase> list = TransitionOut(gameObject, isRecursiveCall: false);
			if (onComplete != null && list.Count > 0)
			{
				TransitionController.Instance.StartCoroutine(CallActionAfterDelay(GetTransitionOutTime(list), onComplete));
			}
			return list;
		}

		private static List<TransitionBase> TransitionOut(GameObject gameObject, bool isRecursiveCall)
		{
			TransitionBase[] components = gameObject.GetComponents<TransitionBase>();
			List<TransitionBase> list = new List<TransitionBase>();
			bool flag = false;
			TransitionBase[] array = components;
			foreach (TransitionBase transitionBase in array)
			{
				if (transitionBase.isActiveAndEnabled && (!isRecursiveCall || !transitionBase.TransitionOutConfig.MustTriggerDirect))
				{
					transitionBase.TransitionOut();
					list.Add(transitionBase);
					if (transitionBase.TransitionOutConfig.TransitionChildren)
					{
						flag = true;
					}
				}
			}
			if ((components.Length == 0) | flag)
			{
				for (int j = 0; j < gameObject.transform.childCount; j++)
				{
					Transform child = gameObject.transform.GetChild(j);
					list.AddRange(TransitionOut(child.gameObject, isRecursiveCall: true));
				}
			}
			return list;
		}

		public static float GetTransitionInTime(List<TransitionBase> transitionBases)
		{
			float num = 0f;
			foreach (TransitionBase transitionBasis in transitionBases)
			{
				num = Mathf.Max(num, transitionBasis.TransitionInConfig.Delay + transitionBasis.TransitionInConfig.Duration);
			}
			return num;
		}

		public static float GetTransitionOutTime(List<TransitionBase> transitionBases)
		{
			float num = 0f;
			foreach (TransitionBase transitionBasis in transitionBases)
			{
				num = Mathf.Max(num, transitionBasis.TransitionOutConfig.Delay + transitionBasis.TransitionOutConfig.Duration);
			}
			return num;
		}

		public static IEnumerator CallActionAfterDelay(float delay, Action action)
		{
			yield return new WaitForSeconds(delay);
			action();
		}

		public static Texture2D TakeScreenshot()
		{
			Texture2D texture2D = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, mipChain: false, linear: false);
			texture2D.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0, recalculateMipMaps: false);
			texture2D.Apply();
			return texture2D;
		}

		public static void LoadScene(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}
	}
}
