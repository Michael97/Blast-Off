using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //Define Enum
    public enum GameStateEnum { Main, Game, Options, Pause, Shop, Death };

    //This is what you need to show in the inspector.
    public GameStateEnum GameStateInstance;
}
