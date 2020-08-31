using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class div : MonoBehaviour
{
    public int num;
    Animator div_anim;
    public AudioClip div_SE;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        div_anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<CoinManager>().CoinDiv(num);
        audiosource.PlayOneShot(div_SE);
        div_anim.SetBool("Div", true);
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
    }

    public void ExitDivAnim()
    {
        div_anim.SetBool("Div", false);
    }
}
