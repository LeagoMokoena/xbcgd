using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maze : MonoBehaviour
{
    private Touch touch;

    private Vector2 positiontouch;

    private Quaternion rotationx, rotationz;

    private float spedModifer = 0.1f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Moved:
                    rotationx = Quaternion.Euler(-touch.deltaPosition.x * spedModifer, 0f, 0f);
                    transform.rotation = rotationx * transform.rotation;
                    rotationz = Quaternion.Euler(0f, 0f, -touch.deltaPosition.y * spedModifer);
                    transform.rotation = transform.rotation * rotationz;
                    break;
            }
        }
    }
}
