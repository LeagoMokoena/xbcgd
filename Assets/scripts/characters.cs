using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "character ", menuName = "character files")]
public class characters : ScriptableObject
{
    public string nm;
    [TextArea(3,15)]
    public string[] text;
    [TextArea(3,15)]
    public string[] text2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
