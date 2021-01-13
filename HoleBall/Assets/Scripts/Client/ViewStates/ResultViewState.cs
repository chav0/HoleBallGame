namespace Client.ViewStates
{
    public class ResultViewState : BaseViewState
    {
        public override void OnEnter()
        {
            Context.Screens.SetResultView();
            Context.Screens.ResultWindow.MainMenu.onClick.AddListener(() =>
            {
                SetState(new ChooseWorldViewState());
                Context.AppModel.DeleteWorld();
            });
            Context.Screens.ResultWindow.NextWorld.onClick.AddListener(() =>
            {
                SetState(new LoadingViewState(Context.AppModel.World.WorldId + 1));
                Context.AppModel.DeleteWorld();
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
