using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CavasSwitcher : MonoBehaviour {
	public RectTransform InstructionPanel;
	public RectTransform GameUIPanel;
	public RectTransform GameOverPanel;

	private void Start() {
		InstructionPanel.gameObject.SetActive(true);
		GameUIPanel.gameObject.SetActive(false);
		GameOverPanel.gameObject.SetActive(false);

		Cursor.visible = true;
	}

	public void BeginPlay() {
		InstructionPanel.gameObject.SetActive(false);
		GameUIPanel.gameObject.SetActive(true);
		GameOverPanel.gameObject.SetActive(false);

		Cursor.visible = false;
	}

	public void EndGame() {
		InstructionPanel.gameObject.SetActive(false);
		GameUIPanel.gameObject.SetActive(false);
		GameOverPanel.gameObject.SetActive(true);

		Cursor.visible = true;
	}

	public void NewGame() {
		SceneManager.LoadScene(0);
	}
}
