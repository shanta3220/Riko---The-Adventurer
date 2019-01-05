﻿using UnityEngine;

public class ScenePortal : Collidable {

    public string[] sceneNames;
    public Sprite doorLeafOpen;
    private bool canChangeScene;
    public bool isOnMenuScene;


    public void OpenDoor() {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = doorLeafOpen;
        AudioController.instance.PlaySound(SoundClip.gateOpen);
        canChangeScene = true;
    }

    protected override void OnCollide(Collider2D col) {
        if (!canChangeScene)
            return;
        if (col.tag =="Player") {
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            if (isOnMenuScene) {
                MenuController.instance.SaveData();
                return;
            }
            GameManager.instance.SaveData();
        }
    }
}
