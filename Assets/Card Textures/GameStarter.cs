using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.CreateLevel();
        GameManager.instance.FlipAllCardsInScene();
        Debug.Log("cards flipped");
    }

}

