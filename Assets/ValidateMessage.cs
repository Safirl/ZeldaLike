using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateMessage : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] GameObject messagePrefab = null;
    GameObject player = null;
    [SerializeField] GameObject worlds = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Validate()
    {
        GameObject newMessage = Instantiate(messagePrefab);
        newMessage.transform.position = player.transform.position;

        newMessage.GetComponent<Dialog>().SetOneLineDialog(message.text);

        foreach (Transform currentChild in worlds.transform)
        {
            if (currentChild.gameObject.activeSelf)
            {
                newMessage.transform.parent = currentChild;
            }
        }
    } 
}
