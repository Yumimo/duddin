using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    public bool IsGrounded { get; set; }
    public LayerMask m_groundMask;

    public Vector2 boxOffset;
    public Vector2 boxSize;

    public Collider2D m_collider;

    public void CheckGround()
    {
        var _groundCheck = Physics2D.BoxCast(m_collider.bounds.center + new Vector3(boxOffset.x, boxOffset.y), boxSize,
            0, Vector2.down, 0 ,m_groundMask);
        if (_groundCheck.collider != null)
        {
            if (_groundCheck.collider.IsTouching(m_collider))
            {
                IsGrounded = true;
            }
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawWireCube(m_collider.bounds.center + new Vector3(boxOffset.x, boxOffset.y, 0), 
            new Vector3(boxSize.x, boxSize.y));
    }

}
