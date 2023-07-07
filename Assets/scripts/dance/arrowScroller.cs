using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScroller : MonoBehaviour
{
    public float btTempo;

    public bool hsStarted;
    // Start is called before the first frame update
    void Start()
    {
        btTempo = btTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hsStarted)
        {
            if (Input.anyKeyDown)
            {
                hsStarted = true;
            }
            else
            {
                transform.position -= new Vector3(0f,btTempo * Time.deltaTime, 0f);
            }
        }
        
    }
}
