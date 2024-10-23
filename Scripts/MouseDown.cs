using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{
    public bool on_cooldown = false;
    float cooldown_time;
    public float click_cooldown_time = 1f;
    private void Awake()
    {
        Events.chestDamaged += Cooldown;
    }
    void FixedUpdate()
    {
        if (on_cooldown == true && cooldown_time != 0) { cooldown_time -= 0.1f; }
        if (cooldown_time <= 0) { cooldown_time = click_cooldown_time; on_cooldown = false; }
    }

    private void Cooldown() { on_cooldown = true; }
    private void OnDisable()
    {
        Events.chestDamaged -= Cooldown;
    }
}
