using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask1 :MonoBehaviour,ITutorialTask
{
    public string GetTitle()
    {
        return "パネル操作 (1/4)";
    }

    public string GetText()
    {
        return "shuffletimeが進み始めるとパネルを操作することが出来ます.\n"
            + "ただしshuffletimeが0になるとパネル操作は出来なくなります.\n"
            + "今回は特別に時間を止めていてもパネル操作が出来るようにしました.\n"
            + "それではパネルを動かしてみましょう";
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
        int i=0;
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<TutorialManager>().shuffletimeflag = true;
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (GameObject panel in panels)
        {
            //右から3列目上から1行目だけタッチできるように
            if (i==4)
            panel.GetComponent<PanelBase>().shuffleflag = true;

            i++;
        }

        GameTask1 gametask = (new GameObject("Time")).AddComponent<GameTask1>();
        gametask.StartCoroutine(StopTime(1.0f));

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

    protected IEnumerator StopTime(float time = 2.0f)
    {
        yield return new WaitForSeconds(time);
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<TutorialManager>().shuffletimeflag = false;

    }

}
