using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTopColliderScript : MonoBehaviour
{

    public CardScript childScript;
    void Start()
    {
        var card = this.gameObject.transform.GetChild(0);
        childScript = card.GetComponent<CardScript>();
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (childScript.state == "down") {
                childScript.setState("flipUp");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
