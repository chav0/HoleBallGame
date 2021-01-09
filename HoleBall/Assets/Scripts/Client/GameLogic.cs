using Client.Scene;

namespace Client
{
    public class GameLogic
    {
        private readonly GameSettings _gameSettings;
        private readonly UnityScene _scene;
        private World _world;
        
        public GameLogic(GameSettings settings, UnityScene scene)
        {
            _gameSettings = settings; 
            _scene = scene;
        }
        
        public void Init(World world)
        {
            _world = world;
        }

        public World CreateNewWorld(int worldId)
        {
            var worldObj = _scene.CreateWorldObject(worldId); 
            var world = new World(worldObj, worldId);
            return world;
        }
    }
}
