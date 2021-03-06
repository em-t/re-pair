﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardScript : MonoBehaviour
{
    public int cardValue = 2;
    // Start is called before the first frame update
    public SpriteRenderer rend;
    public string state="down";
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
    public void FlipMe(bool toUp = true)
    {
        if (!toUp) {
            transform.eulerAngles = new Vector3( 0,0,180 );
            setState("down");
        }
        if (toUp) {
            transform.eulerAngles = new Vector3(0,0,0);
            setState("up");
        }
    }

    public void setState(string newState)
    {
        if (newState == "up") {
            if (!GameManager.Instance.cardsUp.Contains(this)) {
                GameManager.Instance.cardsUp.Add(this);
                Debug.Log("added " + gameObject.name + " to cardsUp");
            }
        } else if (newState == "down") {
        }
        //Debug.Log(gameObject.name + " setstate to " + newState);
        state = newState;
        t = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == "flipDown") {
            if (transform.eulerAngles.z > 180 ) {
                transform.eulerAngles = new Vector3(0,0,180);
                setState("down");
                return;
            }
            transform.Rotate(new Vector3(0,0,2));
        } else if (state == "flipUp") {
             if (transform.eulerAngles.z > 356 ) {
                transform.eulerAngles = new Vector3(0,0,0);
                setState("up");
                return;
            }
            transform.Rotate(new Vector3(0,0,2));
        } else if (state == "wait") {
            //if (t == 180) {
            //    setState("flipDown");
            //    return;
            //}
        } else if (state == "falling") {
            transform.Translate(Vector3.down * 1 / 20);
            if (t > 120) {
                Destroy(gameObject);
                return;
            }
        }
        t = t + 1;
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,new Vector3(0,0,180),0.5f * Time.deltaTime) ;
    }
}
