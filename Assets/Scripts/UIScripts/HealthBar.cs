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

        healthFill = transform.Find("HP Bar Fill").gameObject;



    }

    private void Update()
    {
        //Debug.Log(healthRect.width);
        //healthRect.width -= 10.0f;
        healthRect = healthFill.GetComponent<RectTransform>().rect;

        if ( Input.GetKeyDown("m"))
        {
            //healthRect.width = healthRect.width - 100.0f;
            healthRect = healthFill.GetComponent<RectTransform>().rect;
            Debug.Log(healthRect.width);
            //Debug.Log(healthRect.width);
            //healthRect.width = 50;
            //healthRect = healthFill.GetComponent<RectTransform>().rect;
            //Debug.Log(healthRect.width);
        }

    }
}
