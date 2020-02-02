using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentComboText : MonoBehaviour
{
   private float _currentCombo;

    private Text ComboText{
        get{
            if(m_ComboText == null)
            {
                m_ComboText = GetComponent<Text>();                
            }
            return m_ComboText;
        }
    }
    private Text m_ComboText;


    private void Update() {
        
        if(_currentCombo != GameEventSystem.GetCurrentCombo())
        {
            _currentCombo = GameEventSystem.GetCurrentCombo();
            
            ComboText.text =(_currentCombo).ToString();
        }
    }
}
