using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBase : MonoBehaviour, IPointerClickHandler
{
    public int panelNo;
    public int x, y;
    private float posx,posy;

    public bool clickflag = false;//クリックしたか
    public bool shuffleflag = true;//シャッフルできる時間かどうか
    public bool lockflag = false;//ロックパネルかどうか

    [SerializeField] bool holeflag;
    [SerializeField] Sprite[] frame_img = new Sprite[2];

    GameObject gamemanager;
    SpriteRenderer frame;

    // Start is called before the first frame update
    void Start()
    {
        posx = transform.position.x;
        posy = transform.position.y;
        gamemanager = GameObject.Find("GameManager");
        frame = this.gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ロックパネルの場合は一連の動作を行わない
        if (lockflag == false)
        {
            //シャッフルできる時間なら起動
            if (shuffleflag)
            {
                if (clickflag)
                {
                    clickflag = false;
                    Changeframe(0);
                }
                else
                {
                    clickflag = true;
                    Changeframe(1);
                }

                if (holeflag)
                    gamemanager.GetComponent<GameManager>().holeflag = true;

                if (clickflag)
                    gamemanager.GetComponent<GameManager>().ShufflePanel(panelNo, this.gameObject);
                else
                {
                    gamemanager.GetComponent<GameManager>().shufflepanelNo = 0;
                    gamemanager.GetComponent<GameManager>().shuffleflag = false;
                }
            }
        }
    }

    //選択されている時に分かりやすくするために
    public void Changeframe(int i)
    {
        if (i == 0)
        {
            frame.sprite = frame_img[0];
            frame.sortingOrder = 3;
        }
        else
        {
            frame.sprite = frame_img[1];
            frame.sortingOrder = 4;
        }

    }
}
