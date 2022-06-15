using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorAssigner : MonoBehaviour {
    private void Start() {
        SpriteRenderer[] sr = GetComponentsInChildren<SpriteRenderer>().Where(x => x.gameObject != gameObject).ToArray();
        for (int i = 0; i < sr.Length; i++) {
            sr[i].color = ColorManager.Colors[i];
        }
    }
}
