using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCheckLeftText : MonoBehaviour
{
    private float _currentTimeLeft;

    private Text TimeLeftText{
        get{
            if(m_TimeLeftText == null)
            {
                m_TimeLeftText = GetComponent<Text>();                
            }
            return m_TimeLeftText;
        }
    }
    private Text m_TimeLeftText;


    private void Update() {
        
        if(_currentTimeLeft != GameEventSystem.GetCurrentTimeCheckLeft())
        {
            _currentTimeLeft = GameEventSystem.GetCurrentTimeCheckLeft();
            
            TimeLeftText.text = Mathf.Round(_currentTimeLeft).ToString();
        }
    }
}
