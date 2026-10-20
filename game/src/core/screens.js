// Shows one <section data-screen="..."> at a time.
export function showScreen(name) {
  for (const screen of document.querySelectorAll("[data-screen]")) {
    screen.hidden = screen.dataset.screen !== name;
  }
}
