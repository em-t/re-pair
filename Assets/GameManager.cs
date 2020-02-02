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

    public GameObject cardPredab;

    public Sprite[] sprites;
    void Awake()
    {
        if(instance == null)
        instance = this;
        DontDestroyOnLoad(gameObject);


    }
    public void FlipAllCardsInScene(bool toUp = false)
    {

        cardScripts = FindObjectsOfType<CardScript>();
        foreach(CardScript cs in cardScripts)
        {
            cs.FlipMe(toUp);
        }
    }

    public void CreateLevel() {

        // Two-dimensional array.
        int[,] level = new int[,] { { 1, 2 }, { 4, 1 }, { 2, 1 }, { 1, 3 } };


        for(int i = 0; i < level.GetLength(0); i++)
        {
            for(int j = 0; j < level.GetLength(1); j++)
            {
                Debug.Log(level[i,j]);
                GameObject cardContainer = Instantiate(cardPredab, new Vector3(i*7,0,j*7), Quaternion.identity);
                Transform card = cardContainer.transform.GetChild(0).transform.GetChild(0);
                card.GetComponent<CardScript>().cardValue = level[i,j]; // :D
                card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[level[i , j] - 1];
            }
        }
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
            if (cardsUp[0].cardValue == cardsUp[1].cardValue) {
                cardsUp[0].setState("falling");
                cardsUp[1].setState("falling");
                cardsUp.Remove(cardsUp[0]);
                cardsUp.Remove(cardsUp[0]);
            }
            foreach(CardScript card in cardsUp)
            {
                card.setState("flipDown");
            }
            cardsUp.Clear();
        }
    }
}
