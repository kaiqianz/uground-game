using UnityEngine;
using System.Collections;
public class Constant
{
    /// <summary>
    /// 最大生命
    /// </summary>
    public const int MaxHp = 1000;


    /// <summary>
    /// 有几条命
    /// </summary>
    public const int MaxLive = 5;


    public const int normalBulletDamage = 50;

    public static Vector3 LeftSpawnPos = new Vector3(-8f, -6.47f, 0);
    public static Vector3 RightSpawnPos = new Vector3(8f, -6.47f, 0);

    //技能表
    public static SkillInfo[] SkillInfos = new SkillInfo[] {
        new SkillInfo("lunge" , 5 ,0,0.2f), //突进技能
        new SkillInfo("rocket",20,500,0.5f), //火箭技能
         new SkillInfo("ShieldFire",80,10),
          new SkillInfo("lunge",10,10),
    };

    /// <summary>
    /// 突进速度
    /// </summary>
    public const int LungeSpeed = 40;


    /// <summary>
    /// 突进结束速度
    /// </summary>
    public const int LungeEndSpeed = 15;

    //角色对于SkillInfos技能id
    public static int[,] CharSkill = new int[,]
        { {0,1,2 },
          {0,1,2 } };
}


public class SkillInfo
{
    public string name;
    public int damage = 0;
    /// <summary>
    /// CD时间 单位秒
    /// </summary> 
    public int cd = 1000; 

    /// <summary>
    /// 持续时间
    /// </summary>
    public float duration = 0;

    public SkillInfo(string name ,int cd, int damage, float duration = 0)
    {
        this.cd = cd;
        this.damage = damage;
        this.name = name;
        this.duration = duration;
    }

}

