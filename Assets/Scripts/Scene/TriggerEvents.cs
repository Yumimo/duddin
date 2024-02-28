using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerEvents : MonoBehaviour
{
    public UnityEvent enterEvent;
    public UnityEvent exitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        enterEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        exitEvent?.Invoke();
    }
}
