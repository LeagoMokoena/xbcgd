using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note : MonoBehaviour
{
    public bool pressable;

    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            if( pressable )
            {
                gameObject.SetActive(false);

                //Manager.instance.Hit();

                if(Mathf.Abs(transform.position.y) > 0.25 )
                {
                    Manager.instance.norm();
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Manager.instance.hitted();
                }
                else
                {
                    Manager.instance.perfect();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            pressable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            pressable = false;

            Manager.instance.missed();
        }
    }
}
