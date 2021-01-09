using Client.Model;
using Client.Scene;
using UnityEngine;

namespace Client.ModelStates
{
    public class GameModelState : BaseModelState
    {
        private GameLogic _gameLogic;
        private World _world;
        private float _startTime;
        private UnityScene _scene;
        private Input _input;
        private int _worldId; 
        
        public override int TickRate { get; protected set; } = 40;
        public override World World => _world;
        public override ModelStatus Status => ModelStatus.Battle;

        public GameModelState(int worldId)
        {
            _worldId = worldId; 
        }
        
        public override void OnEnter()
        {
            _scene = Context.Scene;
            _gameLogic = new GameLogic(Context.Settings, _scene);
            _world = _gameLogic.CreateNewWorld(_worldId);
            _gameLogic.Init(_world);
            _startTime = Time.realtimeSinceStartup;
        }
        
        public override void OnExit()
        {
            _scene.Dispose();
            _world.Dispose();
        }
        
        public override void Update(double currentTime)
        {

        }
    }
}
