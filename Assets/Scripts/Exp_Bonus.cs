using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_Bonus : MonoBehaviour
{

    [SerializeField] private int bonus = 10;

    private void OnMouseDown()
    {
        GameManager.Instance.CurrentPlayer.AddExp(bonus);
        Destroy(gameObject);
    }
}
