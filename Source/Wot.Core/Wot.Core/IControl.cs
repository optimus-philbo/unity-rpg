namespace Wot.Core
{
    public interface IControl
    {
        /// <summary>
        /// Initialises the specified engine.
        /// </summary>
        /// <param name="engine">The engine.</param>
        void Initialise(GameEngine engine);

        /// <summary>
        /// Updates the specified engine.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <returns></returns>
        void Update(GameEngine engine);

        /// <summary>
        /// Shutdowns the specified engine.
        /// </summary>
        /// <param name="engine">The engine.</param>
        void Shutdown(GameEngine engine);
    }
}