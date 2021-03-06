using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaywrightSharp
{
    /// <summary>
    /// Options for <see cref="IBrowserType.LaunchAsync(LaunchOptions)"/>.
    /// </summary>
    public class LaunchOptions
    {
        /// <summary>
        /// Whether to run browser in headless mode. Defaults to true unless the devtools option is true.
        /// </summary>
        public bool? Headless { get; set; }

        /// <summary>
        /// Additional arguments to pass to the browser instance.
        /// </summary>
        public string[] Args { get; set; }

        /// <summary>
        /// Path to a User Data Directory.
        /// </summary>
        public string UserDataDir { get; set; }

        /// <summary>
        /// Whether to auto-open DevTools panel for each tab. If this option is true, the headless option will be set false.
        /// </summary>
        public bool? Devtools { get; set; }

        /// <summary>
        /// Path to a browser executable to run instead of the bundled one.
        /// </summary>
        public string ExecutablePath { get; set; }

        /// <summary>
        /// If specified, accepted downloads are downloaded into this folder. Otherwise, temporary folder is created and is deleted when browser is closed.
        /// </summary>
        public string DownloadsPath { get; set; }

        /// <summary>
        /// Whether to ignore HTTPS errors during navigation. Defaults to false.
        /// </summary>
        public bool? IgnoreHTTPSErrors { get; set; }

        /// <summary>
        /// Maximum time in milliseconds to wait for the browser instance to start.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        ///  Whether to pipe browser process stdout and stderr into process.stdout and process.stderr. Defaults to false.
        /// </summary>
        public bool? DumpIO { get; set; }

        /// <summary>
        /// Slows down PlaywrightSharp operations by the specified amount of milliseconds. Useful so that you can see what is going on.
        /// </summary>
        public int? SlowMo { get; set; }

        /// <summary>
        /// If true, Playwright does not pass its own configurations args and only uses the ones from args.
        /// Dangerous option; use with care. Defaults to false.
        /// </summary>
        public bool? IgnoreDefaultArgs { get; set; }

        /// <summary>
        /// Close the browser process on Ctrl-C. Defaults to true.
        /// </summary>
        public bool? HandleSIGINT { get; set; }

        /// <summary>
        /// Close the browser process on SIGTERM. Defaults to true.
        /// </summary>
        public bool? HandleSIGTERM { get; set; }

        /// <summary>
        /// Close the browser process on SIGHUP. Defaults to true.
        /// </summary>
        public bool? HandleSIGHUP { get; set; }

        /// <summary>
        /// Enable Chromium sandboxing. Defaults to true.
        /// </summary>
        public bool? ChromiumSandbox { get; set; }

        /// <summary>
        /// if <see cref="IgnoreDefaultArgs"/> is set to <c>false</c> this list will be used to filter default arguments.
        /// </summary>
        public string[] IgnoredDefaultArgs { get; set; }

        /// <summary>
        /// Specify environment variables that will be visible to browser. Defaults to Environment variables.
        /// </summary>
        public Dictionary<string, string> Env { get; set; }

        /// <summary>
        /// Firefox user preferences. Learn more about the Firefox user preferences at about:config.
        /// </summary>
        public Dictionary<string, object> FirefoxUserPrefs { get; set; }

        /// <summary>
        /// Network proxy settings.
        /// </summary>
        public ProxySettings Proxy { get; set; }

        /// <summary>
        /// Converts the <see cref="LaunchOptions"/> to <see cref="LaunchPersistentOptions"/>.
        /// </summary>
        /// <returns>The object converted to <see cref="LaunchPersistentOptions"/>.</returns>
        public LaunchPersistentOptions ToPersistentOptions()
            => new LaunchPersistentOptions
            {
                Headless = Headless,
                Args = Args,
                UserDataDir = UserDataDir,
                Devtools = Devtools,
                ExecutablePath = ExecutablePath,
                DownloadsPath = DownloadsPath,
                IgnoreHTTPSErrors = IgnoreHTTPSErrors,
                Timeout = Timeout,
                DumpIO = DumpIO,
                SlowMo = SlowMo,
                IgnoreDefaultArgs = IgnoreDefaultArgs,
                IgnoredDefaultArgs = IgnoredDefaultArgs,
                Env = Env,
                FirefoxUserPrefs = FirefoxUserPrefs,
                Proxy = Proxy,
                ChromiumSandbox = ChromiumSandbox,
            };

        internal virtual Dictionary<string, object> ToChannelDictionary()
        {
            var args = new Dictionary<string, object>();

            if (Headless != null)
            {
                args["headless"] = Headless;
            }

            if (Args != null)
            {
                args["args"] = Args;
            }

            if (!string.IsNullOrEmpty(UserDataDir))
            {
                args["userDataDir"] = UserDataDir;
            }

            if (Devtools != null)
            {
                args["devTools"] = Devtools;
            }

            if (ExecutablePath != null)
            {
                args["executablePath"] = ExecutablePath;
            }

            if (DownloadsPath != null)
            {
                args["downloadsPath"] = DownloadsPath;
            }

            if (IgnoreHTTPSErrors != null)
            {
                args["ignoreHTTPSErrors"] = IgnoreHTTPSErrors;
            }

            if (Timeout != null)
            {
                args["timeout"] = Timeout;
            }

            if (DumpIO != null)
            {
                args["dumpIO"] = DumpIO;
            }

            if (SlowMo != null)
            {
                args["slowMo"] = SlowMo;
            }

            if (IgnoreDefaultArgs != null)
            {
                args["ignoreDefaultArgs"] = IgnoreDefaultArgs;
            }

            if (IgnoredDefaultArgs != null)
            {
                args["ignoredDefaultArgs"] = IgnoredDefaultArgs;
            }

            if (Env != null)
            {
                args["env"] = Env.Select(kv => new NameValueEntry(kv.Key, kv.Value));
            }

            if (FirefoxUserPrefs != null)
            {
                args["firefoxUserPrefs"] = FirefoxUserPrefs;
            }

            if (Proxy != null)
            {
                args["proxy"] = Proxy;
            }

            if (ChromiumSandbox != null)
            {
                args["chromiumSandbox"] = ChromiumSandbox;
            }

            return args;
        }
    }
}
