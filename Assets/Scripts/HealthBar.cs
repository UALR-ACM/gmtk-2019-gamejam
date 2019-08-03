using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public EntityStats stats;

	public RectTransform healthFillPanel;
	private float healthFillMaxWidth;

	private void Start() {
		healthFillMaxWidth = healthFillPanel.rect.width;
	}

	private void Update() {
		Rect rect = healthFillPanel.rect;
		float newWidth = healthFillMaxWidth * stats.GetHealthPercentage();
		healthFillPanel.rect.Set(rect.x, rect.y, newWidth, rect.height);
	}
}
