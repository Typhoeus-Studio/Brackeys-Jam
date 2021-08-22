namespace FiniteStateMachine.Interface
{
    public class StateMachineInt
    {
        private IState _currentState;
        
        
        public StateMachineInt()
        {
            
        }

        public void ChangeState(IState nextState)
        {
            _currentState?.OnExit();

            _currentState = nextState;
            _currentState.OnEnter();
        }

        public void Update()
        {
            _currentState.Update();
        }
    }
}