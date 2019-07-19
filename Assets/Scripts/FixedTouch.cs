using UnityEngine;
using System.Collections;

public static class FixedTouch {

    public static Vector2 FixedTouchDelta(this Touch aTouch)
    {
        float dt = Time.deltaTime / aTouch.deltaTime;
        if (dt == 0 || float.IsNaN(dt) || float.IsInfinity(dt))
            dt = 1.0f;
        return aTouch.deltaPosition * dt;
    }
}
