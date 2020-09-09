using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject[] copper=new GameObject[10];
    public GameObject[] silver=new GameObject[10];
    public GameObject[] gold=new GameObject[10];


    public Rigidbody2D rigidbody;
    public int coin=0;

    //private Animator drop_anim;
    private int i, j, k;
    private int hun=0, ten=0, one=0;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        CoinChecker();
       // drop_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

     public void CoinPlus(int i)
    {
        coin += i;
        coin = Mathf.Clamp(coin, 0, 1110);
        CoinChecker();
    }

    public void CoinMinus(int i)
    {
        coin -= i;
        coin = Mathf.Clamp(coin, 0, 1110);
        CoinChecker();
    }

    public void CoinMult(int i)
    {
        coin *= i;
        coin = Mathf.Clamp(coin, 0, 1110);
        CoinChecker();
    } 

    public void CoinDiv(int i)
    {
        coin =coin/i;
        CoinChecker();
    }

    //穴に落ちた時
    public void CoinZero()
    {
        coin = 0;
        CoinChecker();
        Destroy(this.gameObject);
    }

    public void CoinDrop()
    {
        //Destroy(this.gameObject);
    }

    //コインを表示する関数
    private void CoinChecker()
    {
        for (i = 0; i < 10; i++)
        {
            copper[i].SetActive(false);
            silver[i].SetActive(false);
            gold[i].SetActive(false);
        }

        int subcoin = coin;
        hun = 0;
        ten = 0;
        one = 0;

        while (subcoin >= 100 && hun<10)
        {
            subcoin -= 100;
            hun++;
        }
        while(subcoin>=10 && ten<10)
        {
            subcoin -= 10;
            ten++;
        }
        while (subcoin > 0&& one<10)
        {
            subcoin -= 1;
            one++;
        }

        for (i = 0; i < hun; i++)
        {
            gold[i].SetActive(true);
        }
        for (j = 0; j < ten; j++)
        {
            silver[j].SetActive(true);
        }
        for (k = 0; k < one; k++)
        {
            copper[k].SetActive(true);
        }
    }
}
