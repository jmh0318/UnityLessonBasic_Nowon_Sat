using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerStateMachine playerState;

    public State state;

    private void Update()
    {
        switch (state
        {
            case State.Idle:
                break;
            case State.Prepare:
                state++;
                break;
            case State.Casting:
                break;
            case State.OnAction:
                state++;
                break;
            case State.Finish:
                break;
            default:
                break;
        }
    }
    public enum State
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
}
