using Assets.Scripts.Character.Attack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#if DEBUG
using UnityEditor;
#endif
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Character.Health
{
    [Serializable]
    public class InnerHealth
    {
        public int OverHealth;
        public int MinHealth;
    }

    //[ExecuteAlways]
    [RequireComponent(typeof(DamageEffect))]
    public class HealthComponent : MonoBehaviour
    {
        public PersonType Type;

        [ContextMenuItem("Проверить состояние инициализации", "ShowInitState")]
        [Range(0, 300)]
        [SerializeField] private int health;
        public int Health { get => health; }

        [SerializeField] private bool isDead;
        public bool IsDead { get => isDead; }

        public Action<int> OnHealthChanged;
        public Action OnDead;
        public string soundName;

        private DamageEffect damageEffect;
        private PlaySound playSound;

        [Header("Test")]
        public InnerHealth Inner;
        [Space]
        [TextArea]
        [Tooltip("Тестовое поле")]
        public string Txt;
        public Transform Target;

#if DEBUG
        [MenuItem("Tools/Menu")]
        public static void Menu()
        {
            Debug.Log("Menu: ok");
        }
#endif

        [ContextMenu("Проверить состояние инициализации")]
        public void ShowInitState()
        {
            if (!damageEffect) Debug.LogError("damageEffect == null");
            if (!playSound) Debug.LogError("playSound == null");
            if (damageEffect && playSound) Debug.Log("ShowInitState: ok");
        }

        void Start()
        {
            damageEffect = GetComponent<DamageEffect>();
            playSound = GetComponentInChildren<PlaySound>();
#if DEBUG
            Debug.Log("Start");
#endif
            Log.Info("Start2");
            Log.Info2("Start2");
        }

        //private void Update()
        //{
        //    Debug.Log("Update");
        //}

        //private void Update()
        //{
        //    Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10, Color.red, 10);
        //}

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 1);
        }

        private void OnDrawGizmosSelected()
        {
            //Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 2);
        }

        public void ApplyDamage(AttackComponent attackComponent)
        {
            health -= attackComponent.Damage;
            if (damageEffect) damageEffect.ShowDamageEffect();
            if (playSound) playSound.Play(soundName);

            if (health <= 0)
            {
                isDead = true;
                health = 0;
                OnDead?.Invoke();
            }

            OnHealthChanged?.Invoke(health);
        }
    }
}

public class PersHp
{
    static List<PersHp> Types = new List<PersHp>()
    {
        new PersHp() { Name="Bandit", HP=200},
        new PersHp() { Name = "Police", HP = 250},
    };

    private int HP;
    public object Name { get; private set; }
}

public static class Log
{
    public static void Info(string s)
    {
#if DEBUG
        Debug.Log(s);
#endif
    }

    [Conditional("DEBUG")]
    public static void Info2(string s) => Debug.Log(s);
}