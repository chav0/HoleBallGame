namespace Client.ViewStates
{
    public class MainMenuViewState : BaseViewState
    {
        public override void OnEnter()
        {
            Context.Screens.SetLobbyView();
            Context.Screens.MainMenu.ToWorldsButton.onClick.AddListener(() =>
            {
                SetState(new ChooseWorldViewState());
            });
            Context.Screens.MainMenu.Cheat.onClick.AddListener(() =>
            {
                Context.AppModel.PlayerProfileStorage.LastCompletedWorld = 1000; 
            });
        }
        
        public override void PreModelUpdate()
        {
            
        }

        public override void PostModelUpdate()
        {

        }
    }
}
