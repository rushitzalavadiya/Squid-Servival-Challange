using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses
{
	public abstract class TransitionGameObjectBase : TransitionBase
	{
		[Tooltip("The target gameobject upon which to perform the transition. If not specified then the transition will typically operate upon the current gameobject.")]
		public UnityEngine.GameObject Target;

		public void Awake()
		{
			if (Target == null)
			{
				Target = base.gameObject;
			}
		}
	}
}
