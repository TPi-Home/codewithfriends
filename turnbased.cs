using Godot;
using System;

public class GameManager : Node {
    enum GameState {
        Exploration,
        Combat
    }

    GameState currentState;
    bool isEnemyTurn = false;

    public override void _Ready() {
        currentState = GameState.Exploration;
    }
    //This is your main gameplay loop. Every game has this. Delta is time since last frame.
    //This is not the the only way to do it, I will share a file showing where you could use a variable to pause it as I think it makes the logic clearer despite being potentially less efficient.
    public override void _Process(float delta) {
        switch (currentState) {
            case GameState.Exploration:
                UpdateExploration(delta);
                ProcessExplorationInputs();
                break;
            case GameState.Combat:
                UpdateCombat(delta);
                ProcessCombatInputs();
                break;
        }
        RenderGame();
    }

    void UpdateExploration(float delta) {
        // Update player position, handle NPC interactions, etc.
        // Example: player movement
        player.Translate(Vector3.Right * speed * delta);
    }

    void UpdateCombat(float delta) {
        // Update combat state, handle turn-based logic, etc.
        if (isEnemyTurn) {
            HandleEnemyTurn();
        }
    }

    void ProcessExplorationInputs() {
        // Handle player inputs for exploration (movement, interaction, etc.)
        if (Input.IsActionJustPressed("attack")) {
            OnPlayerEncounterEnemy();
        }
    }

    void ProcessCombatInputs() {
        // Handle player inputs for combat (selecting actions, targets, etc.)
        if (Input.IsActionJustPressed("confirm")) {
            ExecutePlayerAction();
        }
    }

    void RenderGame() {
        // This is typically handled by the engine, but you can include custom rendering logic here if needed
    }

    void OnPlayerEncounterEnemy() {
        EnterCombat();
        // Additional setup for combat, such as displaying combat UI, etc.
    }

    void OnCombatEnd() {
        ExitCombat();
        // Cleanup after combat
    }

    void EnterCombat() {
        currentState = GameState.Combat;
        // Additional setup for combat, like initializing combat UI, characters, etc.
    }

    void ExitCombat() {
        currentState = GameState.Exploration;
        // Clean up combat state, hide combat UI, etc.
    }

    void ExecutePlayerAction() {
        // Execute the player's chosen action
        // For example, attack, use item, etc.
        EndPlayerTurn();
    }

    void EndPlayerTurn() {
        // Logic to end the player's turn and transition to the enemy's turn
        isEnemyTurn = true;
        HandleEnemyTurn();
    }

    void HandleEnemyTurn() {
        // Example: enemy takes action
        PerformEnemyAttack();
        isEnemyTurn = false;
    }

    void PerformEnemyAttack() {
        // Example enemy attack logic
    }
}
