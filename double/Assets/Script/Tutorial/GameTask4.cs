using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask4 : MonoBehaviour,ITutorialTask
{
    GameObject[] panels;

    public string GetTitle()
    {
        return "パネル操作 (4/4)";
    }

    public string GetText()
    {
        return "パネルを入れ替えることが出来ました\n"
            + "このように穴とパネルの位置を替えて,上手くコインを増やしましょう\n"
            + "ただし紫の枠で囲まれているものは入れ替えることが出来ないので注意してください\n"
            +"今回は時間を止めているので,自由にパネルを入れ替えてみてください.\n\n"
            +"ボタンを押すと時間が動き出します.";
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
        panels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject panel in panels)
        {
            panel.GetComponent<PanelBase>().shuffleflag = true;
        }

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
        return 0.0f;
    }
}
