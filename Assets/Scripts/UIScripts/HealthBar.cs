using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public EntityStats stats;

	public RectTransform healthFillPanel;
	private float healthFillMaxWidth;

    private GameObject healthFill;
    private Rect healthRect;

	private void Start() {
		healthFillMaxWidth = healthFillPanel.rect.width;

        healthFill = transform.Find("HP Bar Fill");
        healthRect = healthFill.GetComponent<RectTransform>().rect;
        Debug.Log(healthRect.width);


    }

    private void Update()
    {
        //Debug.Log(healthRect.width);
        //healthRect.width -= 10.0f;
        Debug.Log(healthRect.width);
    }
}
