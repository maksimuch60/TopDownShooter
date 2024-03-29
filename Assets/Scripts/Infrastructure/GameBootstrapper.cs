﻿using System;
using TDS.Infrastructure.StateMachine;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private void Start()
        {
            GameStateMachine gameStateMachine = new();
            Services.Container.Register<IGameStateMachine>(gameStateMachine);
            
            gameStateMachine.Enter<BootstrapState>();
        }
    }
}