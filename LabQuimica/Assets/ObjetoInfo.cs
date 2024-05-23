using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoInfo : MonoBehaviour, IPointerClickHandler
{
    public string objectInfo;
    public GameObject infoPanel;
    public Text infoText;

    void Start()
	{
		infoText = infoPanel.GetComponentInChildren<Text>();
		if (infoText == null)
		{
			Debug.LogError("InfoText component not found in InfoPanel.");
		}
		else
		{
			Debug.Log("InfoText component found: " + infoText.gameObject.name);
		}
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object clicked: " + gameObject.name);
        DisplayInfo();
    }

    void DisplayInfo()
    {
        if (infoPanel != null && infoText != null)
        {
            Debug.Log("Displaying info: " + objectInfo);
            infoText.text = objectInfo;
            infoPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("InfoPanel or InfoText is not assigned.");
        }
    }
}
