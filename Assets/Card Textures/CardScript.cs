using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardScript : MonoBehaviour
{
    public int cardValue = 2;
    // Start is called before the first frame update
    public SpriteRenderer rend;
    private string state="static";
    private int t = 0;
    public List<Sprite> sprites;
    public Card card;
    void Start()
    {
        //cardValue = Random.Range(1,2);
        //Texture2D texture = Resources.Load<Texture2D>("Card Textures/" + cardValue);
        //Material material = new Material(Shader.Find("Diffuse"));
        //material.mainTexture = texture;
        //gameObject.GetComponent<Renderer>().material = material;
        //var card = GameManager.instance.myPack.Cards[2];
    }
    public void FlipMe(bool up = true)
    {
        if (!up)
        transform.eulerAngles = new Vector3( 0,0,180 );
        if (up)
        transform.eulerAngles = new Vector3(0,0,0);
    }
    public void UpdateMe(Card card)
    {
        //Debug.Log("I am" + card.name);
        //rend.sprite = card.sprite;
        //cardValue = card.arvo;
    }

    public void setState(string newState)
    {
        state = newState;
        t = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == "flipDown") {
            if (transform.eulerAngles.z > 180 ) {
                transform.eulerAngles = new Vector3(0,0,180);
                setState("static");
                return;
            }
            transform.Rotate(new Vector3(0,0,1));
        } else if (state == "flipUp") {
             if (transform.eulerAngles.z > 358 ) {
                transform.eulerAngles = new Vector3(0,0,0);
                setState("wait");
                return;
            }
            transform.Rotate(new Vector3(0,0,1));
        } else if (state == "wait") {
            if (t == 180) {
                setState("flipDown");
                return;
            }
        }
        t = t + 1;
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,new Vector3(0,0,180),0.5f * Time.deltaTime) ;
    }
}
