using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

using Excellcube.BoundaryCamera;

namespace Excellcube.BoundaryCamera.Editor
{    
    [CustomEditor(typeof(BoundaryCamera))]
    public class BoundaryCameraEditor : UnityEditor.Editor
    {
        private enum Corner {
            LeftLower, LeftUpper, RightUpper, RightLower
        }
        
        private Camera m_Camera;
        private Boundary[] m_Boundaries;
        private BoundaryEditor[] m_BoundaryEditors;

        private BoundaryCamera m_BoundaryCamera;

        void OnEnable() {
            m_Boundaries = FindObjectsOfType<Boundary>();
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
        }

        void OnSceneGUI() {
            if(m_Boundaries != null && m_Boundaries.Length > 0) {
                if(m_BoundaryEditors == null) {
                    m_BoundaryEditors = new BoundaryEditor[m_Boundaries.Length];
                    for(int i=0 ; i<m_Boundaries.Length ; i++) {
                        m_BoundaryEditors[i] = CreateEditor(m_Boundaries[i]) as BoundaryEditor;
                    }
                }

                for(int i=0 ; i<m_Boundaries.Length ; i++) {
                    m_BoundaryEditors[i].DrawAllBoundingBox();
                }
            }

            if(m_BoundaryCamera == null) {
                m_BoundaryCamera = target as BoundaryCamera;
            }
            m_BoundaryCamera.BoundInArea(forceInBound: false);
        }
    }

}