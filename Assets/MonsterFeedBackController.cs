using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFeedBackController : MonoBehaviour
{

    public Animator animator;

        private void OnEnable() {
            GameEventSystem.onGreatCombo += OnGreatCombo;
            GameEventSystem.onBadCombo  += OnBadCombo;
        }

        private void OnDisable() {
            GameEventSystem.onGreatCombo -= OnGreatCombo;
            GameEventSystem.onBadCombo  -= OnBadCombo;
            
        }

    public void OnGreatCombo()
    {
        animator.SetTrigger("great-combo");
    }

    public void OnBadCombo()
    {
        animator.SetTrigger("bad-combo");
    }
}
