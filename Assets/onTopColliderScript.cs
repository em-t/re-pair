using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTopColliderScript : MonoBehaviour
{

    public CardScript parentScript;
    void Start()
    {
        parentScript = transform.parent.GetComponent<CardScript>();
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            parentScript.setState("flipUp");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
