using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Match3;
[RequireComponent(typeof(TwitchIRC))]
public class TwitchChatMessageReceiver : MonoBehaviour
{
    private TwitchIRC IRC;
    // public Text textToshow;
    void Start()
    {
        IRC = this.GetComponent<TwitchIRC>();
        //IRC.SendCommand("CAP REQ :twitch.tv/tags"); //register for additional data such as emote-ids, name color etc.
        IRC.messageRecievedEvent.AddListener(OnChatMsgRecieved);
    }

    void OnChatMsgRecieved(string msg)
    {
        //parse from buffer.

        if(GameEventSystem.GetCurrentGameState() != GameState.INGAME)
            return;


        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);


        Debug.Log("Twitch Message Received: " + msg);

        //textToshow.text = msgString;
        //remove old messages for performance reasons.
        //if (messages.Count > maxMessages)
        // {
        //     Destroy(messages.First.Value);
        //     messages.RemoveFirst();
        //  }

        //add new message.
        //CreateUIMessage(user, msgString);
        ParseInputEvent(msg);
    }

    public void ParseInputEvent(string msg)
    {

        int msgIndex = msg.IndexOf("PRIVMSG #");
        string msgString = msg.Substring(msgIndex + IRC.channelName.Length + 11);
        string user = msg.Substring(1, msg.IndexOf('!') - 1);



        if(!ValidadeMsg(msgString))
            return;

        string collum = msgString.Substring(0, 1);
        string row = msgString.Substring(1, 1);
        string direction = msgString.Substring(2, 1);

        int rowInt = GetIntRow(row);
        int collumInt = GetIntCollum(collum);
        SwapDirection directionEnum = GetSwapDirection(direction);

        if(!ValidateRowIndex(rowInt))
            return;
        
        if(!ValidateRowIndex(collumInt))
            return;

        Debug.Log("Row: " + row + ", Collum: " + collum + ", Direction: " + direction);
        Debug.Log("Row: " + rowInt + "Collum: " + collumInt + "Direction: " + directionEnum);

        GameEventSystem.SwapPieces(collumInt, rowInt, directionEnum);

        GameEventSystem.MessageValid(user,msgString);
    }

    public int GetIntRow(string rowstring)
    {   
            int valueParsed;
            
            if(int.TryParse(rowstring, out valueParsed ))
            {

                valueParsed =  6 - valueParsed;


                return valueParsed;
            }
            else
                return -1;
        
    }

    public int GetIntCollum(string collumString)
    {
        if (collumString.ToUpper() == "A")
        {
            return 0;
        }
        else if (collumString.ToUpper() == "B")
        {
            return 1;
        }
        else if (collumString.ToUpper() == "C")
        {
            return 2;
        }
        else if (collumString.ToUpper() == "D")
        {
            return 3;
        }
        else if (collumString.ToUpper() == "E")
        {
            return 4;
        }
        else if (collumString.ToUpper() == "F")
        {
            return 5;
        }
        else
            return -1;
    }

    public SwapDirection GetSwapDirection(string direction)
    {
        string directionToCompare = direction.ToUpperInvariant();

        if  (directionToCompare == "U")
        {

            return SwapDirection.UP;
        }
        else if (directionToCompare == "D")
        {

            return SwapDirection.DOWN;
        }
        else if (directionToCompare == "L")
        {

            return SwapDirection.LEFT;
        }
        else if (directionToCompare == "R")
        {

            return SwapDirection.RIGHT;
        }
        else
            return SwapDirection.NULL;
    }


    public bool ValidateRowIndex(int rowIndex)
    {
        if(rowIndex < 0 || rowIndex > 5)
        return false;
        else
        return true;
    }

    public bool ValidadeMsg(string msg)
    {
        if( msg.Length != 3)
            return false;
        else
            return true;
    }
}
