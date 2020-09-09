using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTask2 : ITutorialTask
{
    public string GetTitle()
    {
        return "画面の説明 (2/2)";
    }

    public string GetText()
    {
        return "shuffletimeはパネル交換できる時間です.0になるまでパネルを動かすことが出来ます.\n "
            + "scoreはゴールに入れたコインの枚数を表示します.\n"
            + "clearscoreは目標となるスコアです.scoreがこれより大きくなるとゲームクリアで次のゲームに進めます\n\n"
            +"(Nextを押すと時間が進み始めます)";
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
        return 0f;
    }
}
