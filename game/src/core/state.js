// Single source of truth for one playthrough.
export const TOTAL_NIGHTS = 7;
export const STARTING_BUDGET = 10; // euros for replacements, whole week

export function createGameState() {
  return {
    night: 1,
    budget: STARTING_BUDGET,
    score: 0,
    suspicion: {}, // housemate id -> strikes (3 = confrontation)
  };
}
