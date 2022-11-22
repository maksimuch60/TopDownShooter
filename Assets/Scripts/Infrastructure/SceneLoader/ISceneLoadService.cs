using System;

namespace TDS.Infrastructure
{
    public interface ISceneLoadService : IService
    {
        void Load(string sceneName, Action completeCallback);
    }
}