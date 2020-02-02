using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int _currentScore;

    private Text scoreText{
        get{
            if(m_scoreText == null)
            {
                m_scoreText = GetComponent<Text>();                
            }
            return m_scoreText;
        }
    }
    private Text m_scoreText;


    private void Update() {
        
        if(_currentScore != GameEventSystem.GetCurrentScore())
        {
            _currentScore = GameEventSystem.GetCurrentScore();
            scoreText.text = _currentScore.ToString();
        }
    }
    
}
