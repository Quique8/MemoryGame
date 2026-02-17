using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Dealer_lvl2 : MonoBehaviour
{
    public GameObject[] cards;
    void Start()
    {
        StartCoroutine(DealCards());
    }
    private IEnumerator DealCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            //activamos la animacion de cada carta
            GameObject card = cards[i];
            card.SetActive(true);
            card.GetComponent<Anim_Carta>().PlayDealAnimation();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
