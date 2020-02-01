using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardPack : ScriptableObject
{
    [SerializeField]private List<Card> cards;
    public List<Card> Cards => cards;
}
