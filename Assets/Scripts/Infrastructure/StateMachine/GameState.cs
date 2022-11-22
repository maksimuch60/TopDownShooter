using TDS.Game.InputService;
using TDS.Game.Player;
using UnityEngine;

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
            UnRegisterLocalServices();
        }

        private void UnRegisterLocalServices()
        {
            Services.Container.UnRegister<IInputService>();
        }

        private void OnGameSceneLoaded()
        {
            RegisterLocalServices();
        }

        private void RegisterLocalServices()
        {
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            RegisterInputService(playerMovement);
            InitPlayerMovement(playerMovement);
        }

        private void InitPlayerMovement(PlayerMovement playerMovement)
        {
            playerMovement.Construct(Services.Container.Get<IInputService>());
        }

        private void RegisterInputService(PlayerMovement playerMovement)
        {
            Services.Container.Register<IInputService>(
                new StandaloneInputService(Camera.main, playerMovement.transform));
        }
    }
}