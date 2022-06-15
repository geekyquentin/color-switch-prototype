using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    [SerializeField] private Transform player;

    private void Update() {
        if (!player) { return; }
        if (player.position.y > transform.position.y) {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
}
