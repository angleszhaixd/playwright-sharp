namespace PlaywrightSharp
{
    /// <summary>
    /// <see cref="IBrowserContext.ExposeBindingAsync(string, System.Action{BindingSource})"/> caller information.
    /// </summary>
    public class BindingSource
    {
        /// <summary>
        /// Browser Context.
        /// </summary>
        public IBrowserContext Context { get; set; }

        /// <summary>
        /// Page.
        /// </summary>
        public IPage Page { get; set; }

        /// <summary>
        /// Frame.
        /// </summary>
        public IFrame Frame { get; set; }
    }
}
