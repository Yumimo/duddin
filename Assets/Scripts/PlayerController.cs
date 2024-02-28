using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsGrounded => groundCollider.IsGrounded;
    [HideInInspector] public Rigidbody2D rigidbody2D;
    public PlayerInput Input;
    public HumanoidAnimation Animation;
    public StateManager stateManager;

    private GroundCollider groundCollider;
    private AgentRenderer agentRenderer;

    private State currentState = null;
    public State CurrentState => currentState;
    public State PreviousState { private set; get; }

    [Header("Current State")]
    public string stateName;
    void Awake()
    {
        groundCollider = GetComponentInChildren<GroundCollider>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        stateManager.SetupStates(this);
    }

    private void Start()
    {
        Input.OnPlayerMove += agentRenderer.FaceDirection;
        TransitionToState(stateManager.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        groundCollider.CheckGround();
        if(currentState != null)
        {
            currentState.StateUpdate();
        }
    }

    public void DisableControl()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        Input.HoldInput = true;
    }
    public void EnableControls()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Input.HoldInput = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Penguin"))
        {
            TransitionToState(stateManager.Knockback);
        }
    }
    internal void TransitionToState(State nextState)
    {

        if (nextState == null) return;

        if (currentState != null)
        {
            currentState.Exit();
        }
        PreviousState = currentState;
        currentState = nextState;
        currentState.Enter();

        //Debugger
        if (PreviousState == null || PreviousState.GetType() != currentState.GetType())
        {
            stateName = currentState.GetType().ToString();
        }
    }

    private void OnDisable()
    {
        Input.OnPlayerMove -= agentRenderer.FaceDirection;
    }
}
