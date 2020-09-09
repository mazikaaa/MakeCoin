using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleManager : MonoBehaviour
{
    public int shufflepanelNo = -1;
    public bool shuffleflag = false;//パネルを一つ選択しているか
    public bool holeflag = false;//選択したパネルが穴か

    private GameObject shuffleobj;
    private float shuffle_x = 0, shuffle_y = 0;//パネルの位置
    private int x =0,y=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShufflePanel(int panelNo, GameObject panel)
    {
        //もうすでにシャッフルするパネルを一つ選んでいる時
        if (shuffleflag)
        {
            int locx = panel.GetComponent<PanelBase>().x;
            int locy = panel.GetComponent<PanelBase>().y;

            int dis = Mathf.Abs(locx - x) + Mathf.Abs(locy - y);

            //パネルが隣り合っていたら
            if (dis <= 1)
            {

                //シャッフルするパネルの内,どちらが穴パネルだったら
                if (holeflag)
                {
                    float posx = panel.transform.position.x;
                    float posy = panel.transform.position.y;

                    shuffleobj.transform.position = new Vector3(posx, posy, 0);
                    panel.transform.position = new Vector3(shuffle_x, shuffle_y, 0);
                    shuffleobj.GetComponent<PanelBase>().x = locx;
                    shuffleobj.GetComponent<PanelBase>().y = locy;
                    panel.GetComponent<PanelBase>().x = this.x;
                    panel.GetComponent<PanelBase>().y = this.y;

                    panel.GetComponent<PanelBase>().clickflag = false;
                    shuffleobj.GetComponent<PanelBase>().clickflag = false;
                    panel.GetComponent<PanelBase>().Changeframe(0);
                    shuffleobj.GetComponent<PanelBase>().Changeframe(0);
                    shuffleobj = null;
                    shuffleflag = false;
                    holeflag = false;
                }
                else
                {
                    shuffle_x = 0.0f;
                    shuffle_y = 0.0f;
                    shuffleobj.GetComponent<PanelBase>().clickflag = false;
                    panel.GetComponent<PanelBase>().clickflag = false;
                    panel.GetComponent<PanelBase>().Changeframe(0);
                    shuffleobj.GetComponent<PanelBase>().Changeframe(0);
                    shuffleobj = null;
                    shuffleflag = false;

                }
            }
            else
            {
                shuffleobj.GetComponent<PanelBase>().clickflag = false;
                panel.GetComponent<PanelBase>().clickflag = false;
                panel.GetComponent<PanelBase>().Changeframe(0);
                shuffleobj.GetComponent<PanelBase>().Changeframe(0);
                shuffleobj = null;
                shuffleflag = false;
                holeflag = false;
            }
        }
        else
        {
            this.x = panel.GetComponent<PanelBase>().x;
            this.y = panel.GetComponent<PanelBase>().y;
            shuffle_x = panel.transform.position.x;
            shuffle_y = panel.transform.position.y;
            shuffleobj = panel;
            shuffleflag = true;
        }

    }
}
