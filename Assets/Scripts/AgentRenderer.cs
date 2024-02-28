using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    private Transform agent;
    private bool isStopFlip;
    public Vector2 Direction { get; set; }

    public void FaceDirection(Vector2 direction)
    {
        if (isStopFlip) return;

        Direction = direction;
        if (agent == null)
        {
            agent = transform.parent;
        }
        var localScale = agent.localScale;
        localScale = direction.x switch
        {
            < 0 => new Vector3(Mathf.Abs(localScale.x), localScale.y, localScale.z),
            > 0 => new Vector3(-1 * Mathf.Abs(localScale.x), localScale.y, localScale.z),
            _ => localScale
        };
        agent.localScale = localScale;
    }

}
