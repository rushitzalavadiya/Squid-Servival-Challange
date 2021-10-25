using UnityEngine;

namespace DG.Tweening
{
    public static class DOTweenCYInstruction
    {
        public class WaitForCompletion : CustomYieldInstruction
        {
            private readonly Tween t;

            public WaitForCompletion(Tween tween)
            {
                t = tween;
            }

            public override bool keepWaiting
            {
                get
                {
                    if (t.active) return !t.IsComplete();
                    return false;
                }
            }
        }

        public class WaitForRewind : CustomYieldInstruction
        {
            private readonly Tween t;

            public WaitForRewind(Tween tween)
            {
                t = tween;
            }

            public override bool keepWaiting
            {
                get
                {
                    if (t.active)
                    {
                        if (t.playedOnce) return t.position * (t.CompletedLoops() + 1) > 0f;
                        return true;
                    }

                    return false;
                }
            }
        }

        public class WaitForKill : CustomYieldInstruction
        {
            private readonly Tween t;

            public WaitForKill(Tween tween)
            {
                t = tween;
            }

            public override bool keepWaiting => t.active;
        }

        public class WaitForElapsedLoops : CustomYieldInstruction
        {
            private readonly int elapsedLoops;
            private readonly Tween t;

            public WaitForElapsedLoops(Tween tween, int elapsedLoops)
            {
                t = tween;
                this.elapsedLoops = elapsedLoops;
            }

            public override bool keepWaiting
            {
                get
                {
                    if (t.active) return t.CompletedLoops() < elapsedLoops;
                    return false;
                }
            }
        }

        public class WaitForPosition : CustomYieldInstruction
        {
            private readonly float position;
            private readonly Tween t;

            public WaitForPosition(Tween tween, float position)
            {
                t = tween;
                this.position = position;
            }

            public override bool keepWaiting
            {
                get
                {
                    if (t.active) return t.position * (t.CompletedLoops() + 1) < position;
                    return false;
                }
            }
        }

        public class WaitForStart : CustomYieldInstruction
        {
            private readonly Tween t;

            public WaitForStart(Tween tween)
            {
                t = tween;
            }

            public override bool keepWaiting
            {
                get
                {
                    if (t.active) return !t.playedOnce;
                    return false;
                }
            }
        }
    }
}