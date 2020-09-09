using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTask1_2 : MonoBehaviour, ITutorialTask
{
    public string GetTitle()
    {
        return "コインゲージの落下";
    }

    public string GetText()
    {
        return "shuffletimeが0になるとコインゲージが落下し始めます.\n"
            + "またパネルも動かせなくなるので注意してください\n"
            + "コインゲージはパネルに載るとそのパネルの効果が発動します\n"
            + "そしてゴールに到達すると中に入っているコインの分だけスコアが加算されます\n";
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
        return 0.0f;
    }
}
