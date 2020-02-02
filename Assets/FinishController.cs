using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
public class FinishController : MonoBehaviour
{
    public LeanWindow generalFinishWindow;
    public LeanWindow FinishWindowWin;
    public LeanWindow FinishWindowLose;


    private void OnEnable()
    {
        GameEventSystem.onGameFinishVariant += OnFinishGame;
    }

    private void OnDisable()
    {

        GameEventSystem.onGameFinishVariant -= OnFinishGame;
    }


    private void Update()
    {
        if (!generalFinishWindow.On)
            return;

        if(GameEventSystem.GetCurrentGameState() == GameState.FINALSCREEN)
            return;
        
        if(GameEventSystem.GetCurrentGameState() == GameState.FINALSCREENLOST)
            return;
        
        if(GameEventSystem.GetCurrentGameState() == GameState.FINALSCREENWIN)
            return;

        generalFinishWindow.TurnOff();


    }
    public void OnFinishGame(bool playerWin)
    {
        generalFinishWindow.TurnOn();

        if (playerWin)
        {
            FinishWindowWin.TurnOn();
        }
        else
        {
            FinishWindowLose.TurnOn();
        }
    }
}
