using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class TransitionController : MonoBehaviour
	{
		private static TransitionController _instance;

		private bool _newSceneLoaded;

		public Texture2D ScreenSnapshot
		{
			get;
			set;
		}

		public bool IsInCrossTransition
		{
			get;
			set;
		}

		public ScreenWipeComponents SharedScreenWipeComponents
		{
			get;
			set;
		}

		public ScreenFadeComponents SharedScreenFadeComponents
		{
			get;
			set;
		}

		public static TransitionController Instance
		{
			get
			{
				if (_instance == null)
				{
					GameObject gameObject = new GameObject("(Beautiful Transitions - Controller)");
					_instance = gameObject.AddComponent<TransitionController>();
					_instance.Setup();
					Object.DontDestroyOnLoad(gameObject);
				}
				return _instance;
			}
			private set
			{
				_instance = value;
			}
		}

		public static bool IsActive => Instance != null;

		private void Setup()
		{
			SharedScreenWipeComponents = new ScreenWipeComponents();
			SharedScreenFadeComponents = new ScreenFadeComponents();
		}

		public IEnumerator LoadSceneAndWaitForLoad(string sceneToLoad)
		{
			SceneManager.sceneLoaded += OnSceneFinishedLoading;
			TransitionHelper.LoadScene(sceneToLoad);
			while (!_newSceneLoaded)
			{
				yield return null;
			}
			_newSceneLoaded = false;
			SceneManager.sceneLoaded -= OnSceneFinishedLoading;
		}

		private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
		{
			_newSceneLoaded = true;
		}

		public void TakeScreenshot()
		{
			StartCoroutine(TakeScreenshotCoroutine());
		}

		public IEnumerator TakeScreenshotCoroutine()
		{
			yield return new WaitForEndOfFrame();
			ScreenSnapshot = TransitionHelper.TakeScreenshot();
		}
	}
}
