using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsScript : MonoBehaviour
{
	void Start() {
		string json = File.ReadAllText(Application.dataPath + "/JSON/savedSettings.json");
		GameSettings loadedSettings = JsonUtility.FromJson<GameSettings>(json);
		Debug.Log("Zoom Speed : " + loadedSettings.zoomSpeed);
		Debug.Log("Camera Speed : " + loadedSettings.cameraSpeed);
		Debug.Log("Edge Scroll : " + loadedSettings.edgeScrollEnabled);

	}

	// Update is called once per frame
	public class GameSettings {
		public float zoomSpeed;
		public float cameraSpeed;
		public bool edgeScrollEnabled;
		
	}
}
