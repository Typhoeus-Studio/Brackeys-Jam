using CustomFeatures.Timer;
using FiniteStateMachine.Generic;
using HyperTemplate.HyperMono.HyperCore;
using HyperTemplate.HyperMono.HyperManager.GameStates;
using ModuleHandler;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager
{
    public class GameManager : HyperManager<GameManager>
    {
        public ModuleCenter moduleCenter;
        public LevelData levelData;
        public LevelController levelController;
        public StateMachine<GameManager> stateMachine;

        public State<GameManager>[] states;
        [HideInInspector] public Level currentLevel;
        [SerializeField] private float firstStartDelay;

        public virtual void Awake()
        {
            
        }
        void Start()
        {
            Loading();

            if (firstStartDelay > 0)
                TimerProcessor.Instance.AddTimer(firstStartDelay, AfterLoadingScreen);
            else
            {
                AfterLoadingScreen();
            }
        }

        public void AfterLoadingScreen()
        {
            InitFirst();
            InitializeStates();
            stateMachine.ChangeState(states[0]);
            AfterStatesInit();
            IsInitialized = true;
        }

        public virtual void Loading()
        {
        }

        public void InitFirst()
        {
            Application.targetFrameRate = 60;
        }

        public virtual void AfterStatesInit()
        {
        }

        public void StartLevel()
        {
            stateMachine.ChangeState(states[1]);
        }


        private void Update()
        {
            if (IsInitialized)
                stateMachine.Update();
        }

        public void InitializeStates()
        {
            states = new State<GameManager>[]
            {
                new IdleState(),
                new GameState(),
                new WinState(),
                new LoseState(),
            };
            stateMachine = new StateMachine<GameManager>(this);
        }

        public void ChangeState(int index)
        {
            stateMachine.ChangeState(states[index]);
        }

        public override void Initialize()
        {
        }
    }
}