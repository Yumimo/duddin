using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PenguinEvent : MonoBehaviour
{
    public PlayableDirector cutscene;
    public UnityEvent penguinEvent;
    private bool isDone;
    public void RingValidation()
    {
        if (!GameManager.Instance.HasRing) return;
        if (isDone) return;
        cutscene.Play();
        penguinEvent?.Invoke();
        isDone = true;
    }
}
