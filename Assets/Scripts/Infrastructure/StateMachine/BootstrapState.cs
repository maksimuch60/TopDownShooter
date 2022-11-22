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

        public override void Exit()
        {
            
        }

        private void RegisterAllGlobalServices()
        {
            Services.Container.Register<ISceneLoadService>(new SyncSceneLoadService());
        }

        private void OnSceneLoaded()
        {
            StateMachine.Enter<MenuState>();
        }
    }
}