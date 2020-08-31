using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
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
        col.GetComponent<CoinManager>().rigidbody.velocity = new Vector3(0.0f, -1.0f, 0.0f);
    }
}
