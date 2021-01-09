using UnityEngine;

namespace Client.View
{
    public class Screens : MonoBehaviour
    {
        public MainMenu MainMenu;
        public ChooseWorld ChooseWorld;
        public GameWindow GameWindow; 
        public ResultWindow ResultWindow; 

        public void SetLobbyView()
        {
            MainMenu.gameObject.SetActive(true);
            ChooseWorld.gameObject.SetActive(false);
            GameWindow.gameObject.SetActive(false);
            ResultWindow.gameObject.SetActive(false);
        }

        public void SetChooseWorldView()
        {
            MainMenu.gameObject.SetActive(false);
            ChooseWorld.gameObject.SetActive(true);
            GameWindow.gameObject.SetActive(false);
            ResultWindow.gameObject.SetActive(false);
        }

        public void SetBattleView()
        {
            MainMenu.gameObject.SetActive(false);
            ChooseWorld.gameObject.SetActive(false);
            GameWindow.gameObject.SetActive(true);
            ResultWindow.gameObject.SetActive(false);
        }

        public void SetResultView()
        {
            MainMenu.gameObject.SetActive(false);
            ChooseWorld.gameObject.SetActive(false);
            GameWindow.gameObject.SetActive(false);
            ResultWindow.gameObject.SetActive(true);
        }
    }
}
