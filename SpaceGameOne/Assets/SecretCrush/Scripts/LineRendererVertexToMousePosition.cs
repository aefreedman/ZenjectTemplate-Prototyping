using UnityEngine;

namespace SecretCrush.Scripts
{
    public class LineRendererVertexToMousePosition : MonoBehaviour
    {
        public LineRenderer LineRenderer;
        public int[] Indices;
        public int Z;
        public bool Opposite;
        public float ClampLength;
        
        // Use this for initialization
        private void Start()
        {
            if (LineRenderer == null) LineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var index in Indices)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var localMousePos = gameObject.transform.InverseTransformVector(mousePos) - gameObject.transform.position;
                if (Opposite)
                {
                    localMousePos = gameObject.transform.position - gameObject.transform.InverseTransformVector(mousePos);
                }
                var v = localMousePos;
                v = Vector3.ClampMagnitude(v, ClampLength);
                LineRenderer.SetPosition(0, new Vector3(0, 0, Z));

                v.z = Z;

                LineRenderer.SetPosition(index, v);
            }
        }
    }
}