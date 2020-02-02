using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("paskaa");
        GameManager.Instance.CreateLevel();
        GameManager.Instance.FlipAllCardsInScene();
        Debug.Log("cards flipped");
    }

}

