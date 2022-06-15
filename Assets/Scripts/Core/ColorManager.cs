using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    public static ColorManager instance;

    public static Color[] Colors { get => instance.colors; }

    [SerializeField] Color[] colors;

    private void Awake() {
        if (instance == null) {
            instance = this;

            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
