using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTask1: ITutorialTask
{
    public string GetTitle()
    {
        return "画面の説明 (1/2)";
    }

    public string GetText()
    {
        return "右上にあるのがコインゲージです.\n"
            +"真ん中には16枚のパネルがあります.これを操作してコインを増やしましょう\n"
            +"右下のケースがゴールです.コインゲージをゴールさせるとスコアが加算されます\n";
    }

    public bool GetNextButton()
    {
        return true;
    }

    public bool GetBackButton()
    {
        return true;
    }

    public void OnTaskSetting()
    {
    }

    public void NextTask()
    {
    }

    public bool CheckTask()
    {
        return false;
    }

    public float GetTransitionTime()
    {
        return 0f;
    }
}
