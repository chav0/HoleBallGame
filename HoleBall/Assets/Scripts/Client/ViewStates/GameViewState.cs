namespace Client.ViewStates
{
    public class GameViewState : BaseViewState
    {
        public override void OnEnter()
        {
            Context.Screens.SetBattleView();
            
            Context.Screens.GameWindow.Start.onClick.AddListener(() =>
            {
                Context.AppModel.World.Start();
                Context.Screens.GameWindow.Restart.gameObject.SetActive(true);
                Context.Screens.GameWindow.Start.gameObject.SetActive(false);
            });
            
            Context.Screens.GameWindow.Restart.onClick.AddListener(() =>
            {
                Context.AppModel.World.Restart();
                Context.Screens.GameWindow.Restart.gameObject.SetActive(false);
                Context.Screens.GameWindow.Start.gameObject.SetActive(true);
            });
        }
        
        public override void PreModelUpdate()
        {

        }

        public override void PostModelUpdate()
        {
            if (Context.AppModel.World.BallInTheHole)
            {
                Context.AppModel.World.SetWin();
                SetState(new ResultViewState());
            }
        }
    }
}
