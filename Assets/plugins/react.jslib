mergeInto(LibraryManager.library, {
  GameOver: function (userName, score) {
    window.dispatchReactUnityEvent("GameOver", UTF8ToString(userName), score);
  },
});

mergeInto(LibraryManager.library, {
  SetScore: function (userName, score) {
    window.dispatchReactUnityEvent("SetScore", UTF8ToString(userName), score);
  },
});

mergeInto(LibraryManager.library, {
  Quit: function (userName, score) {
    window.dispatchReactUnityEvent("Quit", UTF8ToString(userName), score);
  },
});