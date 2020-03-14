using UnityEngine;

public abstract class Character : MonoBehaviour {
    private State currentState;
    public State State {
        get { return currentState; }
    }
    public abstract State ReturnHomeState();
    public abstract void InitCharacter();
    [SerializeField] public int maxHealth;
    [SerializeField] public int health;
    public int Health {
        get { return health; }
    }
    public virtual void ChangeHealth(int amount) {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }
    private void Start() {
        InitCharacter();
        SetState(ReturnHomeState());
        health = maxHealth;
    }

    private void FixedUpdate() {
        currentState.Tick();
    }

    public void SetState(State state) {
        if (currentState != null) {
            currentState.OnStateExit();
        }

        currentState = state;

        if (currentState != null) {
            currentState.OnStateEnter();
        }
    }
}