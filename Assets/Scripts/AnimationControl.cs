using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine(AnimStop());
        StartCoroutine(PlayAnimInterval(30, 0.1f));
    }

    // Update is called once per frame
    void Update()
    {
       
        if (anim["CardAnim2"].speed > 0.25)
            anim["CardAnim2"].speed -= 0.00005f;

    }

    private IEnumerator AnimStop()
    {
        
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);

    }
    private IEnumerator PlayAnimInterval(int n, float time)
    {
        while (n > 0)
        {
            anim.Play();
            --n;
            yield return new WaitForSeconds(time);
        }
    }
}
