using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask4_2 : MonoBehaviour,ITutorialTask
{
    GameObject gamemanager;
    float time = 0.0f;
    private bool onecheckflag = false;//一回CheckTask()をクリアしたら,2度とクリアしない

    public string GetTitle()
    {
        return "パネル操作 (4/4)";
    }

    public string GetText()
    {
        return "パネルを入れ替えることが出来ました\n"
            + "このように穴とパネルの位置を替えて,上手くコインを増やしましょう\n"
            + "ただし紫の枠で囲まれているものは入れ替えることが出来ないので注意してください\n"
            + "時間を止めているので,自由にパネルを入れ替えてみてください.\n\n"
            + "ボタンを押すと時間が動き出します.";
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
        gamemanager.GetComponent<TutorialManager>().shuffletimeflag = true;
    }
    public void NextTask()
    {
    }

    public bool CheckTask()
    {
        time += Time.deltaTime;
        if (time >= 2.0f&&!onecheckflag)
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
