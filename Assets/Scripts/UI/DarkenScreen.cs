using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenScreen : MonoBehaviour {

    public void FadeToAlpha(float alpha, float time) {
        Image image = GetComponent<Image>();
        image.color = Color.black;
        image.CrossFadeAlpha(0, 0, false);
        image.CrossFadeAlpha(alpha, time, false);
    }
}
