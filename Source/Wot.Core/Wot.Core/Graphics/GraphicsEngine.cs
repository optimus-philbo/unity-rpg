using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Wot.Core.Graphics
{
    /// <summary>
    /// Engine used to render graphics
    /// </summary>
    public class GraphicsEngine
    {
        /// <summary>
        /// The backbuffer
        /// </summary>
        private static Bitmap backbuffer;

        /// <summary>
        /// The window to render to
        /// </summary>
        private readonly Form window;

        /// <summary>
        /// Gets or sets the width of the window.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the window.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the list of objects to draw.
        /// </summary>
        /// <value>
        /// To draw.
        /// </value>
        public IList<IGraphicsObject> ToDraw { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicsEngine"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public GraphicsEngine(Form window, int width, int height)
        {
            ToDraw = new List<IGraphicsObject>();

            this.window = window;

            SetSize(width, height);

            backbuffer = new Bitmap(width, height);
        }

        /// <summary>
        /// Sets the size of the window.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;

            window.ClientSize = new Size(Width, Height);
        }

        /// <summary>
        /// Updates the rendered objects
        /// </summary>
        public void Update()
        {
            var g = System.Drawing.Graphics.FromImage(backbuffer);

            // Clear the background.  normally if you weren't using a backbuffer, this would cause severe flicker.
            g.Clear(Color.White);

            foreach (var o in ToDraw)
            {
                o.Draw(g);
            }

            // Flip the backbuffer
            var frontbuffer = System.Drawing.Graphics.FromHwnd(window.Handle);
            frontbuffer.DrawImage(backbuffer, new Point(0, 0));
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public void Shutdown()
        {
            foreach (var o in ToDraw)
            {
                o.Dispose();
            }

            backbuffer.Dispose();
        }
    }
}