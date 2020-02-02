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
    public CardScript[] cardScripts;
    public List<CardScript> cardsUp;
    void Awake()
    {
        if(instance == null)
        instance = this;
        DontDestroyOnLoad(gameObject);
        cardScripts = FindObjectsOfType<CardScript>();

    }
    public void FlipAllCardsInScene(bool toUp = false)
    {
        foreach(CardScript cs in cardScripts)
        {
            cs.FlipMe(toUp);
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
        if (cardsUp.Count >= 3) {
            foreach(CardScript card in cardsUp)
            {
                card.setState("flipDown");
            }
            cardsUp.Clear();
        }
    }
}
