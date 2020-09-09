using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTask1 : MonoBehaviour,ITutorialTask
{
    GameObject gamemanager;
    private bool onecheckflag = false;//一回CheckTask()をクリアしたら,2度とクリアしない

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
        return false;
    }

    public bool GetBackButton()
    {
        return false;
    }

    public void OnTaskSetting()
    {
        gamemanager = GameObject.Find("GameManager");
    }
    public void NextTask()
    {
        
    }

    public bool CheckTask()
    {
        if (gamemanager.GetComponent<TutorialManager>().guagecount == 0 && !onecheckflag)
        { 
            onecheckflag = true;
            return true;
        }

        return false;
    }

    public float GetTransitionTime()
    {
        return 0.0f;
    }
}
