using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _tranformMovement;
    [SerializeField] private PlayerGetBrick balo;

    Rigidbody rb;
    BoxCollider boxCollider;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bot") || collision.collider.CompareTag("Player"))
        {
            if (balo._countBrick < collision.collider.GetComponent<Character>()._botGetBrick._countBrick)
            {
                StartCoroutine(fall());
                _tranformMovement.GetComponent<AnimationController>().PlayRun();
            }
        }
    }
 
    IEnumerator fall()
    {
        _tranformMovement.GetComponent<AnimationController>().PlayFall();
        balo._countBrick = 0;
        foreach (Transform item in balo._targetPoint)
        {
            item.SetParent(null);
            ResourceManager._instance.ChangeColor(5, item.gameObject);
            rb = item.gameObject.AddComponent<Rigidbody>();
            rb.mass = 1f;
            rb.drag = 0.5f;
            boxCollider = item.gameObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(1, 1, 1);
            item.gameObject.tag = "BrickCharacter";
        }
        balo.ResetBrick();
        yield return new WaitForSeconds(1.0f);
    }
}
