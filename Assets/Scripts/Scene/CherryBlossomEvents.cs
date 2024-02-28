using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class CherryBlossomEvents : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cherryBlossomCamera;
    [SerializeField] CinemachineVirtualCamera _followCamera;

    public PlayableDirector cherryCutscene;
    public Collider2D _cherryTriggerBlocker;

    public int prioCamera = 11;
    public int staticCamera = 10;
    private bool isTriggered;
    public void TriggerCherryBlossomEvent()
    {
        if (isTriggered) return;
        cherryCutscene.Play();
        isTriggered = true;
    }

    public void EnterCherryBlossomArea()
    {
        _cherryBlossomCamera.Priority = prioCamera;
        _followCamera.Priority = staticCamera;
    }

    public void ExitCherryBlossomArea()
    {
        _cherryBlossomCamera.Priority = staticCamera;
        _followCamera.Priority = prioCamera;

        if(GameManager.Instance.HasRing)
        {
            _cherryTriggerBlocker.isTrigger = false;
        }
    }
}
