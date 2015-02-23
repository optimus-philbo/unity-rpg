using System.Windows.Forms;
namespace Wot.Core.Input
{
    /// <summary>
    /// Keyboard input
    /// </summary>
    public class KeyboardInput
    {
        /// <summary>
        /// Occurs when [on key down].
        /// </summary>
        public event KeyEventHandler OnKeyDown;

        /// <summary>
        /// Occurs when [on key up].
        /// </summary>
        public event KeyEventHandler OnKeyUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInput" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public KeyboardInput(Control control)
        {
            control.KeyDown += ControlOnKeyDown;
            control.KeyUp += ControlOnKeyUp;
        }

        /// <summary>
        /// Called when [key down].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyEventArgs">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        public void ControlOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if(OnKeyDown != null)
            {
                OnKeyDown(sender, keyEventArgs);
            }
        }

        /// <summary>
        /// Called when [key up].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyEventArgs">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        public void ControlOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (OnKeyUp != null)
            {
                OnKeyUp(sender, keyEventArgs);
            }
        }
    }
}