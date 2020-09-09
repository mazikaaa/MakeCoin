using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask3 : MonoBehaviour,ITutorialTask
{
    GameObject[] panels;
    public string GetTitle()
    {
        return "パネル操作 (3/4)";
    }

    public string GetText()
    {
        return "タッチしたパネルは赤い枠で囲まれます\n"
            +"次にTouchと表示されている穴のパネルをタッチしてましょう.\n"
            ;
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
        int i = 0;
        GameObject touchframe = GameObject.Find("Touchframe1");
        Animator animator = touchframe.GetComponent<Animator>();
        animator.SetBool("Activate", false);

        GameObject touchframe2 = GameObject.Find("Touchframe2");
        Animator animator2 = touchframe2.GetComponent<Animator>();
        animator2.SetBool("Activate", true);

        panels = GameObject.FindGameObjectsWithTag("Panel");
        foreach (GameObject panel in panels)
        {
            //右から2列目上から1行目だけタッチできるように
            if (i == 8)
                panel.GetComponent<PanelBase>().shuffleflag = true;

            i++;
        }
    }

    public void NextTask()
    {
        GameObject touchframe2 = GameObject.Find("Touchframe2");
        Animator animator2 = touchframe2.GetComponent<Animator>();
        animator2.SetBool("Activate", false);
    }

    public bool CheckTask()
    {
        int i= 0;
        foreach (GameObject panel in panels)
        {
            //右から3列目上から1行目が穴のパネルだったら
            if (panel.GetComponent<PanelBase>().panelNo == 8)
            {
                if (panel.GetComponent<PanelBase>().x==1)
                    return true;
            }
            i++;
        }
        return false;
    }

    public float GetTransitionTime()
    {
        return 0.0f;
    }
}
