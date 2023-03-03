using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : UICanvas
{
    //public Text score;
    

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MianMenu>();
        Close(0);
    }

    public void GamePlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
    }
}
