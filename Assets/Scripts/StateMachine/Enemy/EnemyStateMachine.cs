using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IState _currentState;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        ChangeState(new EnemyMovementState());
    }

    public void ChangeState(IState newState)
    {
        _currentState?.Exit(_enemy);
        _currentState = newState;
        _currentState.Enter(_enemy);
    }

    private void Update()
    {
        _currentState?.Execute(_enemy);
    }
}
