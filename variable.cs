    enum GameState {
        Exploration,
        Combat
    }

    GameState currentState;
    bool isPaused = false;
    bool isEnemyTurn = false;

    public override void _Ready() {
        currentState = GameState.Exploration;
    }

    public override void _Process(float delta) {
        if (isPaused) {
            // If the game is paused, only update the combat-related logic
            if (currentState == GameState.Combat) {
                UpdateCombat(delta);
                ProcessCombatInputs();
            }
        } else {
            // If the game is not paused, update the exploration-related logic
            if (currentState == GameState.Exploration) {
                UpdateExploration(delta);
                ProcessExplorationInputs();
            }
        }
        RenderGame();
    }