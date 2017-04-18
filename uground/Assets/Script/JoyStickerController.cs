using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickerController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{
	private Image bgImg;
	private Image joystickerImg; 

	//store
	public Vector3 InputDirection{set; get;}

    public bool isClick;
	// Use this for initialization
	void Start () {
		bgImg = GetComponent<Image> ();
		joystickerImg = transform.Find("center").GetComponent<Image> ();
		InputDirection = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
			float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector3 (x, 0, y);

			//block the inner image
			InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

			joystickerImg.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3), InputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));
	
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
        isClick = true;
    }



	public virtual void OnPointerUp(PointerEventData ped)
	{
		//put the joysticker back
		InputDirection = Vector3.zero;
		joystickerImg.rectTransform.anchoredPosition = Vector3.zero;
        isClick = false;

    }


	// Update is called once per frame
	void Update () {
	
	}
}
