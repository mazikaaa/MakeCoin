using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTask : MonoBehaviour,ITutorialTask
{
    public string GetTitle()
    {
        return "ゲームのクリア判定";
    }

    public string GetText()
    {
        return "これでチュートリアルは終了です.\n"
            +"ボタンを押すとスタート画面に戻ります\n";
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
