using System.Collections;
using System.Collections.Generic;
using Lean.Transition.Examples;
using UnityEngine;

public class BadComboAnimation : MonoBehaviour
{
    public LeanAnimation comboAnimation{
        get{
            if(m_comboAnimation == null)
                m_comboAnimation = GetComponent<LeanAnimation>();
            return m_comboAnimation;
        }
    }
    public LeanAnimation m_comboAnimation;

    private void OnEnable() {
        GameEventSystem.onBadCombo  += OnBadCombo;
    }

    private void OnDisable() {
        GameEventSystem.onBadCombo  -= OnBadCombo;
        
    }

    public void OnBadCombo(){
        comboAnimation.BeginTransitions();

    }
}
