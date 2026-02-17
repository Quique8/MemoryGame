using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Dealer : MonoBehaviour
{
    public GameObject[] cards;
    void Start()
    {
        StartCoroutine(DealCards());
    }
    void Update()
    {
        
    }

    private IEnumerator DealCards()
    {
        yield return new WaitForSeconds(0.5f);
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
