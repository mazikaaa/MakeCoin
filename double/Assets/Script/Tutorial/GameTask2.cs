using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTask2 : MonoBehaviour,ITutorialTask
{
    GameObject[] panels;
    bool onecheckflag = false;//一回CheckTask()をクリアしたら,2度とクリアしない

    public string GetTitle()
    {
        return "パネル操作 (2/4)";
    }

    public string GetText()
    {
        return "パネルを動かしてみましょう\n"
            + "穴(黒いパネル)に隣接するパネルを交換することが出来ます.\n"
            + "Touchと表示されているパネルをクリックしてみましょう\n";
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
        GameObject touchframe = GameObject.Find("Touchframe1");
        Animator animator = touchframe.GetComponent<Animator>();
        animator.SetBool("Activate",true);
        panels = GameObject.FindGameObjectsWithTag("Panel");

    }
    public void NextTask()
    {
    }

    public bool CheckTask()
    {
        foreach (GameObject panel in panels)
        {
            if (panel.GetComponent<PanelBase>().clickflag && !onecheckflag)
            {
                onecheckflag = true;
                return true;
            }
        }
        return false;
    }

    public float GetTransitionTime()
    {
        return 0.0f;
    }
}
