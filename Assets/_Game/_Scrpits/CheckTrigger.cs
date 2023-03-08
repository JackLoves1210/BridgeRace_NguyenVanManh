using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _tranformMovement;
    [SerializeField] private PlayerGetBrick baloSelf;
    Rigidbody rb;
    BoxCollider boxCollider;
    public bool isFalling = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bot") )
        {
            if (baloSelf._countBrick < collision.collider.GetComponentInChildren<PlayerGetBrick>()._countBrick)
            {
                StartCoroutine(fall());
                // _tranformMovement.GetComponent<PlayerMovement>().ActiveSpeed();
                Debug.Log("1");
 
            }
        }
        else if (collision.collider.CompareTag("Player"))
        {
            if (baloSelf._countBrick < collision.collider.GetComponentInChildren<PlayerGetBrick>()._countBrick)
            {
                StartCoroutine(fall());
            }
            Debug.Log("2");

        }
    }
 
    IEnumerator fall()
    {
        isFalling = true;
        _tranformMovement.GetComponent<AnimationController>().PlayFall();
        baloSelf._countBrick = 0;
        foreach (Transform item in baloSelf._targetPoint)
        {
            item.SetParent(null);
            ResourceManager._instance.ChangeColor(5, item.gameObject);
            rb = item.gameObject.AddComponent<Rigidbody>();
            rb.mass = 1f;
            rb.drag = 0.5f;
            boxCollider = item.gameObject.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(1, 1, 1);
            item.gameObject.tag = "BrickCharacter";
            item.GetComponent<Renderer>().material.color = Color.gray;
        }
        baloSelf.ResetBrick();
        yield return new WaitForSeconds(2f);
        isFalling = false;

    }
}
