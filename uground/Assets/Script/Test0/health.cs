using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class health : NetworkBehaviour {

    [SyncVar(hook = "changeHP")]
    public int healths = 100;

    public Image img;

    public void TakeD(int aaa)
    {
        if (!isServer)
            return;

        healths -= aaa;
        if (healths <= 0)
        {
            healths = 100;
            RpcRespawn();
        }
    }



    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            transform.position = Vector3.zero;
        }
    }

    private void changeHP(int h)
    {
        img.fillAmount = h * 1.0f / 100;
    }
}
