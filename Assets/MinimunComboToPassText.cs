using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimunComboToPassText : MonoBehaviour
{
  private float _currentComboToPass;

    private Text ComboToPassText{
        get{
            if(m_ComboToPassText == null)
            {
                m_ComboToPassText = GetComponent<Text>();                
            }
            return m_ComboToPassText;
        }
    }
    private Text m_ComboToPassText;


    private void Update() {
        
        if(_currentComboToPass != GameEventSystem.GetCurrentMinPiecesToDestroy())
        {
            _currentComboToPass = GameEventSystem.GetCurrentMinPiecesToDestroy();
            ComboToPassText.text =_currentComboToPass.ToString();
    }
}
}
