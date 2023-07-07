using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rythmControls : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public Sprite sprite,_sprite;

    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            _renderer.sprite = _sprite;
        }

        if(Input.GetKeyUp(keyCode))
        {
            _renderer.sprite = sprite;
        }
    }
}
