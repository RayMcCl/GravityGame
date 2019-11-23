using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Button runButton;
	public InputField angleField;
	public InputField speedField;
	public ShipController ship;

	void Start () {
		runButton.onClick.AddListener(onRunClick);
	}

	void onRunClick () {
		int angle = int.Parse(angleField.text);
		int speed = int.Parse(speedField.text);

		ship.angle = angle;
		ship.speed = speed;
	}
}
