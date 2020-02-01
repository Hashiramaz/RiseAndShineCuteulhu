using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
        public delegate void GameEvent();
        public delegate void GameEventPassIntValue(int value);
        public delegate float GameFloatValue();
        public delegate int GameIntValue();
        public delegate bool GameBoolValue();


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

        public static event GameEvent onGameReset;
        public static void ResetGame()
        {
            if (onGameReset != null)
                onGameReset();
        } 
}
