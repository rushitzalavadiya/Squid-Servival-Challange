using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components
{
	[AddComponentMenu("Beautiful Transitions/Transition Manager")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionManager : MonoBehaviour
	{
		[Tooltip("The default transitions that will be used when transitioning to a new scene. If not specified then it is assumed that they are on the same gameobject as this component.")]
		public UnityEngine.GameObject[] DefaultSceneTransitions;

		public static TransitionManager Instance
		{
			get;
			private set;
		}

		public static bool IsActive => Instance != null;

		private void Awake()
		{
			if (Instance != null)
			{
				if (Instance != this)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else
			{
				Instance = this;
			}
		}

		private void OnDestroy()
		{
			bool flag = Instance == this;
		}

		public void TransitionOutAndLoadScene(string sceneName)
		{
			if (DefaultSceneTransitions.Length == 0)
			{
				TransitionOutAndLoadScene(sceneName, base.gameObject);
			}
			else
			{
				TransitionOutAndLoadScene(sceneName, DefaultSceneTransitions);
			}
		}

		public void TransitionOutAndLoadScene(string sceneName, params UnityEngine.GameObject[] transitionGameObjects)
		{
			float delay = TransitionOut(transitionGameObjects);
			LoadSceneDelayed(sceneName, delay);
		}

		public void TransitionOut()
		{
			if (DefaultSceneTransitions.Length == 0)
			{
				TransitionOut(new UnityEngine.GameObject[1]
				{
					base.gameObject
				});
			}
			else
			{
				TransitionOut(DefaultSceneTransitions);
			}
		}

		public float TransitionOut(UnityEngine.GameObject[] transitionGameObjects)
		{
			List<TransitionBase> list = new List<TransitionBase>();
			foreach (UnityEngine.GameObject gameObject in transitionGameObjects)
			{
				list.AddRange(TransitionHelper.TransitionOut(gameObject));
			}
			return TransitionHelper.GetTransitionOutTime(list);
		}

		public void LoadSceneDelayed(string sceneName, float delay = 0f)
		{
			if (!Mathf.Approximately(delay, 0f))
			{
				StartCoroutine(LoadSceneDelayedCoroutine(sceneName, delay));
			}
			else
			{
				TransitionHelper.LoadScene(sceneName);
			}
		}

		private static IEnumerator LoadSceneDelayedCoroutine(string sceneName, float delay)
		{
			yield return new WaitForSeconds(delay);
			TransitionHelper.LoadScene(sceneName);
		}
	}
}
