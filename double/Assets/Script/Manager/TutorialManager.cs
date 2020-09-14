using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] panel = new GameObject[16];
    public GameObject[] touchframe = new GameObject[2];
    public int[] lockpanelpos = { -1, -1, -1 };
    public GameObject coinguage, goal;
    public Text time_text, score_text, clear_text;
    public AudioClip score_SE;
    public bool shuffletimeflag = false;//シャッフル出来る時間かどうかを判定

    public float shuffletimeover;//シャッフルできる時間を決める
    public int clearscore;//クリアするためのコインの枚数

    private int[] coins = new int[4];
    private float shuffletime = 0.0f;
    private int i, j;
    private int x, y;//パネルの座標
    private int score = 0;
    public int guagecount = 4;

    private int coinstack;//前のステージからのコインの持ち込み

    private AudioSource audioSource;

    GameObject panelobj, coinobj, goalobj;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        coinstack = 10;//チュートリアル用に
        CoinSort();
    
        //配置するパネルの位置をランダムに交換する
        for (i = 0; i < panel.Length; i++)
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
                panelobj = Instantiate(panel[i * 4 + j], new Vector3(-625.0f + i * 160.0f, 265.0f - j * 160.0f, 0.0f), Quaternion.identity);
                panelobj.GetComponent<PanelBase>().panelNo = i * 4 + j;
                panelobj.GetComponent<PanelBase>().x = i;
                panelobj.GetComponent<PanelBase>().y = j;
                panelobj.GetComponent<PanelBase>().shuffleflag = false;
                panelobj.transform.SetParent(canvas.transform, false);
            }
        }

        //ゲージ作成
        for (i = 0; i < 4; i++)
        {
            coinobj = Instantiate(coinguage, new Vector3(-625.0f + i * 160.0f, 415.0f - i * 1.0f, 0.0f), Quaternion.identity); ;
            coinobj.GetComponent<CoinManager>().coin = coins[i];
            coinobj.transform.SetParent(canvas.transform, false);
        }

        //ゴール生成
        for (i = 0; i < 4; i++)
        {
            goalobj = Instantiate(goal, new Vector3(-625.0f + i * 160.0f, -450.0f, 0.0f), Quaternion.identity);
            goalobj.transform.SetParent(canvas.transform, false);
        }

        touchframe[0].transform.SetAsLastSibling();
        touchframe[1].transform.SetAsLastSibling();
        clear_text.text = clearscore.ToString("f0");
        time_text.text = shuffletimeover.ToString("f4");
        audioSource = GetComponent<AudioSource>();

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

    //coinの箱が移動を開始する
    void CoinStart()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("Panel");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject panel in panels)
        {
            panel.GetComponent<PanelBase>().shuffleflag = false;
        }

        foreach (GameObject coin in coins)
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
        guagecount -= 1;

        if (guagecount == 0) ;
           // ClearChecker();
    }

    //ゲームクリアしたかの判定

    private void GameStart()
    {
        shuffletimeflag = true;
    }


    public void GoOverStartButton()
    {

        SceneManager.LoadScene("StartScene");
    }

    public void GoClearStartButton()
    {
        SceneManager.LoadScene("StartScene");
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
