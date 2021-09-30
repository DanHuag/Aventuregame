using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteeffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
    }
}
