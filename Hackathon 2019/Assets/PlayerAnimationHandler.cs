using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {

    enum AnimationState {
        Idle,
        Run
    }

    private Rigidbody2D rb2d;
    private Animator animator;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(rb2d.velocity.x != 0) {
            SetAnimationState(AnimationState.Run);
        }

        if(rb2d.velocity.x < -0.2) {
            var scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        if(rb2d.velocity.x == 0) {
            SetAnimationState(AnimationState.Idle);
        }

        if(rb2d.velocity.x > 0.2) {
            var scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void SetAnimationState(AnimationState state) {
        animator.SetInteger("AnimState", (int)state);
    }

}
