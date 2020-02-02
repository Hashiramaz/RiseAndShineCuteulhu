using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentLifeText : MonoBehaviour
{
    public Text textlife;


    private float _currentLife;

    private void Update()
    {
    
            textlife.text = GameEventSystem.GetCurrentLife().ToString();
        
    }
}
