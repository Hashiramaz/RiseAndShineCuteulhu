using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticReplayToogle : MonoBehaviour
{

    public bool automaticReplay = true;
    private void OnEnable()
    {
        GameEventSystem.onGetAutomaticRestart += OnValue_AutomaticReplay;
    }

    private void OnDisable()
    {
        GameEventSystem.onGetAutomaticRestart -= OnValue_AutomaticReplay;

    }

    public void SetAutomaticRestart(bool value)
    {
        automaticReplay = value;
    }

    public bool OnValue_AutomaticReplay()
    {
        return automaticReplay;
    }
}
