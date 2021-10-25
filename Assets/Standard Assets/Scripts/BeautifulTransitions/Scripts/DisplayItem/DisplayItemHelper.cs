using System.Collections;
using UnityEngine;

namespace BeautifulTransitions.Scripts.DisplayItem
{
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	internal class DisplayItemHelper
	{
		public static void SyncActiveStateAnimated(GameObject gameObject)
		{
			gameObject.GetComponent<Animator>().SetBool("Active", gameObject.activeSelf);
		}

		public static void SetAttention(GameObject gameObject, bool attention)
		{
			gameObject.GetComponent<Animator>().SetBool("Attention", attention);
		}

		public static void SetActiveAnimated(MonoBehaviour caller, GameObject gameObject, bool value)
		{
			caller.StartCoroutine(SetActiveAnimatedCoroutine(gameObject, value));
		}

		public static IEnumerator SetActiveAnimatedCoroutine(GameObject gameObject, bool value)
		{
			Animator animator = gameObject.GetComponent<Animator>();
			if (value)
			{
				gameObject.SetActive(value: true);
				animator.Play("NotActive");
				animator.SetBool("Active", value: true);
				yield break;
			}
			animator.SetBool("Active", value: false);
			bool closedStateReached = false;
			while (!closedStateReached)
			{
				if (!animator.IsInTransition(0))
				{
					closedStateReached = animator.GetCurrentAnimatorStateInfo(0).IsName("NotActive");
				}
				yield return new WaitForEndOfFrame();
			}
			gameObject.SetActive(value: false);
		}
	}
}
