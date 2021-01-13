namespace Client.ViewStates
{
    public class GameViewState : BaseViewState
    {
        public override void OnEnter()
        {
            Context.Screens.SetBattleView();

            var startButton = Context.Screens.GameWindow.Start;
            var restartButton = Context.Screens.GameWindow.Restart; 
            
            restartButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
            
            startButton.onClick.AddListener(() =>
            {
                Context.AppModel.World.Start();
                restartButton.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
            });
            
            Context.Screens.GameWindow.Restart.onClick.AddListener(() =>
            {
                Context.AppModel.World.Restart();
                restartButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
            });
            
            Context.Screens.GameWindow.ToMenu.onClick.AddListener(() =>
            {
                SetState(new ChooseWorldViewState());
                Context.AppModel.DeleteWorld();
            });
        }
        
        public override void PreModelUpdate()
        {

        }

        public override void PostModelUpdate()
        {
            if (Context.AppModel.World.BallInTheHole)
            {
                if (Context.AppModel.PlayerProfileStorage.LastCompletedWorld < Context.AppModel.World.WorldId)
                    Context.AppModel.PlayerProfileStorage.LastCompletedWorld = Context.AppModel.World.WorldId; 
                Context.AppModel.World.SetWin();
                SetState(new ResultViewState());
            }
        }
    }
}
