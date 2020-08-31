using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(this.gameObject.GetComponent<PanelBase>().x!=0)
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(-1.0f, 0.0f, 0.0f);
    }
}
