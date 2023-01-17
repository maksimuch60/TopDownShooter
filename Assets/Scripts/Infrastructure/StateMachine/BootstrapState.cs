using TDS.Infrastructure.Coroutine;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine
{
    public class BootstrapState : BaseState
    {
        public BootstrapState(IGameStateMachine stateMachine) : base(stateMachine)
        {
            
        }

        public override void Enter()
        {
            RegisterAllGlobalServices();

            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("MenuScene", OnSceneLoaded);
        }

        private void OnSceneLoaded()
        {
            StateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
            
        }

        private void RegisterAllGlobalServices()
        {
            CreateCoroutineRunner();
            Services.Container.Register<ISceneLoadService>(
                new SyncSceneLoadService(Services.Container.Get<ICoroutineRunner>()));
        }

        private void CreateCoroutineRunner()
        {
            CoroutineRunner coroutineRunner = new GameObject(nameof(CoroutineRunner)).AddComponent<CoroutineRunner>();
            Object.DontDestroyOnLoad(coroutineRunner);
            Services.Container.Register<ICoroutineRunner>(coroutineRunner);
        }
    }
}