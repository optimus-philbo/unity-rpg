using System;

namespace Wot.Core.Graphics
{
    /// <summary>
    /// Interface for an object that can be drawn.
    /// </summary>
    public interface IGraphicsObject : IDisposable
    {
        /// <summary>
        /// Gets or sets the z order.
        /// </summary>
        /// <value>
        /// The z order.
        /// </value>
        int ZOrder { get; set; }

        /// <summary>
        /// Draws the object using specified graphics.
        /// </summary>
        /// <param name="g">The g.</param>
        void Draw(System.Drawing.Graphics g);
    }
}