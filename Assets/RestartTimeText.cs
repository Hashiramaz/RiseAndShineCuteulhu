using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartTimeText : MonoBehaviour
{
    private float _currentResetTimeLeft;

    private Text ResetTimeLeftText{
        get{
            if(m_ResetTimeLeftText == null)
            {
                m_ResetTimeLeftText = GetComponent<Text>();                
            }
            return m_ResetTimeLeftText;
        }
    }
    private Text m_ResetTimeLeftText;


    private void Update() {
        
       
            _currentResetTimeLeft = GameEventSystem.GetCurrentTimeToRestartGame();
            
            ResetTimeLeftText.text =Mathf.Round(_currentResetTimeLeft).ToString();
        
    }
    
}

