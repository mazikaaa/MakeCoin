using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mult: MonoBehaviour
{
    public int num;
    Animator mult_anim;
    public AudioClip mult_SE;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        mult_anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<CoinManager>().CoinMult(num);
        audiosource.PlayOneShot(mult_SE);
        mult_anim.SetBool("Mult", true);
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
    }

    public void ExitMultAnim()
    {
        mult_anim.SetBool("Mult", false);
    }
}
