using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private Player player;

    public void HealPlayer()
    {
        if(player.ReturnIsDead() == false)
        {
            player.Heal();
        }
    }

    public void DamagePlayer()
    {
        if(player.ReturnIsDead() == false)
        {
            player.Damage();
        }
    }
}
