using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    private bool isColliding = false;

    void Update()
    {
        //if(isColliding)
        //Debug.Log(isColliding);
        isColliding = false;

    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("circle_fade");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator OpenDoor(Vector3 byAngles, float inTime)
    {
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (float i = 0f; i < 1f; i += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, i);
            yield return null;

        }
        //Snapping to the correct angle
        transform.rotation = toAngle;        
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor(Vector3.down * 45, 0.8f));
            isColliding = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(LoadScene());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor(Vector3.up * 45, 0.8f));
            
        }
    }
}

