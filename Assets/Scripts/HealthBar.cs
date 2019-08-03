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
}
