using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public EntityStats stats;

	public Transform healthFillPanel;
	private float healthFillMaxWidth;

	private void Start() {
		healthFillMaxWidth = healthFillPanel.localScale.x;
	}
    

	private void Update() {

        float newWidth = healthFillMaxWidth * stats.GetHealthPercentage();



        if (newWidth <= 0)
        {
            newWidth = 0;
        }

        Vector3 newScale = healthFillPanel.localScale;
        newScale.x = newWidth;
        healthFillPanel.localScale = newScale;

	}
}
