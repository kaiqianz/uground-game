using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Bullet : NetworkBehaviour {
    [SyncVar(hook = "changeLayer")]
    public int ownerid = 0;

    public int damage = Constant.normalBulletDamage;
	void OnCollisionEnter2D(Collision2D s)
    {
        Debug.Log(s.gameObject.name);
        SuperPlayerCtrl sp = s.gameObject.GetComponent<SuperPlayerCtrl>();
        if(sp != null && sp.IDCODE == ownerid)
            return;
        if(sp != null)
        {
            sp.TakeD(damage,s.transform);
        }
        Destroy(gameObject);
    }

    private void changeLayer(int ownerid)
    {
        this.ownerid = ownerid;
        if (GameManager.Instance.ID != ownerid)
            this.gameObject.layer = 11;
    }
}
