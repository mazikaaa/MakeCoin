using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] panel = new GameObject[16];
    public int[] lockpanelpos = { -1,-1,-1};
    public GameObject coinguage, gameclear, gameover,startpanel;
    public Text time_text,score_text,clear_text,num_over,num_clear,stage_text;
    public Animator panel_anim;
    public AudioClip score_SE;

    public int shufflepanelNo= -1;
    public bool shuffleflag = false;//パネルを一つ選択しているか
    public bool holeflag = false;//選択したパネルが穴か
    public float shuffletimeover;//シャッフルできる時間を決める
    public int clearscore;//クリアするためのコインの枚数

    private int[] coins = new int[4];
    private float shuffletime = 0.0f;
    private float shuffle_x=0, shuffle_y=0;//パネルの位置
    private bool shuffletimeflag = false;//シャッフル出来る時間かどうかを判定
    private int i, j;
    private int x, y;//パネルの座標
    private int score = 0;
    private int guagecount = 4;
    private int stageNo;

    private int coinstack;//前のステージからのコインの持ち込み

    private GameObject shuffleobj;
    private AudioSource audioSource;

    GameObject panelobj,coinobj;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        coinstack = PlayerPrefs.GetInt("Coin",0);
        CoinSort();
        stageNo = PlayerPrefs.GetInt("STAGE",1);
        if (stageNo < 10)
        {
            stage_text.text = "Stage " + stageNo.ToString("f0");
        }
        else
        {
            stage_text.text = "Last Stage";
        }
        //配置するパネルの位置をランダムに交換する
        for (i = 0; i <panel.Length; i++)
        {

            //ロックパネルの位置は固定にする
            for (j = 0; j < lockpanelpos.Length; j++)
            {
                if (i == lockpanelpos[j])
                    goto End;
            }

            int randomIndex = Random.Range(i, panel.Length);

            for (j = 0; j < lockpanelpos.Length; j++)
            {
                if (randomIndex == lockpanelpos[j])
                    goto End;
            }

            GameObject tmp = panel[i];
            panel[i] = panel[randomIndex];
            panel[randomIndex] = tmp;

        End:;
        }

        //パネル生成
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                panelobj=Instantiate(panel[i*4+j], new Vector3(-300.0f + i *100.0f, 150.0f - j * 100.0f, 0.0f), Quaternion.identity);
                panelobj.GetComponent<PanelBase>().panelNo = i * 4 + j;
                panelobj.GetComponent<PanelBase>().x = i;
                panelobj.GetComponent<PanelBase>().y = j;
                panelobj.transform.SetParent(canvas.transform, false);   
            }
        }
        
        //ゲージ生成
        for (i = 0; i < 4; i++)
        {
            coinobj = Instantiate(coinguage, new Vector3(-300.0f + i * 100.0f, 250.0f - i * 1.0f, 0.0f), Quaternion.identity); ;
            coinobj.GetComponent<CoinManager>().coin = coins[i];
            coinobj.transform.SetParent(canvas.transform, false);
        }

        clear_text.text = clearscore.ToString("f0");
        time_text.text = shuffletimeover.ToString("f4");
        audioSource = GetComponent<AudioSource>();

        panel_anim.SetBool("Start", true);
        startpanel.transform.SetAsLastSibling();
        Invoke("GameStart", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (shuffletimeflag)
        {
            shuffletime += Time.deltaTime;

            time_text.text = (shuffletimeover - shuffletime).ToString("f4");

            if (shuffletime > shuffletimeover)
            {
                CoinStart();
            }
        }

    }

    //選択した二つのパネルを交換
    public void  ShufflePanel(int panelNo,GameObject panel)
    {
        //もうすでにシャッフルするパネルを一つ選んでいる時
        if (shuffleflag)
        {
            int locx = panel.GetComponent<PanelBase>().x;
            int locy = panel.GetComponent<PanelBase>().y;

            int dis = Mathf.Abs(locx - x)+ Mathf.Abs(locy - y);

            //パネルが隣り合っていたら
            if (dis<=1)
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

    //coinの箱が移動を開始する
    void CoinStart()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach(GameObject panel in panels)
        {
            panel.GetComponent<PanelBase>().shuffleflag = false;
        }

        foreach(GameObject coin in coins)
        {
            coin.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
        }

        shuffletimeflag = false;
        time_text.text = 0.0f.ToString();

        Debug.Log("コインスタート");
    }

    //coinの数を集計する
    public void GetScore(int coin)
    {
        score += coin;

        score_text.text = score.ToString("f0");
        audioSource.PlayOneShot(score_SE);
    }

    //コインの箱の数を集計
    public void GuageChecker()
    {
        guagecount -=1;

        if (guagecount == 0)
            ClearChecker();
    }

    //ゲームクリアしたかの判定
    public void ClearChecker()
    {
        if (score >= clearscore)
            GameClear();
        else
            GameOver();

    }

    private void GameStart()
    {
        shuffletimeflag = true;
    }

    public void GameClear()
    {
        num_clear.text = score.ToString("f0");
        canvas.sortingOrder=5;
        gameclear.transform.SetAsLastSibling();

        PlayerPrefs.SetInt("Coin", score);//次のステージにコインの持ち込み
        if(stageNo<10)
            stageNo += 1;
        PlayerPrefs.SetInt("STAGE", stageNo);
        gameclear.SetActive(true);
    }

    public void GameOver()
    {
        num_over.text = score.ToString("f0");
        canvas.sortingOrder = 5;
        gameover.transform.SetAsLastSibling();
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("STAGE", 1);
        gameover.SetActive(true);
    }

    public void GoOverStartButton()
    {

        SceneManager.LoadScene("StartScene");
    }

    public void GoClearStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoNextStageButton()
    {
        
        SceneManager.LoadScene("PanelScene" + stageNo);
    }

    public void SubmitButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    //コインの振り分け
    private void CoinSort()
    {
        int mountain = coinstack / 4;//コインの山分け

        int randomcoin = coinstack / 8;//山分けにランダム性を持たせる

        for (i = 0; i < 3; i++)
        {
            int coin = mountain + Random.Range(-randomcoin, randomcoin);
            coins[i] = coin;
            coinstack -= coin;
        }

        coins[3] = coinstack;
    }

}
