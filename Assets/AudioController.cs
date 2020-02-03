using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
   private void OnEnable() {
       GameEventSystem.onGameStart += OnGameStart;
       GameEventSystem.onGameFinishVariant += OnGameFinish;
       GameEventSystem.onGreatCombo += OnGreatCombo;
       GameEventSystem.onBadCombo += OnBadCombo;
   }

   private void OnDisable() {
       GameEventSystem.onGameStart -= OnGameStart;
       GameEventSystem.onGameFinishVariant -= OnGameFinish;
       GameEventSystem.onGreatCombo -= OnGreatCombo;
       GameEventSystem.onBadCombo -= OnBadCombo;
       
   }


    public void OnGameStart()
    {
        AudioManager.instance.Stop("win-game-music");
    }

    public void OnGameFinish(bool playerWin)
    {

        if(playerWin)
        {
            
           // AudioManager.instance.Play("game-win1");
            AudioManager.instance.Play("game-win2");
            Invoke("PlayFinalMusic",4f);
        }
        else
        {
            AudioManager.instance.Play("game-lose1");
            AudioManager.instance.Play("game-lose-2");

        }
    }

    public void OnGreatCombo()
    {
            AudioManager.instance.Play("great-combo");
    }

    public void OnBadCombo()
    {
            AudioManager.instance.Play("bad-combo");

    }

    public void PlayFinalMusic(){
        AudioManager.instance.Play("win-game-music");
    }
}
