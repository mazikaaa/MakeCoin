using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plus : MonoBehaviour
{
    public int num;
    Animator plus_anim;
    public AudioClip plus_SE;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        plus_anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<CoinManager>().CoinPlus(num);
        plus_anim.SetBool("Plus",true);
        audiosource.PlayOneShot(plus_SE);
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
    }

    public void ExitPlusAnim()
    {
        plus_anim.SetBool("Plus", false);
    }
}
