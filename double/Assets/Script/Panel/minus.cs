using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minus: MonoBehaviour
{
    public int num;
    Animator minus_anim;
    public AudioClip minus_SE;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        minus_anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<CoinManager>().CoinMinus(num);
        audiosource.PlayOneShot(minus_SE);
        minus_anim.SetBool("Minus",true);
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
    }

    public void ExitMinusAnim()
    {
        minus_anim.SetBool("Minus", false);
    }
}
