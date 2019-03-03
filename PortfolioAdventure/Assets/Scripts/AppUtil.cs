using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppUtil : MonoBehaviour
{
    public static void InitTween(){
        DOTween.useSmoothDeltaTime = true;
    }
}
