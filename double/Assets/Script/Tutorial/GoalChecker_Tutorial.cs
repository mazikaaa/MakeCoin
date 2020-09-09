using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker_Tutorial : MonoBehaviour
{
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        int coin = col.GetComponent<CoinManager>().coin;
        Destroy(col.gameObject);
        gamemanager.GetComponent<TutorialManager>().GetScore(coin);
        gamemanager.GetComponent<TutorialManager>().GuageChecker();
    }
}
