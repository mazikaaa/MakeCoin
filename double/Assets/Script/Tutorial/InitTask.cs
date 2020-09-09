using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTask : ITutorialTask
{
    public string GetTitle()
    {
        return "はじめに";
    }

    public string GetText()
    {
        return "ここではこのゲームの説明をします\n" + "このゲームはパネルの効果を使ってコインを増やしていくゲームです\n";
    }

    public bool GetNextButton()
    {
        return true;
    }

    public bool GetBackButton()
    {
        return false;
    }

    public void OnTaskSetting()
    {
    }

    public void NextTask()
    {
    }

    public bool CheckTask()
    {
            return true; 
    }

    public float GetTransitionTime()
    {
        return 0f;
    }
}
