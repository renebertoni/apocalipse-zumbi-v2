using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static bool NearTheTarget(Transform objTransfom, LayerMask layerMask)
    {
        Collider[] hitColliders = Physics.OverlapSphere(objTransfom.position + objTransfom.forward, 1f, layerMask);
        return hitColliders.Length > 0;
    }
}
