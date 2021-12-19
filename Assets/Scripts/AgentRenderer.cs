using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{

    #region Summary

    /// <summary>
    /// It directs the agent to side that user presses. D => right, A => left side.
    /// </summary>
    /// <param name="input">movement input that PlayerInput returns</param>
    /// <returns></returns>

    #endregion
    public void HandleFlipDirection(Vector2 input) // Faces direction that we press down
    {
        if (Mathf.Abs(input.x) < Mathf.Epsilon) return; // if we are not moving
        transform.parent.localScale = new Vector2(Mathf.Sign(input.x) * 
                                                  Mathf.Abs(transform.localScale.x), 1f);
    }
}

        // ? Mathf.Sign returns 1 when given value is positive or zero, so it means if we are moving on right side (if our input.x is positive), it will return "1", so when we multiply with abs value localscale.x (1) =>  1.
        // ? If input.x is negative it will return -1f. So when we multiply with abs value localscale.x (1) * (-1) => -1;