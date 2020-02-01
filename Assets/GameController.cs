using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public int currentScore;

  public int recordScore;


  
}
public enum GameState 
{
    MENU,
    PREPARING,
    INGAME,
    FINALSCREEN
}