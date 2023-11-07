using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject talk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
       


    }

    private void OnTriggerEnter(Collider other)
    {
        talk.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("Day Onechat 1");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            talk.SetActive(false);
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("CHAT");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            talk.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void Weed_talk()
    {
        SceneManager.LoadScene("Day Onechat 1");
    }

    public void not_talk()
    {
        talk.SetActive(false);
        SceneManager.LoadScene("Work");
    }
}
