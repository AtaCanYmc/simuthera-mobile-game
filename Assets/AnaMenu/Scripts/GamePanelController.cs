using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelController : MonoBehaviour
{
	public static readonly string[] panelOrder = new[] {"Game0", "Game1", "Game2", "Game3", "Game4", "Game5"};
	public static readonly int initialPanelIndex = 2;
	public static readonly float swipeRegFactor = 0.10f;
	
	private RectTransform gamePanelContainer;
	private Vector2 viewPoint;
	private int activePanel;

	IEnumerator MoveGameContainer(int nextPanelIndex)
	{
		RectTransform prevGameContainer = gamePanelContainer.Find(panelOrder[activePanel]) as RectTransform;
		RectTransform nextGameContainer = gamePanelContainer.Find(panelOrder[nextPanelIndex]) as RectTransform;
		RectTransform prevInnerContainer = prevGameContainer.GetChild(0) as RectTransform;
		RectTransform nextInnerContainer = nextGameContainer.GetChild(0) as RectTransform;
		RectTransform prevButton = prevGameContainer.GetChild(1) as RectTransform;
		RectTransform nextButton = nextGameContainer.GetChild(1) as RectTransform;
		
		CanvasGroup prevCanvasGroup = prevInnerContainer.GetComponent<CanvasGroup>();
		CanvasGroup nextCanvasGroup = nextInnerContainer.GetComponent<CanvasGroup>();
		
		nextGameContainer.SetAsLastSibling();
		
		float panelX = nextGameContainer.localPosition.x;
		Vector2 targetPos = new Vector2(viewPoint.x - panelX, viewPoint.y);

		Vector2 velocity = new Vector2(0, 0);
		do
		{
			prevInnerContainer.localScale = Vector2.Lerp(prevInnerContainer.localScale, new Vector2(1f, 1f), 12f*Time.deltaTime);
			nextInnerContainer.localScale = Vector2.Lerp(nextInnerContainer.localScale, new Vector2(1.35f, 1.35f), 12f*Time.deltaTime);
			prevButton.localScale = Vector2.Lerp(prevButton.localScale, new Vector2(1f, 1f), 12f*Time.deltaTime);
			nextButton.localScale = Vector2.Lerp(nextButton.localScale, new Vector2(1.35f, 1.35f), 12f*Time.deltaTime);
			
			prevCanvasGroup.alpha = Mathf.Lerp(prevCanvasGroup.alpha, 0.5f, 10f*Time.deltaTime);
			nextCanvasGroup.alpha = Mathf.Lerp(nextCanvasGroup.alpha, 1f, 10f*Time.deltaTime);
			
			gamePanelContainer.anchoredPosition = Vector2.SmoothDamp(gamePanelContainer.anchoredPosition, targetPos, ref velocity, 0.25f);
			
			yield return null;
		} while (gamePanelContainer.anchoredPosition != targetPos);

		nextInnerContainer.localScale = new Vector2(1f, 1f);
		prevInnerContainer.localScale = new Vector2(1.35f, 1.35f);
		prevButton.localScale = new Vector2(1f, 1f);
		nextButton.localScale = new Vector2(1.35f, 1.35f);
		
		prevCanvasGroup.alpha = 0.5f;
		nextCanvasGroup.alpha = 1f;
		
		gamePanelContainer.anchoredPosition = targetPos;
	}
	
	public void disableButton(int panelIndex) {
		gamePanelContainer.Find(panelOrder[panelIndex]).GetChild(1).GetComponent<Button>().interactable = false;
	}
	
	public void enableButton(int panelIndex) {
		gamePanelContainer.Find(panelOrder[panelIndex]).GetChild(1).GetComponent<Button>().interactable = true;
	}
	
    // Start is called before the first frame update
    void Start()
    {
		gamePanelContainer = this.GetComponent<RectTransform>();
		viewPoint = gamePanelContainer.anchoredPosition;
		
		Transform initialPanel = gamePanelContainer.Find(panelOrder[initialPanelIndex]);
		float panelX = initialPanel.transform.localPosition.x;
		gamePanelContainer.anchoredPosition = new Vector2(viewPoint.x - panelX, viewPoint.y);
		initialPanel.GetChild(0).localScale = new Vector2(1.35f, 1.35f);
		initialPanel.GetChild(1).localScale = new Vector2(1.35f, 1.35f);
		initialPanel.GetChild(1).GetComponent<Button>().interactable = true;
		initialPanel.GetChild(0).GetComponent<CanvasGroup>().alpha = 1f;
		activePanel = initialPanelIndex;
		initialPanel.SetAsLastSibling();
    }

	public static Vector2 initialTouchPos;
	public static Vector2 touchDelta;
	public static bool swipe;

    // Update is called once per frame
    void Update()
    {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			
			switch (touch.phase)
            {
                case TouchPhase.Began:
					initialTouchPos = touch.position;
					touchDelta = new Vector2(0, 0);
                    break;
                case TouchPhase.Moved:
                    touchDelta = touch.position - initialTouchPos;
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(touchDelta.x) > Screen.currentResolution.width*swipeRegFactor)
						swipe = true;			
                    break;
            }
		}
		
		if(swipe) {
			disableButton(activePanel);
			
			if (touchDelta.x > 0) { // Right
				
				if (activePanel > 0)
				{
					StopAllCoroutines();
					StartCoroutine(MoveGameContainer(activePanel - 1));
					activePanel--;
				}
				
			} else { // Left
				
				if (activePanel < panelOrder.Length - 1)
				{
					StopAllCoroutines();
					StartCoroutine(MoveGameContainer(activePanel + 1));
					activePanel++;
				}
				
			}
			
			swipe = false;
			enableButton(activePanel);
		}
		
		//For Keyboard
		
	    if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
	    {
		    if (activePanel > 0)
		    {
				disableButton(activePanel);
			    StopAllCoroutines();
			    StartCoroutine(MoveGameContainer(activePanel - 1));
				activePanel--;
				enableButton(activePanel);
		    }
	    } else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
	    {
		    if (activePanel < panelOrder.Length - 1)
		    {
				disableButton(activePanel);
			    StopAllCoroutines();
			    StartCoroutine(MoveGameContainer(activePanel + 1));
				activePanel++;
				enableButton(activePanel);
		    }
	    }
    }
}
