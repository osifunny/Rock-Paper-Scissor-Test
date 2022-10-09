using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Player : MonoBehaviour
{
    public Transform atkPosRef;
    public Card chosenCard;
    public HealthBar healthBar;
    public TMP_Text healthText;
    public float Health;
    public AudioSource audioSource;
    public AudioClip damageClip;
    private Tweener animationTweener;
    private void Start(){
        Health = 100;
    }
    public Attack? AttackValue{
        get => chosenCard == null ? null : chosenCard.AttackValue;
    }
    public void Reset(){
        if(chosenCard != null) chosenCard.Reset();
        chosenCard = null;
    }
    public void SetChosenCard(Card newCard){
        if(chosenCard != null) chosenCard.Reset();
        chosenCard = newCard;
        chosenCard.transform.DOScale(chosenCard.transform.localScale*1.2f,0.2f);
    }
    public void ChangeHealth(float amount){
        Health += amount;
        Health = Mathf.Clamp(Health,0,100);
        healthBar.UpdateBar(Health/100);
        healthText.text = " " + Health + " ";
    }
    public void AnimateAttack()
    {
        animationTweener = chosenCard.transform
        .DOMove(atkPosRef.position,0.5f);
    }
    public void AnimateDamage(){
        audioSource.PlayOneShot(damageClip);
        var image = chosenCard.transform.GetComponent<Image>();
        animationTweener = image
        .DOColor(Color.red,0.1f)
        .SetLoops(3,LoopType.Yoyo)
        .SetDelay(0.2f);
    }
    public void AnimateDraw(){
        animationTweener = chosenCard.transform
        .DOMove(chosenCard.OriginalPosition,1)
        .SetEase(Ease.InBack)
        .SetDelay(0.2f);
    }
    public bool IsAnimating(){
        return animationTweener.IsActive();
    }
    public void IsClickable(bool value){
        Card[] cards = GetComponentsInChildren<Card>();
        foreach(var card in cards) card.SetClickable(value);
    }
}
