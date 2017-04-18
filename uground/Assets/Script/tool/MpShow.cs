using UnityEngine;
using System.Collections;

public class MpShow : MonoBehaviour {

    private int mpshowCount = 5;


    public void setMp(float mp)
    {
        int temp = (int)(mp + 199) / 200;
        //temp++;
        if (temp != mpshowCount)
        {
            mpshowCount = temp;
            for(int i=0; i<5;i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(i < mpshowCount);
            }
        }
    }
}
