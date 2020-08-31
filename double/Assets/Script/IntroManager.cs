using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject[] intro = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntroChange(int i)
    {
        if (i == 3)
        {
            intro[i - 1].SetActive(false);
            intro[i].SetActive(true);
        }
        else if(i==0)
        {
            intro[i+1].SetActive(false);
            intro[i].SetActive(true);
        }
        else
        {
            intro[i - 1].SetActive(false);
            intro[i].SetActive(true);
            intro[i + 1].SetActive(false);
        }
    }

    public void GoStartButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
