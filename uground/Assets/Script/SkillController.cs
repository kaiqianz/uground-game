using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SkillController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickerImg;

    private Image CDImg;
    private Text CDText;
    public int skillid = 0;


    //store
    public Vector3 InputDirection { set; get; }

    public bool isClick;


    public UnityEvent onUp = new UnityEvent();
    // Use this for initialization
    void Awake()
    {
        bgImg = GetComponent<Image>();
        joystickerImg = transform.Find("center").GetComponent<Image>();
        CDImg = transform.Find("CD").GetComponent<Image>();
        CDText = CDImg.transform.GetChild(0).GetComponent<Text>();
        InputDirection = Vector3.zero;
        // setSkillCD(1.5666666f);
        initSkill(skillid,false);
    }


    int MaxCD = 0;

    public SkillInfo skillInfo;

    public void initSkill(int skillid,bool isCD)
    {
        this.skillid = skillid;
        joystickerImg.sprite = Resources.Load<Sprite>("skill_" + skillid);
        skillInfo = Constant.SkillInfos[skillid];
        MaxCD = skillInfo.cd;
        cdtime = MaxCD;
        setSkillState(isCD);
    }

    public bool isCD = false;


    /// <summary>
    /// 开关CD
    /// </summary>
    /// <param name="state"></param>
    public void setSkillState(bool state)
    {
        isCD = state;
        cdtime = MaxCD;
        CDImg.gameObject.SetActive(state);
    }


    float cdtime = 0;
    /// <summary>
    /// 设置CD时间
    /// </summary>
    /// <param name="state"></param>
    public void setSkillCD(float cd)
    {
        cdtime -= cd;
        if (cdtime <= 0)
        {
            cdtime = 0;
            setSkillState(false);
        }
        if (cdtime >= 1.1f)
        {
            CDText.text = (Mathf.RoundToInt(cdtime)).ToString();
        }
        else
            CDText.text = string.Format("{0:F}", cdtime);

    }


    public virtual void OnDrag(PointerEventData ped)
    {
        if (isCD)
            return;
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector3(x, 0, y);

            //block the inner image
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            joystickerImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3), InputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));

        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        isClick = true;
    }



    public virtual void OnPointerUp(PointerEventData ped)
    {

        //put the joysticker back

        joystickerImg.rectTransform.anchoredPosition = Vector3.zero;
        isClick = false;

        if (isCD)
        {
            InputDirection = Vector3.zero;
            return;
        }


        Debug.Log("start Skill " + this.name + "   id " + skillid);
        onUp.Invoke();

        setSkillState(true);

        InputDirection = Vector3.zero;

    }


    // Update is called once per frame
    void Update()
    {
        if (isCD)
            setSkillCD(Time.deltaTime);
    }
}
