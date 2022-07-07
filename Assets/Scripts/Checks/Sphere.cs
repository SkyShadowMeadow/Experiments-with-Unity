using UnityEngine;

namespace Checks
{
    public class Sphere : MonoBehaviour
    {
        [field:SerializeField] public int Remainder { get; private set; }
        [field:SerializeField] public Color color0 { get; private set; }
        [field:SerializeField] public Color color1 { get; private set; }
        [field:SerializeField] public Color color2 { get; private set; }
        [field:SerializeField] public Color color3 { get; private set; }
        
        private MeshRenderer _meshRenderer;
        public bool IsColorChanged { get; private set; }
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void ChangeColor()
        {
            IsColorChanged = true;
            
            switch (Remainder)
            {
                case 0:
                    _meshRenderer.material.color = color0;
                    break;
                case 1:
                    _meshRenderer.material.color = color1;
                    break;
                case 2:
                    _meshRenderer.material.color = color2;
                    break;
                case 3:
                    _meshRenderer.material.color = color3;
                    break;
            }
        }
        
    }
}
