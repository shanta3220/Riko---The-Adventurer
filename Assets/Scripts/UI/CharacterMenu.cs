﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour {
    //Text field
    public Text levelText, hitpointText, goldText, upgradeCostText, xpText;
    public Text characterSelectorText;
    public Button characterSelectorButton;
    //logic field
    public Image CharacterSelectionImage;
    public Image currentWeaponImage;
    public RectTransform xpBar;


    public int currentCharacterSelection = 0;
    private Animator anim;
    private int[] skinPrices = { 0, 300, 1000 };

    private void Start() {
        anim = GameManager.instance.player.GetComponent<Animator>();
        Invoke("DeleyValue", 0.5f);
    }

    //CharacterSelection
    public void OnArrowClick(bool right) {
        if (right) {
            currentCharacterSelection++;
            //if no more character
            if (GameManager.instance.playerSprites.Count == currentCharacterSelection)
                currentCharacterSelection = 0;
            OnSelectionChange();
        
        }
        else {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0) {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }
            OnSelectionChange();
        }
    }

    private void OnSelectionChange() {
        CharacterSelectionImage.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        SkinSelector();
    }

    //Ceapon upgrade
    public void OnUpgradeClick() {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //update character Information
    public void UpdateMenu() {
        //weapon

        CharacterSelectionImage.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        currentWeaponImage.sprite = GameManager.instance.weaponSprite;
        upgradeCostText.text = GameManager.instance.weapon.weaponPrinces[GameManager.instance.weapon.weaponLevel].ToString();
        //meta
        hitpointText.text = GameManager.instance.player.health.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        levelText.text = "NOT IMPLEMENTED";

        //XP Bar
        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector2(0.5f, 1f);
        
    }

    public void UnlockSkin() {
        if (GameManager.instance.TryUnlockSkin(currentCharacterSelection, skinPrices[currentCharacterSelection])) {
            characterSelectorText.text = "Selected";
            UpdateMenu();
        }
        else characterSelectorText.text = skinPrices[currentCharacterSelection].ToString();

    }

    public void SkinSelector() {
        //if is unlocked
        if (GameManager.instance.data.skins[currentCharacterSelection]) {
            characterSelectorText.text = "Selected";
            anim.runtimeAnimatorController = GameManager.instance.playerSkins[currentCharacterSelection];
            GameManager.instance.data.selectedSkin = currentCharacterSelection;
        }
        else {
            characterSelectorText.text = skinPrices[currentCharacterSelection].ToString();
        }
    }

    public void DeleyValue() {
        currentCharacterSelection = GameManager.instance.data.selectedSkin;
    }
}
