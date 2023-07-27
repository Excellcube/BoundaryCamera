using UnityEngine;
using UnityEditor;

namespace Excellcube.BoundaryCamera.Editor {
    [CustomEditor(typeof(Boundary), true)]
    [CanEditMultipleObjects]
    public class BoundaryEditor : UnityEditor.Editor {
        private Boundary m_Boundary;

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
            DrawAllBoundingBox();
        }

        public void DrawAllBoundingBox() {
            if(m_Boundary != null) {
                DrawBoundingBox(m_Boundary, Color.yellow);
            }
        }

        public void DrawBoundingBox(Boundary boundary, Color color) {
            BoxCollider collider = null;

            if(boundary) {
                boundary = target as Boundary;
                GameObject go = boundary.gameObject;
                collider = go.GetComponent<BoxCollider>();
            }

            if (collider)
            {
                Matrix4x4 prevMatrix = Handles.matrix;

                Handles.matrix = collider.transform.localToWorldMatrix;

                Bounds localBound = new Bounds(collider.center, collider.size);
                DrawBox(localBound, color);

                Handles.matrix = prevMatrix;
            }
        }

        void DrawBox(Bounds bounds, Color color)
        {
            Vector3[] corners = new Vector3[8];
            corners[0] = bounds.min;
            corners[1] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
            corners[2] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
            corners[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
            corners[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
            corners[5] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
            corners[6] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
            corners[7] = bounds.max;

            float lineWidth = 5f;
            Handles.color = color;
            
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