using System.Windows.Forms;

namespace Wot.Core.Input
{
    /// <summary>
    /// Mouse input
    /// </summary>
    public class MouseInput
    {
        /// <summary>
        /// Occurs when [on left button clicked].
        /// </summary>
        public event MouseEventHandler OnLeftButtonClicked;

        /// <summary>
        /// Occurs when [on right button clicked].
        /// </summary>
        public event MouseEventHandler OnRightButtonClicked;

        /// <summary>
        /// Occurs when [on middle button clicked].
        /// </summary>
        public event MouseEventHandler OnMiddleButtonClicked;

        /// <summary>
        /// Occurs when [on left button double clicked].
        /// </summary>
        public event MouseEventHandler OnLeftButtonDoubleClicked;

        /// <summary>
        /// Occurs when [on right button double clicked].
        /// </summary>
        public event MouseEventHandler OnRightButtonDoubleClicked;

        /// <summary>
        /// Occurs when [on wheel up].
        /// </summary>
        public event MouseEventHandler OnWheelUp;

        /// <summary>
        /// Occurs when [on wheel down].
        /// </summary>
        public event MouseEventHandler OnWheelDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseInput" /> class.
        /// </summary>
        /// <param name="control">The control.</param>
        public MouseInput(Control control)
        {
            control.MouseMove += OnMouseMove;
            control.MouseClick += OnMouseClick;
            control.MouseWheel += OnMouseWheel;
        }

        /// <summary>
        /// Gets or sets the mouse position x coordinate.
        /// </summary>
        /// <value>
        /// The mouse position x coordinate.
        /// </value>
        public double PositionX { get; set; }

        /// <summary>
        /// Gets or sets the mouse position y coordinate.
        /// </summary>
        /// <value>
        /// The mouse position y coordinate.
        /// </value>
        public double PositionY { get; set; }

        /// <summary>
        /// Called when [mouse move].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseEventArgs">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            PositionX = mouseEventArgs.X;
            PositionY = mouseEventArgs.Y;
        }

        /// <summary>
        /// Called when [mouse click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseEventArgs">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void OnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Clicks == 1)
            {
                if (mouseEventArgs.Button == MouseButtons.Left)
                {
                    if (OnLeftButtonClicked != null)
                    {
                        OnLeftButtonClicked(sender, mouseEventArgs);
                    }
                }
                else if (mouseEventArgs.Button == MouseButtons.Right)
                {
                    if (OnRightButtonClicked != null)
                    {
                        OnRightButtonClicked(sender, mouseEventArgs);
                    }
                }
                else if (mouseEventArgs.Button == MouseButtons.Middle)
                {
                    if (OnMiddleButtonClicked != null)
                    {
                        OnMiddleButtonClicked(sender, mouseEventArgs);
                    }
                }
            }
            else
            {
                if (mouseEventArgs.Button == MouseButtons.Left)
                {
                    if (OnLeftButtonDoubleClicked != null)
                    {
                        OnLeftButtonDoubleClicked(sender, mouseEventArgs);
                    }
                }
                else if (mouseEventArgs.Button == MouseButtons.Right)
                {
                    if (OnRightButtonDoubleClicked != null)
                    {
                        OnRightButtonDoubleClicked(sender, mouseEventArgs);
                    }
                }
            }
        }

        /// <summary>
        /// Called when [mouse wheel].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="mouseEventArgs">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        public void OnMouseWheel(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Delta > 0)
            {
                if (OnWheelUp != null)
                {
                    OnWheelUp(sender, mouseEventArgs);
                }
            }
            else if (mouseEventArgs.Delta < 0)
            {
                if (OnWheelDown != null)
                {
                    OnWheelDown(sender, mouseEventArgs);
                }
            }
        }
    }
}