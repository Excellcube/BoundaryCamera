using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Excellcube.BoundaryCamera
{
    [ExecuteInEditMode]
    public class BoundaryCamera : MonoBehaviour
    {
        private enum Corner {
            LeftLower, LeftUpper, RightUpper, RightLower
        }

        private Camera m_Camera;
        private Boundary m_Boundary;
        
        private int m_LayerMask;
        private Vector3 m_PrevPosition;
        private Quaternion m_PrevRotation;


        [Header("디버깅")]
        [SerializeField]
        private bool m_DrawDebugLine = true;


        void Start()
        {
            m_LayerMask = 1 << Boundary.layer;
        }

        /// <summary>
        /// 카메라 위치를 강제로 설정. 현재 로직상 카메라가 바운더리 존재하지 않으면
        /// 카메라의 위치를 강제로 prev position과 prev rotation으로 설정
        /// </summary>
        public void ForceSetPosition(Vector3 position, Quaternion rotation) {
            m_PrevPosition = position;
            m_PrevRotation = rotation;
        }

        void LateUpdate()
        {
            if(!FindBoundary()) {
                return;
            }

            BoundInArea();
        }

        public void BoundInArea(bool forceInBound = true) {
            if(m_Camera == null) {
                m_Camera = GetComponent<Camera>();

                m_PrevPosition = m_Camera.transform.position;
                m_PrevRotation = m_Camera.transform.rotation;

                m_LayerMask = 1 << Boundary.layer;
            }

            // 카메라의 각 모서리를 Boundary의 높이에 raycasting.
            RaycastHit leftLowerHit, leftUpperHit, rightLowerHit, rightUpperHit;
            bool isInBoundary = true;

            isInBoundary &= RaycastToCorner(Corner.LeftLower, out leftLowerHit);
            isInBoundary &= RaycastToCorner(Corner.LeftUpper, out leftUpperHit);
            isInBoundary &= RaycastToCorner(Corner.RightLower, out rightLowerHit);
            isInBoundary &= RaycastToCorner(Corner.RightUpper, out rightUpperHit);

            if(isInBoundary && m_DrawDebugLine) {
                Debug.DrawLine(leftLowerHit.point, leftUpperHit.point, Color.blue);
                Debug.DrawLine(leftUpperHit.point, rightUpperHit.point, Color.blue);
                Debug.DrawLine(rightUpperHit.point, rightLowerHit.point, Color.blue);
                Debug.DrawLine(rightLowerHit.point, leftLowerHit.point, Color.blue);

                m_PrevPosition = m_Camera.transform.position;
                m_PrevRotation = m_Camera.transform.rotation;
            } else if(forceInBound) {
                m_Camera.transform.position = m_PrevPosition;
                m_Camera.transform.rotation = m_PrevRotation;
            }
        }

        private bool RaycastToCorner(Corner corner, out RaycastHit hit) {
            Vector2 coord = Vector2.zero;
            switch(corner) {
                case Corner.LeftLower  : coord = new Vector2(0, 0); break;
                case Corner.LeftUpper  : coord = new Vector2(0, 1); break;
                case Corner.RightLower : coord = new Vector2(1, 0); break;
                case Corner.RightUpper : coord = new Vector2(1, 1); break;
            }

            Vector3 start = m_Camera.ViewportToWorldPoint(new Vector3(coord.x, coord.y, 0));
            Vector3 end   = m_Camera.ViewportToWorldPoint(new Vector3(coord.x, coord.y, 1));
            Vector3 direction = end - start;

            if(Physics.Raycast(start, direction, out hit, Mathf.Infinity, m_LayerMask)) {
                if(m_DrawDebugLine) {
                    Debug.DrawLine(start, hit.point, Color.green);
                }
                return true;
            } else {
                if(m_DrawDebugLine) {
                    Debug.DrawRay(start, direction * 200, Color.red);
                }
                return false;
            }
        }

        private bool FindBoundary() {
            // 카메라의 이동 제한 영역을 탐색.
            if(m_Boundary == null) {
                m_Boundary = FindObjectOfType<Boundary>();
                // Boundary를 찾을 수 없을 경우 로직 종료.
                if(m_Boundary == null) {
                    Debug.LogWarning("[BoundaryCamera] BoundaryCamera가 사용하는 Boundary를 찾을 수 없음");
                    return false;
                }

                // collider의 높이를 매우 작은 값으로 설정. 평면과 같은 수준으로 얇게 생성한다.
                BoxCollider collider = m_Boundary.GetComponent<BoxCollider>();
                Vector3 size = collider.size;
                size.y = 0.01f;
                collider.size = size;
            }
            return true;
        }
    }
}