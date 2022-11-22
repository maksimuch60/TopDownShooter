namespace TDS.Infrastructure.StateMachine
{
    public class GameState : BaseState
    {
        public GameState(IGameStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            ISceneLoadService sceneLoadService = Services.Container.Get<ISceneLoadService>();
            sceneLoadService.Load("GameScene", OnGameSceneLoaded);
        }

        public override void Exit()
        {
            
        }

        private void OnGameSceneLoaded()
        {
            //TODO: register all local game state services
        }
    }
}