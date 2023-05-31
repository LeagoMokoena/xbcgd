using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    public characters ch;

    bool talking = false;

    public GameObject player;
    public GameObject dilagouUI;

    float dis;
    float responder = 0;

    public Text talker;
    public Text dilogueBox;
    public Text messageBox;

    // Start is called before the first frame update
    void Start()
    {
        dilagouUI.SetActive(false);
    }

    private void OnMouseOver()
    {
        dis = Vector3.Distance(player.transform.position,this.transform.position);
        if(dis <= 2.5f)
        {
            if(Input.GetKeyDown(KeyCode.E) && talking==false) 
            {
                conversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && talking == true)
            {
                endCoversation();
            }
        }
    }

    private void conversation()
    {
        talking = true;
        dilagouUI.SetActive(true);
        talker.text = ch.nm;
        dilogueBox.text = ch.text[0];
    }

    void endCoversation()
    {
        talking=false;
        dilagouUI.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
