using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int currentScore;

    public int recordScore;

    public float maxTimeToWaitBetweenChecks = 10f;
    public float currentTimeleft;

    public float maxLifeCount;
    public float CurrentLifeCount;
    public GameState gameState;

    public int winCondition = 15;

    public int minPiecesToDestroy = 5;
    private void OnEnable()
    {
        GameEventSystem.onAddScore += OnAddScore;
        GameEventSystem.onGetCurrentScore += OnValue_CurrentScore;
        GameEventSystem.onGetCurrentTimeCheckLeft += OnValue_CurrentTimeChekLeft;

        GameEventSystem.onGameStart   += OnStartGame;
        GameEventSystem.onGameFinish += OnFinishGame;
        GameEventSystem.onGamePrepare += OnPrepareGame;
        GameEventSystem.onReturnToMenu += OnReturnToMenu;
        GameEventSystem.onGetCurrentGameState += OnValue_CurrentGameState;

        GameEventSystem.onCheckMatch      += OnCheckMatchs;
        GameEventSystem.onCheckBarScore += OnCheckBarScore;
        GameEventSystem.onGetCurrentMinPiecesToDestroy += OnValue_CurrentMinPiecesToDestroy;
        GameEventSystem.onGameFinishVariant += OnFinishGameVariant;
    }

    private void OnDisable()
    {
        GameEventSystem.onAddScore -= OnAddScore;
        GameEventSystem.onGetCurrentScore -= OnValue_CurrentScore;
        GameEventSystem.onGetCurrentTimeCheckLeft -= OnValue_CurrentTimeChekLeft;
        
        GameEventSystem.onGameStart   -= OnStartGame;
        GameEventSystem.onGameFinish -= OnFinishGame;
        GameEventSystem.onGamePrepare -= OnPrepareGame;
        GameEventSystem.onReturnToMenu -= OnReturnToMenu;
        GameEventSystem.onGetCurrentGameState -= OnValue_CurrentGameState;
        GameEventSystem.onCheckMatch      -= OnCheckMatchs;
        GameEventSystem.onCheckBarScore -= OnCheckBarScore;
        GameEventSystem.onGetCurrentMinPiecesToDestroy -= OnValue_CurrentMinPiecesToDestroy;
        GameEventSystem.onGameFinishVariant -= OnFinishGameVariant;
    }

    private void Update()
    {

      if(gameState != GameState.INGAME)
        return;

        currentTimeleft -= Time.deltaTime;

        if (currentTimeleft < 0)
            StartCheckWait();
    }

    public void StartCheckWait()
    {
        currentTimeleft = maxTimeToWaitBetweenChecks;
        GameEventSystem.CheckMatch();
    }

    // public bool isWaiting;
    // IEnumerator CheckMatchWaitRoutine()
    // {
    //   isWaiting = true;
    //   yield return new  WaitForSeconds(10f);
    //   isWaiting = false;
    //     GameEventSystem.CheckMatch();

    // }

    void PrepareGameToStart()
    {
      SetGamestate(GameState.PREPARING);
      StartCoroutine(PreparingRoutine());
    }
    IEnumerator PreparingRoutine()
    {
      yield return new WaitForSeconds(1f);
      GameEventSystem.StartGame();
      
    }
    private void StartGame()
    {
      SetGamestate(GameState.INGAME);
    }
    private void FinishGame()
    {
        SetGamestate(GameState.FINALSCREEN);
    }

    private void FinishGame(bool value)
    {
      //SetGamestate(GameState.FINALSCREEN);
      if (value)
      {
        SetGamestate(GameState.FINALSCREENWIN);
      }else
      {
        SetGamestate(GameState.FINALSCREENLOST);
      }
    }

    private void ReturnToMenu()
    {
       SetGamestate(GameState.MENU);
    }
    
    public void SetGamestate(GameState _state)
    {
        gameState = _state;

    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    // public void AddBar()
    // {

    // }

    // public void RemoveBar()
    // {

    // }

    public void CheckMatchs()
    {
      Match3.MatchManager.instance.StartCheckMatchsRoutine();
    }

    public void CheckBarScore()
    {
     // StartCoroutine(CheckBarRoutine());
     if(GameEventSystem.GetCurrentCombo() > minPiecesToDestroy){
       GameEventSystem.GreatCombo();
        Debug.Log("MANDOU BEM!");
        AddPieceLevel();
     }
      else{
        GameEventSystem.BadCombo();
        Debug.Log("MANDOU MAL =(");
      }

    }

    public void AddPieceLevel()
    {
      minPiecesToDestroy++; 
    }

    public void ResetMinPieces()
    {
      minPiecesToDestroy = 5;
    }

    public void AddLife()
    {

    }

    public void RemoveLife()
    {

    }



    #region CallBacks

    public void OnAddScore()
    {
        currentScore += 10;
    }
    public int OnValue_CurrentScore()
    {
        return currentScore;
    }

    public void OnPrepareGame()
    {
      PrepareGameToStart();
    }
    public void OnStartGame()
    {
      StartGame();
    }

    public void OnFinishGame()
    {
      FinishGame();
    }
    public void OnFinishGameVariant(bool value)
    {
      FinishGame(value);
    }



    public void OnReturnToMenu()
    {
      ReturnToMenu();
    }

    

    public GameState OnValue_CurrentGameState()
    {
      return gameState;
    }

  //Registrar

    public void OnCheckMatchs()
    {
      //CheckBarScore();
      CheckMatchs();
    }

    public void OnCheckBarScore()
    {
      CheckBarScore();
    }


    public float OnValue_CurrentBarCount()
    {
      return CurrentLifeCount;
    }

    public float OnValue_MaxLifeCount(){
        return maxLifeCount;
    }

    public int OnValue_CurrentMinPiecesToDestroy(){
      return minPiecesToDestroy;
    }

    

    // public void OnTimeFinish()
    // {

    // }

    public float OnValue_CurrentTimeChekLeft()
    {
        return currentTimeleft;
    }

    #endregion



}
public enum GameState
{
    MENU,
    PREPARING,
    INGAME,
    FINALSCREEN,
    FINALSCREENWIN,
    FINALSCREENLOST
}