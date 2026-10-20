import { showScreen } from "./core/screens.js";
import { createGameState, TOTAL_NIGHTS } from "./core/state.js";

let state = null;

const status = document.querySelector(".navbar__status");

function startGame() {
  state = createGameState();
  status.textContent = `Night ${state.night} / ${TOTAL_NIGHTS}`;
  showScreen("night");
}

function backToStart() {
  state = null;
  status.textContent = `Night 0 / ${TOTAL_NIGHTS}`;
  showScreen("start");
}

document.querySelector('[data-action="play"]').addEventListener("click", startGame);
document.querySelector('[data-action="back"]').addEventListener("click", backToStart);
