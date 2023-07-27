using UnityEngine;
using UnityEditor;

namespace RadiusOne.BoundaryCamera.Editor {
    [CustomEditor(typeof(Boundary), true)]
    [CanEditMultipleObjects]
    public class BoundaryEditor : UnityEditor.Editor {
        private static Boundary m_Boundary;
        private BoxCollider m_Collider;

        void OnEnable() {
            if(target is Boundary) {
                m_Boundary = target as Boundary;
            }
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
        }

        void OnSceneGUI() {
            if(m_Boundary) {
                if(!m_Collider) {
                    m_Boundary = target as Boundary;
                    GameObject go = m_Boundary.gameObject;
                    m_Collider = go.GetComponent<BoxCollider>();
                }
            }

            if (m_Collider)
            {
                // BoxCollider의 bounds를 가져옵니다.
                Bounds bounds = m_Collider.bounds;

                // BoundingBox의 8개 모서리를 계산합니다.
                Vector3[] corners = new Vector3[8];
                corners[0] = bounds.min;
                corners[1] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
                corners[2] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
                corners[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
                corners[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
                corners[5] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
                corners[6] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
                corners[7] = bounds.max;

                // Scene View에서 사각형을 그립니다.
                float lineWidth = 5.0f;
                Handles.color = Color.red;
                Handles.DrawAAPolyLine(lineWidth, corners[0], corners[1]);
                Handles.DrawAAPolyLine(lineWidth, corners[1], corners[5]);
                Handles.DrawAAPolyLine(lineWidth, corners[5], corners[4]);
                Handles.DrawAAPolyLine(lineWidth, corners[4], corners[0]);

                Handles.DrawAAPolyLine(lineWidth, corners[2], corners[3]);
                Handles.DrawAAPolyLine(lineWidth, corners[3], corners[7]);
                Handles.DrawAAPolyLine(lineWidth, corners[7], corners[6]);
                Handles.DrawAAPolyLine(lineWidth, corners[6], corners[2]);

                Handles.DrawAAPolyLine(lineWidth, corners[0], corners[2]);
                Handles.DrawAAPolyLine(lineWidth, corners[1], corners[3]);
                Handles.DrawAAPolyLine(lineWidth, corners[4], corners[6]);
                Handles.DrawAAPolyLine(lineWidth, corners[5], corners[7]);
            }
        }
    }
}