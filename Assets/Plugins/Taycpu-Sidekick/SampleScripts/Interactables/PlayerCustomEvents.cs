using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomEvents : MonoBehaviour
{
    [SerializeField] private PlayerWallet playerWallet;

    public void WhenPump()
    {
        playerWallet.AddPump();

        Debug.Log("Item wearing");
    }

    public void WhenDump()
    {
        playerWallet.AddDump();
        Debug.Log("Item losing");
    }

    public void WhenTrap()
    {
    }
}