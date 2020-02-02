using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3;

public class InputReceiver : MonoBehaviour
{
 


    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SendSwapEvent(1,2,SwapDirection.RIGHT);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

            SendSwapEvent(4,5,SwapDirection.UP);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SendSwapEvent(0,4,SwapDirection.DOWN);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SendSwapEvent(0,5,SwapDirection.RIGHT);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SendSwapEvent(0,5,SwapDirection.LEFT);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SendSwapEvent(4,3,SwapDirection.UP);
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            SendCheckMatchEvent();
        }
        if(Input.GetKeyDown(KeyCode.D)){
            GameEventSystem.FinishGame();
        }
    }

    public void SendSwapEvent(int collumn, int row, SwapDirection direction)
    {
        GameEventSystem.SwapPieces(collumn,row,direction);
    }


    public void SendCheckMatchEvent()
    {
        GameEventSystem.CheckMatch();
    }



}
