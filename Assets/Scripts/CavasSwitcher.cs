using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CavasSwitcher : MonoBehaviour {
	public RectTransform InstructionPanel;
	public RectTransform GameUIPanel;
	public RectTransform GameOverPanel;
	public RectTransform CreditsPanel;

	private void Start() {
		InstructionPanel.gameObject.SetActive(true);
		GameUIPanel.gameObject.SetActive(false);
		GameOverPanel.gameObject.SetActive(false);
		CreditsPanel.gameObject.SetActive(false);
	}

	private void BeginPlay() {
		InstructionPanel.gameObject.SetActive(false);
		GameUIPanel.gameObject.SetActive(true);
		GameOverPanel.gameObject.SetActive(false);
		CreditsPanel.gameObject.SetActive(false);
	}

	private void EndGame() {
		InstructionPanel.gameObject.SetActive(false);
		GameUIPanel.gameObject.SetActive(false);
		GameOverPanel.gameObject.SetActive(true);
		CreditsPanel.gameObject.SetActive(false);
	}

	private void DisplayCredits() {
		InstructionPanel.gameObject.SetActive(false);
		GameUIPanel.gameObject.SetActive(false);
		GameOverPanel.gameObject.SetActive(true);
		CreditsPanel.gameObject.SetActive(false);
	}

	private void NewGame() {
		SceneManager.LoadScene(0);
	}
}
