using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CardPack myPack;
    public List<Card> shuffledCards;
    public List<CardScript> allCardScripts;
    public GameObject player;

    void Awake()
    {
        if(instance == null)
        instance = this;
        DontDestroyOnLoad(gameObject);


    }
    public void FlipAllCardsInScene(bool up = true)
    {
        foreach(CardScript cs in allCardScripts)
        {
            cs.FlipMe(up);
        }
    }
    public void ShuffleCards()
    {
        shuffledCards = myPack.Cards;
        //Random r = new Random();

        //shuffledCards.Sort((x, y) => r.Next(-1, 1));
    }
    public void UpdateAllCards()
    {
        for(int i = 0; i < allCardScripts.Count; i++)
        {
            allCardScripts[i].UpdateMe(myPack.Cards[i]);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.transform.GetChild(0).GetComponent<PlayerController>().isDead == true)
        {
            Debug.Log("GAME VITTU OVER.");
        }
    }


}
