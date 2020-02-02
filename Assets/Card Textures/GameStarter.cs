using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.FlipAllCardsInScene();
        Debug.Log("cards flipped");
        //GameManager.instance.ShuffleCards();
        GameManager.instance.UpdateAllCards();
    }

}

