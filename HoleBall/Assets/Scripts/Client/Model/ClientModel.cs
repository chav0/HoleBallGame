using Client.ModelStates;
using Client.Scene;

namespace Client.Model
{
    public class ClientModel
    {
        public readonly GameSettings Settings;
        public readonly UnityScene Scene;
        private readonly Resources Resources; 
        
        public BaseModelState CurrentState { get; set; }
        public ModelStatus Status => CurrentState.Status; 
        public World World => CurrentState.World;
        
        public ClientModel(GameSettings gameSettings, UnityScene scene, Resources resources)
        {
            Settings = gameSettings;
            Scene = scene;
            Resources = resources; 
            CurrentState = new InitModelState();
            CurrentState.Context = this; 
            CurrentState.OnEnter();
        }

        public void Update(double currentTime)
        {
            CurrentState.Update(currentTime);
        }

        public void CreateWorld(int worldId)
        {
            CurrentState.SetState(new GameModelState(worldId));
        }

        public void DeleteWorld()
        {
            CurrentState.SetState(new InitModelState());
        }
    }

    public enum ModelStatus
    {
        Init,
        Battle,
    }
}
