using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IState _currentState;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        ChangeState(new PlayerMovementState());
    }

    public void ChangeState(IState newState)
    {
        _currentState?.Exit(_player);
        _currentState = newState;
        _currentState.Enter(_player);
    }

    private void Update()
    {
        _currentState?.Execute(_player);
    }
}
