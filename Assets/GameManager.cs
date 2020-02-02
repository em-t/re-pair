using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }


    public CardPack myPack;
    public List<Card> shuffledCards;
    public List<CardScript> allCardScripts;
    public GameObject player;

    public CardScript[] cardScripts;
    public List<CardScript> cardsUp;

    public GameObject cardPredab;

    public Sprite[] sprites;

    void Awake()
    {
       if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
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
        int[,] level = new int[,] {
            { 1, 5, 5, 3, 1},
            { 4, 1, 3 ,2, 1},
            { 4, 1, 2 ,5, 2},
            { 1, 2, 5 ,6, 6},
        };
        player = GameObject.Find("PLAYERPREFAB");

        for(int i = 0; i < level.GetLength(0); i++)
        {
            for(int j = 0; j < level.GetLength(1); j++)
            {
                GameObject cardContainer = Instantiate(cardPredab, new Vector3(i*7,0,j*7), Quaternion.identity);
                Transform card = cardContainer.transform.GetChild(0).transform.GetChild(0);
                card.GetComponent<CardScript>().cardValue = level[i,j]; // :D
                card.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[level[i , j] - 1];
            }
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
            cardsUp.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (cardsUp.Count >= 3) {
            if (cardsUp[0].cardValue == cardsUp[1].cardValue) {
                cardsUp[1].setState("falling");
                cardsUp[0].setState("falling");
                cardsUp.Remove(cardsUp[1]);
                cardsUp.Remove(cardsUp[0]);
            } else if (cardsUp[0].cardValue == cardsUp[2].cardValue) {
                cardsUp[2].setState("falling");
                cardsUp[0].setState("falling");
                cardsUp.Remove(cardsUp[2]);
                cardsUp.Remove(cardsUp[0]);
            } else if (cardsUp[1].cardValue == cardsUp[1].cardValue) {
                cardsUp[2].setState("falling");
                cardsUp[1].setState("falling");
                cardsUp.Remove(cardsUp[2]);
                cardsUp.Remove(cardsUp[1]);
            }
            foreach(CardScript card in cardsUp)
            {
                card.setState("flipDown");
            }
            cardsUp.Clear();
        }
    }


}
