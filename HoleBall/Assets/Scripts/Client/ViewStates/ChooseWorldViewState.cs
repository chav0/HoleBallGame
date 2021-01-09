namespace Client.ViewStates
{
    public class ChooseWorldViewState : BaseViewState
    {
        public override void OnEnter()
        {
            Context.Screens.SetChooseWorldView();
            Context.Screens.ChooseWorld.WorldButton1.Button.onClick.AddListener(() =>
            {
                SetState(new LoadingViewState(1));
            });
            Context.Screens.ChooseWorld.WorldButton2.Button.onClick.AddListener(() =>
            {
                SetState(new LoadingViewState(2));
            });
            Context.Screens.ChooseWorld.WorldButton3.Button.onClick.AddListener(() =>
            {
                SetState(new LoadingViewState(3));
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