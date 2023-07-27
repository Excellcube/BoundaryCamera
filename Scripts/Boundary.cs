using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiusOne.BoundaryCamera
{
    [ExecuteInEditMode]
    public class Boundary : MonoBehaviour
    {
        public static int layer = 31;

        private void Awake() {
            string layerName = LayerMask.LayerToName(layer);
            if(!string.IsNullOrEmpty(layerName)) {
                Debug.LogWarning($"[Boundary] BoundaryCamera가 사용하는 레이어({layer})가 이미 사용중입니다.({layerName}) BoundaryCamera가 정상적으로 동작하지 않을 수 있습니다.");
            }
            gameObject.layer = layer;
        }
    }
}