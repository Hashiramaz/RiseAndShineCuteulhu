using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentChannelNameInputField : MonoBehaviour
{
    public string currentChannelName;


    public void SetCurrentChannelName(string _channelName)
    {
        currentChannelName = _channelName;
    }


    private void OnEnable()
    {
        GameEventSystem.onGetCurrentChannelName += OnValue_CurrentChannelName;
    }

    private void OnDisable()
    {
        GameEventSystem.onGetCurrentChannelName -= OnValue_CurrentChannelName;

    }



    public string OnValue_CurrentChannelName()
    {
        return currentChannelName;
    }
}
