using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float spawnRate = 0.1f;
    [SerializeField] private float catchRate = 0.1f;
    [SerializeField] private int attack = 0;
    [SerializeField] private int defenece = 0;
    [SerializeField] private int hp = 10;
    [SerializeField] private AudioClip crySound;

    private AudioSource audioSource;

    public float SpawnRate { get => spawnRate; set => spawnRate = value; }
    public float CatchRate { get => catchRate; set => catchRate = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defenece { get => defenece; set => defenece = value; }
    public int Hp { get => hp; set => hp = value; }
    public AudioClip CrySound { get => crySound; set => crySound = value; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        Assert.IsNotNull(audioSource);
        Assert.IsNotNull(CrySound);
    }

    private void OnMouseDown()
    {
        PartyQuestSceneManager[] managers = FindObjectsOfType<PartyQuestSceneManager>();
        audioSource.PlayOneShot(CrySound);
        foreach(PartyQuestSceneManager partyQuestSceneManager in managers)
        {
            if (partyQuestSceneManager.gameObject.activeSelf)
            {
                partyQuestSceneManager.enemyTapped(this.gameObject);
            }
        }
    }
}
