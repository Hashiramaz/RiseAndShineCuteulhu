using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3;
public class GameEventSystem : MonoBehaviour
{
        public delegate void GameEvent();
        public delegate void GameBoolEvent(bool value);
        public delegate void GameEventPassIntValue(int value);
        public delegate float GameFloatValue();
        public delegate int GameIntValue();
        public delegate bool GameBoolValue();
        public delegate GameState GameStateEvent();

        public delegate void GameSwapPieceEvent(int row, int collum, SwapDirection direction);

        public static event GameStateEvent onGetCurrentGameState;
        public static GameState GetCurrentGameState(){
            if(onGetCurrentGameState != null)
                return onGetCurrentGameState();
            else
                return GameState.MENU;
        }

        public static event GameEvent onGamePrepare;
        public static void PrepareGame()
        {
            if (onGamePrepare != null)
                onGamePrepare();
        }

        public static event GameEvent onReturnToMenu;
        public static void ReturnToMenu()
        {
            if (onReturnToMenu != null)
                onReturnToMenu();
        }
        public static event GameEvent onGameStart;
        public static void StartGame()
        {
            if (onGameStart != null)
                onGameStart();
        }

        public static event GameEvent onGameFinish;
        public static void FinishGame()
        {
            if (onGameFinish != null)
                onGameFinish();
        }

        public static event GameBoolEvent onGameFinishVariant;
        public static void FinishGameVariant(bool value)
        {
            if (onGameFinishVariant != null)
                onGameFinishVariant(value);
        }

        public static event GameEvent onGameReset;
        public static void ResetGame()
        {
            if (onGameReset != null)
                onGameReset();
        }

        public static event GameIntValue onGetCurrentScore;

        public static int GetCurrentScore()
        {
            if(onGetCurrentScore != null)
                return onGetCurrentScore();
            else
                return 0;
        } 
        public static event GameIntValue onGetCurrentCombo;

        public static int GetCurrentCombo()
        {
            if(onGetCurrentCombo != null)
                return onGetCurrentCombo();
            else
                return 0;
        } 
        public static event GameIntValue onGetCurrentMinPiecesToDestroy;

        public static int GetCurrentMinPiecesToDestroy()
        {
            if(onGetCurrentMinPiecesToDestroy != null)
                return onGetCurrentMinPiecesToDestroy();
            else
                return 0;
        } 

        public static event GameFloatValue onGetCurrentTimeCheckLeft;
        public static float GetCurrentTimeCheckLeft()
        {
            if(onGetCurrentTimeCheckLeft != null)
                return onGetCurrentTimeCheckLeft();
            else
                return 0;
        } 

        public static event GameSwapPieceEvent onReceiveSwapPieceEvent;

        public static void SwapPieces(int collumn, int row, SwapDirection direction)
        {
            if(onReceiveSwapPieceEvent != null)
            {
                onReceiveSwapPieceEvent(collumn,row,direction);
            }
        }

        public static event GameEvent onCheckMatch;

        public static void CheckMatch(){
            if(onCheckMatch != null)
                onCheckMatch();
        }
        public static event GameEvent onAddScore;

        public static void AddScore(){
            if(onAddScore != null)
                onAddScore();
        }
        public static event GameEvent onCheckBarScore;

        public static void CheckBarScore(){
            if(onCheckBarScore != null)
                onCheckBarScore();
        }
        public static event GameEvent onGreatCombo;

        public static void GreatCombo(){
            if(onGreatCombo != null)
                onGreatCombo();
        }
        public static event GameEvent onBadCombo;

        public static void BadCombo(){
            if(onBadCombo != null)
                onBadCombo();
        }
        public static event GameEvent onResetDestroyedPieces;

        public static void ResetDestroyedPieces(){
            if(onResetDestroyedPieces != null)
                onResetDestroyedPieces();
        }

        public static GameEventPassIntValue onAddDestroyedBlock;

        public static void AddDestroyedBlocks(int blockNum)
        {
            if(onAddDestroyedBlock != null)
                onAddDestroyedBlock(blockNum);
        }

        public static GameFloatValue onGetCurrentLife;

        public static float GetCurrentLife(){
            if(onGetCurrentLife != null)
                return GetCurrentLife();
            else 
                return 0f;
        }
}
