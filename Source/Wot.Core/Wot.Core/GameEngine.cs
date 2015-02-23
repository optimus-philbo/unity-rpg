using System.Threading;
using System.Windows.Forms;
using Wot.Core.Graphics;
using Wot.Core.Input;

namespace Wot.Core
{
    /// <summary>
    /// Engine used to control the game.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// Win32 message
        /// </summary>
        private Win32.NativeMessage msg;

        /// <summary>
        /// Gets or sets the window.
        /// </summary>
        /// <value>
        /// The window.
        /// </value>
        private readonly Form window;

        /// <summary>
        /// The logic thread
        /// </summary>
        private Thread logic;

        /// <summary>
        /// Gets or sets the input engine.
        /// </summary>
        /// <value>
        /// The input engine.
        /// </value>
        public InputEngine InputEngine { get; set; }

        /// <summary>
        /// Gets or sets the graphics engine.
        /// </summary>
        /// <value>
        /// The graphics engine.
        /// </value>
        public GraphicsEngine GraphicsEngine { get; set; }

        /// <summary>
        /// Gets or sets the current control.
        /// </summary>
        /// <value>
        /// The current control.
        /// </value>
        public IControl CurrentControl { get; set; }

        /// <summary>
        /// Gets or sets the state of the current.
        /// </summary>
        /// <value>
        /// The state of the current.
        /// </value>
        public EngineState CurrentState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine" /> class.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="control">The control.</param>
        public GameEngine(Form window, IControl control)
        {
            this.window = window;
            msg = new Win32.NativeMessage();

            InputEngine = new InputEngine(window);
            GraphicsEngine = new GraphicsEngine(window, 640, 480);

            CurrentControl = control;
        }

        /// <summary>
        /// Starts the engine.
        /// </summary>
        public void Start()
        {
            CurrentState = EngineState.Running;

            logic = new Thread(StartLogic) {IsBackground = true};
            logic.Start();

            while (true)
            {
                Update();

                if (CurrentState != EngineState.Running) break;
            }

            GraphicsEngine.Shutdown();
        }

        /// <summary>
        /// Starts the logic.
        /// </summary>
        public void StartLogic()
        {
            CurrentControl.Initialise(this);

            while (true)
            {
                CurrentControl.Update(this);

                if (CurrentState != EngineState.Running) break;
            }

            CurrentControl.Shutdown(this);
        }

        /// <summary>
        /// Sets a new control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void SetControl(IControl control)
        {
            CurrentControl.Shutdown(this);
            CurrentControl = control;
            CurrentControl.Initialise(this);
        }

        /// <summary>
        /// Updates the game engine
        /// </summary>
        public void Update()
        {
            if (window.Created)
            {
                if (Win32.PeekMessage(out msg, window.Handle, 0, 0, (uint)Win32.PM.REMOVE))
                {
                    if (msg.message == (uint)Win32.WindowsMessage.WM_QUIT)
                    {
                        CurrentState = EngineState.Quit;
                    }
                    else
                    {
                        Win32.TranslateMessage(ref msg);
                        Win32.DispatchMessage(ref msg);
                    }
                }
                else
                {
                    GraphicsEngine.Update();
                    Thread.Sleep(2);
                }
            }
            else
            {
                CurrentState = EngineState.Error;
            }
        }
    }
}
