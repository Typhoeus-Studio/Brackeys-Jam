namespace FiniteStateMachine.Generic
{
    public class StateMachine<T>
    {
        public State<T> currentState;

        public T owner;

        private bool stateChanging;
        private State<T> nextState;

        public bool IsCurrentStateNull
        {
            get => currentState == null;
        }

        public StateMachine(T owner)
        {
            this.owner = owner;
        }


        public void ChangeState(State<T> newState)
        {
            stateChanging = true;
            nextState = newState;
        }

        public void Update()
        {
            currentState?.UpdateState(owner);
            if (stateChanging) ChangeStateInUpdate();
        }

        private void ChangeStateInUpdate()
        {
            currentState?.ExitState(owner);
            currentState = nextState;
            currentState.EnterState(owner);
            stateChanging = false;
        }
    }
}