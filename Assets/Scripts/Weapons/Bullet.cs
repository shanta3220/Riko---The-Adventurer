﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Collidable {
    //damageStructure
    public int damagePoint = 1;
    public float pushForce = 2.0f;
   
    //upgrade
    private Rigidbody2D rBody;
    public int weaponLevel = 0;
    public float bulletSpeed = 5;
    public bool canMove;
    public float zRot;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    protected override void Start() {
        base.Start();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(gameObject, 1f);
    }

    
    private void FixedUpdate() {
        if (canMove)
            rBody.AddForce(transform.right * bulletSpeed);
    }

    protected override void OnCollide(Collider2D col) {
        base.OnCollide(col);
        if (col.tag == "Blocking")
            anim.SetInteger("Anim", 1);
            
    }

}