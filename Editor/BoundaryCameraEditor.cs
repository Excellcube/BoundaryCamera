using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

using RadiusOne.BoundaryCamera;

namespace RadiusOne.BoundaryCamera.Editor
{
    [CustomEditor(typeof(BoundaryCamera))]
    public class BoundaryCameraEditor : UnityEditor.Editor
    {
        private Boundary m_Boundary;

        void OnEnable() {
            m_Boundary = FindObjectOfType<Boundary>();
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
        }

        void OnSceneGUI() {

        }
    }

}