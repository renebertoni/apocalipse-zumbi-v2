using UnityEngine;

public class Helper
{
    public Vector3 RandomPosition(Transform objTransform, float radius)
    {
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        randomPosition += objTransform.position;
        randomPosition.y = objTransform.position.y;
        return randomPosition;
    }

    public CloseTarget CloseTargets(Vector3 position, float radius, LayerMask layerMask)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, radius, layerMask);
        var closeTarget = ScriptableObject.CreateInstance<CloseTarget>();
        closeTarget.CreateCloseTarget(hitColliders, hitColliders.Length > 0);

        return closeTarget;
    }

    public int[] TimeConvert(float time)
    {
        var minute = (int)(time / 60);
        var second = (int)(time % 60);
        int[] timeConverted = {minute, second};
        return timeConverted;
    }

    public void Save(Score newScore)
    {
        string json = JsonUtility.ToJson(newScore);
        // TODO criar arquivo de save
    }
}
