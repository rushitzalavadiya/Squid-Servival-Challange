using DG.Tweening.Plugins;
using UnityEngine;

namespace DG.Tweening
{
    public static class DOTweenProShortcuts
    {
        static DOTweenProShortcuts()
        {
            new SpiralPlugin();
        }

        public static Tweener DOSpiral(this Transform target, float duration, Vector3? axis = default,
            SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f,
            bool snapping = false)
        {
            if (Mathf.Approximately(speed, 0f)) speed = 1f;
            if (!axis.HasValue || axis == Vector3.zero) axis = Vector3.forward;
            var tweenerCore = DOTween.To(SpiralPlugin.Get(), () => target.localPosition,
                delegate(Vector3 x) { target.localPosition = x; }, axis.Value, duration).SetTarget(target);
            tweenerCore.plugOptions.mode = mode;
            tweenerCore.plugOptions.speed = speed;
            tweenerCore.plugOptions.frequency = frequency;
            tweenerCore.plugOptions.depth = depth;
            tweenerCore.plugOptions.snapping = snapping;
            return tweenerCore;
        }

        public static Tweener DOSpiral(this Rigidbody target, float duration, Vector3? axis = default,
            SpiralMode mode = SpiralMode.Expand, float speed = 1f, float frequency = 10f, float depth = 0f,
            bool snapping = false)
        {
            if (Mathf.Approximately(speed, 0f)) speed = 1f;
            if (!axis.HasValue || axis == Vector3.zero) axis = Vector3.forward;
            var tweenerCore = DOTween
                .To(SpiralPlugin.Get(), () => target.position, target.MovePosition, axis.Value, duration)
                .SetTarget(target);
            tweenerCore.plugOptions.mode = mode;
            tweenerCore.plugOptions.speed = speed;
            tweenerCore.plugOptions.frequency = frequency;
            tweenerCore.plugOptions.depth = depth;
            tweenerCore.plugOptions.snapping = snapping;
            return tweenerCore;
        }
    }
}