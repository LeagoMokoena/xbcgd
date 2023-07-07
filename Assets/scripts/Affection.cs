using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Affection : MonoBehaviour
{
    public int ammoi;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindWithTag("Affection").GetComponent<Text>().text = "Affection points: " + ammoi.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
