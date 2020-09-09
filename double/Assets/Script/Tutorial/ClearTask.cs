using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTask : MonoBehaviour,ITutorialTask
{
    public string GetTitle()
    {
        return "ゲームのクリア判定";
    }

    public string GetText()
    {
        return "scoreがclearscoreより大きければゲームクリアです.\n"
            + "ゲームクリアすると次のステージに進むことが出来ます.\n"
            + "逆に小さいとゲームオーバーになります.\n"
            + "ゲームオーバーになるとステージ1からやり直しになります.\n";
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
        return true;
    }

    public float GetTransitionTime()
    {
        return 0.0f;
    }
}
