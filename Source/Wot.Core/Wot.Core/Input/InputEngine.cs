using System.Windows.Forms;

namespace Wot.Core.Input
{
    /// <summary>
    /// Engine used to control inputs.
    /// </summary>
    public class InputEngine
    {
        /// <summary>
        /// Gets or sets the mouse input.
        /// </summary>
        /// <value>
        /// The mouse input.
        /// </value>
        public MouseInput MouseInput { get; set; }

        /// <summary>
        /// Gets or sets the keyboard input.
        /// </summary>
        /// <value>
        /// The keyboard input.
        /// </value>
        public KeyboardInput KeyboardInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputEngine" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public InputEngine(Control control)
        {
            MouseInput = new MouseInput(control);
            KeyboardInput = new KeyboardInput(control);
        }
    }
}
