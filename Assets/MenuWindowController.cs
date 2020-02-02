using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
[RequireComponent(typeof(LeanWindow))]
public class MenuWindowController : MonoBehaviour
{
    public LeanWindow leanWindow
    {
        get
        {
            if (m_leanWindow == null)
                m_leanWindow = GetComponent<LeanWindow>();
            return m_leanWindow;
        }
    }
    public LeanWindow m_leanWindow;

    private void Update()
    {
        if(!leanWindow.On && GameEventSystem.GetCurrentGameState() == GameState.MENU)
        {
            leanWindow.TurnOn();
        }
        
        if(leanWindow.On && GameEventSystem.GetCurrentGameState() != GameState.MENU)
        {
            leanWindow.TurnOff();
        }

    }
}
