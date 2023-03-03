using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{

    
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
        
        Time.timeScale = 1;
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
} 
