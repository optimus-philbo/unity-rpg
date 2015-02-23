using System.Windows.Forms;

namespace Wot.Core.Test
{
    public class TestControl : IControl
    {
        public void Initialise(GameEngine engine)
        {
            engine.InputEngine.KeyboardInput.OnKeyDown += (sender, args) =>
                                                          {
                                                              if (args.KeyCode == Keys.Escape)
                                                              {
                                                                  engine.CurrentState = EngineState.Quit;
                                                              }
                                                          };
        }

        public void Update(GameEngine engine)
        {
        }

        public void Shutdown(GameEngine engine)
        {
            engine.InputEngine.KeyboardInput = null;
        }
    }

    public class MainWindow : Form
    {
        private static GameEngine engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // The OptimizedDoubleBuffer style has no effect due to the way we control this game (drawing would have to be in OnPaint for it to benefit us at all.)
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Opaque, true);

            engine = new GameEngine(this, new TestControl());
        }

        static void Main()
        {
            var mw = new MainWindow();
            mw.Show();

            engine.Start();

            Application.Exit();
        }
    }
}
