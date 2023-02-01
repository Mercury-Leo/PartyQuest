using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Attack : MonoBehaviour
{

    [SerializeField] private AudioClip attackSound;
    [SerializeField] private float attackRate = 3f;
    [SerializeField] private float attackDMG = 10f;

    private AudioSource audioSource;
    private Animator animator;
    

    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(animator);
    }

    public void attack()
    {
        audioSource.PlayOneShot(attackSound);
        animator.Play(PartyQuestConst.ATTACK_ANIMATION);
    }
}
