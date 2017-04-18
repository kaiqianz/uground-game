using UnityEngine;
using System.Collections;

public class hpShow : MonoBehaviour {


    public Transform hpgreen;
    public Transform hpred;

    public int oldblood = Constant.MaxHp;
    public int blood = Constant.MaxHp;
    public void setBlood(int b)
    {
        this.blood = b;
        setScale(hpgreen, b);
    }

    void Update()
    {
        if(oldblood !=  blood)
        {
            oldblood = (int)Mathf.Lerp(blood , oldblood, 0.6f);
            setScale(hpred, oldblood);
        }
    }

    void setScale(Transform t,int b)
    {
        t.localScale = new Vector3(0.98f * b / Constant.MaxHp, 0.85f, 1);
    }
}
