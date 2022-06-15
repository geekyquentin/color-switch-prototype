using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ColorAssignerForImage : MonoBehaviour {
    private void Start() {
        RawImage[] im = GetComponentsInChildren<RawImage>().Where(x => x.gameObject != gameObject).ToArray();
        for (int i = 0; i < im.Length; i++) {
            im[i].color = ColorManager.Colors[i];
        }
    }
}
