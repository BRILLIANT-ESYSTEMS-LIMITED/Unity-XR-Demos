using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject m_PrefabToSpawn;
    XRSocketInteractor m_SocketInteractor;

    const float minSphereSize = 0.05f;
    const float maxSphereSize = 1.25f;

    void OnEnable()
    {
        m_SocketInteractor = GetComponent<XRSocketInteractor>();
        m_SocketInteractor.onSelectExit.AddListener(ObjectGrabbed);
    }

    void ObjectGrabbed(XRBaseInteractable interactable)
    {
        // Spawn another sphere of random size
        GameObject newSphere = Instantiate(m_PrefabToSpawn, transform.position, Quaternion.identity);
        newSphere.transform.localScale = GetRandomScale();
    }

    Vector3 GetRandomScale()
    {
        float scale = UnityEngine.Random.Range(minSphereSize, maxSphereSize);
        return new Vector3(scale, scale, scale);
    }
}
