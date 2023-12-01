using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    private string host = "http://localhost/nugget/";
    private string getAllMessages;
    private string insertNewMessage;


    // Get tout nos messages
    IEnumerator Start()
    {
        string getAllMessages = host + "getAllMessages.php";

        WWW gatherMessagesRequest = new WWW(getAllMessages);
        yield return gatherMessagesRequest;

        string result = gatherMessagesRequest.text;
    }


    // Set un message
    public IEnumerator UpdateMessagesWithPHP(string playerMessage, int numberOfDefenders, string defendersNames)
    {
        string insertNewMessage = host + "insertNewMessage.php?playermessage=" + playerMessage + "&numberOfDefenders=" + numberOfDefenders + "&defendersNames=" + defendersNames;

        WWW updateMessagesRequest = new WWW(insertNewMessage);
        yield return updateMessagesRequest;
    }


}
