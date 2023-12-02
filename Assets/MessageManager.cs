using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class Message
{
    public int messageId;
    public string playerMessage;
    public int numberOfDefenders;
    public string defendersNames;
}

public class MessageManager : MonoBehaviour
{
    [SerializeField] private GameObject playerBase;
    [SerializeField] private Text message;
    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private GameObject letter;

    private string host = "http://localhost/nugget/";
    private string getAllMessages;
    private string getOneMessage;
    private string insertNewMessage;
    private string jsonResponse;
    private Message randomMessage;

    void Start()
    {
        letter = GameObject.FindGameObjectWithTag("NPC");

        StartCoroutine(GetOneMessage());
    }

    IEnumerator GetOneMessage()
    {
        getOneMessage = host + "getOneMessage.php";

        using (UnityWebRequest www = UnityWebRequest.Get(getOneMessage))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                jsonResponse = www.downloadHandler.text;
                randomMessage = JsonUtility.FromJson<Message>(jsonResponse);

                InsertOneMessage(randomMessage);
            }
            else
            {
                Debug.LogError($"Erreur de requête : {www.error}");
            }
        }
    }

    public IEnumerator UpdateMessagesWithPHP(string playerMessage, int numberOfDefenders, string defendersNames)
    {
        string insertNewMessage = host + "insertNewMessage.php?playermessage=" + playerMessage + "&numberOfDefenders=" + numberOfDefenders + "&defendersNames=" + defendersNames;

        WWW updateMessagesRequest = new WWW(insertNewMessage);
        yield return updateMessagesRequest;
    }

    public void InsertOneMessage(Message message)
    {
        letter.GetComponent<Dialog>().Clear();
        letter.GetComponent<Dialog>().SetOneLineDialog(message.playerMessage);
        letter.GetComponent<Dialog>().SetOneLineDialog("Vous avez reçu " + message.numberOfDefenders + " alliés");
    }

    public void Submit()
    {
        StartCoroutine(UpdateMessagesWithPHP(message.text, int.Parse(dropdown.options[dropdown.value].text), "Ally"));
    }
}
