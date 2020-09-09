using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    int stageNo;
    public GameObject Continue;

    // Start is called before the first frame update
    void Start()
    {
        stageNo = PlayerPrefs.GetInt("STAGE", 1);
        if (stageNo >= 2)
        {
            Continue.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartStageButton()
    {
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("STAGE", 1);
        SceneManager.LoadScene("PanelScene1");
    }

    public void ContinueStageButton()
    {
        SceneManager.LoadScene("PanelScene" + stageNo);
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExplanationButton()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
