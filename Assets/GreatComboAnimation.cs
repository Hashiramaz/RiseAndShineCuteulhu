using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using Lean;
using Lean.Transition.Examples;

public class GreatComboAnimation : MonoBehaviour
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
        GameEventSystem.onGreatCombo  += OnGreatCombo;
    }

    private void OnDisable() {
        GameEventSystem.onGreatCombo  -= OnGreatCombo;
        
    }

    public void OnGreatCombo(){
        comboAnimation.BeginTransitions();

    }


}
